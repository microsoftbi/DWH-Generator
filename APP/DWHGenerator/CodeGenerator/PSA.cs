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

            List<string> tables = (from p in dc.ATTRIBUTE select p.TABLE_NAME).ToList();



            StringBuilder sb = new StringBuilder();

            foreach (var tableitem in tables.Distinct())
            {
                sb.AppendLine("CREATE TABLE [dbo].["+ tableitem+"]");
                sb.AppendLine("(");



                sb.AppendLine(")");
            }

            result = sb.ToString();

            return result;
        }
    }
}
