using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_Original
{
    public class SQLTableTrigger_Original
    {
        public string TABLE_NAME_Original { get; private set; }
        public string TRIGGER_NAME_Original { get; private set; }
        public string TRIGGER_SCHEMA_Original { get; private set; }

        // -----------------------------------------------------

        public SQLTableTrigger_Original(DataRow dr)
        {
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
            this.TRIGGER_NAME_Original = dr["TRIGGER_NAME"].ToString();
            this.TRIGGER_SCHEMA_Original = dr["TRIGGER_SCHEMA"].ToString();
        }

        public SQLTableTrigger_Original(string table_Name, string trigger_Name, string trigger_Schema)
        {
            this.TABLE_NAME_Original = table_Name;
            this.TRIGGER_NAME_Original = trigger_Name;
            this.TRIGGER_SCHEMA_Original = trigger_Schema;
        }
    }
}
