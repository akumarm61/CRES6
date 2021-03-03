namespace Test
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgExcel = new System.Windows.Forms.DataGridView();
            this.btnReadExcel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgExcel
            // 
            this.dgExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExcel.Location = new System.Drawing.Point(12, 119);
            this.dgExcel.Name = "dgExcel";
            this.dgExcel.RowHeadersWidth = 123;
            this.dgExcel.Size = new System.Drawing.Size(1140, 580);
            this.dgExcel.TabIndex = 0;
            this.dgExcel.Text = "dataGridView1";
            // 
            // btnReadExcel
            // 
            this.btnReadExcel.Location = new System.Drawing.Point(30, 21);
            this.btnReadExcel.Name = "btnReadExcel";
            this.btnReadExcel.Size = new System.Drawing.Size(225, 69);
            this.btnReadExcel.TabIndex = 1;
            this.btnReadExcel.Text = "ReadExcel";
            this.btnReadExcel.UseVisualStyleBackColor = true;
            this.btnReadExcel.Click += new System.EventHandler(this.btnReadExcel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(372, 20);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(225, 69);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 48F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 697);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReadExcel);
            this.Controls.Add(this.dgExcel);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dgExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgExcel;
        private System.Windows.Forms.Button btnReadExcel;
        private System.Windows.Forms.Button btnExit;
    }
}

