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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace AutoGageConverter
{
    public partial class MappingMenu : Form
    {
        public DataTable importeduserdata = new DataTable();
        public List<MappedField> listofmappings = new List<MappedField>();
     
        public MappingMenu()
        {
            InitializeComponent();

            importeduserdata.Columns.Add("IN", typeof(string));
            importeduserdata.Columns.Add("OUT", typeof(string));

            // The ActiveMappings file is simply a 3-Column CSV with a .txt extension.
            // It should only be modified by using the mapping menu
            if (!File.Exists(AppDataHelper.ADH("ActiveMappings.txt")))
            {
                File.Copy("ActiveMappings.txt", AppDataHelper.ADH("ActiveMappings.txt"));
            }
            string[] lines = File.ReadAllLines(AppDataHelper.ADH("ActiveMappings.txt"));

            // Load the list of current mappings to the DataGridView
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 3)
                {
                    MappedField mf = new MappedField
                    {
                        ImportThis = parts[0],
                        IntoThis = parts[1],
                        DisplayedAs = parts[2]
                    };

                    // Console.WriteLine(parts[0] + "\t" + parts[1] + "\t" + parts[2]);

                    listofmappings.Add(mf);
                }
            }

            labelgridview.DataSource = new BindingSource { DataSource = listofmappings };

            mappinggridview.AutoGenerateColumns = false;
            labelgridview.Columns[0].ReadOnly = true;
            labelgridview.Columns[1].ReadOnly = true;
        }

        private void Loadrzgbtn_Click(object sender, EventArgs e)
        {
            if (mapFileDialog.ShowDialog() == DialogResult.OK)
            {

                // Read the RZG? file.
                using (StreamReader sr = new StreamReader(mapFileDialog.FileName))
                {
                    string[] cols = sr.ReadLine().Replace("\"", String.Empty).Split(',');

                    for (int i = 0; i < cols.Length; i++)
                    {
                        // Load an existing mapping if found
                        MappedField matchinglookup = listofmappings.FirstOrDefault(d => d.ImportThis == cols[i]);
                        if (matchinglookup != null)
                        {
                            importeduserdata.Rows.Add(cols[i], matchinglookup.IntoThis);
                        }
                        else
                        {
                            importeduserdata.Rows.Add(cols[i], "NOT USED");
                            // Console.WriteLine("<" + cols[i] + ">\t");
                        }
                    }

                    // Bind the DataTable to the DataGridView.
                    mappinggridview.DataSource = new BindingSource { DataSource = importeduserdata };

                }

                

            }
        }

        private void Savemappingtofile()
        {
            string[] lines = listofmappings.Select(mf => $"{mf.IntoThis},{mf.ImportThis},{mf.DisplayedAs}").ToArray();

            // Write the array of strings to a file
            File.WriteAllLines(AppDataHelper.ADH("ActiveMappings.txt"), lines);
        }

        private void Labelgridview_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (labelgridview.Columns[e.ColumnIndex].Index == 0 || labelgridview.Columns[e.ColumnIndex].Index == 1)
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() == "NOT USED")
                    {
                        e.CellStyle.BackColor = Color.Black;
                        e.CellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        private void Mappinggridview_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.FormattedValue.ToString() != "NOT USED")
                {
                    bool foundDuplicate = false;
                    foreach (DataGridViewRow row in mappinggridview.Rows)
                    {
                        if (row.Index != e.RowIndex && row.Cells[1].Value != null && row.Cells[1].Value.ToString() == e.FormattedValue.ToString())
                        {
                            e.Cancel = true;
                            mappinggridview.Rows[e.RowIndex].ErrorText = "Cannot Have Duplicates";
                            foundDuplicate = true;
                            break;
                        }
                    }
                    if (!foundDuplicate)
                    {
                        mappinggridview.Rows[e.RowIndex].ErrorText = String.Empty;
                    }
                }

            }
        }

        private void Mappinggridview_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < importeduserdata.Rows.Count; i++)
            {
                if (importeduserdata.Rows[i][1].ToString() != null && importeduserdata.Rows[i][1].ToString() != "NOT USED")
                {
                    MappedField existingMapping = listofmappings.FirstOrDefault(d => d.ImportThis == importeduserdata.Rows[i][0].ToString());
                    if (existingMapping != null)
                    {
                        existingMapping.ImportThis = "NOT USED";
                    }

                    MappedField dbfieldtomap = listofmappings.FirstOrDefault(d => d.IntoThis == importeduserdata.Rows[i][1].ToString());
                    if (dbfieldtomap != null)
                    {
                        dbfieldtomap.ImportThis = importeduserdata.Rows[i][0].ToString();
                    }
                    
                }
            }
            labelgridview.Refresh();
        }

    }
}
