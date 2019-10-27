using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenerator
{
    class PSA
    {
        public static string GenerateLandingZone()
        { 
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.ATTRIBUTE select p).ToList();

            List<string> lstTables = (from p in lstMetas select p.TABLE_NAME).ToList();

            StringBuilder sb = new StringBuilder();

            //Table
            foreach (var itemTable in lstTables.Distinct())
            {
                sb.AppendLine("CREATE TABLE [dbo].["+ itemTable+"]");
                sb.AppendLine("(");

                //Fields
                var lstColumns = (from p in lstMetas where p.TABLE_NAME == itemTable where p.PK==1 || p.BK==1 || p.DI==1 select p).ToList();

                int n = lstColumns.Count;
                int pt = 0;

                foreach (var itemColumn in lstColumns)
                {
                    pt++;

                    if (pt < n)
                    {
                        sb.AppendLine(FieldGenerate(itemColumn.COLUMN_NAME, itemColumn.DATA_TYPE, itemColumn.CHARACTER_MAXIMUM_LENGTH, itemColumn.NUMERIC_PRECISION, itemColumn.NUMERIC_SCALE)+",");
                    }
                    else
                    {
                        sb.AppendLine(FieldGenerate(itemColumn.COLUMN_NAME, itemColumn.DATA_TYPE, itemColumn.CHARACTER_MAXIMUM_LENGTH, itemColumn.NUMERIC_PRECISION, itemColumn.NUMERIC_SCALE));
                    }
                }

                sb.AppendLine(")");
            }

            result = sb.ToString();

            return result;
        }

        public static string GenerateSTG()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.ATTRIBUTE select p).ToList();

            List<string> lstTables = (from p in lstMetas select p.TABLE_NAME).ToList();

            StringBuilder sb = new StringBuilder();

            //Table
            foreach (var itemTable in lstTables.Distinct())
            {
                sb.AppendLine("CREATE TABLE [dbo].[" + itemTable + "_STG]");
                sb.AppendLine("(");

                //Fields
                var lstColumns = (from p in lstMetas where p.TABLE_NAME == itemTable where p.PK == 1 || p.BK == 1 || p.DI == 1 select p).ToList();

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine(FieldGenerate(itemColumn.COLUMN_NAME, itemColumn.DATA_TYPE, itemColumn.CHARACTER_MAXIMUM_LENGTH, itemColumn.NUMERIC_PRECISION, itemColumn.NUMERIC_SCALE) + ",");
                }

                sb.AppendLine("\t[HD] [char] (32),");
                sb.AppendLine("\t[INSERT TIME] [datetime] NULL");

                sb.AppendLine(")");
            }

            result = sb.ToString();

            return result;
        }

        public static string GenerateHIS()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.ATTRIBUTE select p).ToList();

            List<string> lstTables = (from p in lstMetas select p.TABLE_NAME).ToList();

            StringBuilder sb = new StringBuilder();

            //Table
            foreach (var itemTable in lstTables.Distinct())
            {
                sb.AppendLine("CREATE TABLE [dbo].[" + itemTable + "_STG]");
                sb.AppendLine("(");

                //Fields
                var lstColumns = (from p in lstMetas where p.TABLE_NAME == itemTable where p.PK == 1 || p.BK == 1 || p.DI == 1 select p).ToList();

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine(FieldGenerate(itemColumn.COLUMN_NAME, itemColumn.DATA_TYPE, itemColumn.CHARACTER_MAXIMUM_LENGTH, itemColumn.NUMERIC_PRECISION, itemColumn.NUMERIC_SCALE) + ",");
                }

                sb.AppendLine("\t[HD] [char] (32),");
                sb.AppendLine("\t[INSERT TIME] [datetime] NULL,");
                sb.AppendLine("\t[VALID FROM] [datetime] NULL,");
                sb.AppendLine("\t[VALID TO] [datetime] NULL,");
                sb.AppendLine("\t[IS CURRENT] [int] NULL");

                sb.AppendLine(")");
            }

            result = sb.ToString();

            return result;
        }

        public static string GenerateUSPSTG()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.ATTRIBUTE select p).ToList();

            List<string> lstTables = (from p in lstMetas select p.TABLE_NAME).ToList();

            StringBuilder sb = new StringBuilder();

            //Table
            foreach (var itemTable in lstTables.Distinct())
            {

                sb.AppendLine("USE [STAGE]");
                sb.AppendLine("CREATE PROCEDURE [STAGE].[dbo].[USP_"+itemTable+"_STG]");
                sb.AppendLine("AS");
                sb.AppendLine("\tBEGIN");
                sb.AppendLine("\tTRUNCATE TABLE [STAGE].[dbo].[" + itemTable+"_STG];");
                sb.AppendLine("");
                sb.AppendLine("\tINSERT INTO [STAGE].[dbo].[" + itemTable+"_STG]");
                sb.AppendLine("\tSELECT");

                //Fields
                var lstColumns = (from p in lstMetas where p.TABLE_NAME == itemTable where p.PK == 1 || p.BK == 1 || p.DI == 1 select p).ToList();

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine("\t\t" + itemColumn.COLUMN_NAME + ",");
                }


                sb.AppendLine("\t\tCONVERT(");
                sb.AppendLine("\t\tCHAR(32),");
                sb.AppendLine("\t\tHASHBYTES(");
                sb.AppendLine("\t\t'MD5',");

                int n = lstColumns.Count;
                int pt = 0;

                foreach (var itemColumn in lstColumns)
                {
                    pt++;

                    if (pt < n)
                    {
                        sb.AppendLine("\t\t\tISNULL(TRIM(CONVERT(NVARCHAR(255), [" + itemColumn.COLUMN_NAME+"])), N'') + N'W|D'");
                    }
                    else
                    {
                        sb.AppendLine("\t\t\t+ ISNULL(TRIM(CONVERT(NVARCHAR(255), [" + itemColumn.COLUMN_NAME+"])), N'') + N'W|D'");
                    }
                }

                sb.AppendLine("\t\t),");
                sb.AppendLine("\t\t2");
                sb.AppendLine("\t\t) AS HD,");
                sb.AppendLine("\t\tGETDATE() AS [INSERT TIME]");
                sb.AppendLine("\tFROM [STAGE].[dbo].[" + itemTable+"];");
                sb.AppendLine("");
                sb.AppendLine("END;");
            }

            result = sb.ToString();

            return result;
        }

        public static string GenerateUSPHIS()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.ATTRIBUTE select p).ToList();

            List<string> lstTables = (from p in lstMetas select p.TABLE_NAME).ToList();

            StringBuilder sb = new StringBuilder();

            string PK = "";

            //Table
            foreach (var itemTable in lstTables.Distinct())
            {
                PK = (from p in dc.ATTRIBUTE where p.TABLE_NAME == itemTable select p.COLUMN_NAME).ToList()[0];

                sb.AppendLine("USE [STAGE]");
                sb.AppendLine("CREATE PROCEDURE [STAGE].[dbo].[USP_" + itemTable + "_HIS]");
                sb.AppendLine("AS");
                sb.AppendLine("BEGIN");

                sb.AppendLine("\tDECLARE @VALIDFROM AS DATETIME;");
                sb.AppendLine("\tDECLARE @VALIDTO AS DATETIME;");
                sb.AppendLine("\tDECLARE @DEFAULTVALIDTO AS DATETIME;");
                sb.AppendLine("");
                sb.AppendLine("\tSET @VALIDFROM = GETDATE();");
                sb.AppendLine("\tSET @VALIDTO = GETDATE();");
                sb.AppendLine("\tSET @DEFAULTVALIDTO = '2199-12-31';");
                sb.AppendLine("");
                sb.AppendLine("\tINSERT INTO [dbo].[" + itemTable+"_HIS]");
                sb.AppendLine("\tSELECT");

                //Fields
                var lstColumns = (from p in lstMetas where p.TABLE_NAME == itemTable where p.PK == 1 || p.BK == 1 || p.DI == 1 select p).ToList();

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine("\t\t" + itemColumn.COLUMN_NAME + ",");
                }

                sb.AppendLine("\t\t[HD],");
                sb.AppendLine("\t\t[INSERT TIME],");
                sb.AppendLine("\t\t[VALID FROM],");
                sb.AppendLine("\t\t[VALID TO],");
                sb.AppendLine("\t\t[IS CURRENT]");
                sb.AppendLine("\tFROM");
                sb.AppendLine("\t(");
                sb.AppendLine("\tMERGE [dbo].[" + itemTable + "_HIS] AS TARGET");
                sb.AppendLine("\tUSING [dbo].[" + itemTable + "_STG] AS SOURCE");
                sb.AppendLine("\t\tON TARGET." + PK + " = SOURCE." + PK + "");

                sb.AppendLine("\tWHEN MATCHED AND SOURCE.HD <> TARGET.HD THEN");
                sb.AppendLine("\t--Existing data, UPDATE BRANCH, update old data, then using OUTPUT to insert new data.");
                sb.AppendLine("\t\tUPDATE SET TARGET.[VALID TO] = @VALIDTO,");
                sb.AppendLine("\t\tTARGET.[IS CURRENT] = 0");
                sb.AppendLine("\t\t--New data, INSERT BRANCH");
                sb.AppendLine("\tWHEN NOT MATCHED BY TARGET THEN");
                sb.AppendLine("\t\tINSERT");
                sb.AppendLine("\t\t(");

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine("\t\t\t" + itemColumn.COLUMN_NAME + ",");
                }

                sb.AppendLine("\t\t\t[HD],");
                sb.AppendLine("\t\t\t[INSERT TIME],");
                sb.AppendLine("\t\t\t[VALID FROM],");
                sb.AppendLine("\t\t\t[VALID TO],");
                sb.AppendLine("\t\t\t[IS CURRENT]");
                sb.AppendLine("\t\t)");
                sb.AppendLine("\t\tVALUES");

                sb.AppendLine("\t\t(");

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine("\t\t\tSOURCE." + itemColumn.COLUMN_NAME + ",");
                }

                sb.AppendLine("\t\t\tSOURCE.HD,");
                sb.AppendLine("\t\t\tGETDATE(),");
                sb.AppendLine("\t\t\t@VALIDFROM,");
                sb.AppendLine("\t\t\t@VALIDTO,");
                sb.AppendLine("\t\t\t@DEFAULTVALIDTO,");
                sb.AppendLine("\t\t\t1");
                sb.AppendLine("\t\t)");

                sb.AppendLine("\t--Data deleted by source, DELETE BRANCH, update old data");
                sb.AppendLine("\tWHEN NOT MATCHED BY SOURCE THEN");
                sb.AppendLine("\t\tUPDATE SET TARGET.[VALID TO] = @VALIDTO,");
                sb.AppendLine("\t\tTARGET.[IS CURRENT] = 0");
                sb.AppendLine("\tOUTPUT $action AS MERGE_ACTION,");

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine("\t\tSOURCE." + itemColumn.COLUMN_NAME + ",");
                }

                sb.AppendLine("\t\tSOURCE.[HD],");
                sb.AppendLine("\t\tSOURCE.[INSERT TIME],");
                sb.AppendLine("\t\t@VALIDFROM AS [VALID FROM],");
                sb.AppendLine("\t\t@DEFAULTVALIDTO AS [VALID TO],");
                sb.AppendLine("\t\t1 AS [IS CURRENT]");
                sb.AppendLine("\t) MERGE_OUTPUT");
                sb.AppendLine("\tWHERE MERGE_OUTPUT.MERGE_ACTION = 'UPDATE';");
                sb.AppendLine("");
                sb.AppendLine("\tEND;");
                sb.AppendLine("GO");


            }

            result = sb.ToString();

            return result;
        }


        public static string FieldGenerate(string FieldName, string FieldType, int? CharLen, int? nPrecision, int? nScale)
        {
            string result="";

            //[ID] [int] NULL,
            result = "\t[" + FieldName + "] " + FieldType+ "";
            if (FieldType.ToUpper() == "NVARCHAR")
            {
                result += "("+CharLen.ToString()+")";
            }
            if (FieldType.ToUpper() == "DECIMAL")
            {
                result += "(" + nPrecision.ToString() + "," + nScale.ToString() + ")";
            }

            result += " NULL";

            return result;
        }
    }
}
