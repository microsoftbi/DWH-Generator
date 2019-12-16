using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    public static class DATAVAULT
    {
        public static string GenerateTableSAT()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            List<string> lstDVTables = (from p in lstMetas where string.IsNullOrEmpty(p.DV_SAT_TABLENAME)==false select p.DV_SAT_TABLENAME).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("USE " + Common.GetDVDatabaseName());
            sb.AppendLine("GO");
            sb.AppendLine();

            //Table
            foreach (string itemTable in lstDVTables.Distinct())
            {
                sb.AppendLine("CREATE TABLE [dbo].[" + itemTable + "]");
                sb.AppendLine("(");

                sb.AppendLine("\t[HK] [CHAR](32) NOT NULL,");
                sb.AppendLine("\t[LOAD_DTS] [DATETIMEOFFSET](7) NOT NULL,");
                sb.AppendLine("\t[LOAD_END_DTS] [DATETIMEOFFSET](7) NULL,");
                sb.AppendLine("\t[REC_SRC] [NVARCHAR](20) NOT NULL,");
                sb.AppendLine("\t[HASH_DIFF] [CHAR](32) NOT NULL,");
                sb.AppendLine("\t[CDC_OPERATION_CODE] [CHAR](1) NOT NULL,");




                //Fields
                var lstColumns = (from p in lstMetas where p.DV_SAT_TABLENAME == itemTable && string.IsNullOrEmpty(p.DV_SAT_TABLENAME) == false select p).ToList();

                int n = lstColumns.Count;
                int pt = 0;

                foreach (var itemColumn in lstColumns)
                {
                    pt++;

                    if (pt < n)
                    {
                        sb.AppendLine(Common.FieldGenerate(itemColumn.COLUMN_NAME, itemColumn.DATA_TYPE, itemColumn.CHARACTER_MAXIMUM_LENGTH, itemColumn.NUMERIC_PRECISION, itemColumn.NUMERIC_SCALE) + ",");
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

        public static string GenerateUSPSAT()
        {
            string result = "";


            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            var lstDVTables = (from p in lstMetas where string.IsNullOrEmpty(p.DV_SAT_TABLENAME) == false select new { p.DV_SAT_TABLENAME, p.TABLE_NAME, p.RECORDSOURCE }).ToList();

            StringBuilder sb = new StringBuilder();

            string strDVDBName = Common.GetDVDatabaseName();
            string strPSADBName = Common.GetPSADatabaseName();

            sb.AppendLine("USE " + strDVDBName);
            sb.AppendLine("GO");
            sb.AppendLine();

            string PK = "";

            //Table
            foreach (var itemTable in lstDVTables.Distinct())
            {
                PK = (from p in dc.V_ATTRIBUTE where p.DV_SAT_TABLENAME == itemTable.DV_SAT_TABLENAME && p.PK == true select p.COLUMN_NAME).ToList()[0];

                //Fields
                var lstColumns = (from p in lstMetas where p.DV_SAT_TABLENAME == itemTable.DV_SAT_TABLENAME && string.IsNullOrEmpty(p.DV_SAT_TABLENAME) == false select p).ToList();

                int n = lstColumns.Count;
                int pt = 0;

                sb.AppendLine("CREATE PROCEDURE [DBO].[USP_" + itemTable.DV_SAT_TABLENAME + "]");
                sb.AppendLine("AS");
                sb.AppendLine("BEGIN");
                sb.AppendLine("\tDECLARE @LOGSOURCE AS NVARCHAR(100);");
                sb.AppendLine("\tSET @LOGSOURCE = N'STAGE.dbo.USP_" + itemTable.DV_SAT_TABLENAME + "';");
                sb.AppendLine("");
                sb.AppendLine("\tEXEC META.dbo.USP_WRITELOG N'Start to load ["+strDVDBName+"].[DBO].["+itemTable.DV_SAT_TABLENAME + "]', @LOGSOURCE, N'N';");
                sb.AppendLine("");
                sb.AppendLine("\tBEGIN TRY");
                sb.AppendLine("\t\tBEGIN TRAN;");
                sb.AppendLine("");
                sb.AppendLine("\t\t\tINSERT INTO ["+strDVDBName+"].[dbo].["+itemTable.DV_SAT_TABLENAME + "]");
                sb.AppendLine("\t\t\t(");
                sb.AppendLine("\t\t\t\t[HK],");
                sb.AppendLine("\t\t\t\t[LOAD_DTS],");
                sb.AppendLine("\t\t\t\t[LOAD_END_DTS],");
                sb.AppendLine("\t\t\t\t[REC_SRC],");
                sb.AppendLine("\t\t\t\t[HASH_DIFF],");
                sb.AppendLine("\t\t\t\t[CDC_OPERATION_CODE],");

                //DI fields
                pt = 0;
                foreach (var itemColumn in lstColumns)
                {
                    pt++;
                    if (pt < n)
                        sb.AppendLine("\t\t\t\t[" + itemColumn.COLUMN_NAME + "],");
                    else
                        sb.AppendLine("\t\t\t\t[" + itemColumn.COLUMN_NAME + "]");
                }


                sb.AppendLine("\t\t\t)");
                sb.AppendLine("\t\t\tSELECT [HK],");
                sb.AppendLine("\t\t\t\t[LOAD_DTS],");
                sb.AppendLine("\t\t\t\t[LOAD_END_DTS],");
                sb.AppendLine("\t\t\t\t[REC_SRC],");
                sb.AppendLine("\t\t\t\t[HASH_DIFF],");
                sb.AppendLine("\t\t\t\t[CDC_OPERATION_CODE],");


                //DI fields
                pt = 0;
                foreach (var itemColumn in lstColumns)
                {
                    pt++;
                    if (pt < n)
                        sb.AppendLine("\t\t\t\t[" + itemColumn.COLUMN_NAME + "],");
                    else
                        sb.AppendLine("\t\t\t\t[" + itemColumn.COLUMN_NAME + "]");
                }

                sb.AppendLine("\t\t\tFROM");
                sb.AppendLine("\t\t\t(");
                sb.AppendLine("\t\t\t\tSELECT [HK],");
                sb.AppendLine("\t\t\t\t\t[LOAD_DTS_BATCH] AS [LOAD_DTS],");
                sb.AppendLine("\t\t\t\t\tCAST('9999-12-31' AS DATETIMEOFFSET) AS [LOAD_END_DTS],");
                sb.AppendLine("\t\t\t\t\t[RECORD_SOURCE] AS [REC_SRC],");
                sb.AppendLine("\t\t\t\t\t[HD] AS [HASH_DIFF],");
                sb.AppendLine("\t\t\t\t\t[CDC_OPERATION_CODE],");


                //DI fields
                pt = 0;
                foreach (var itemColumn in lstColumns)
                {
                    pt++;
                    sb.AppendLine("\t\t\t\t\t[" + itemColumn.COLUMN_NAME + "],");
                }


                sb.AppendLine("\t\t\t\t\tROW_NUMBER() OVER (PARTITION BY HD ORDER BY [LOAD_DTS_BATCH] DESC) AS RN");
                sb.AppendLine("\t\t\t\tFROM ["+strPSADBName+"].["+itemTable.RECORDSOURCE+"].["+itemTable.TABLE_NAME+"_LOG]");
                sb.AppendLine("\t\t\t) AS t");
                sb.AppendLine("\t\t\tWHERE t.RN = 1");
                sb.AppendLine("\t\t\t\tAND t.[HASH_DIFF] NOT IN");
                sb.AppendLine("\t\t\t\t(");
                sb.AppendLine("\t\t\t\t\t    SELECT [HASH_DIFF] FROM ["+strDVDBName+"].[dbo].["+itemTable.DV_SAT_TABLENAME + "]");
                sb.AppendLine("\t\t\t\t);");
                sb.AppendLine("");
                sb.AppendLine("\t\t\tEXEC META.dbo.USP_WRITELOG N'Finish to load [" + strDVDBName + "].[DBO].[" + itemTable.DV_SAT_TABLENAME + "]', @LOGSOURCE, N'N';");
                sb.AppendLine("");
                sb.AppendLine("\t\tCOMMIT TRAN;");
                sb.AppendLine("\tEND TRY");
                sb.AppendLine("\tBEGIN CATCH");
                sb.AppendLine("\t\tDECLARE @ERROR_MESSAGE AS NVARCHAR(4000);");
                sb.AppendLine("\t\tSET @ERROR_MESSAGE = N'Failed to load [" + strDVDBName + "].[DBO].[" + itemTable.DV_SAT_TABLENAME + "]' + ISNULL(ERROR_MESSAGE(), '');");
                sb.AppendLine("\t\tEXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';");
                sb.AppendLine("\tEND CATCH");
                sb.AppendLine("");
                sb.AppendLine("END;");
                sb.AppendLine("");
                sb.AppendLine("GO");


                sb.AppendLine("");
                sb.AppendLine("");
            }

            result = sb.ToString();


            return result;
        }

        public static string GenerateTableHUB()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            var lstDVTables = (from p in lstMetas where string.IsNullOrEmpty(p.DV_HUB_TABLENAME) == false select new { p.DV_HUB_TABLENAME, p.TABLE_NAME, p.RECORDSOURCE,p.DV_HUB_BK }).ToList();

            StringBuilder sb = new StringBuilder();

            string strDVDBName = Common.GetDVDatabaseName();
            string strPSADBName = Common.GetPSADatabaseName();

            sb.AppendLine("USE " + strDVDBName);
            sb.AppendLine("GO");
            sb.AppendLine();

            string PK = "";

            //Table
            foreach (var itemTable in lstDVTables.Distinct())
            {
                PK = (from p in dc.V_ATTRIBUTE where p.DV_HUB_TABLENAME == itemTable.DV_HUB_TABLENAME && p.PK == true select p.COLUMN_NAME).ToList()[0];

                sb.AppendLine("CREATE TABLE [dbo].["+itemTable.DV_HUB_TABLENAME+"]");
                sb.AppendLine("(");
                sb.AppendLine("\t[HK] [CHAR](32) NOT NULL,");
                sb.AppendLine("\t[" + itemTable.DV_HUB_BK + "] [NVARCHAR](50) NOT NULL,");
                sb.AppendLine("\t[LOAD_DTS] [DATETIME] NOT NULL,");
                sb.AppendLine("\t[REC_SRC] [NVARCHAR](50) NOT NULL,");
                sb.AppendLine(")");
                sb.AppendLine("GO");

            }

            result = sb.ToString();

            return result;
        }

        public static string GenerateUSPHUB()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            var lstDVTables = (from p in lstMetas where string.IsNullOrEmpty(p.DV_HUB_TABLENAME) == false select new { p.DV_HUB_TABLENAME, p.TABLE_NAME, p.RECORDSOURCE, p.DV_HUB_BK }).ToList();

            StringBuilder sb = new StringBuilder();

            string strDVDBName = Common.GetDVDatabaseName();
            string strPSADBName = Common.GetPSADatabaseName();

            sb.AppendLine("USE " + strDVDBName);
            sb.AppendLine("GO");
            sb.AppendLine();

            string PK = "";

            //Table
            foreach (var itemTable in lstDVTables.Distinct())
            {
                PK = (from p in dc.V_ATTRIBUTE where p.DV_HUB_TABLENAME == itemTable.DV_HUB_TABLENAME && p.PK == true select p.COLUMN_NAME).ToList()[0];

                //Fields
                var lstColumns = (from p in lstMetas where p.DV_SAT_TABLENAME == itemTable.DV_HUB_TABLENAME && string.IsNullOrEmpty(p.DV_SAT_TABLENAME) == false select p).ToList();

                int n = lstColumns.Count;
                int pt = 0;

                sb.AppendLine("CREATE PROCEDURE [DBO].[USP_" + itemTable.DV_HUB_TABLENAME + "]");
                sb.AppendLine("AS");
                sb.AppendLine("BEGIN");
                sb.AppendLine("\tDECLARE @LOGSOURCE AS NVARCHAR(100);");
                sb.AppendLine("\tSET @LOGSOURCE = N'STAGE.dbo.USP_" + itemTable.DV_HUB_TABLENAME + "';");
                sb.AppendLine("");
                sb.AppendLine("\tEXEC META.dbo.USP_WRITELOG N'Start to load [" + strDVDBName + "].[DBO].[" + itemTable.DV_HUB_TABLENAME + "]', @LOGSOURCE, N'N';");
                sb.AppendLine("");
                sb.AppendLine("\tBEGIN TRY");
                sb.AppendLine("\t\tBEGIN TRAN;");
                sb.AppendLine("");
                sb.AppendLine("\t\t\tINSERT INTO [" + strDVDBName + "].[dbo].[" + itemTable.DV_HUB_TABLENAME + "]");

                sb.AppendLine("\t\t\t\tSELECT ");
                sb.AppendLine("\t\t\t\t[HK]");
                sb.AppendLine("\t\t\t\t,[" + PK + "]");
                sb.AppendLine("\t\t\t\t,GETDATE() AS LOAD_DTS");
                sb.AppendLine("\t\t\t\t,'" + itemTable.RECORDSOURCE + "' AS RECORDSOURCE");
                sb.AppendLine("\t\t\tFROM [" + strPSADBName + "].[" + itemTable.RECORDSOURCE + "].[" + itemTable.TABLE_NAME + "_LOG] STG");
                sb.AppendLine("\t\t\tWHERE NOT EXISTS (");

                sb.AppendLine("\t\t\t\tSELECT HK FROM "+strDVDBName+".dbo."+itemTable.DV_HUB_TABLENAME+" HUB WHERE HUB.HK=STG.HK");
                sb.AppendLine("\t\t\t)");
                sb.AppendLine("");
                sb.AppendLine("\t\t\tEXEC META.dbo.USP_WRITELOG N'Finish to load [" + strDVDBName + "].[DBO].[" + itemTable.DV_HUB_TABLENAME + "]', @LOGSOURCE, N'N';");

                sb.AppendLine("");
                sb.AppendLine("\t\tCOMMIT TRAN;");
                sb.AppendLine("\tEND TRY");
                sb.AppendLine("\tBEGIN CATCH");
                sb.AppendLine("\t\tDECLARE @ERROR_MESSAGE AS NVARCHAR(4000);");
                sb.AppendLine("\t\tSET @ERROR_MESSAGE = N'Failed to load [" + strDVDBName + "].[DBO].[" + itemTable.DV_HUB_TABLENAME + "]' + ISNULL(ERROR_MESSAGE(), '');");
                sb.AppendLine("\t\tEXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';");
                sb.AppendLine("\tEND CATCH");
                sb.AppendLine("");
                sb.AppendLine("END;");
                sb.AppendLine("");
                sb.AppendLine("GO");

                sb.AppendLine("");
                sb.AppendLine("");
            }

            result = sb.ToString();

            return result;
        }

    }
}
