using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoGageConverter
{
    public partial class NewPartScreening : Form
    {
        public DataTable dt;

        public DataRow ImportedPart
        {
            get { return dt.Rows[0]; }
        }

        public NewPartScreening()
        {
            InitializeComponent();
        }

        public NewPartScreening(DataTable table)
        {
           InitializeComponent();
            this.dt = table;
            BindingSource bindingSource = new BindingSource { DataSource = dt };
            newpartsgrid.DataSource = bindingSource;
        }

        private void Continuebtn_Click(object sender, EventArgs e)
        {
            dt.AcceptChanges();
            this.Close();
        }
    }
}
