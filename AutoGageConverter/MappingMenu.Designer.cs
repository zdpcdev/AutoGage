namespace AutoGageConverter
{
    partial class MappingMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MappingMenu));
            this.mappinggridview = new System.Windows.Forms.DataGridView();
            this.IN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OUT = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.loadrzgbtn = new System.Windows.Forms.Button();
            this.mapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelgridview = new System.Windows.Forms.DataGridView();
            this.TODO = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mappinggridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelgridview)).BeginInit();
            this.SuspendLayout();
            // 
            // mappinggridview
            // 
            this.mappinggridview.AllowUserToAddRows = false;
            this.mappinggridview.AllowUserToDeleteRows = false;
            this.mappinggridview.AllowUserToResizeRows = false;
            this.mappinggridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mappinggridview.BackgroundColor = System.Drawing.SystemColors.Control;
            this.mappinggridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mappinggridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mappinggridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IN,
            this.OUT});
            this.mappinggridview.Location = new System.Drawing.Point(32, 109);
            this.mappinggridview.Name = "mappinggridview";
            this.mappinggridview.Size = new System.Drawing.Size(241, 597);
            this.mappinggridview.TabIndex = 0;
            this.mappinggridview.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.Mappinggridview_CellValidated);
            this.mappinggridview.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Mappinggridview_CellValidating);
            // 
            // IN
            // 
            this.IN.DataPropertyName = "IN";
            this.IN.Frozen = true;
            this.IN.HeaderText = "RZG Column";
            this.IN.Name = "IN";
            this.IN.Width = 93;
            // 
            // OUT
            // 
            this.OUT.DataPropertyName = "OUT";
            this.OUT.HeaderText = "DB Name";
            this.OUT.Items.AddRange(new object[] {
            "NOT USED",
            "QUANTITY",
            "PART",
            "MATERIAL",
            "WIDTH",
            "LENGTH",
            "THICKNESS",
            "SCRIBES",
            "UF_1",
            "UF_2",
            "UF_3",
            "UF_4",
            "UF_5",
            "UF_6",
            "UF_7",
            "UF_8",
            "UF_9",
            "UF_10",
            "UF_11",
            "UF_12",
            "UF_13",
            "UF_14",
            "UF_15",
            "UF_16",
            "UF_17",
            "UF_18",
            "UF_19",
            "UF_20"});
            this.OUT.Name = "OUT";
            this.OUT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OUT.Width = 78;
            // 
            // loadrzgbtn
            // 
            this.loadrzgbtn.BackColor = System.Drawing.Color.DarkTurquoise;
            this.loadrzgbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadrzgbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadrzgbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadrzgbtn.Location = new System.Drawing.Point(32, 33);
            this.loadrzgbtn.Name = "loadrzgbtn";
            this.loadrzgbtn.Size = new System.Drawing.Size(214, 51);
            this.loadrzgbtn.TabIndex = 1;
            this.loadrzgbtn.Text = "Load File to Map";
            this.loadrzgbtn.UseVisualStyleBackColor = false;
            this.loadrzgbtn.Click += new System.EventHandler(this.Loadrzgbtn_Click);
            // 
            // mapFileDialog
            // 
            this.mapFileDialog.FileName = "selectedfiletomap";
            this.mapFileDialog.Filter = "RazorGage Parts Files (*.RZG)|*.RZG|Text files (*.txt)|*.txt|CSV files (*.csv)|*." +
    "csv";
            // 
            // labelgridview
            // 
            this.labelgridview.AllowUserToAddRows = false;
            this.labelgridview.AllowUserToDeleteRows = false;
            this.labelgridview.AllowUserToResizeRows = false;
            this.labelgridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.labelgridview.BackgroundColor = System.Drawing.SystemColors.Control;
            this.labelgridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.labelgridview.Location = new System.Drawing.Point(306, 109);
            this.labelgridview.Name = "labelgridview";
            this.labelgridview.Size = new System.Drawing.Size(297, 597);
            this.labelgridview.TabIndex = 2;
            this.labelgridview.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Labelgridview_CellFormatting);
            // 
            // TODO
            // 
            this.TODO.AutoSize = true;
            this.TODO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TODO.Location = new System.Drawing.Point(377, 33);
            this.TODO.Name = "TODO";
            this.TODO.Size = new System.Drawing.Size(216, 32);
            this.TODO.TabIndex = 3;
            this.TODO.Text = "This feature is not yet implemented.\r\nYour mappings will not be saved.";
            this.TODO.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MappingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 729);
            this.Controls.Add(this.TODO);
            this.Controls.Add(this.labelgridview);
            this.Controls.Add(this.loadrzgbtn);
            this.Controls.Add(this.mappinggridview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MappingMenu";
            this.Text = "Map RZG File";
            ((System.ComponentModel.ISupportInitialize)(this.mappinggridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelgridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mappinggridview;
        private System.Windows.Forms.Button loadrzgbtn;
        private System.Windows.Forms.OpenFileDialog mapFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn IN;
        private System.Windows.Forms.DataGridViewComboBoxColumn OUT;
        private System.Windows.Forms.DataGridView labelgridview;
        private System.Windows.Forms.Label TODO;
    }
}