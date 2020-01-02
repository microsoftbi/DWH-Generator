using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Generator
{
    public class PSA_TYPE2
    {
        //public static string GenerateTableSTG()
        //{
        //    string result = "";

        //    DataClassesDataContext dc = new DataClassesDataContext();

        //    var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

        //    var lstTables = (from p in lstMetas select new { p.TABLE_NAME, p.RECORDSOURCE }).ToList();

        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine("USE "+Common.GetPSADatabaseName());
        //    sb.AppendLine("GO");
        //    sb.AppendLine();

        //    //Table
        //    foreach (var itemTable in lstTables.Distinct())
        //    {
        //        sb.AppendLine("CREATE TABLE [" + itemTable.RECORDSOURCE + "].[" + itemTable.TABLE_NAME + "_STG]");
        //        sb.AppendLine("(");

        //        sb.AppendLine("\t[LOAD_DTS] [DATETIMEOFFSET](7) NOT NULL,");
        //        sb.AppendLine("\t[SEQUENCE_NO] [bigint] NULL,");
        //        sb.AppendLine("\t[SESSION_DTS] [datetimeoffset](7) NOT NULL,");
        //        sb.AppendLine("\t[Fully_Qualified_File_Name] [varchar](256) NOT NULL,");
        //        sb.AppendLine("\t[FILE_TRANSFER_DTS] [datetimeoffset](7) NOT NULL,");
        //        sb.AppendLine("\t[REC_SRC] [varchar](20) NULL,");


        //        //Fields
        //        var lstColumns = (from p in lstMetas where p.TABLE_NAME == itemTable.TABLE_NAME where p.PK == true || p.BK == true || p.DI == true select p).ToList();

        //        int n = lstColumns.Count;
        //        int pt = 0;

        //        foreach (var itemColumn in lstColumns)
        //        {
        //            pt++;

        //            if (pt < n)
        //            {
        //                sb.AppendLine(Common.FieldGenerate(itemColumn.COLUMN_NAME, itemColumn.DATA_TYPE, itemColumn.CHARACTER_MAXIMUM_LENGTH, itemColumn.NUMERIC_PRECISION, itemColumn.NUMERIC_SCALE) + ",");
        //            }
        //            else
        //            {
        //                sb.AppendLine(Common.FieldGenerate(itemColumn.COLUMN_NAME, itemColumn.DATA_TYPE, itemColumn.CHARACTER_MAXIMUM_LENGTH, itemColumn.NUMERIC_PRECISION, itemColumn.NUMERIC_SCALE));
        //            }
        //        }

        //        sb.AppendLine(")");
        //        sb.AppendLine("");
        //        sb.AppendLine("");
        //    }

        //    result = sb.ToString();

        //    return result;
        //}

        public static Metadata MetaAttribute { get; set; }

        public static void LoadMetaAttribute()
        {
            DataClassesDataContext dc = new DataClassesDataContext();

            string strHASHDUMMY = Common.GetHASHDUMMY();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            var lstTables = (from p in lstMetas select new { p.TABLE_NAME, p.RECORDSOURCE }).ToList();

            MetaAttribute = new Metadata();

            MetaAttribute.PSADatabaseName = Common.GetPSADatabaseName();
            MetaAttribute.HashTail = Common.GetHASHDUMMY();

            //Tables
            foreach (var itemTable in lstTables.Distinct())
            {
                MetaTable mtObj = new MetaTable();
                mtObj.PK = (from p in dc.V_ATTRIBUTE where p.TABLE_NAME == itemTable.TABLE_NAME && p.PK == true 
                            select new Field() { FieldName = p.COLUMN_NAME, FieldType = Common.FieldTypeGenerate(p.DATA_TYPE, p.CHARACTER_MAXIMUM_LENGTH, p.NUMERIC_PRECISION, p.NUMERIC_SCALE) }).ToList();
                mtObj.DI = (from p in dc.V_ATTRIBUTE where p.TABLE_NAME == itemTable.TABLE_NAME && p.DI == true
                            select new Field() { FieldName = p.COLUMN_NAME, FieldType = Common.FieldTypeGenerate(p.DATA_TYPE, p.CHARACTER_MAXIMUM_LENGTH, p.NUMERIC_PRECISION, p.NUMERIC_SCALE) }).ToList();
                mtObj.ObjectName = itemTable.TABLE_NAME;
                mtObj.SchemaName = itemTable.RECORDSOURCE;
                mtObj.RecordSource = itemTable.RECORDSOURCE;

                MetaAttribute.MTA.Add(mtObj);
            }
        }

        public static string GenerateTableCDC()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/PSAT2/CDC.handlebar"));

            result = template(MetaAttribute);

            return result;
        }

        public static string GenerateTableLOG()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/PSAT2/LOG.handlebar"));

            result = template(MetaAttribute);

            return result;
        }

        public static string GenerateVIEWMTA()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/PSAT2/MTA.handlebar"));

            result = template(MetaAttribute);

            return result;
        }

        public static string GenerateVIEWCURRENT()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/PSAT2/LOGCURRENT.handlebar"));

            result = template(MetaAttribute);

            return result;
        }

        public static string GenerateUSPLOG()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/PSAT2/USPLOG.handlebar"));

            result = template(MetaAttribute);

            return result;
        }

        //public static string GenerateUSPSTG()
        //{
        //    string result = "";

        //    DataClassesDataContext dc = new DataClassesDataContext();

        //    var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

        //    var lstTables = (from p in lstMetas select new { p.TABLE_NAME, p.RECORDSOURCE }).ToList();

        //    StringBuilder sb = new StringBuilder();

        //    string strDVDBName = Common.GetDVDatabaseName();
        //    string strPSADBName = Common.GetPSADatabaseName();

        //    sb.AppendLine("USE " + Common.GetPSADatabaseName());
        //    sb.AppendLine("GO");
        //    sb.AppendLine();

        //    string PK = "";

        //    //Table
        //    foreach (var itemTable in lstTables.Distinct())
        //    {
        //        PK = (from p in dc.V_ATTRIBUTE where p.TABLE_NAME == itemTable.TABLE_NAME && p.PK == true select p.COLUMN_NAME).ToList()[0];


        //        sb.AppendLine("CREATE PROCEDURE [" + itemTable.RECORDSOURCE + "].[USP_" + itemTable.TABLE_NAME + "_STG]");
        //        sb.AppendLine("AS");
        //        sb.AppendLine("\tBEGIN");


        //        //Fields
        //        var lstColumns = (from metas in lstMetas where metas.TABLE_NAME == itemTable.TABLE_NAME where metas.PK == true || metas.BK == true || metas.DI == true select metas).ToList();
        //        int n = lstColumns.Count;
        //        int pt = 0;

        //        sb.AppendLine("\tDECLARE @LOGSOURCE AS NVARCHAR(100);");
        //        sb.AppendLine("\tSET @LOGSOURCE = N'[" + strPSADBName + "].[" + itemTable.RECORDSOURCE + "].[USP_" + itemTable.TABLE_NAME + "_STG]';");
        //        sb.AppendLine("\t");
        //        sb.AppendLine("\tEXEC META.dbo.USP_WRITELOG N'Start to load [" + strPSADBName + "].[" + itemTable.RECORDSOURCE + "].[" + itemTable.TABLE_NAME + "_STG]', @LOGSOURCE, N'N';");
        //        sb.AppendLine("\t");
        //        sb.AppendLine("\tTRUNCATE TABLE [" + itemTable.RECORDSOURCE + "].[" + itemTable.TABLE_NAME + "_STG];");
        //        sb.AppendLine("\t");
        //        sb.AppendLine("\tBEGIN TRY");
        //        sb.AppendLine("\t\tBEGIN TRAN;");
        //        sb.AppendLine("\t");
        //        sb.AppendLine("\t\t\tINSERT INTO [" + itemTable.RECORDSOURCE + "].[" + itemTable.TABLE_NAME + "_STG]");
        //        sb.AppendLine("\t\t\t(");

        //        foreach (var itemColumn in lstColumns)
        //        {
        //            sb.AppendLine("\t\t\t\t[" + itemColumn.COLUMN_NAME + "],");
        //        }

        //        sb.AppendLine("\t\t\t\t[FULLY_QUALIFIED_FILE_NAME],");
        //        sb.AppendLine("\t\t\t\t[FILE_TRANSFER_DTS],");
        //        sb.AppendLine("\t\t\t\t[LOAD_DTS],");
        //        sb.AppendLine("\t\t\t\t[REC_SRC],");
        //        sb.AppendLine("\t\t\t\t[SEQUENCE_NO],");
        //        sb.AppendLine("\t\t\t\t[SESSION_DTS]");

        //        sb.AppendLine("\t\t\t)");
        //        sb.AppendLine("\t\t\tSELECT");


        //        //DI fields
        //        foreach (var itemColumn in lstColumns)
        //        {
        //            sb.AppendLine("\t\t\t\t[" + itemColumn.COLUMN_NAME + "],");
        //        }

        //        sb.AppendLine("\t\t\t\t[FULLY_QUALIFIED_FILE_NAME],");
        //        sb.AppendLine("\t\t\t\t[FILE_TRANSFER_DTS],");
        //        sb.AppendLine("\t\t\t\t[LOAD_DTS],");
        //        sb.AppendLine("\t\t\t\t[REC_SRC],");
        //        sb.AppendLine("\t\t\t\tROW_NUMBER() OVER (ORDER BY [" + PK + "]) AS [SEQUENCE_NO],");
        //        sb.AppendLine("\t\t\t\tSYSDATETIMEOFFSET() AS [SESSION_DTS]");


        //        sb.AppendLine("\t\t\tFROM [" + itemTable.RECORDSOURCE + "].[" + itemTable.TABLE_NAME + "]");
                
        //        sb.AppendLine("\t\t\t");
        //        sb.AppendLine("\t\t\tEXEC META.dbo.USP_WRITELOG N'Finish to load [" + strPSADBName + "].[" + itemTable.RECORDSOURCE + "].[" + itemTable.TABLE_NAME + "_STG]', @LOGSOURCE, N'N';");
        //        sb.AppendLine("\t\t\t");
        //        sb.AppendLine("\t\tCOMMIT TRAN;");
        //        sb.AppendLine("\tEND TRY");
        //        sb.AppendLine("\tBEGIN CATCH");
        //        sb.AppendLine("\t");
        //        sb.AppendLine("\t\tDECLARE @ERROR_MESSAGE AS NVARCHAR(4000);");
        //        sb.AppendLine("\t\tSET @ERROR_MESSAGE = N'Failed to load [" + strPSADBName + "].[" + itemTable.RECORDSOURCE + "].[" + itemTable.TABLE_NAME + "_STG]' + ISNULL(ERROR_MESSAGE(), '');");
        //        sb.AppendLine("\t\tEXEC META.dbo.USP_WRITELOG @ERROR_MESSAGE, @LOGSOURCE, N'E';");
        //        sb.AppendLine("\tEND CATCH");
        //        sb.AppendLine("\tEND;");
        //        sb.AppendLine("\tGO");
        //        sb.AppendLine("");
        //        sb.AppendLine("");
        //        sb.AppendLine("");
        //    }

        //    result = sb.ToString();

        //    return result;
        //}

        public static string GenerateUSPCDC()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/PSAT2/USPCDC.handlebar"));

            result = template(MetaAttribute);

            return result;
        }

        public static string GenerateExecuteFlow()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            var lstTables = (from p in lstMetas select new { p.TABLE_NAME, p.RECORDSOURCE }).ToList();

            StringBuilder sb = new StringBuilder();

            string strPSADBName= Common.GetPSADatabaseName();

            sb.AppendLine("USE " + strPSADBName);
            sb.AppendLine("GO");
            sb.AppendLine();

            //Table
            foreach (var itemTable in lstTables.Distinct())
            {
                //sb.AppendLine("EXEC [" + strPSADBName + "].[" + itemTable.RECORDSOURCE + "].[USP_" + itemTable.TABLE_NAME + "_STG]");
                sb.AppendLine("EXEC [" + strPSADBName + "].[" + itemTable.RECORDSOURCE + "].[USP_" + itemTable.TABLE_NAME + "_CDC]");
                sb.AppendLine("EXEC [" + strPSADBName + "].[" + itemTable.RECORDSOURCE + "].[USP_" + itemTable.TABLE_NAME + "_LOG]");
                sb.AppendLine("");
            }

            result = sb.ToString();

            return result;
        }
    }
}
