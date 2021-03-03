using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Drawing;
using System.Net;
using Newtonsoft.Json.Linq;

using System.ComponentModel;
using System.Threading;

namespace WinTestCF
{
    class JSONUtils
    {

        #region Properties

        public static DataTable JSONM61DataDict
        {
            get;
            set;
        }

        public static string JSONM61CFInputs
        {
            get;
            set;
        }

        public static DataTable JSONM61Lookup
        {
            get;
            set;
        }

        public static DataTable JSONM61CFOutput
        {
            get;
            set;
        }

        public static DataSet M61CFOutput = new DataSet();

        public static string JSONM61BatchUpdate
        {
            get;
            set;
        }

        #endregion


        public static void InitAndAddCFParametersToJSON(IDictionary<string, object> Params)
        {
            JSONUtils.JSONM61CFInputs = string.Empty;
            JSONM61CFInputs = "{";
            foreach (string Param in Params.Keys)
            {
                JSONM61CFInputs += "\"" + Param.ToString() + "\": " + "\"" + Params[Param].ToString() + "\",";
            }
        }

        public static void SerielizeDataTableToJSON(DataTable table)
        {
            JSONM61CFInputs += "\"" + table.TableName + "\": ";
            JSONM61CFInputs += JsonConvert.SerializeObject(table, Formatting.Indented);
        }

        public static void CompleteJSON()
        {
            JSONUtils.JSONM61CFInputs += "}";
        }

        public static void WriteJsonToFile(string FullFilePath = @"C:\temp\Deal.json")
        {
            if (FullFilePath == "")
                FullFilePath = @"C:\temp\M61CFRequest.json";

            FileInfo fi = new FileInfo(FullFilePath);

            if (!Directory.Exists(fi.DirectoryName))
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }

            File.WriteAllText(FullFilePath, JSONUtils.JSONM61CFInputs);
        }



    }
}