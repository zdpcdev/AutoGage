namespace AutoGageConverter
{
    partial class Settingsmenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settingsmenu));
            this.label1 = new System.Windows.Forms.Label();
            this.restorepointselector = new System.Windows.Forms.ComboBox();
            this.restorebtn = new System.Windows.Forms.Button();
            this.resetbtn = new System.Windows.Forms.Button();
            this.deletebkupsbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.configinfobox = new System.Windows.Forms.TextBox();
            this.adjustautoidbtn = new System.Windows.Forms.Button();
            this.changepreview = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveandapplybtn = new System.Windows.Forms.Button();
            this.infoaboutsaving = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.aboutInfoText = new System.Windows.Forms.Label();
            this.exportbtn = new System.Windows.Forms.Button();
            this.exportSettingsDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changepreview)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "Every time you SAVE the settings, a backup with those settings is created. You ca" +
    "n restore a previous version of the settings here.";
            // 
            // restorepointselector
            // 
            this.restorepointselector.AccessibleName = "Backup Selector Dropdown";
            this.restorepointselector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.restorepointselector.FormattingEnabled = true;
            this.restorepointselector.Location = new System.Drawing.Point(754, 139);
            this.restorepointselector.Name = "restorepointselector";
            this.restorepointselector.Size = new System.Drawing.Size(270, 21);
            this.restorepointselector.TabIndex = 4;
            // 
            // restorebtn
            // 
            this.restorebtn.AccessibleName = "Restore Previous Settings";
            this.restorebtn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.restorebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.restorebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restorebtn.Location = new System.Drawing.Point(9, 153);
            this.restorebtn.Name = "restorebtn";
            this.restorebtn.Size = new System.Drawing.Size(270, 65);
            this.restorebtn.TabIndex = 5;
            this.restorebtn.Text = "Restore Previous Settings";
            this.restorebtn.UseVisualStyleBackColor = false;
            this.restorebtn.Click += new System.EventHandler(this.Restorebtn_Click);
            // 
            // resetbtn
            // 
            this.resetbtn.AccessibleName = "Reset Settings to Default";
            this.resetbtn.BackColor = System.Drawing.Color.Coral;
            this.resetbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resetbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetbtn.Location = new System.Drawing.Point(754, 373);
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.Size = new System.Drawing.Size(270, 65);
            this.resetbtn.TabIndex = 6;
            this.resetbtn.Text = "Reset Settings to Default";
            this.resetbtn.UseVisualStyleBackColor = false;
            this.resetbtn.Click += new System.EventHandler(this.Resetbtn_Click);
            // 
            // deletebkupsbtn
            // 
            this.deletebkupsbtn.AccessibleName = "Delete all backups";
            this.deletebkupsbtn.BackColor = System.Drawing.Color.LightCoral;
            this.deletebkupsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deletebkupsbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletebkupsbtn.Location = new System.Drawing.Point(9, 47);
            this.deletebkupsbtn.Name = "deletebkupsbtn";
            this.deletebkupsbtn.Size = new System.Drawing.Size(270, 65);
            this.deletebkupsbtn.TabIndex = 8;
            this.deletebkupsbtn.Text = "Delete ALL Backups";
            this.deletebkupsbtn.UseVisualStyleBackColor = false;
            this.deletebkupsbtn.Click += new System.EventHandler(this.Deletebkupsbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.configinfobox);
            this.groupBox1.Controls.Add(this.adjustautoidbtn);
            this.groupBox1.Controls.Add(this.deletebkupsbtn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(745, 550);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 171);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danger - These Actions Cannot Be Undone.";
            // 
            // configinfobox
            // 
            this.configinfobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configinfobox.Location = new System.Drawing.Point(9, 124);
            this.configinfobox.Name = "configinfobox";
            this.configinfobox.Size = new System.Drawing.Size(164, 26);
            this.configinfobox.TabIndex = 10;
            this.configinfobox.TextChanged += new System.EventHandler(this.Configinfobox_TextChanged);
            // 
            // adjustautoidbtn
            // 
            this.adjustautoidbtn.Enabled = false;
            this.adjustautoidbtn.Location = new System.Drawing.Point(178, 124);
            this.adjustautoidbtn.Name = "adjustautoidbtn";
            this.adjustautoidbtn.Size = new System.Drawing.Size(100, 26);
            this.adjustautoidbtn.TabIndex = 9;
            this.adjustautoidbtn.Text = "Adjust AutoID";
            this.adjustautoidbtn.UseVisualStyleBackColor = true;
            this.adjustautoidbtn.Click += new System.EventHandler(this.Adjustautoidbtn_Click);
            // 
            // changepreview
            // 
            this.changepreview.AccessibleName = "Setting Editor";
            this.changepreview.AllowUserToResizeRows = false;
            this.changepreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.changepreview.BackgroundColor = System.Drawing.SystemColors.Control;
            this.changepreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.changepreview.Location = new System.Drawing.Point(20, 40);
            this.changepreview.Name = "changepreview";
            this.changepreview.Size = new System.Drawing.Size(700, 800);
            this.changepreview.TabIndex = 1;
            this.changepreview.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Changespreview_CellEndEdit);
            this.changepreview.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Changespreview_CellValidating);
            this.changepreview.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.Changespreview_DefaultValuesNeeded);
            this.changepreview.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.Changepreview_UserDeletedRow);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.restorebtn);
            this.groupBox2.Location = new System.Drawing.Point(745, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 231);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rollback Changes";
            // 
            // saveandapplybtn
            // 
            this.saveandapplybtn.AccessibleName = "Save and Apply Changes";
            this.saveandapplybtn.BackColor = System.Drawing.Color.LightGreen;
            this.saveandapplybtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveandapplybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveandapplybtn.Location = new System.Drawing.Point(753, 40);
            this.saveandapplybtn.Name = "saveandapplybtn";
            this.saveandapplybtn.Size = new System.Drawing.Size(270, 59);
            this.saveandapplybtn.TabIndex = 2;
            this.saveandapplybtn.Text = "Save and Apply Criteria";
            this.saveandapplybtn.UseVisualStyleBackColor = false;
            this.saveandapplybtn.Click += new System.EventHandler(this.Saveandapplybtn_Click);
            // 
            // infoaboutsaving
            // 
            this.infoaboutsaving.AutoSize = true;
            this.infoaboutsaving.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoaboutsaving.Location = new System.Drawing.Point(20, 13);
            this.infoaboutsaving.Name = "infoaboutsaving";
            this.infoaboutsaving.Size = new System.Drawing.Size(625, 16);
            this.infoaboutsaving.TabIndex = 9;
            this.infoaboutsaving.Text = "Adjust the settings in the editor below. No changes are made UNTIL you press \"Sav" +
    "e and Apply Criteria\".";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.aboutInfoText);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(745, 727);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 113);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "About";
            // 
            // aboutInfoText
            // 
            this.aboutInfoText.Location = new System.Drawing.Point(9, 22);
            this.aboutInfoText.Name = "aboutInfoText";
            this.aboutInfoText.Size = new System.Drawing.Size(278, 88);
            this.aboutInfoText.TabIndex = 0;
            this.aboutInfoText.Text = "AutoGage PLP V7.4.0 (01/04/2024)\r\nUses Default Mappings\r\nRazorGage With AutoList\r" +
    "\nScribes\r\nPocketHoles\r\n";
            // 
            // exportbtn
            // 
            this.exportbtn.BackColor = System.Drawing.Color.Plum;
            this.exportbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exportbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportbtn.Location = new System.Drawing.Point(754, 459);
            this.exportbtn.Name = "exportbtn";
            this.exportbtn.Size = new System.Drawing.Size(270, 65);
            this.exportbtn.TabIndex = 11;
            this.exportbtn.Text = "Export Settings to Desktop";
            this.exportbtn.UseVisualStyleBackColor = false;
            this.exportbtn.Click += new System.EventHandler(this.Exportbtn_Click);
            // 
            // exportSettingsDialog
            // 
            this.exportSettingsDialog.DefaultExt = "txt";
            this.exportSettingsDialog.InitialDirectory = "Desktop";
            this.exportSettingsDialog.Title = "Save Parts Critera As";
            // 
            // settingsmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 861);
            this.Controls.Add(this.exportbtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.infoaboutsaving);
            this.Controls.Add(this.saveandapplybtn);
            this.Controls.Add(this.restorepointselector);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.changepreview);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resetbtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingsmenu";
            this.Text = "Modify Parts Criteria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settingsmenu_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changepreview)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox restorepointselector;
        private System.Windows.Forms.Button restorebtn;
        private System.Windows.Forms.Button resetbtn;
        private System.Windows.Forms.Button deletebkupsbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView changepreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button saveandapplybtn;
        private System.Windows.Forms.Label infoaboutsaving;
        private System.Windows.Forms.Button adjustautoidbtn;
        private System.Windows.Forms.TextBox configinfobox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label aboutInfoText;
        private System.Windows.Forms.Button exportbtn;
        private System.Windows.Forms.SaveFileDialog exportSettingsDialog;
    }
}