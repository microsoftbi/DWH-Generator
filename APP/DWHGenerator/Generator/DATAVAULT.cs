using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    public static class DATAVAULT
    {
        public static string Generate()
        {
            string result = "";

            DataClassesDataContext dc = new DataClassesDataContext();

            var lstMetas = (from p in dc.ATTRIBUTEs select p).ToList();

            List<string> lstDVTables = (from p in lstMetas where string.IsNullOrEmpty(p.DV_TABLENAME)==false select p.DV_TABLENAME).ToList();

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
                var lstColumns = (from p in lstMetas where p.DV_TABLENAME == itemTable where string.IsNullOrEmpty(p.DV_TABLENAME) == false select p).ToList();

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
    }
}
