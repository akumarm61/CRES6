using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Office;
using Microsoft.Office.Interop.Excel;

namespace WinTestCF
{

    class ExcelReader
    {

        #region Properties
        Microsoft.Office.Interop.Excel.Application _excelApp;
        public Dictionary<string, object> m61params;
        public string Status = string.Empty;
        public string ExcelFileName = string.Empty;
        #endregion

        public ExcelReader()
        {
            _excelApp = new Microsoft.Office.Interop.Excel.Application();
            m61params = new Dictionary<string, object>();
        }

        /// <summary>
        /// Open the file path received in Excel. Then, open the workbook
        /// within the file. Send the workbook to the next function, the internal scan
        /// function. Will throw an exception if a file cannot be found or opened.
        /// </summary>
        public System.Data.DataSet ReadExcel(string thisFileName)
        {
            System.Data.DataSet dsExcel = new System.Data.DataSet();
            System.Data.DataTable dtFunding;
            try
            {
                //
                // This mess of code opens an Excel workbook. I don't know what all
                // those arguments do, but they can be changed to influence behavior.
                //
                Workbook workBook = _excelApp.Workbooks.Open(thisFileName,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);


                dtFunding = ExcelScanInternal(workBook, "Funding");
                dsExcel.Tables.Add(dtFunding);

                m61params = GetParameters(workBook);

                workBook.Close(false, thisFileName, null);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                Status = "Success";
            }
            catch(Exception ex)
            {
                Status = ex.Message;
            }
            return dsExcel;
        }

        /// <summary>
        /// Scan the selected Excel workbook and store the information in the cells
        /// for this workbook in an object[,] array. Then, call another method
        /// to process the data.
        /// </summary>
        private System.Data.DataTable ExcelScanInternal(Workbook workBookIn, String TableName)
        {
            //
            // Get sheet Count and store the number of sheets.
            //
            int numSheets = workBookIn.Sheets.Count;
            //Inputs - schedule
            Worksheet sheet = (Worksheet)workBookIn.Sheets["Inputs - schedule"];
            if (sheet != null)
            {
                Microsoft.Office.Interop.Excel.Range excelRange = sheet.Range["A9:M154"];
                
                //object[,] valueArray = (object[,])excelRange.get_Value(
                //    XlRangeValueDataType.xlRangeValueDefault);

                return ExcelRangeToDataTable(excelRange, TableName);
            }
            else
                return new System.Data.DataTable();

        }

        public System.Data.DataTable ExcelRangeToDataTable(Range range, string TableName)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            //var cells = range.Cells;
            string CellFormat = string.Empty;
            int rows = range.Rows.Count;
            int cols = range.Columns.Count;
            string name, colname = string.Empty;
            Range target;
            List<string> colList = new List<string>();
            System.Data.DataRow row;

            for (int c = 1; c <= cols; c++)
            {
                //colname = range.Cells[1, c].Value2;
                target = range.Cells[1, c];
                try
                {
                    name = Convert.ToString(target.Value2);//((Name)target.Name).Name;
                    if (name != null || name != string.Empty)
                        colname = name.Substring(name.LastIndexOf(@"!") + 1);
                    else
                        colname = "Missing" + c.ToString();
                    colList.Add(colname.ToLower());
                    table.Columns.Add(colname);

                }
                catch (System.Runtime.InteropServices.COMException e)
                {
                    Status += "\nExcelRangeToDataTable: " + e.Message;
                    throw;
                }

            }

            for (int r = 2; r <= rows; r++)
            {
                if (range.Cells[r, 1].Value2 != null)
                    if (range.Cells[r, 1].Value2.ToString().Trim() != "" && range.Cells[r, 1].Value2.ToString() != String.Empty)
                    {
                        row = table.NewRow();

                        for (int c = 1; c <= table.Columns.Count; c++)
                        {
                            CellFormat = range.Cells[r, c].NumberFormat;
                            if(CellFormat.Equals("m/d/yyyy"))
                                row[c - 1] = DateTime.FromOADate(range.Cells[r, c].Value2);
                            else
                                row[c - 1] = range.Cells[r, c].Value2;
                        }
                        table.Rows.Add(row);
                    }
                    else
                        break;
                else
                    break;
            }
            table.TableName = TableName;
            return table;
        }

        private Dictionary<string, object> GetParameters(Workbook workBook)
        {
            try
            {
                string sValue = string.Empty;
                DateTime dt;
                //Dictionary<string, object> m61params = new Dictionary<string, object>();
                Worksheet sheet = (Worksheet)workBook.Sheets["Inputs"];
                
                m61params.Add("CREDealID", Convert.ToString(sheet.Range["BackshopDealID"].Value2));  //BackshopDealID
                m61params.Add("DealName", Convert.ToString(sheet.Range["D_1"].Value2));  //DealName

                //Closing Date
                dt = DateTime.FromOADate(sheet.Range["D_2"].Value2);
                if (sheet.Range["D_2"].Value2 != null)
                    m61params.Add("ClosingDate", dt);

                //First Payment Date
                dt = DateTime.FromOADate(sheet.Range["D_3"].Value2);
                if (sheet.Range["D_3"].Value2 != null)
                    m61params.Add("FirstPaymentDate", dt);
                
                //Initial Maturity Date
                dt = DateTime.FromOADate(sheet.Range["D275"].Value2);
                if (sheet.Range["D275"].Value2 != null)
                    m61params.Add("InitialMaturityDate", dt);

                //Fully Extended Maturity Date
                dt = DateTime.FromOADate(sheet.Range["D280"].Value2);
                if (sheet.Range["D280"].Value2 != null)
                    m61params.Add("FullyExtendedMaturityDate", dt);

                //IO Term
                if (sheet.Range["D_IO_Term"].Value2 != null)
                    m61params.Add("IOTerm", Convert.ToInt32(sheet.Range["D_IO_Term"].Value2));

                //Amortization Term
                if (sheet.Range["D289"].Value2 != null)
                    m61params.Add("AmortizationTerm", Convert.ToInt32(sheet.Range["D289"].Value2));

                //InitialFunding - D_8.02
                if (sheet.Range["D_8.02"].Value2 != null)
                    m61params.Add("InitialFunding", Convert.ToDecimal(sheet.Range["D_8.02"].Value2));
                //FutureFunding - D_8.02
                if (sheet.Range["D_8.03"].Value2 != null)
                    m61params.Add("FutureFunding", Convert.ToDecimal(sheet.Range["D_8.03"].Value2));
            }
            catch(System.Runtime.InteropServices.COMException e)
            {
                Status += "\nGetParameters: " + e.Message;
            }
            return m61params;
        }

    }

}
