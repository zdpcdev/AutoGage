using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoGageConverter
{
    // AutoGage
    // Last updated on 01/08/2024
    // Using RazorGage PLP V7.4.0 as a reference
    // With pocketholes and scribes, but no spaceballs

    // AutoGage replaces the process of pressing "Convert a Comma Delimited Parts File to a RazorGage Parts File"
    // It assumes you are using the default settings provided by the PLP
    // It can convert an entire folder or a single file
    // The names of converted files are printed to the audit log
    // Errors are also printed there
    // The converted files are placed in the same directory as the original RZG files
    // It may not account for any custom fields (user fields, uf_##), you will have to adjust it accordingly
    // There is a built-in diff-checking utility to compare AutoGage output with RazorGage

    // When modifiying this program, take a look at your existing RazorGage settings and output.
    // An RZG file is simply a CSV file with a different extension
    // An rdb file is a mdb file with a different extension
    // The mdb file is an access database using JET 4.0

    // AutoGage has been migrated to 64-Bit.
    // To switch to 32-Bit, In AutoGage's Properties > Build > Platform Target "Prefer 32-bit" MUST be selected, otherwise the ADO connector will not be found.
    // Make sure the installer target is also switched over.
    // Then switch all instances of Properties.Settings.Default.cs64 to .cs32 in this project.

    // You CANNOT test this project directly in Visual Studio
    // Build the project first, then the installer, then install the app

    // The installer uses files from the AutoGageConverter project in its AppData folder, do not remove them


    // Official Documentation for RazorGage PLP
    // https://razorgage.com/downloads/
    // https://razorgage.com/wp-content/uploads/2015/11/PLP.pdf

    // About The Original PLP
    // RazorGage PLP is a Visual Basic 6 Application
    // It uses http://helpcentral.componentone.com/nethelp/vsflexgrid8/componentonevsflexgridpro8.html for tables displayed within the app
    // It is packaged with a few mdb files used for settings

    // PLPDefDefault.mdb
    // This file contains most of the application's default settings.
    // AutoGage's mapping file is based off of the "tblPartsFileMapping" table

    // ManualPartsTemplateDefault.mdb
    // The template used when the user manually creates a parts file

    // ROPartsFileDefaultTemplate.mdb
    // AutoGage calls it "NewTemplate.mdb"
    // This file is copied, then filled with data from the RZG file

    // The 32-Bit Access DB connection string is:
    // DataSource=.Microsoft.Jet.OLEDB.4.0

    // End of RazorGage PLP Documentation


    public partial class AutoGage : Form
    {

        // The active settings profile gets loaded to this DataTable on start
        public DataTable loadedpartstable = new DataTable();
        // This table is for editing any new parts that are found
        public DataTable newpartstable;

        public AutoGage()
        {
            InitializeComponent();
            Properties.Settings.Default.Reload();

            if (!Directory.Exists(AppDataHelper.AD("AutoGage")))
            {
                Directory.CreateDirectory(AppDataHelper.AD("AutoGage"));
            }

            // The file names of Default and Active Settings are stored in the app as properties
            // You can easily change them if needed
            if (!File.Exists(AppDataHelper.ADH(Properties.Settings.Default.activesettingsfile)))
            {
                File.Copy(Properties.Settings.Default.defaultsettingsfile, AppDataHelper.ADH(Properties.Settings.Default.activesettingsfile));
                Properties.Settings.Default.profile = "Default";
            }

            if (!File.Exists(AppDataHelper.ADH("NewTemplate.mdb")))
            {
                File.Copy("NewTemplate.mdb", AppDataHelper.ADH("NewTemplate.mdb"));
            }

            if (!Directory.Exists(AppDataHelper.ADH("RestorePoints")))
            {
                Directory.CreateDirectory(AppDataHelper.ADH("RestorePoints"));
            }

            ConfigurePartsTables();

            activeProfileLabel.Text = "Active Settings Profile: " + Properties.Settings.Default.profile;
        }

        public void ConfigurePartsTables()
        {
            // Create the DataGridView that allows the user to preview the currently active settings
            string[] settingscontents = File.ReadAllLines(AppDataHelper.ADH(Properties.Settings.Default.activesettingsfile));
            string[] datatypesthatareboxes = { "VALID_PART", "POCKET_HOLES", "SWITCH_DIMS", "REVERSE_SCRIBES" };

            loadedpartstable = new DataTable();

            if (settingscontents.Length > 0)
            {

                string[] headerLabels = settingscontents[0].Split(',');
                foreach (string headerWord in headerLabels)
                {
                    if (datatypesthatareboxes.Contains(headerWord))
                    {
                        loadedpartstable.Columns.Add(new DataColumn(headerWord, typeof(bool)));
                    }
                    else
                    {
                        loadedpartstable.Columns.Add(new DataColumn(headerWord, typeof(string)));
                    }

                }

                loadedpartstable.DefaultView.Sort = "PART ASC";

                // This is a mini DataTable used for handling new parts during processing before they are added
                newpartstable = loadedpartstable.Clone();

                // Fill The DataTable With Data
                for (int part = 1; part < settingscontents.Length; part++)
                {
                    string[] dataWords = settingscontents[part].Split(',');
                    DataRow dr = loadedpartstable.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in headerLabels)
                    {
                        dr[headerWord] = dataWords[columnIndex++];
                    }
                    loadedpartstable.Rows.Add(dr);
                }
            }

            if (loadedpartstable.Rows.Count > 0)
            {
                BindingSource bindingSource = new BindingSource { DataSource = loadedpartstable };
                activepreviewgrid.DataSource = bindingSource;
            }
        }

        // Click Handler for the file converter
        private void ConversionBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdSingleFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                StartConversionProcess(ofdSingleFile.FileNames);
            }
        }

        // Update the button text on drag and drop
        private void ConversionBtn_DragEnter(object sender, DragEventArgs e)
        {
            conversionbtn.Text = "Convert " + ((string[])e.Data.GetData(DataFormats.FileDrop)).Where(f => Path.GetExtension(f) == ".RZG").Count() + " file(s)";
            e.Effect = DragDropEffects.Copy;
        }

        private void ConversionBtn_DragLeave(object sender, EventArgs e)
        {
            conversionbtn.Text = "Convert File(s)";
        }

        // Perform conversion on successful drop
        private void ConversionBtn_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = ((string[])e.Data.GetData(DataFormats.FileDrop)).Where(f => Path.GetExtension(f) == ".RZG").ToArray();
            StartConversionProcess(files);
        }

        // Handle UI management not directly related to the conversion process
        private void StartConversionProcess(string[] listoffiles)
        {
            ToggleControls(false, Color.Coral);

            // Progress bar management
            double step = 1.0 / listoffiles.Count() * 100.0;
            conversionstatus.Value = 0;
            conversionstatus.Step = (int)Math.Ceiling(step);
            conversionstatus.Visible = true;

            // Conversion
            foreach (string currentfile in listoffiles)
            {
                ConvertRZGFile(currentfile);
                conversionstatus.PerformStep();
            }

            // UI management
            conversionbtn.Text = "Convert File(s)";
            conversionstatus.Visible = false;

            ToggleControls(true, Color.PaleGreen);
        }

        // Helper function for button appearance
        private void ToggleControls(bool status, Color col)
        {
            conversionbtn.BackColor = col;
            conversionbtn.Enabled = status;
            settingsbtn.Enabled = status;
        }


        // START OF CONVERSION PROCESS
        private void ConvertRZGFile(string passedfile)
        {

            // The sequence number always starts at 1.
            // It increases by 1 for each part in the file, including invalid ones
            int seq = 1;
            // This list will contain all the valid parts after they have been properly formatted.
            List<RzgConverter> listofvalidpartstoconvert = new List<RzgConverter>();


            // The path of the RZG (CSV) file
            string fullrzgpath = passedfile;
            // Just the name of the RZG file
            string rzgfilename = Path.GetFileName(fullrzgpath);
            // The path of the rdb (Access Database) file
            string fulldbpath = passedfile.Replace(Path.GetExtension(passedfile), ".rdb");

            // This flag gets set to true if new parts are added, that way the settings get updated
            bool newpartswereadded = false;


            // Avoid converting existing rdb files
            if (!File.Exists(fulldbpath))
            {
                auditlog.Text += "\r\n" + rzgfilename;
                try
                {
                    // New files are created based on a template provided by RazorGage PLP in its app data folder.
                    // By using the copy from RazorGage, we do not need to manually replicate the database format.
                    File.Copy(AppDataHelper.ADH(@"NewTemplate.mdb"), fulldbpath);

                    // The name of the table where parts will be inserted
                    string tableName = "tblParts";

                    // Create a connection string for the access database
                    // The RazorGage PLP uses the old Jet 4.0 format, this can be found by opening a .rdb file in a hex editor
                    // We are using a 64-Bit connection string, you can change this to .cs32 and then adjust the app and installer to target 32-bit if needed.
                    string connectionString = Properties.Settings.Default.cs64 + fulldbpath;
                    //Console.WriteLine(connectionString);

                    // Read the first line of the RZG file to get the column names
                    string[] columnNames = File.ReadLines(fullrzgpath).First().Replace("\"", String.Empty).Split(',');

                    // Read the RZG file line by line and execute the insert command for each row
                    using (StreamReader reader = new StreamReader(fullrzgpath))
                    {
                        // Skip the column names
                        reader.ReadLine();
                        // Store the list of parts in an array
                        string[] rzgfilecontent = File.ReadAllLines(fullrzgpath);
                        // Create variables needed to hold each part's properties.
                        string currentpartname = "AUTOGAGE";
                        bool cpisvalid = false;
                        bool cphaspocketholes = false;
                        bool cpdimentionsswitched = false;
                        bool cpscribesarereversed = false;

                        // For each part in the RZG file...
                        for (int individualpart = 1; individualpart < rzgfilecontent.Length; individualpart++)
                        {
                            // Invalid parts contain a PartName of "Invalid Part", but a valid RoomText description
                            // We must be careful to not process an Invalid Part
                            if (rzgfilecontent[individualpart].Replace("\"", String.Empty).Split(',')[Array.FindIndex(columnNames, x => x == "PartName")] != "Invalid Part")
                            {
                                // Lookup the part name
                                // RoomText contains the full partname and its properties, but PartName is the abbreviation that gets stored in the rdb.
                                currentpartname = rzgfilecontent[individualpart].Replace("\"", String.Empty).Split(',')[Array.FindIndex(columnNames, x => x == "RoomText")];

                                DataRow[] foundRows = loadedpartstable.Select($"PART = '{currentpartname}'");

                                // If it was found in the ActiveSettings.txt file..
                                if (foundRows.Length > 0)
                                {
                                    // Retrive all it's existing properties from settings
                                    DataRow currentpartdata = foundRows[0];

                                    cpisvalid = currentpartdata.Field<bool>("VALID_PART");
                                    cphaspocketholes = currentpartdata.Field<bool>("POCKET_HOLES");
                                    cpdimentionsswitched = currentpartdata.Field<bool>("SWITCH_DIMS");
                                    cpscribesarereversed = currentpartdata.Field<bool>("REVERSE_SCRIBES");

                                    // Console.WriteLine(currentpartname + " is valid?" + currentpartdata.Field<bool>("VALID_PART"));
                                }
                                else
                                {
                                    // Prepare a new row for the new part notification
                                    DataRow npr = newpartstable.NewRow();
                                    npr["PART"] = currentpartname;
                                    npr["VALID_PART"] = false;
                                    npr["POCKET_HOLES"] = false;
                                    npr["Process"] = "Default";
                                    npr["SWITCH_DIMS"] = false;
                                    npr["REVERSE_SCRIBES"] = false;
                                    newpartstable.Rows.Add(npr);

                                    // Create a new form, passing in an empty newpartstable DataTable
                                    NewPartScreening form = new NewPartScreening(newpartstable);
                                    form.ShowDialog();

                                    // After the notification is dismissed, import the part
                                    loadedpartstable.ImportRow(form.ImportedPart);
                                    loadedpartstable.AcceptChanges();

                                    // Set all the part properties so it can be processed correctly
                                    DataRow currentpartdata = form.ImportedPart;

                                    cpisvalid = currentpartdata.Field<bool>("VALID_PART");
                                    cphaspocketholes = currentpartdata.Field<bool>("POCKET_HOLES");
                                    cpdimentionsswitched = currentpartdata.Field<bool>("SWITCH_DIMS");
                                    cpscribesarereversed = currentpartdata.Field<bool>("REVERSE_SCRIBES");

                                    newpartstable.Rows.Clear();

                                    newpartswereadded = true;
                                }
                                // At this stage in the process, we know if a part is valid or not, regardless if it was old or new
                                // Now we start processing it accordingly
                                // If the current part is valid, it gets exported to the rdb file.
                                if (cpisvalid)
                                {
                                    // Remove the quotes from the data, and split the row into columns
                                    string[] tempvalues = rzgfilecontent[individualpart].Replace("\"", String.Empty).Split(',');

                                    // Configure switch dims, this must be done before the scribes because scribes are adjusted based on part length
                                    double adjustedwidth = double.Parse(tempvalues[Array.FindIndex(columnNames, x => x == "Width")]);
                                    double adjustedlength = double.Parse(tempvalues[Array.FindIndex(columnNames, x => x == "Length")]);
                                    if (cpdimentionsswitched)
                                    {
                                        adjustedwidth = double.Parse(tempvalues[Array.FindIndex(columnNames, x => x == "Length")]);
                                        adjustedlength = double.Parse(tempvalues[Array.FindIndex(columnNames, x => x == "Width")]);
                                    }


                                    // Prepare the scribes
                                    string[] substrings = tempvalues[Array.FindIndex(columnNames, x => x == "ScribeInfo")].Split('|');

                                    // All 0s must be removed beforehand
                                    if (substrings.Length > 1)
                                    {
                                        substrings = substrings.Where((x => x != "0")).ToArray();
                                    }
                                    else
                                    {
                                        substrings = substrings.ToArray();
                                    }

                                    string convertedscribes = String.Empty;

                                    // If the part has scribes
                                    if (substrings.Length > 0)
                                    {
                                        // Get the combined length of the scribe offsets
                                        double total = 0;
                                        foreach (string part in substrings)
                                        {
                                            if (double.TryParse(part, out double number))
                                            {
                                                total += number;
                                            }
                                        }

                                        // Reversed scribes require special handling.
                                        // This flag avoids messing that up.
                                        bool cpscribewasadded = false;

                                        // Reverse them if needed
                                        if (cpscribesarereversed)
                                        {
                                            if (substrings.Length == 1)
                                            {
                                                // If there's only 1 scribe, reversing involves using the part length to inverse the number
                                                if (double.TryParse(substrings[0], out double num))
                                                {
                                                    substrings[0] = (adjustedlength - double.Parse(substrings[0])).ToString();
                                                }
                                                // MessageBox.Show(adjustedlength.ToString(), substrings[0]);
                                            }
                                            else if (total < adjustedlength)
                                            {
                                                // Prefix the array with the remaining empty space on the board.
                                                // Ex: If a board is 30 ft long and I have scribes 2, 3, and 5, there are 20 feet remaining on the right side.
                                                // When swapping the scribes, that 20 feet should now be on the left side of the board.
                                                cpscribewasadded = true;
                                                string[] reversedarray = new string[substrings.Length];

                                                reversedarray[0] = Math.Round(adjustedlength - total, 3).ToString();
                                                int j = 1;
                                                for (int k = substrings.Length - 1; k >= 1; k--)
                                                {
                                                    reversedarray[j] = substrings[k];
                                                    j++;
                                                }
                                                substrings = reversedarray;

                                            }
                                            else
                                            {
                                                string[] reversedarray = new string[substrings.Length];
                                                int j = 0;
                                                for (int k = substrings.Length - 1; k >= 0; k--)
                                                {
                                                    reversedarray[j] = substrings[k];
                                                    j++;
                                                }
                                                substrings = reversedarray;

                                            }

                                        }



                                        // If the length is >= to the part length, remove the last scribe
                                        // string debug = "Regular";
                                        if (total >= adjustedlength && cpscribewasadded == false)
                                        {
                                            substrings = substrings.Where((source, index) => index != substrings.Length - 1).ToArray();
                                            // debug = "Chopped";
                                        }

                                        convertedscribes = string.Join("|", substrings);
                                        // MessageBox.Show("The length is " + adjustedlength.ToString() + "\nThe sum is: " + total.ToString() + "\n" + debug + " Scribes: \n" + convertedscribes);

                                    }


                                    // Every converted part gets added to this list
                                    // After all parts have been converted, they are added to the rdb file in a single loop
                                    listofvalidpartstoconvert.Add(
                                        new RzgConverter(
                                            /* int AutoNumber;    */    Properties.Settings.Default.defaultautoid + Properties.Settings.Default.userautoid,
                                            /* string FILENAME;   */    rzgfilename.Replace(".RZG", ""),
                                            /* int SEQ_NUMBER;    */    seq,
                                            /* int QUANTITY;      */    Int32.Parse(tempvalues[Array.FindIndex(columnNames, x => x == "PartQty")]),
                                            /* string PART;       */    tempvalues[Array.FindIndex(columnNames, x => x == "PartName")],
                                            /* string MATERIAL;   */    tempvalues[Array.FindIndex(columnNames, x => x == "Material")],
                                            /* double WIDTH;      */    adjustedwidth,
                                            /* double LENGTH;     */    adjustedlength,
                                            /* double THICKNESS;  */    double.Parse(tempvalues[Array.FindIndex(columnNames, x => x == "Thickness")]),
                                            /* string SCRIBES;    */    convertedscribes,
                                            /* bool SPACEBALLS;   */    "",
                                            /* bool POCKETHOLES;  */    cphaspocketholes,
                                            /* bool PANEL;        */    false,
                                            /* bool B_GRADE;      */    false,
                                            /* string UF_1;       */    tempvalues[Array.FindIndex(columnNames, x => x == "SHOPID")].Trim(),
                                            /* string UF_2;       */    tempvalues[Array.FindIndex(columnNames, x => x == "CabinetID")].Trim()
                                        ));

                                    // The autoIDnum only increases for valid parts.
                                    Properties.Settings.Default.userautoid += 1;
                                }


                            }

                            // The sequence # increases regardless, which seems like a mistake.
                            // This means RazorGage exports rdb files that may skip certain numbers.
                            seq += 1;
                        }
                    }


                    // Open up the access database
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();

                        using (OleDbCommand command = new OleDbCommand())
                        {
                            command.Connection = connection;

                            // For every part converted, insert it into the database
                            foreach (RzgConverter item in listofvalidpartstoconvert)
                            {
                                // Create a query
                                command.CommandText = $"INSERT INTO {tableName} (AutoIDNum, FILENAME, SEQ_NUM, QUANTITY, PART, MATERIAL, WIDTH, LENGTH, THICKNESS, SCRIBES, SPACEBALLS, POCKETHOLES, PANEL, B_GRADE, UF_1, UF_2) VALUES (@AutoIDNum, @FILENAME, @SEQ_NUM, @QUANTITY, @PART, @MATERIAL, @WIDTH, @LENGTH, @THICKNESS, @SCRIBES, @SPACEBALLS, @POCKETHOLES, @PANEL, @B_GRADE, @UF_1, @UF_2)";
                                // Add the values from the DataTable to the query
                                command.Parameters.AddWithValue("@AutoIDNum", item.AutoNumber);
                                command.Parameters.AddWithValue("@FILENAME", item.FILENAME);
                                command.Parameters.AddWithValue("@SEQ_NUM", item.SEQ_NUMBER);
                                command.Parameters.AddWithValue("@QUANTITY", item.QUANTITY);
                                command.Parameters.AddWithValue("@PART", item.PART);
                                command.Parameters.AddWithValue("@MATERIAL", item.MATERIAL);
                                command.Parameters.AddWithValue("@WIDTH", item.WIDTH);
                                command.Parameters.AddWithValue("@LENGTH", item.LENGTH);
                                command.Parameters.AddWithValue("@THICKNESS", item.THICKNESS);
                                command.Parameters.AddWithValue("@SCRIBES", item.SCRIBES);
                                command.Parameters.AddWithValue("@SPACEBALLS", item.SPACEBALLS);
                                command.Parameters.AddWithValue("@POCKETHOLES", item.POCKETHOLES);
                                command.Parameters.AddWithValue("@PANEL", item.PANEL);
                                command.Parameters.AddWithValue("@PANEL", item.B_GRADE);
                                command.Parameters.AddWithValue("@UF_1", item.UF_1);
                                command.Parameters.AddWithValue("@UF_2", item.UF_2);
                                // Unused user fields
                                //command.Parameters.AddWithValue("@UF_3", item.UF_3);
                                //command.Parameters.AddWithValue("@UF_4", item.UF_4);
                                //command.Parameters.AddWithValue("@UF_5", item.UF_5);
                                //command.Parameters.AddWithValue("@UF_6", item.UF_6);
                                //command.Parameters.AddWithValue("@UF_7", item.UF_7);
                                //command.Parameters.AddWithValue("@UF_8", item.UF_8);
                                //command.Parameters.AddWithValue("@UF_9", item.UF_9);
                                //command.Parameters.AddWithValue("@UF_10", item.UF_10);
                                //command.Parameters.AddWithValue("@UF_11", item.UF_11);
                                //command.Parameters.AddWithValue("@UF_12", item.UF_12);
                                //command.Parameters.AddWithValue("@UF_13", item.UF_13);
                                //command.Parameters.AddWithValue("@UF_14", item.UF_14);
                                //command.Parameters.AddWithValue("@UF_15", item.UF_15);
                                //command.Parameters.AddWithValue("@UF_16", item.UF_16);
                                //command.Parameters.AddWithValue("@UF_17", item.UF_17);
                                //command.Parameters.AddWithValue("@UF_18", item.UF_18);
                                //command.Parameters.AddWithValue("@UF_19", item.UF_19);
                                //command.Parameters.AddWithValue("@UF_20", item.UF_20);

                                // Execute the query
                                command.ExecuteNonQuery();

                                // Clear the parameters for the next iteration
                                command.Parameters.Clear();
                            }
                        }

                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    auditlog.Text += "\r\n" + ex.Message + " Line " + (new StackTrace(ex, true)).GetFrame(0).GetFileLineNumber();
                }
            }
            else
            {
                auditlog.Text += "\r\n" + rzgfilename + " was already converted.";
            }

            // After all parts have been converted, write any new parts to the settings file
            if (newpartswereadded)
            {
                StringBuilder sb = new StringBuilder();
                IEnumerable<string> cn = loadedpartstable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", cn));
                foreach (DataRow row in loadedpartstable.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }
                string filenametimestamp = DateTime.Now.ToString("MMMM-dd-yyyy-hh-mm-ss");
                string adjustedsettingsname = AppDataHelper.ADH(@"RestorePoints\CVT-" + filenametimestamp + ".txt");

                File.WriteAllText(adjustedsettingsname, sb.ToString());
                File.Delete(AppDataHelper.ADH(Properties.Settings.Default.activesettingsfile));
                File.Copy(adjustedsettingsname, AppDataHelper.ADH(Properties.Settings.Default.activesettingsfile));

                Properties.Settings.Default.profile = "CVT-" + filenametimestamp;
                Properties.Settings.Default.Save();
                activeProfileLabel.Text = "Active Settings Profile" + Properties.Settings.Default.profile;

                MessageBox.Show("Parts were added and your default profile has changed to \n" + Properties.Settings.Default.profile, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //foreach (DataRow dr in loadedpartstable.Rows)
            //{
            //    foreach (DataColumn col in loadedpartstable.Columns)
            //    {
            //        Console.WriteLine("Column: {0}, Value: {1}", col.ColumnName, dr[col]);
            //    }
            //}

        } // END OF CONVERSION PROCESS

        private void Settingsbtn_Click(object sender, EventArgs e)
        {
            Form sm = new Settingsmenu();
            sm.ShowDialog();
            ConfigurePartsTables();
            activeProfileLabel.Text = "Active Settings Profile: " + Properties.Settings.Default.profile;
        }

        private void Activepreviewgrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            activepreviewgrid.ClearSelection();
        }

        private void Openmappingbtn_Click(object sender, EventArgs e)
        {
            new MappingMenu().ShowDialog();
        }

        private void Comparebtn_Click(object sender, EventArgs e)
        {
            var conversiontype = MessageBox.Show("Do you want to compare an entire folder?", "Compare File(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (conversiontype == DialogResult.Yes)
            {
                new Verification().ShowDialog();
            }
            else
            {
                new ComparisionView().ShowDialog();
            }
        }
    }
}
