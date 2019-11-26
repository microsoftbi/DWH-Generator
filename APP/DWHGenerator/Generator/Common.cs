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

            //result = "\t[" + FieldName + "] " + FieldType + "";
            //if (FieldType.ToUpper() == "NVARCHAR")
            //{
            //    result += "(" + CharLen.ToString() + ")";
            //}
            //if (FieldType.ToUpper() == "DECIMAL")
            //{
            //    result += "(" + nPrecision.ToString() + "," + nScale.ToString() + ")";
            //}

            result += " NULL";

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
