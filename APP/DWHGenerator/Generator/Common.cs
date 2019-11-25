using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            //[ID] [int] NULL,
            result = "\t[" + FieldName + "] " + FieldType + "";
            if (FieldType.ToUpper() == "NVARCHAR")
            {
                result += "(" + CharLen.ToString() + ")";
            }
            if (FieldType.ToUpper() == "DECIMAL")
            {
                result += "(" + nPrecision.ToString() + "," + nScale.ToString() + ")";
            }

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
    }
}
