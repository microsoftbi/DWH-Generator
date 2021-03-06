﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    /// <summary>
    /// This code is my first version of the generator, and it is exired now, the code is not deleted, just for a memory.
    /// At the beginning I write it jusing juse string appendline.
    /// Then I learnt how to use handler with meta data behind.
    /// </summary>
    public class PSA_TYPE1
    {
        public static string GenerateLandingZone()
        { 
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            var lstTables = (from p in lstMetas select new { p.TABLE_NAME, p.RECORDSOURCE}).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("USE " + Common.GetPSADatabaseName());
            sb.AppendLine("GO;");
            sb.AppendLine();

            //Table
            foreach (var itemTable in lstTables.Distinct())
            {
                sb.AppendLine("CREATE TABLE [" + itemTable.RECORDSOURCE + "].[" + itemTable.TABLE_NAME + "]");
                sb.AppendLine("(");

                //Fields
                var lstColumns = (from p in lstMetas where p.TABLE_NAME == itemTable.TABLE_NAME where p.PK==true || p.BK== true || p.DI== true select p).ToList();

                int n = lstColumns.Count;
                int pt = 0;

                foreach (var itemColumn in lstColumns)
                {
                    pt++;

                    if (pt < n)
                    {
                        sb.AppendLine(Common.FieldGenerate(itemColumn.COLUMN_NAME, itemColumn.DATA_TYPE, itemColumn.CHARACTER_MAXIMUM_LENGTH, itemColumn.NUMERIC_PRECISION, itemColumn.NUMERIC_SCALE)+",");
                    }
                    else
                    {
                        sb.AppendLine(Common.FieldGenerate(itemColumn.COLUMN_NAME, itemColumn.DATA_TYPE, itemColumn.CHARACTER_MAXIMUM_LENGTH, itemColumn.NUMERIC_PRECISION, itemColumn.NUMERIC_SCALE));
                    }
                }

                sb.AppendLine(")");
                sb.AppendLine("");
                sb.AppendLine("");
            }

            result = sb.ToString();

            return result;
        }

        public static string GenerateSTG()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            var lstTables = (from p in lstMetas select new { p.TABLE_NAME, p.RECORDSOURCE }).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("USE " + Common.GetPSADatabaseName());
            sb.AppendLine("GO;");
            sb.AppendLine();

            //Table
            foreach (var itemTable in lstTables.Distinct())
            {
                sb.AppendLine("CREATE TABLE ["+itemTable.RECORDSOURCE+"].[" + itemTable.TABLE_NAME + "_STG]");
                sb.AppendLine("(");

                //Fields
                var lstColumns = (from p in lstMetas where p.TABLE_NAME == itemTable.TABLE_NAME where p.PK == true || p.BK == true || p.DI == true select p).ToList();

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine(Common.FieldGenerate(itemColumn.COLUMN_NAME, itemColumn.DATA_TYPE, itemColumn.CHARACTER_MAXIMUM_LENGTH, itemColumn.NUMERIC_PRECISION, itemColumn.NUMERIC_SCALE) + ",");
                }

                sb.AppendLine("\t[HD] [char] (32),");
                sb.AppendLine("\t[INSERT TIME] [datetime] NULL");

                sb.AppendLine(")");
                sb.AppendLine("");
                sb.AppendLine("");
            }

            result = sb.ToString();

            return result;
        }

        public static string GenerateHIS()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            var lstTables = (from p in lstMetas select new { p.TABLE_NAME, p.RECORDSOURCE }).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("USE " + Common.GetPSADatabaseName());
            sb.AppendLine("GO;");
            sb.AppendLine();

            //Table
            foreach (var itemTable in lstTables.Distinct())
            {
                sb.AppendLine("CREATE TABLE ["+itemTable.RECORDSOURCE+"].[" + itemTable.TABLE_NAME + "_HIS]");
                sb.AppendLine("(");

                //Fields
                var lstColumns = (from p in lstMetas where p.TABLE_NAME == itemTable.TABLE_NAME where p.PK == true || p.BK == true || p.DI == true select p).ToList();

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine(Common.FieldGenerate(itemColumn.COLUMN_NAME, itemColumn.DATA_TYPE, itemColumn.CHARACTER_MAXIMUM_LENGTH, itemColumn.NUMERIC_PRECISION, itemColumn.NUMERIC_SCALE) + ",");
                }

                sb.AppendLine("\t[HD] [char] (32),");
                sb.AppendLine("\t[INSERT TIME] [datetime] NULL,");
                sb.AppendLine("\t[VALID FROM] [datetime] NULL,");
                sb.AppendLine("\t[VALID TO] [datetime] NULL,");
                sb.AppendLine("\t[IS CURRENT] [int] NULL");

                sb.AppendLine(")");
                sb.AppendLine("");
                sb.AppendLine("");
            }

            result = sb.ToString();

            return result;
        }

        public static string GenerateUSPSTG()
        {
            string result = "";

            string strHASHDUMMY = Common.GetHASHDUMMY();

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            var lstTables = (from p in lstMetas select new { p.TABLE_NAME, p.RECORDSOURCE }).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("USE " + Common.GetPSADatabaseName());
            sb.AppendLine("GO;");
            sb.AppendLine();

            //Table
            foreach (var itemTable in lstTables.Distinct())
            {
                sb.AppendLine("CREATE PROCEDURE ["+itemTable.RECORDSOURCE+"].[USP_"+itemTable.TABLE_NAME+"_STG]");
                sb.AppendLine("AS");
                sb.AppendLine("\tBEGIN");
                sb.AppendLine("\tDECLARE @LOGSOURCE AS NVARCHAR(100);");
                sb.AppendLine("\tSET @LOGSOURCE = N'STAGE.dbo.USP_" + itemTable.TABLE_NAME + "_HIS';");
                sb.AppendLine("\tEXEC META.dbo.USP_WRITELOG N'Start to load " + itemTable.TABLE_NAME + "_HIS', @LOGSOURCE, N'N';");
                sb.AppendLine("");
                sb.AppendLine("\tBEGIN TRY");
                sb.AppendLine("\t\tBEGIN TRAN;");
                sb.AppendLine("\t\t\tTRUNCATE TABLE [STAGE].[dbo].[" + itemTable.TABLE_NAME + "_STG];");
                sb.AppendLine("");
                sb.AppendLine("\t\t\tINSERT INTO [STAGE].[dbo].[" + itemTable.TABLE_NAME + "_STG]");
                sb.AppendLine("\t\t\tSELECT");

                //Fields
                var lstColumns = (from p in lstMetas where p.TABLE_NAME == itemTable.TABLE_NAME where p.PK == true || p.BK == true || p.DI == true select p).ToList();

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine("\t\t\t\t[" + itemColumn.COLUMN_NAME + "],");
                }


                sb.AppendLine("\t\t\t\tCONVERT(");
                sb.AppendLine("\t\t\t\tCHAR(32),");
                sb.AppendLine("\t\t\t\tHASHBYTES(");
                sb.AppendLine("\t\t\t\t'MD5',");

                int n = lstColumns.Count;
                int pt = 0;

                foreach (var itemColumn in lstColumns)
                {
                    pt++;

                    if (itemColumn.PK == true) continue;


                    if (pt == 1)
                    {
                        sb.AppendLine("\t\t\t\t\tISNULL(TRIM(CONVERT(NVARCHAR(255), [" + itemColumn.COLUMN_NAME+"])), N'') + N'"+ strHASHDUMMY + "'");
                    }
                    else
                    {
                        sb.AppendLine("\t\t\t\t\t+ ISNULL(TRIM(CONVERT(NVARCHAR(255), [" + itemColumn.COLUMN_NAME+"])), N'') + N'"+ strHASHDUMMY + "'");
                    }
                }

                sb.AppendLine("\t\t\t\t),");
                sb.AppendLine("\t\t\t\t2");
                sb.AppendLine("\t\t\t\t) AS HD,");
                sb.AppendLine("\t\t\t\tGETDATE() AS [INSERT TIME]");
                sb.AppendLine("\t\t\tFROM [STAGE].[dbo].[" + itemTable.TABLE_NAME + "];");
                sb.AppendLine("\t\tCOMMIT TRAN;");
                sb.AppendLine("\tEND TRY");

                sb.AppendLine("\tBEGIN CATCH");
                sb.AppendLine("\t\tROLLBACK TRAN;");
                sb.AppendLine("\t\tDECLARE @ERROR_MESSAGE AS NVARCHAR(4000);");
                sb.AppendLine("\t\tSET @ERROR_MESSAGE = N'Failed to load " + itemTable.TABLE_NAME + "_HIS' + ISNULL(ERROR_MESSAGE(), '');");
                sb.AppendLine("\t\tEXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';");
                sb.AppendLine("\tEND CATCH");
                sb.AppendLine("");
                sb.AppendLine("END;");
                sb.AppendLine("GO");
                sb.AppendLine("");
                sb.AppendLine("");
            }

            result = sb.ToString();

            return result;
        }

        public static string GenerateUSPHIS()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            var lstTables = (from p in lstMetas select new { p.TABLE_NAME, p.RECORDSOURCE }).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("USE " + Common.GetPSADatabaseName());
            sb.AppendLine("GO;");
            sb.AppendLine();

            string PK = "";

            //Table
            foreach (var itemTable in lstTables.Distinct())
            {
                PK = (from p in dc.V_ATTRIBUTE where p.TABLE_NAME == itemTable.TABLE_NAME && p.PK == true select p.COLUMN_NAME).ToList()[0];

                sb.AppendLine("CREATE PROCEDURE ["+itemTable.RECORDSOURCE+"].[USP_" + itemTable.TABLE_NAME + "_HIS]");
                sb.AppendLine("AS");
                sb.AppendLine("BEGIN");

                sb.AppendLine("\tDECLARE @VALIDFROM AS DATETIME;");
                sb.AppendLine("\tDECLARE @VALIDTO AS DATETIME;");
                sb.AppendLine("\tDECLARE @DEFAULTVALIDTO AS DATETIME;");
                //sb.AppendLine("\tDECLARE @DEFAULTVALIDTO AS DATETIME;");
                sb.AppendLine("\tDECLARE @LOGSOURCE AS NVARCHAR(100);");
                sb.AppendLine("\tSET @VALIDFROM = GETDATE();");
                sb.AppendLine("\tSET @VALIDTO = GETDATE();");
                sb.AppendLine("\tSET @DEFAULTVALIDTO = '2199-12-31';");
                sb.AppendLine("\tSET @LOGSOURCE = N'STAGE.dbo.USP_"+itemTable.TABLE_NAME + "_HIS';");
                sb.AppendLine("");
                sb.AppendLine("\tEXEC META.dbo.USP_WRITELOG N'Start to load "+itemTable.TABLE_NAME + "_HIS', @LOGSOURCE, N'N';");
                sb.AppendLine("");
                sb.AppendLine("\tBEGIN TRY");
                sb.AppendLine("\t\tBEGIN TRAN;");
                sb.AppendLine("\t\t\tINSERT INTO [dbo].[" + itemTable.TABLE_NAME + "_HIS]");
                sb.AppendLine("\t\t\tSELECT");

                //Fields
                var lstColumns = (from p in lstMetas where p.TABLE_NAME == itemTable.TABLE_NAME where p.PK == true || p.BK == true || p.DI == true  select p).ToList();

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine("\t\t\t\t[" + itemColumn.COLUMN_NAME + "],");
                }

                sb.AppendLine("\t\t\t\t[HD],");
                sb.AppendLine("\t\t\t\t[INSERT TIME],");
                sb.AppendLine("\t\t\t\t[VALID FROM],");
                sb.AppendLine("\t\t\t\t[VALID TO],");
                sb.AppendLine("\t\t\t\t[IS CURRENT]");
                sb.AppendLine("\t\t\tFROM");
                sb.AppendLine("\t\t\t(");
                sb.AppendLine("\t\t\t\tMERGE [dbo].[" + itemTable.TABLE_NAME + "_HIS] AS TARGET");
                sb.AppendLine("\t\t\t\tUSING [dbo].[" + itemTable.TABLE_NAME + "_STG] AS SOURCE");
                sb.AppendLine("\t\t\t\t\tON TARGET." + PK + " = SOURCE." + PK + "");

                sb.AppendLine("\t\t\t\tWHEN MATCHED AND SOURCE.HD <> TARGET.HD THEN");
                sb.AppendLine("\t\t\t\t--Existing data, UPDATE BRANCH, update old data, then using OUTPUT to insert new data.");
                sb.AppendLine("\t\t\t\t\tUPDATE SET TARGET.[VALID TO] = @VALIDTO,");
                sb.AppendLine("\t\t\t\t\tTARGET.[IS CURRENT] = 0");
                sb.AppendLine("\t\t\t\t\t--New data, INSERT BRANCH");
                sb.AppendLine("\t\t\t\tWHEN NOT MATCHED BY TARGET THEN");
                sb.AppendLine("\t\t\t\t\tINSERT");
                sb.AppendLine("\t\t\t\t\t(");

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine("\t\t\t\t\t\t[" + itemColumn.COLUMN_NAME + "],");
                }

                sb.AppendLine("\t\t\t\t\t\t[HD],");
                sb.AppendLine("\t\t\t\t\t\t[INSERT TIME],");
                sb.AppendLine("\t\t\t\t\t\t[VALID FROM],");
                sb.AppendLine("\t\t\t\t\t\t[VALID TO],");
                sb.AppendLine("\t\t\t\t\t\t[IS CURRENT]");
                sb.AppendLine("\t\t\t\t\t)");
                sb.AppendLine("\t\t\t\t\tVALUES");

                sb.AppendLine("\t\t\t\t\t(");

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine("\t\t\t\t\t\tSOURCE.[" + itemColumn.COLUMN_NAME + "],");
                }

                sb.AppendLine("\t\t\t\t\t\tSOURCE.HD,");
                sb.AppendLine("\t\t\t\t\t\tGETDATE(),");
                sb.AppendLine("\t\t\t\t\t\t@VALIDFROM,");
                //sb.AppendLine("\t\t\t\t\t\t@VALIDTO,");
                sb.AppendLine("\t\t\t\t\t\t@DEFAULTVALIDTO,");
                sb.AppendLine("\t\t\t\t\t\t1");
                sb.AppendLine("\t\t\t\t\t)");

                sb.AppendLine("\t\t\t\t--Data deleted by source, DELETE BRANCH, update old data");
                sb.AppendLine("\t\t\t\tWHEN NOT MATCHED BY SOURCE THEN");
                sb.AppendLine("\t\t\t\t\tUPDATE SET TARGET.[VALID TO] = @VALIDTO,");
                sb.AppendLine("\t\t\t\t\tTARGET.[IS CURRENT] = 0");
                sb.AppendLine("\t\t\t\tOUTPUT $action AS MERGE_ACTION,");

                foreach (var itemColumn in lstColumns)
                {
                    sb.AppendLine("\t\t\t\t\tSOURCE.[" + itemColumn.COLUMN_NAME + "],");
                }

                sb.AppendLine("\t\t\t\t\tSOURCE.[HD],");
                sb.AppendLine("\t\t\t\t\tSOURCE.[INSERT TIME],");
                sb.AppendLine("\t\t\t\t\t@VALIDFROM AS [VALID FROM],");
                sb.AppendLine("\t\t\t\t\t@DEFAULTVALIDTO AS [VALID TO],");
                sb.AppendLine("\t\t\t\t\t1 AS [IS CURRENT]");
                sb.AppendLine("\t\t\t\t) MERGE_OUTPUT");
                sb.AppendLine("\t\t\tWHERE MERGE_OUTPUT.MERGE_ACTION = 'UPDATE';");
                sb.AppendLine("");
                sb.AppendLine("\t\tEXEC META.dbo.USP_WRITELOG N'Finish to load " + itemTable.TABLE_NAME + "_HIS', @LOGSOURCE, N'N';");
                sb.AppendLine("\t\tCOMMIT TRAN;");
                sb.AppendLine("\tEND TRY");

                sb.AppendLine("\tBEGIN CATCH");
                sb.AppendLine("\t\tROLLBACK TRAN;");
                sb.AppendLine("\t\tDECLARE @ERROR_MESSAGE AS NVARCHAR(4000);");
                sb.AppendLine("\t\tSET @ERROR_MESSAGE = N'Failed to load "+itemTable.TABLE_NAME + "_HIS' + ISNULL(ERROR_MESSAGE(), '');");
                sb.AppendLine("\t\tEXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';");
                sb.AppendLine("\tEND CATCH");

                sb.AppendLine("\tEND;");
                sb.AppendLine("GO");
                sb.AppendLine("");
                sb.AppendLine("");
            }

            result = sb.ToString();

            return result;
        }

        
    }
}
