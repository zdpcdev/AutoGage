namespace AutoGageConverter
{
    partial class ComparisionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparisionView));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.openbtn1 = new System.Windows.Forms.Button();
            this.openbtn2 = new System.Windows.Forms.Button();
            this.comparisioninfotext = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.agnote = new System.Windows.Forms.Label();
            this.rgnote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1341, 281);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView_DataBindingComplete);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(28, 461);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1341, 281);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView_DataBindingComplete);
            // 
            // openbtn1
            // 
            this.openbtn1.BackColor = System.Drawing.Color.LightGreen;
            this.openbtn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openbtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openbtn1.Location = new System.Drawing.Point(28, 14);
            this.openbtn1.Name = "openbtn1";
            this.openbtn1.Size = new System.Drawing.Size(240, 49);
            this.openbtn1.TabIndex = 2;
            this.openbtn1.Text = "Open RDB From AutoGage";
            this.openbtn1.UseVisualStyleBackColor = false;
            this.openbtn1.Click += new System.EventHandler(this.Openbtn1_Click);
            // 
            // openbtn2
            // 
            this.openbtn2.BackColor = System.Drawing.Color.LightGreen;
            this.openbtn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openbtn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openbtn2.Location = new System.Drawing.Point(28, 395);
            this.openbtn2.Name = "openbtn2";
            this.openbtn2.Size = new System.Drawing.Size(240, 49);
            this.openbtn2.TabIndex = 3;
            this.openbtn2.Text = "Open RDB From RazorGage";
            this.openbtn2.UseVisualStyleBackColor = false;
            this.openbtn2.Click += new System.EventHandler(this.Openbtn2_Click);
            // 
            // comparisioninfotext
            // 
            this.comparisioninfotext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comparisioninfotext.Location = new System.Drawing.Point(661, 14);
            this.comparisioninfotext.Name = "comparisioninfotext";
            this.comparisioninfotext.Size = new System.Drawing.Size(708, 49);
            this.comparisioninfotext.TabIndex = 4;
            this.comparisioninfotext.Text = resources.GetString("comparisioninfotext.Text");
            this.comparisioninfotext.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "No File Selected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(289, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "No File Selected";
            // 
            // agnote
            // 
            this.agnote.AutoSize = true;
            this.agnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agnote.Location = new System.Drawing.Point(289, 14);
            this.agnote.Name = "agnote";
            this.agnote.Size = new System.Drawing.Size(127, 16);
            this.agnote.TabIndex = 7;
            this.agnote.Text = "File From AutoGage";
            // 
            // rgnote
            // 
            this.rgnote.AutoSize = true;
            this.rgnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgnote.Location = new System.Drawing.Point(289, 395);
            this.rgnote.Name = "rgnote";
            this.rgnote.Size = new System.Drawing.Size(136, 16);
            this.rgnote.TabIndex = 8;
            this.rgnote.Text = "File From RazorGage";
            // 
            // ComparisionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 754);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comparisioninfotext);
            this.Controls.Add(this.openbtn2);
            this.Controls.Add(this.openbtn1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.agnote);
            this.Controls.Add(this.rgnote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComparisionView";
            this.Text = "Compare 2 RDB Files";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button openbtn1;
        private System.Windows.Forms.Button openbtn2;
        private System.Windows.Forms.Label comparisioninfotext;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label agnote;
        private System.Windows.Forms.Label rgnote;
    }
}