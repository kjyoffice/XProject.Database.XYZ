using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_Original
{
    public class SQLTableTrigger
    {
        public string TABLE_NAME { get; private set; }
        public string TRIGGER_NAME { get; private set; }
        public string TRIGGER_SCHEMA { get; private set; }

        // -----------------------------------------------------

        public SQLTableTrigger(DataRow dr)
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString();
            this.TRIGGER_NAME = dr["TRIGGER_NAME"].ToString();
            this.TRIGGER_SCHEMA = dr["TRIGGER_SCHEMA"].ToString();
        }
    }
}
