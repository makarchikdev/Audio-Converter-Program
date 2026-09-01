namespace Audio_Converter_Program
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.LinkLabel lnkAbout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lstFiles = new System.Windows.Forms.ListView();
            colName = new System.Windows.Forms.ColumnHeader();
            colStatus = new System.Windows.Forms.ColumnHeader();
            colPath = new System.Windows.Forms.ColumnHeader();
            btnAdd = new System.Windows.Forms.Button();
            btnConvert = new System.Windows.Forms.Button();
            progressBar = new System.Windows.Forms.ProgressBar();
            lnkAbout = new System.Windows.Forms.LinkLabel();
            SuspendLayout();

            lstFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colName, colStatus, colPath });
            lstFiles.FullRowSelect = true;
            lstFiles.GridLines = true;
            lstFiles.Location = new System.Drawing.Point(12, 12);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new System.Drawing.Size(600, 290);
            lstFiles.TabIndex = 0;
            lstFiles.UseCompatibleStateImageBehavior = false;
            lstFiles.View = System.Windows.Forms.View.Details;

            colName.Text = "File Name";
            colName.Width = 180;

            colStatus.Text = "Status";
            colStatus.Width = 100;

            colPath.Text = "Full Path";
            colPath.Width = 310;

            btnAdd.Location = new System.Drawing.Point(12, 315);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(120, 35);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add MP3";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            lnkAbout.AutoSize = true;
            lnkAbout.Location = new System.Drawing.Point(52, 355);
            lnkAbout.Name = "lnkAbout";
            lnkAbout.Size = new System.Drawing.Size(40, 15);
            lnkAbout.TabIndex = 4;
            lnkAbout.TabStop = true;
            lnkAbout.Text = "About";
            lnkAbout.LinkColor = System.Drawing.Color.DodgerBlue;
            lnkAbout.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
            lnkAbout.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            lnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAbout_LinkClicked);

            btnConvert.Location = new System.Drawing.Point(492, 315);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(120, 35);
            btnConvert.TabIndex = 2;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += new System.EventHandler(this.btnConvert_Click);

            progressBar.Location = new System.Drawing.Point(145, 320);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(335, 23);
            progressBar.TabIndex = 3;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(624, 385);
            Controls.Add(lnkAbout);
            Controls.Add(progressBar);
            Controls.Add(btnConvert);
            Controls.Add(btnAdd);
            Controls.Add(lstFiles);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Audio Converter Program";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
