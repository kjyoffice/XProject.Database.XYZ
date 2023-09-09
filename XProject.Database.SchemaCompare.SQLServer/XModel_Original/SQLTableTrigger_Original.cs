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
        public string TABLE_NAME { get; private set; }
        public string TRIGGER_NAME { get; private set; }
        public string TRIGGER_SCHEMA { get; private set; }

        // -----------------------------------------------------

        public SQLTableTrigger_Original(DataRow dr)
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString();
            this.TRIGGER_NAME = dr["TRIGGER_NAME"].ToString();
            this.TRIGGER_SCHEMA = dr["TRIGGER_SCHEMA"].ToString();
        }

        public SQLTableTrigger_Original(string table_Name, string trigger_Name, string trigger_Schema)
        {
            this.TABLE_NAME = table_Name;
            this.TRIGGER_NAME = trigger_Name;
            this.TRIGGER_SCHEMA = trigger_Schema;
        }
    }
}
