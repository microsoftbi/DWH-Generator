using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Generator
{
    public static class DATAVAULT
    {
        public static Metadata MetaAttribute { get; set; }

        public static void LoadMetaAttribute()
        {
            DataClassesDataContext dc = new DataClassesDataContext();

            string strHASHDUMMY = Common.GetHASHDUMMY();

            var lstMetas = (from p in dc.V_ATTRIBUTE select p).ToList();

            //DV LINK tables
            var lstDVLINKTables = (from p in lstMetas where string.IsNullOrEmpty(p.DV_LINK_TABLENAME)==false select new { p.DV_LINK_TABLENAME, p.RECORDSOURCE, p.TABLE_NAME }).ToList();
            //DV HUB tables
            var lstDVHUBTables = (from p in lstMetas where string.IsNullOrEmpty(p.DV_HUB_TABLENAME) == false select new { p.DV_HUB_TABLENAME, p.RECORDSOURCE, p.TABLE_NAME }).ToList();
            //DV SAT tables
            var lstDVSATTables = (from p in lstMetas where string.IsNullOrEmpty(p.DV_SAT_TABLENAME) == false select new { p.DV_SAT_TABLENAME, p.RECORDSOURCE, p.TABLE_NAME }).ToList();

            MetaAttribute = new Metadata();

            MetaAttribute.PSADatabaseName = Common.GetPSADatabaseName();
            MetaAttribute.COREDatabaseName = Common.GetDVDatabaseName();

            MetaAttribute.HashTail = Common.GetHASHDUMMY();

            //LINK Tables
            foreach (var itemTable in lstDVLINKTables.Distinct())
            {
                DVMetaTable mtObj = new DVMetaTable();
                mtObj.FK = (from p in dc.V_ATTRIBUTE
                            where p.DV_LINK_TABLENAME == itemTable.DV_LINK_TABLENAME && p.FK == true
                            select new DVField() { FieldName = p.COLUMN_NAME, FieldType = Common.FieldTypeGenerate(p.DATA_TYPE, p.CHARACTER_MAXIMUM_LENGTH, p.NUMERIC_PRECISION, p.NUMERIC_SCALE) }).ToList();

                mtObj.RecordSource = itemTable.RECORDSOURCE;
                mtObj.PSASchemaName = itemTable.RECORDSOURCE;
                mtObj.TableName = itemTable.DV_LINK_TABLENAME;
                mtObj.PSATableName = itemTable.TABLE_NAME;

                MetaAttribute.DVLINKMTA.Add(mtObj);
            }

            //HUB Tables
            foreach (var itemTable in lstDVHUBTables.Distinct())
            {
                DVMetaTable mtObj = new DVMetaTable();
                mtObj.PK = (from p in dc.V_ATTRIBUTE
                            where p.DV_HUB_TABLENAME == itemTable.DV_HUB_TABLENAME && p.PK == true
                            select new DVField() { PSAFieldName=p.COLUMN_NAME, FieldName = p.DV_COLUMN_NAME??p.COLUMN_NAME, FieldType = Common.FieldTypeGenerate(p.DATA_TYPE, p.CHARACTER_MAXIMUM_LENGTH, p.NUMERIC_PRECISION, p.NUMERIC_SCALE) }).ToList();
                mtObj.RecordSource = itemTable.RECORDSOURCE;
                mtObj.PSASchemaName = itemTable.RECORDSOURCE;
                mtObj.TableName = itemTable.DV_HUB_TABLENAME;
                mtObj.PSATableName = itemTable.TABLE_NAME;

                MetaAttribute.DVHUBMTA.Add(mtObj);
            }

            //SAT Tables
            foreach (var itemTable in lstDVSATTables.Distinct())
            {
                DVMetaTable mtObj = new DVMetaTable();
                mtObj.PK = (from p in dc.V_ATTRIBUTE
                            where p.DV_SAT_TABLENAME == itemTable.DV_SAT_TABLENAME && p.PK == true
                            select new DVField() { FieldName = p.COLUMN_NAME, FieldType = Common.FieldTypeGenerate(p.DATA_TYPE, p.CHARACTER_MAXIMUM_LENGTH, p.NUMERIC_PRECISION, p.NUMERIC_SCALE) }).ToList();
                mtObj.DI = (from p in dc.V_ATTRIBUTE
                            where p.DV_SAT_TABLENAME == itemTable.DV_SAT_TABLENAME && p.DI == true
                            select new DVField() { FieldName = p.COLUMN_NAME, FieldType = Common.FieldTypeGenerate(p.DATA_TYPE, p.CHARACTER_MAXIMUM_LENGTH, p.NUMERIC_PRECISION, p.NUMERIC_SCALE) }).ToList();

                mtObj.RecordSource = itemTable.RECORDSOURCE;
                mtObj.PSASchemaName = itemTable.RECORDSOURCE;
                mtObj.TableName = itemTable.DV_SAT_TABLENAME;
                mtObj.PSATableName = itemTable.TABLE_NAME;

                MetaAttribute.DVSATMTA.Add(mtObj);
            }


        }

        public static string GenerateUSPSAT()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/DV/DV_USPSAT.handlebars"));

            result = template(MetaAttribute);

            return result;
        }

        public static string GenerateUSPLINK()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/DV/DV_USPLINK.handlebars"));

            result = template(MetaAttribute);

            return result;
        }

        public static string GenerateUSPHUB()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/DV/DV_USPHUB.handlebars"));

            result = template(MetaAttribute);

            return result;
        }


        public static string GenerateTableSAT()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/DV/DV_SAT.handlebars"));

            result = template(MetaAttribute);

            return result;
        }

        public static string GenerateTableHUB()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/DV/DV_HUB.handlebars"));

            result = template(MetaAttribute);

            return result;
        }

        public static string GenerateTableLINK()
        {
            string result = "";

            var template = Handlebars.Compile(File.ReadAllText(@"LoadPatterns/DV/DV_LINK.handlebars"));

            result = template(MetaAttribute);

            return result;
        }


    }
}
