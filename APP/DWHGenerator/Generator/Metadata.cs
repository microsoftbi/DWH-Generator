using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    public class Metadata
    {
        public string PSADatabaseName { get; set; }
        public string COREDatabaseName { get; set; }
        public string HashTail { get; set; }
        public List<MetaTable> MTA { get; set; }
        public List<DVMetaTable> DVHUBMTA { get; set; }
        public List<DVMetaTable> DVSATMTA { get; set; }
        public List<DVMetaTable> DVLINKMTA { get; set; }

        public Metadata()
        {
            MTA = new List<MetaTable>();
            DVHUBMTA = new List<DVMetaTable>();
            DVSATMTA = new List<DVMetaTable>();
            DVLINKMTA = new List<DVMetaTable>();
            //DVMTA = new List<DVMetaTable>();
        }
    }


    public class MetaTable
    { 
        public string ObjectName { get; set; }
        public string SchemaName { get; set; }
        public string RecordSource { get; set; }
        public List<Field> PK { get; set; }
        public List<Field> DI { get; set; }
        public List<Field> FK { get; set; }
    }

    public class DVMetaTable
    {
        public string TableName { get; set; }
        public string RecordSource { get; set; }
        public string PSATableName { get; set; }
        public string PSASchemaName { get; set; }
        public List<DVField> PK { get; set; } //Used for HUB and SAT
        public List<DVField> DI { get; set; } //Used for SAT
        public List<DVField> FK { get; set; } //Used for LINK
    }

    public class Field
    { 
        public string FieldName { get; set; }
        public string FieldType { get; set; }
    }

    public class DVField
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }

        public string PSAFieldName { get; set; }
    }
}
