using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    /// <summary>
    /// Meta data information, which will be used with load pattern to generate target DWH SQL code.
    /// </summary>
    public class Metadata
    {
        public string PSADatabaseName { get; set; }
        public string COREDatabaseName { get; set; }
        public string HashTail { get; set; }
        /// <summary>
        /// PSA meta tables
        /// </summary>
        public List<MetaTable> MTA { get; set; }
        /// <summary>
        /// Data vault HUB tables
        /// </summary>
        public List<DVMetaTable> DVHUBMTA { get; set; }
        /// <summary>
        /// Data vault SAT tables
        /// </summary>
        public List<DVMetaTable> DVSATMTA { get; set; }
        /// <summary>
        /// Data vault LINK tables
        /// </summary>
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

    /// <summary>
    /// PSA meta tables
    /// </summary>
    public class MetaTable
    { 
        public string ObjectName { get; set; }
        public string SchemaName { get; set; }
        public string RecordSource { get; set; }
        /// <summary>
        /// The source table load method, full load or incremental load.
        /// </summary>
        public string Is_FullLoad { get; set; }
        /// <summary>
        /// Primer key defination, always to be used in HUB tables.
        /// </summary>
        public List<Field> PK { get; set; }
        /// <summary>
        /// Descriptive information field defination, always to be used in SAT tables.
        /// </summary>
        public List<Field> DI { get; set; }
        /// <summary>
        /// Foreign key defination, always to be used in LINK tables.
        /// </summary>
        public List<Field> FK { get; set; }
    }

    /// <summary>
    /// Data vault meta tables.
    /// </summary>
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

    /// <summary>
    /// Field defination.
    /// </summary>
    public class Field
    { 
        public string FieldName { get; set; }
        public string FieldType { get; set; }
    }

    /// <summary>
    /// Data vault field defination
    /// </summary>
    public class DVField
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }

        public string PSAFieldName { get; set; }
    }
}
