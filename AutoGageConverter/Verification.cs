using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoGageConverter
{
    public partial class Verification : Form
    {

        private readonly DataTable dt1 = new DataTable();
        private readonly DataTable dt2 = new DataTable();

        public Verification()
        {
            InitializeComponent();

            
            dt1.Columns.Add("Same", typeof(string));
            dataGridView1.DataSource = dt1;

           
            dt2.Columns.Add("Different", typeof(string));
            dataGridView2.DataSource = dt2;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = razorgagefolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Console.WriteLine(razorgagefolder.SelectedPath);
                rglabel.Text = Path.GetFileName(razorgagefolder.SelectedPath);
                CanCompare();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = autogagefolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Console.WriteLine(autogagefolder.SelectedPath);
                aglabel.Text = Path.GetFileName(autogagefolder.SelectedPath);
                CanCompare();
            }
        }

        private void CanCompare()
        {
            if (aglabel.Text != "No folder selected" && rglabel.Text != "No folder selected")
            {
                comparebtn.Enabled = true;
            }
            else
            {
                comparebtn.Enabled = false;
            }
        }

        private void Comparebtn_Click(object sender, EventArgs e)
        {
            List<string> razorfilenames = new List<string> { };
            List<string> autofilenames = new List<string> { };

            foreach (string file in Directory.GetFiles(razorgagefolder.SelectedPath))
            {
                // Check if the file has .RZG extension
                if (Path.GetExtension(file).Equals(".rdb", StringComparison.OrdinalIgnoreCase))
                {
                    razorfilenames.Add(file);
                }
            }

            foreach (string file in Directory.GetFiles(autogagefolder.SelectedPath))
            {
                // Check if the file has .RZG extension
                if (Path.GetExtension(file).Equals(".rdb", StringComparison.OrdinalIgnoreCase))
                {
                    autofilenames.Add(file);
                }
            }

            if (razorfilenames.Count == autofilenames.Count)
            {
                comparebtn.Text = "Processing Files";
                comparebtn.Enabled = false;
                for (int i = 0; i < razorfilenames.Count; i++)
                {
                    string connectionString1 = Properties.Settings.Default.cs64 + razorfilenames[i];
                    string connectionString2 = Properties.Settings.Default.cs64 + autofilenames[i];

                    using (OleDbConnection connection1 = new OleDbConnection(connectionString1))
                    using (OleDbConnection connection2 = new OleDbConnection(connectionString2))
                    {
                        connection1.Open();
                        connection2.Open();

                        OleDbCommand command1 = new OleDbCommand("SELECT * FROM tblParts", connection1);
                        OleDbCommand command2 = new OleDbCommand("SELECT * FROM tblParts", connection2);

                        OleDbDataReader reader1 = command1.ExecuteReader();
                        OleDbDataReader reader2 = command2.ExecuteReader();

                        bool isDifferent = false;
                        while (reader1.Read() && reader2.Read())
                        {
                            for (int j = 1; j < 34; j++)
                            {
                                if (!reader1[j].Equals(reader2[j]))
                                {
                                    isDifferent = true;
                                    break;
                                }
                            }

                            if (isDifferent)
                            {
                                break;
                            }
                        }

                        if (isDifferent)
                        {
                            dt2.Rows.Add(Path.GetFileName(razorfilenames[i]));
                        }
                        else
                        {
                            dt1.Rows.Add(Path.GetFileName(razorfilenames[i]));
                        }
                    }
                }



                comparebtn.Text = "Compare";
                comparebtn.Enabled = true;
            }
            //else
            //{
            //    Console.WriteLine("ERROR");
            //}

            //Console.WriteLine("DONE");
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string passedfile = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            new ComparisionView(passedfile, autogagefolder.SelectedPath, razorgagefolder.SelectedPath).ShowDialog();
            // MessageBox.Show(Path.Combine(autogagefolder.SelectedPath, passedfile));
        }

        private void DataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string passedfile = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            new ComparisionView(passedfile, autogagefolder.SelectedPath, razorgagefolder.SelectedPath).ShowDialog();
            // MessageBox.Show(Path.Combine(autogagefolder.SelectedPath, passedfile));
        }

    }
}
