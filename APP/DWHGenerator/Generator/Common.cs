using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Generator
{
    class Common
    {
        public static string FieldTypeGenerate(string FieldType, int? CharLen, int? nPrecision, int? nScale)
        {
            string result = "";

            result = FieldType.ToUpper();

            switch (FieldType.ToUpper())
            {
                case "NVARCHAR":
                    result += "(" + CharLen.ToString() + ")";
                    break;
                case "CHAR":
                    result += "(" + CharLen.ToString() + ")";
                    break;
                case "NCHAR":
                    result += "(" + CharLen.ToString() + ")";
                    break;
                case "VARCHAR":
                    result += "(" + CharLen.ToString() + ")";
                    break;
                case "DECIMAL":
                    result += "(" + nPrecision.ToString() + "," + nScale.ToString() + ")";
                    break;
            }

            return result;
        }
        
        
        /// <summary>
        /// Generate filed expr script accouding to type defination information.(Information schema)
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="FieldType"></param>
        /// <param name="CharLen"></param>
        /// <param name="nPrecision"></param>
        /// <param name="nScale"></param>
        /// <returns></returns>
        public static string FieldGenerate(string FieldName, string FieldType, int? CharLen, int? nPrecision, int? nScale)
        {
            string result = "";

            result = "\t[" + FieldName + "] " + FieldType + "";
            switch (FieldType.ToUpper())
            {
                case "NVARCHAR":
                    result += "(" + CharLen.ToString() + ")";
                    break;
                case "CHAR":
                    result += "(" + CharLen.ToString() + ")";
                    break;
                case "NCHAR":
                    result += "(" + CharLen.ToString() + ")";
                    break;
                case "VARCHAR":
                    result += "(" + CharLen.ToString() + ")";
                    break;
                case "DECIMAL":
                    result += "(" + nPrecision.ToString() + "," + nScale.ToString() + ")";
                    break;
            }

            result += " NULL";

            return result;
        }

        /// <summary>
        /// Data type convert in MTA view.
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="FieldType"></param>
        /// <param name="CharLen"></param>
        /// <param name="nPrecision"></param>
        /// <param name="nScale"></param>
        /// <param name="LFieldType"></param>
        /// <param name="LCharLen"></param>
        /// <param name="LnPrecision"></param>
        /// <param name="LnScale"></param>
        /// <returns></returns>
        /// public static string FieldConvert(string FieldName, string FieldType, int? CharLen, int? nPrecision, int? nScale, string LFieldType, int? LCharLen, int? LnPrecision, int? LnScale)
        public static string FieldConvert(string FieldName, string FieldType, int? CharLen, int? nPrecision, int? nScale)
        {
            string result = "";

            switch (FieldType.ToUpper())
            {
                case "INT":
                    result += "CONVERT(INT, CONVERT(NVARCHAR(30), [" + FieldName + "])) AS [" + FieldName + "]";
                    break;
                case "BIGINT":
                    result += "CONVERT(BIGINT, CONVERT(NVARCHAR(30), [" + FieldName + "])) AS [" + FieldName + "]";
                    break;
                case "TINYINT":
                    result += "CONVERT(TINYINT, CONVERT(NVARCHAR(30), [" + FieldName + "])) AS [" + FieldName + "]";
                    break;
                case "CHAR":
                    result += "CONVERT(CHAR(" + CharLen.ToString() + "), [" + FieldName + "]) AS [" + FieldName + "]";
                    break;
                case "NCHAR":
                    result += "CONVERT(NCHAR(" + CharLen.ToString() + "), [" + FieldName + "]) AS [" + FieldName + "]";
                    break;
                case "VARCHAR":
                    result += "CONVERT(VARCHAR(" + CharLen.ToString() + "), [" + FieldName + "]) AS [" + FieldName + "]";
                    break;
                case "NVARCHAR":
                    result += "CONVERT(NVARCHAR(" + CharLen.ToString() + "), [" + FieldName + "]) AS [" + FieldName + "]";
                    break;
                case "DECIMAL":
                    result += "CONVERT(DECIMAL(" + nPrecision.ToString() + "," + nScale.ToString() + "), CONVERT(NVARCHAR(20), [" + FieldName + "])) AS [" + FieldName + "]";
                    break;
                case "DATE":
                    result += "CONVERT(DATE, CONVERT(NVARCHAR(20), [" + FieldName + "])) AS [" + FieldName + "]";
                    break;
                case "DATETIME":
                    result += "CONVERT(DATETIME, CONVERT(NVARCHAR(30), [" + FieldName + "])) AS [" + FieldName + "]";
                    break;
                case "DATETIMEOFFSET":
                    result += "CONVERT(DATETIMEOFFSET, CONVERT(NVARCHAR(30), [" + FieldName + "])) AS [" + FieldName + "]";
                    break;//datetimeoffset
            }

            return result;
        }

        /// <summary>
        /// Get PSA database name
        /// </summary>
        /// <returns></returns>
        public static string GetPSADatabaseName()
        {
            string result="";

            DataClassesDataContext dc = new DataClassesDataContext();

            result = (from p in dc.Layers where p.LayerName == "PSA" select p.DatabaseName).First();

            return result;
        }

        /// <summary>
        /// Get Data Vault database name
        /// </summary>
        /// <returns></returns>
        public static string GetDVDatabaseName()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            result = (from p in dc.Layers where p.LayerName == "DV" select p.DatabaseName).First();

            return result;
        }

        /// <summary>
        /// Get HASH DUMMY
        /// </summary>
        /// <returns></returns>
        public static string GetHASHDUMMY()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            result = (from p in dc.CONFIGURATION where p.ConfigName == "HASHDUMMY" select p.ConfigValue).First();

            return result;
        }

        public static int ExecuteNonQueryWithGo(string strSQL)
        {
            int result = 0;
            string[] arr = System.Text.RegularExpressions.Regex.Split(strSQL, "GO");
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Generator.Properties.Settings.METAConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < arr.Length; n++)
                    {
                        string strsql = arr[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            result = cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    //return -1;
                    throw new Exception(E.Message);
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            return result;
        }
    }
}
