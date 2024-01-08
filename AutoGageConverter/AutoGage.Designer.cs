namespace AutoGageConverter
{
    partial class AutoGage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoGage));
            this.label1 = new System.Windows.Forms.Label();
            this.conversionbtn = new System.Windows.Forms.Button();
            this.ofdSingleFile = new System.Windows.Forms.OpenFileDialog();
            this.activeProfileLabel = new System.Windows.Forms.Label();
            this.auditlabel = new System.Windows.Forms.Label();
            this.settingsbtn = new System.Windows.Forms.Button();
            this.activepreviewgrid = new System.Windows.Forms.DataGridView();
            this.conversionstatus = new System.Windows.Forms.ProgressBar();
            this.auditlog = new System.Windows.Forms.TextBox();
            this.openmappingbtn = new System.Windows.Forms.Button();
            this.comparebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.activepreviewgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "This program converts RazorGage RZG files to rdb Part files in bulk. You can sele" +
    "ct multiple files at a time, drag and drop is also supported.";
            // 
            // conversionbtn
            // 
            this.conversionbtn.AllowDrop = true;
            this.conversionbtn.BackColor = System.Drawing.Color.SpringGreen;
            this.conversionbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.conversionbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conversionbtn.Location = new System.Drawing.Point(25, 72);
            this.conversionbtn.Name = "conversionbtn";
            this.conversionbtn.Size = new System.Drawing.Size(175, 60);
            this.conversionbtn.TabIndex = 2;
            this.conversionbtn.Text = "Convert File(s)";
            this.conversionbtn.UseVisualStyleBackColor = false;
            this.conversionbtn.Click += new System.EventHandler(this.ConversionBtn_Click);
            this.conversionbtn.DragDrop += new System.Windows.Forms.DragEventHandler(this.ConversionBtn_DragDrop);
            this.conversionbtn.DragEnter += new System.Windows.Forms.DragEventHandler(this.ConversionBtn_DragEnter);
            this.conversionbtn.DragLeave += new System.EventHandler(this.ConversionBtn_DragLeave);
            // 
            // ofdSingleFile
            // 
            this.ofdSingleFile.Filter = "RazorGage Parts Files (*.RZG)|*.RZG|Text files (*.txt)|*.txt|CSV files (*.csv)|*." +
    "csv";
            this.ofdSingleFile.Multiselect = true;
            // 
            // activeProfileLabel
            // 
            this.activeProfileLabel.AutoSize = true;
            this.activeProfileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeProfileLabel.Location = new System.Drawing.Point(22, 235);
            this.activeProfileLabel.Name = "activeProfileLabel";
            this.activeProfileLabel.Size = new System.Drawing.Size(168, 16);
            this.activeProfileLabel.TabIndex = 4;
            this.activeProfileLabel.Text = "Active Parts Critera: Default";
            // 
            // auditlabel
            // 
            this.auditlabel.AutoSize = true;
            this.auditlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auditlabel.Location = new System.Drawing.Point(651, 20);
            this.auditlabel.Name = "auditlabel";
            this.auditlabel.Size = new System.Drawing.Size(63, 16);
            this.auditlabel.TabIndex = 6;
            this.auditlabel.Text = "Audit Log";
            // 
            // settingsbtn
            // 
            this.settingsbtn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.settingsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.settingsbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settingsbtn.Location = new System.Drawing.Point(25, 152);
            this.settingsbtn.Name = "settingsbtn";
            this.settingsbtn.Size = new System.Drawing.Size(175, 60);
            this.settingsbtn.TabIndex = 3;
            this.settingsbtn.Text = "Settings";
            this.settingsbtn.UseVisualStyleBackColor = false;
            this.settingsbtn.Click += new System.EventHandler(this.Settingsbtn_Click);
            // 
            // activepreviewgrid
            // 
            this.activepreviewgrid.AllowUserToAddRows = false;
            this.activepreviewgrid.AllowUserToDeleteRows = false;
            this.activepreviewgrid.AllowUserToResizeColumns = false;
            this.activepreviewgrid.AllowUserToResizeRows = false;
            this.activepreviewgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.activepreviewgrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.activepreviewgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.activepreviewgrid.Cursor = System.Windows.Forms.Cursors.No;
            this.activepreviewgrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.activepreviewgrid.Location = new System.Drawing.Point(25, 265);
            this.activepreviewgrid.Name = "activepreviewgrid";
            this.activepreviewgrid.ReadOnly = true;
            this.activepreviewgrid.ShowEditingIcon = false;
            this.activepreviewgrid.Size = new System.Drawing.Size(689, 275);
            this.activepreviewgrid.TabIndex = 5;
            this.activepreviewgrid.TabStop = false;
            this.activepreviewgrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Activepreviewgrid_DataBindingComplete);
            // 
            // conversionstatus
            // 
            this.conversionstatus.Location = new System.Drawing.Point(445, 18);
            this.conversionstatus.Name = "conversionstatus";
            this.conversionstatus.Size = new System.Drawing.Size(200, 20);
            this.conversionstatus.Step = 1;
            this.conversionstatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.conversionstatus.TabIndex = 7;
            this.conversionstatus.Visible = false;
            // 
            // auditlog
            // 
            this.auditlog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.auditlog.Location = new System.Drawing.Point(445, 72);
            this.auditlog.Multiline = true;
            this.auditlog.Name = "auditlog";
            this.auditlog.ReadOnly = true;
            this.auditlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.auditlog.Size = new System.Drawing.Size(269, 140);
            this.auditlog.TabIndex = 8;
            this.auditlog.WordWrap = false;
            // 
            // openmappingbtn
            // 
            this.openmappingbtn.BackColor = System.Drawing.Color.Plum;
            this.openmappingbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openmappingbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openmappingbtn.Location = new System.Drawing.Point(224, 152);
            this.openmappingbtn.Name = "openmappingbtn";
            this.openmappingbtn.Size = new System.Drawing.Size(174, 60);
            this.openmappingbtn.TabIndex = 9;
            this.openmappingbtn.Text = "Print Mapping";
            this.openmappingbtn.UseVisualStyleBackColor = false;
            this.openmappingbtn.Click += new System.EventHandler(this.Openmappingbtn_Click);
            // 
            // comparebtn
            // 
            this.comparebtn.BackColor = System.Drawing.Color.LightCoral;
            this.comparebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comparebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comparebtn.Location = new System.Drawing.Point(224, 72);
            this.comparebtn.Name = "comparebtn";
            this.comparebtn.Size = new System.Drawing.Size(174, 60);
            this.comparebtn.TabIndex = 10;
            this.comparebtn.Text = "Compare Files";
            this.comparebtn.UseVisualStyleBackColor = false;
            this.comparebtn.Click += new System.EventHandler(this.Comparebtn_Click);
            // 
            // AutoGage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 577);
            this.Controls.Add(this.comparebtn);
            this.Controls.Add(this.openmappingbtn);
            this.Controls.Add(this.conversionstatus);
            this.Controls.Add(this.activepreviewgrid);
            this.Controls.Add(this.settingsbtn);
            this.Controls.Add(this.auditlabel);
            this.Controls.Add(this.activeProfileLabel);
            this.Controls.Add(this.conversionbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.auditlog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoGage";
            this.Text = "AutoGage PLP V7.4.0";
            ((System.ComponentModel.ISupportInitialize)(this.activepreviewgrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button conversionbtn;
        private System.Windows.Forms.OpenFileDialog ofdSingleFile;
        private System.Windows.Forms.Label activeProfileLabel;
        private System.Windows.Forms.Label auditlabel;
        private System.Windows.Forms.Button settingsbtn;
        private System.Windows.Forms.DataGridView activepreviewgrid;
        private System.Windows.Forms.ProgressBar conversionstatus;
        private System.Windows.Forms.TextBox auditlog;
        private System.Windows.Forms.Button openmappingbtn;
        private System.Windows.Forms.Button comparebtn;
    }
}

