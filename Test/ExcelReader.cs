using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Office;
using Microsoft.Office.Interop.Excel;

namespace Test
{

    class ExcelReader
    {

        #region Properties
        Microsoft.Office.Interop.Excel.Application _excelApp;
        #endregion

        public ExcelReader()
        {
            //_excelApp = new Microsoft.Office.Interop.Excel.Application();
        }

        public System.Data.DataTable ReadExcel(string filepath, string fileext)
        {
            System.Data.DataTable dtFunding = new System.Data.DataTable();
            ExcelOpenSpreadsheets(filepath);
            return dtFunding;
        }

        /// <summary>
        /// Open the file path received in Excel. Then, open the workbook
        /// within the file. Send the workbook to the next function, the internal scan
        /// function. Will throw an exception if a file cannot be found or opened.
        /// </summary>
        public void ExcelOpenSpreadsheets(string thisFileName)
        {
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


                ExcelScanInternal(workBook);

                //
                // Clean up.
                //
                workBook.Close(false, thisFileName, null);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
            }
            catch
            {
                //
                // Deal with exceptions.
                //
            }
        }

        /// <summary>
        /// Scan the selected Excel workbook and store the information in the cells
        /// for this workbook in an object[,] array. Then, call another method
        /// to process the data.
        /// </summary>
        private void ExcelScanInternal(Workbook workBookIn)
        {
            //
            // Get sheet Count and store the number of sheets.
            //
            int numSheets = workBookIn.Sheets.Count;
            //Inputs - schedule
            Worksheet sheet = (Worksheet)workBookIn.Sheets["Inputs - schedule"];
            if(sheet != null)
            {
                Microsoft.Office.Interop.Excel.Range excelRange = sheet.Range["A9:O154"];
                object[,] valueArray = (object[,])excelRange.get_Value(
                    XlRangeValueDataType.xlRangeValueDefault);

            }

        }

    }

}
