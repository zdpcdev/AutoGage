using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoGageConverter
{
    public partial class Settingsmenu : Form
    {

        public DataTable dt;
        public bool newchanges = false;
        public string reasonforchanges = "USR-";
        private readonly string userappdatapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public Settingsmenu()
        {
            InitializeComponent();

            Fillthesettingseditor(Path.Combine(userappdatapath, Properties.Settings.Default.activesettingsfile));
            Filltherestorepointselector();

            Properties.Settings.Default.Reload();
        }

        // Creates a DataTable and connect it to the DataGridView
        private void Fillthesettingseditor(string filepath)
        {
            changepreview.ReadOnly = true;
            
            string[] settingscontents = File.ReadAllLines(filepath);
            string[] datatypesthatareboxes = { "VALID_PART", "POCKET_HOLES", "SWITCH_DIMS", "REVERSE_SCRIBES" };

            dt = new DataTable();

            if (settingscontents.Length > 0)
            {
                //Create Header For DataGridView
                string firstLine = settingscontents[0];
                string[] headerLabels = firstLine.Split(',');
                foreach (string headerWord in headerLabels)
                {
                    if (datatypesthatareboxes.Contains(headerWord))
                    {
                        dt.Columns.Add(new DataColumn(headerWord, typeof(bool)));
                    }
                    else
                    {
                        dt.Columns.Add(new DataColumn(headerWord, typeof(string)));
                    }

                }
                //Fill The DataTable
                for (int i = 1; i < settingscontents.Length; i++)
                {
                    string[] dataWords = settingscontents[i].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in headerLabels)
                    {
                        dr[headerWord] = dataWords[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }
            }

            // Auto sort the table in alphabetical order by part name
            dt.DefaultView.Sort = "PART ASC";

            if (dt.Rows.Count > 0)
            {
                BindingSource bindingSource = new BindingSource { DataSource = dt };
                changepreview.DataSource = bindingSource;
            }

            changepreview.ReadOnly = false;
        }

        // Defines default values when a user creates a new part
        private void Changespreview_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["PART"].Value = "Enter Part Name";
            e.Row.Cells["VALID_PART"].Value = true;
            e.Row.Cells["Process"].Value = "Default";
            e.Row.Cells["POCKET_HOLES"].Value = false;
            e.Row.Cells["SWITCH_DIMS"].Value = false;
            e.Row.Cells["REVERSE_SCRIBES"].Value = false;
            // Add more columns as needed...
        }

        // Ensure the part name is unique and not empty.
        private void Changespreview_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string newCellValue = e.FormattedValue.ToString();

                if (string.IsNullOrWhiteSpace(newCellValue))
                {
                    changepreview.Rows[e.RowIndex].ErrorText = "The column cannot be empty or whitespace";
                    e.Cancel = true;
                }
                else
                {
                    foreach (DataGridViewRow row in changepreview.Rows)
                    {
                        if (row.Index != e.RowIndex) // Exclude the current row
                        {
                            if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == newCellValue)
                            {
                                changepreview.Rows[e.RowIndex].ErrorText = "The part name must be unique";
                                e.Cancel = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        // Clear the error message when the user is done editing.
        private void Changespreview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            changepreview.Rows[e.RowIndex].ErrorText = string.Empty;
            newchanges = true;
            reasonforchanges = "USR-";
        }

        // Flag that the user made changes
        private void Changepreview_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            newchanges = true;
            reasonforchanges = "USR-";
        }


        private void Filltherestorepointselector()
        {
            // Fill The ComboBox With The List Of Backups
            List<String> Configurations = Directory.EnumerateFiles(Path.Combine(userappdatapath, "RestorePoints"))
                                      .OrderByDescending(f => File.GetLastWriteTime(f))
                                      .Select(p => Path.GetFileName(p))
                                      .ToList();
            restorepointselector.DataSource = Configurations;
        }

        // Write any data from the gridview into the ActiveSettings.txt file
        private void Startthesaveprocess()
        {
            if(newchanges == true)
            {
                var window = MessageBox.Show(
                "Do you want to save the changes?",
                "Save and Apply Criteria",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (window == DialogResult.Yes)
                {
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                    sb.AppendLine(string.Join(",", columnNames));
                    foreach (DataRow row in dt.Rows)
                    {
                        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                        sb.AppendLine(string.Join(",", fields));
                    }
                    string filenametimestamp = DateTime.Now.ToString("MMMM-dd-yyyy-hh-mm-ss");
                    File.WriteAllText(Path.Combine(userappdatapath, @"RestorePoints\" + reasonforchanges + filenametimestamp + ".txt"), sb.ToString());
                    File.Delete(Path.Combine(userappdatapath, Properties.Settings.Default.activesettingsfile));
                    File.Copy(Path.Combine(userappdatapath, @"RestorePoints\"+ reasonforchanges + filenametimestamp + ".txt"), Path.Combine(userappdatapath, Properties.Settings.Default.activesettingsfile));

                    Properties.Settings.Default.profile = reasonforchanges + filenametimestamp;
                    Properties.Settings.Default.Save();

                    Filltherestorepointselector();
                }
                // Reset the flag so the user is not prompted to save
                newchanges = false;
                reasonforchanges = "USR-";
            }
        }

        // Prompt the user to save their changes when closing the form
        private void Settingsmenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Startthesaveprocess();
        }

        // Click handler for the Restore Previous Settings button
        private void Restorebtn_Click(object sender, EventArgs e)
        {
            string restoredSettingsPath = @"RestorePoints\" + restorepointselector.SelectedItem.ToString();
            Fillthesettingseditor(Path.Combine(userappdatapath, restoredSettingsPath));

            MessageBox.Show(
                "Restored Parts from " + restorepointselector.SelectedItem,
                "Settings Restored",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            newchanges = true;
            reasonforchanges = "RST-";
        }

        // Click handler for the Reset Settings to Default button
        private void Resetbtn_Click(object sender, EventArgs e)
        {
            Fillthesettingseditor(Path.Combine(userappdatapath, "DefaultSettings.txt"));
            MessageBox.Show(
                "All Parts Will Be RESET to Default!",
                "Settings Reset",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            newchanges = true;
            reasonforchanges = "DFT-";
        }

        // Click handler for the Save and Apply Changes button
        private void Saveandapplybtn_Click(object sender, EventArgs e)
        {
            Startthesaveprocess();
        }

        // Backup deletion process
        private void Deletebkupsbtn_Click(object sender, EventArgs e)
        {
            var window = MessageBox.Show(
                "This action cannot be undone, do you wish to continue?",
                "Confirm Backup Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (window == DialogResult.Yes)
            {
                string folderPath = Path.Combine(userappdatapath, "RestorePoints");

                try
                {
                    // Check if directory exists
                    if (Directory.Exists(folderPath))
                    {
                        // Get all files in the directory
                        string[] files = Directory.GetFiles(folderPath);
                        // Loop through each file and delete it
                        foreach (string file in files)
                        {
                            File.Delete(file);
                        }
                        //Console.WriteLine("All files in the directory have been deleted.");
                        Filltherestorepointselector();
                    }
                    
                }
                catch (Exception ex)
                {
                    // Handle any errors that occurred.
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

        }

        private void Adjustautoidbtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userautoid = 1;
            Properties.Settings.Default.defaultautoid = int.Parse(configinfobox.Text) - 1;
            Properties.Settings.Default.Save();

            configinfobox.Text = string.Empty;

            MessageBox.Show(
                "The AutoID # has been reset to " + (Properties.Settings.Default.defaultautoid + 1).ToString(),
                "AutoID Reset",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Configinfobox_TextChanged(object sender, EventArgs e)
        {
            bool successfullyParsed = int.TryParse(configinfobox.Text, out _);
            if (successfullyParsed && int.Parse(configinfobox.Text) > 419999)
            {
                adjustautoidbtn.Enabled = true;
            }
            else
            {
                adjustautoidbtn.Enabled = false;
            }
        }

        private void Exportbtn_Click(object sender, EventArgs e)
        {
            Startthesaveprocess();
            exportSettingsDialog.FileName = "AutoGage740Export-" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss") + ".txt";
            if (exportSettingsDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Path.Combine(userappdatapath, Properties.Settings.Default.activesettingsfile), Path.Combine(userappdatapath, exportSettingsDialog.FileName));
                MessageBox.Show("An export file has been saved to \n" + exportSettingsDialog.FileName);
            }
            
        }

    }
}
