using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
//using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace FSCJobNumbers
{
    class FSCYN
    {
        static private System.Data.DataTable dt = null;
        static public string ParseColumnValues(Worksheet ws, out string sColumnHeader)
        {
            string sValues = "";
            Range rngUsed = ws.UsedRange;
            Range rng = rngUsed.get_Range((object)rngUsed.Cells[1, 1], (object)rngUsed.Cells[1, 1]);
            sColumnHeader = rng.Cells.Text.ToString();

            for (int i = 2; i <= rngUsed.Rows.Count; i++)
            {
                rng = rngUsed.get_Range((object)rngUsed.Cells[i, 1], (object)rngUsed.Cells[i, 1]);

                if (!String.IsNullOrEmpty(rng.Cells.Text.ToString()) && rng.Cells.Text.ToString() != "" && rng.Cells.Text.ToString().Length > 0)
                    sValues = sValues + rng.Cells.Text.ToString() + ",";
            }
            
            if (sValues.Length > 1)
                sValues = sValues.Substring(0, (sValues.Length - 1));

            return sValues;
        }

        static public string GetQuery(string sQueryType, string sInStatement, string sDatabase)
        {
            string sQuery = "";

            if (sQueryType == "JOB")
            {
                //sQuery = "SELECT '' AS \"Record\", e.\"JOB NUMBER\", e.\"FSC YN\" " +
                sQuery = "SELECT * " +
                    "FROM "  + sDatabase + "..ESTIMATE e " +
                    "WHERE e.\"JOB NUMBER\" IN ( " + sInStatement + ") " +
                    //"AND e.\"FSC YN\" = 'N' " +
                    "ORDER BY e.\"JOB NUMBER\"";
            }
            else if (sQueryType == "PO")
            {
                //sQuery = "SELECT '' AS \"Record\", olin.\"ORDER NO\", olin.\"FSC YN\" " +
                sQuery = "SELECT * " +
                    "FROM " + sDatabase + "..ORDERLIN olin " +
                    "WHERE olin.\"ORDER NO\" IN  " +
                    "( " + sInStatement + ") ";
                    //"ORDER BY olin.\"ORDER NO\"";
                    //"JOIN "  + sDatabase + "..ORDERINF oinf ON oinf.\"DATAFLEX RECNUM ONE\" = olin.\"ORDERINF RECNUM\" " +
                    //"WHERE olin.\"ORDER NO\" IN  " +
                    //    "( " + sInStatement + ") ";
                    //"AND olin.\"FSC YN\" = 'N' " +
                    
            }

            return sQuery;
        }

        //static public string GetUpdateQuery(string sQueryType, string sInStatement, string sDatabase)
        //{
        //    string sQuery = "";

        //    if (sQueryType == "JOB")
        //    {
        //        sQuery = string.Format("UPDATE {0}..ESTIMATE SET \"FSC YN\"='Y' WHERE \"FSC YN\"='N' AND \"JOB NUMBER\" IN ({1})", sDatabase, sInStatement);
        //        //sQuery = "UPDATE " + sDatabase + "..ESTIMATE " +
        //        //    "SET \"FSC YN\"='Y' " +
        //        //    "WHERE \"FSC YN\"='N' " +
        //        //    "AND \"JOB NUMBER\" IN ( " + sInStatement + ")";
        //    }
        //    else if (sQueryType == "PO")
        //    {
        //        sQuery = string.Format("UPDATE {0}..ORDERLIN SET \"FSC YN\"='Y' WHERE \"FSC YN\"='N' AND \"ORDER NO\" IN ({1})", sDatabase, sInStatement);
        //        //sQuery = "UPDATE " + sDatabase + "..ORDERLIN " +
        //        //  "SET \"FSC YN\"='Y' " +
        //        //  "WHERE \"FSC YN\"='N' " +
        //        //  "AND \"ORDER NO\" IN ( " + sInStatement + ")";
        //    }

        //    return sQuery;
        //}

        static public int UpdateFSCYNValue(string sUpdateType, string sInStatement, string sDatabase)
        {
            //string sQuery = GetUpdateQuery(sUpdateType, sInStatement, sDatabase);
            string sQuery = GetQuery(sUpdateType, sInStatement, sDatabase);
            string sConnection = "Server=SGMISSQL;DataBase=" + sDatabase + "; Integrated Security=SSPI";
            int iUpdatedRows = 0;
            int i = 0;
            while (i < dt.Rows.Count) {
                string check = (string)dt.Rows[i]["FSC YN"];
                if(check.Equals("N") || check.Equals("n"))
                    dt.Rows[i]["FSC YN"] = "Y";
                i++;
            }
            try
            {   
                //System.Data.DataTable temp = new System.Data.DataTable;
                SqlConnection connection = new SqlConnection(sConnection);
                //SqlCommand cmd = new SqlCommand(sQuery, connection);
                SqlDataAdapter da = new SqlDataAdapter(sQuery, connection);
                SqlCommandBuilder builder= new SqlCommandBuilder(da);
                //if(sUpdateType == "JOB")
                //    temp = dt;
                //else

                connection.Open();
                iUpdatedRows = da.Update(dt);
                connection.Close();
            }
            catch(Exception ex)
            {
                string sEx = ex.ToString();
                MessageBox.Show(sEx, "File Open Error", MessageBoxButtons.OK);
            }

            return iUpdatedRows;
        }

        static public System.Data.DataTable GetDataTable(string sQueryType, string sInStatement, string sDatabase)
        {
            //Create DataTable and Connection Strings
            dt = new System.Data.DataTable();
            string sQuery = GetQuery(sQueryType, sInStatement, sDatabase);
            string sConnection = "Server=SGMISSQL;DataBase=" + sDatabase + "; Integrated Security=SSPI";

            //create the connections
            SqlConnection connection = new SqlConnection(sConnection);
            SqlCommand cmd = new SqlCommand(sQuery, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //open the connection and fill the datatable
            connection.Open();
            da.Fill(dt);
            da.Dispose();
            cmd.Dispose();
            connection.Dispose();
            connection.Close();
           
            return dt;
        }

        static public Workbook GetExcelWorkbook(string sFilePath)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            Workbook wb = null;

            if (File.Exists(sFilePath))
            {
                app.Workbooks.Open(sFilePath, (object)0, (object)true, (object)5, (object)"", (object)"", (object)true, System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false, 0, true, 1, 1);
                wb = (Workbook)app.Workbooks.Application.ActiveWorkbook;
            }

            return wb;
        }

        static public void reset(){
            if(dt!=null)
                dt.Dispose();
            dt = null;
        }

        static public string[] GetSheetNames(Workbook wb)
        {
            string[] sSheets = null;
            sSheets = new string[wb.Worksheets.Count];

            for (int i = 0; i < wb.Worksheets.Count; i++)
            {
                Worksheet ws = (Worksheet)wb.Worksheets[i + 1];
                sSheets[i] = ws.Name;
            }

            return sSheets;
        }
    }
}
