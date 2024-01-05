namespace AutoGageConverter
{
    partial class NewPartScreening
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPartScreening));
            this.newpartsgrid = new System.Windows.Forms.DataGridView();
            this.info = new System.Windows.Forms.Label();
            this.continuebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.newpartsgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // newpartsgrid
            // 
            this.newpartsgrid.AllowUserToAddRows = false;
            this.newpartsgrid.AllowUserToDeleteRows = false;
            this.newpartsgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.newpartsgrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.newpartsgrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newpartsgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newpartsgrid.Location = new System.Drawing.Point(12, 77);
            this.newpartsgrid.Name = "newpartsgrid";
            this.newpartsgrid.Size = new System.Drawing.Size(665, 85);
            this.newpartsgrid.TabIndex = 0;
            // 
            // info
            // 
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(13, 13);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(616, 52);
            this.info.TabIndex = 1;
            this.info.Text = resources.GetString("info.Text");
            // 
            // continuebtn
            // 
            this.continuebtn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.continuebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continuebtn.Location = new System.Drawing.Point(488, 181);
            this.continuebtn.Name = "continuebtn";
            this.continuebtn.Size = new System.Drawing.Size(189, 42);
            this.continuebtn.TabIndex = 2;
            this.continuebtn.Text = "Continue";
            this.continuebtn.UseVisualStyleBackColor = false;
            this.continuebtn.Click += new System.EventHandler(this.Continuebtn_Click);
            // 
            // NewPartScreening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 235);
            this.ControlBox = false;
            this.Controls.Add(this.continuebtn);
            this.Controls.Add(this.info);
            this.Controls.Add(this.newpartsgrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewPartScreening";
            this.Text = "Configure New Part";
            ((System.ComponentModel.ISupportInitialize)(this.newpartsgrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView newpartsgrid;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button continuebtn;
    }
}