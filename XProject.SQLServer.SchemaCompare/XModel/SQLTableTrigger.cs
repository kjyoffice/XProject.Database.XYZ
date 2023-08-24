using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.SQLServer.SchemaCompare.XModel
{
    public class SQLTableTrigger
    {
        public string TABLE_NAME { get; private set; }
        public string TRIGGER_NAME { get; private set; }
        public string TRIGGER_SCHEMA { get; private set; }
        public string TABLE_NAME_Original { get; private set; }
        public string TRIGGER_NAME_Original { get; private set; }
        public string TRIGGER_SCHEMA_Original { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        public SQLTableTrigger(DataRow dr)
        {
            // Upper
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            this.TRIGGER_NAME = dr["TRIGGER_NAME"].ToString().ToUpper();
            this.TRIGGER_SCHEMA = dr["TRIGGER_SCHEMA"].ToString().ToUpper();
            // Original
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
            this.TRIGGER_NAME_Original = dr["TRIGGER_NAME"].ToString();
            this.TRIGGER_SCHEMA_Original = dr["TRIGGER_SCHEMA"].ToString();
            
            this.CheckSource = string.Empty;
        }

        public SQLTableTrigger(string table_Name, string trigger_Name, string trigger_Schema)
        {
            // Upper
            this.TABLE_NAME = table_Name.ToUpper();
            this.TRIGGER_NAME = trigger_Name.ToUpper();
            this.TRIGGER_SCHEMA = trigger_Schema.ToUpper();
            // Original
            this.TABLE_NAME_Original = table_Name;
            this.TRIGGER_NAME_Original = trigger_Name;
            this.TRIGGER_SCHEMA_Original = trigger_Schema;

            this.CheckSource = XValue.HashValue.SHA512Hash(this.TRIGGER_SCHEMA);
        }
    }
}
