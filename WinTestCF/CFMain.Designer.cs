namespace WinTestCF
{
    partial class CFMain
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
            this.btnReadExcel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgExcel = new System.Windows.Forms.DataGridView();
            this.txtfilename = new System.Windows.Forms.TextBox();
            this.btnFileName = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadExcel
            // 
            this.btnReadExcel.Location = new System.Drawing.Point(966, 48);
            this.btnReadExcel.Name = "btnReadExcel";
            this.btnReadExcel.Size = new System.Drawing.Size(177, 71);
            this.btnReadExcel.TabIndex = 0;
            this.btnReadExcel.Text = "ReadExcel";
            this.btnReadExcel.UseVisualStyleBackColor = true;
            this.btnReadExcel.Click += new System.EventHandler(this.btnReadExcel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1162, 48);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 71);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgExcel
            // 
            this.dgExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExcel.Location = new System.Drawing.Point(25, 151);
            this.dgExcel.Name = "dgExcel";
            this.dgExcel.RowHeadersWidth = 123;
            this.dgExcel.RowTemplate.Height = 46;
            this.dgExcel.Size = new System.Drawing.Size(1250, 521);
            this.dgExcel.TabIndex = 2;
            // 
            // txtfilename
            // 
            this.txtfilename.Location = new System.Drawing.Point(25, 48);
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.Size = new System.Drawing.Size(694, 44);
            this.txtfilename.TabIndex = 3;
            this.txtfilename.Text = "D:\\Temp\\Sizer.xlsx";
            // 
            // btnFileName
            // 
            this.btnFileName.Location = new System.Drawing.Point(767, 48);
            this.btnFileName.Name = "btnFileName";
            this.btnFileName.Size = new System.Drawing.Size(179, 71);
            this.btnFileName.TabIndex = 4;
            this.btnFileName.Text = "Pick File";
            this.btnFileName.UseVisualStyleBackColor = true;
            this.btnFileName.Click += new System.EventHandler(this.btnFileName_Click);
            // 
            // CFMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 685);
            this.Controls.Add(this.btnFileName);
            this.Controls.Add(this.txtfilename);
            this.Controls.Add(this.dgExcel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReadExcel);
            this.Name = "CFMain";
            this.Text = "CFMain";
            ((System.ComponentModel.ISupportInitialize)(this.dgExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadExcel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgExcel;
        private System.Windows.Forms.TextBox txtfilename;
        private System.Windows.Forms.Button btnFileName;
    }
}