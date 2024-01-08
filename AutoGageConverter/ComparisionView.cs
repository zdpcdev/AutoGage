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
    public partial class ComparisionView : Form
    {
        public ComparisionView()
        {
            InitializeComponent();

            // Add the Scroll event handlers
            dataGridView1.Scroll += new ScrollEventHandler(DataGridView_Scroll);
            dataGridView2.Scroll += new ScrollEventHandler(DataGridView_Scroll);
        }

        public ComparisionView(string recivedfile, string autogagefolder, string razorgagefolder)
        {
            InitializeComponent();

            openbtn1.Text = Path.Combine(autogagefolder, recivedfile);
            openbtn2.Text = Path.Combine(razorgagefolder, recivedfile);

            // Add the Scroll event handlers
            dataGridView1.Scroll += new ScrollEventHandler(DataGridView_Scroll);
            dataGridView2.Scroll += new ScrollEventHandler(DataGridView_Scroll);

            ConnectFileToGridView(Path.Combine(autogagefolder, recivedfile), dataGridView1, label1, openbtn1);
            ConnectFileToGridView(Path.Combine(razorgagefolder, recivedfile), dataGridView2, label2, openbtn2);
        }

        private void ConnectFileToGridView(string pathname, DataGridView viewtoupdate, Label amountlabel, Button openfilebtn)
        {
            // Fill a DataTable and link it to the grid view
            string connectionString = Properties.Settings.Default.cs64 + pathname;
            string query = "SELECT * FROM tblParts";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
            DataTable importtable = new DataTable();
            dataAdapter.Fill(importtable);
            viewtoupdate.DataSource = importtable;

            // Set the button text and parts count
            openfilebtn.Text = System.IO.Path.GetFileName(pathname);

            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            query = "SELECT COUNT(*) FROM tblParts";
            OleDbCommand command = new OleDbCommand(query, connection);
            int count = (int)command.ExecuteScalar();
            connection.Close();
            amountlabel.Text = count + " Parts in file.";
        }

        // Scroll event handler
        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridView otherDgv = dgv == dataGridView1 ? dataGridView2 : dataGridView1;

            otherDgv.Scroll -= new ScrollEventHandler(DataGridView_Scroll);

            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                // Sync horizontal scrolling
                otherDgv.HorizontalScrollingOffset = e.NewValue;
            }
            else
            {
                // Check if the DataGridViews are not empty and if the other datagridview has a scrollbar
                if (dgv.RowCount > 0 && otherDgv.RowCount > 0 && otherDgv.Controls.OfType<VScrollBar>().First().Visible)
                {
                    if (otherDgv.RowCount > dgv.FirstDisplayedScrollingRowIndex)
                    {
                        otherDgv.FirstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex;
                    }
                    else if (otherDgv.RowCount < dgv.FirstDisplayedScrollingRowIndex)
                    {
                        otherDgv.FirstDisplayedScrollingRowIndex = otherDgv.RowCount - 1;
                    }

                    CompareDataGrids();
                }
            }

            // Add the Scroll event handler back to the other DataGridView
            otherDgv.Scroll += new ScrollEventHandler(DataGridView_Scroll);
        }



        public void CompareDataGrids()
        {
            bool errorflag = false;
            if (dataGridView1.DataSource != null && dataGridView2.DataSource != null)
            {
                // Find the number of records in the smaller table
                int rowCount = Math.Min(dataGridView1.RowCount, dataGridView2.RowCount);
                int colCount = Math.Min(dataGridView1.ColumnCount, dataGridView2.ColumnCount);

                // Compare each cell
                for (int i = 0; i < rowCount; i++)
                {
                    // AutoIDNum does not matter, so it is excluded from data validation
                    for (int j = 1; j < colCount; j++)
                    {
                        if (!Equals(dataGridView1.Rows[i].Cells[j].Value, dataGridView2.Rows[i].Cells[j].Value))
                        {
                            dataGridView1.Rows[i].Cells[j].ErrorText = $"Cell at row {i} and column {j} are not the same.";
                            dataGridView2.Rows[i].Cells[j].ErrorText = $"Cell at row {i} and column {j} are not the same.";
                            errorflag = true;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].ErrorText = String.Empty;
                            dataGridView2.Rows[i].Cells[j].ErrorText = String.Empty;
                        }
                    }
                }
            }

            // Change button colors if there are any errors
            if (errorflag)
            {
                openbtn1.BackColor = Color.Tomato;
                openbtn2.BackColor = Color.Tomato;
            }
            else
            {
                openbtn1.BackColor = Color.LightGreen;
                openbtn2.BackColor = Color.LightGreen;
            }
        }


        private void Openbtn1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ConnectFileToGridView(openFileDialog1.FileName, dataGridView1, label1, openbtn1);
            }
        }

        private void Openbtn2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                ConnectFileToGridView(openFileDialog2.FileName, dataGridView2, label2, openbtn2);
            }
        }

        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CompareDataGrids();
        }
    }
}
