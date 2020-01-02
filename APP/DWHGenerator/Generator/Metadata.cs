using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    public class Metadata
    {
        public string PSADatabaseName { get; set; }
        public string HashTail { get; set; }
        public List<MetaTable> MTA { get; set; }

        public Metadata()
        {
            MTA = new List<MetaTable>();
        }
    }

    public class MetaTable
    { 
        public string ObjectName { get; set; }
        public string SchemaName { get; set; }
        public string RecordSource { get; set; }
        public List<Field> PK { get; set; }
        public List<Field> DI { get; set; }
    }

    public class Field
    { 
        public string FieldName { get; set; }
        public string FieldType { get; set; }
    }
}
