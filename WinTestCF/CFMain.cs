using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTestCF
{
    public partial class CFMain : Form
    {
        public CFMain()
        {
            InitializeComponent();
        }

        private void btnReadExcel_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;

            if (txtfilename.Text != "") //if there is a file choosen by the user  
            {
                filePath = txtfilename.Text; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0 || fileExt.CompareTo(".xlsm") == 0)
                {
                    try
                    {
                        System.Data.DataSet dsExcel;
                        ExcelReader reader = new ExcelReader();
                        dsExcel = reader.ReadExcel(filePath); //read excel file  
                        if (reader.Status == "Success" && dsExcel.Tables.Count > 0)
                        {
                            dgExcel.Visible = true;
                            dgExcel.DataSource = dsExcel.Tables[0];

                            JSONUtils.InitAndAddCFParametersToJSON(reader.m61params);
                            JSONUtils.SerielizeDataTableToJSON(dsExcel.Tables[0]);
                            JSONUtils.CompleteJSON();
                            JSONUtils.WriteJsonToFile();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnFileName_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                txtfilename.Text = file.FileName;
            }
        }
    }
}
