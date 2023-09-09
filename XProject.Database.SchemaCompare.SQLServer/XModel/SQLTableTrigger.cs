using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLTableTrigger
    {
        public string TABLE_NAME { get; private set; }
        public string TRIGGER_NAME { get; private set; }
        public string TRIGGER_SCHEMA { get; private set; }
        public XModel_Original.SQLTableTrigger_Original Original { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        public SQLTableTrigger(DataRow dr)
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            this.TRIGGER_NAME = dr["TRIGGER_NAME"].ToString().ToUpper();
            this.TRIGGER_SCHEMA = dr["TRIGGER_SCHEMA"].ToString().ToUpper();
            this.Original = new XModel_Original.SQLTableTrigger_Original(dr);
            this.CheckSource = string.Empty;
        }

        public SQLTableTrigger(string table_Name, string trigger_Name, string trigger_Schema)
        {
            this.TABLE_NAME = table_Name.ToUpper();
            this.TRIGGER_NAME = trigger_Name.ToUpper();
            this.TRIGGER_SCHEMA = trigger_Schema.ToUpper();
            this.Original = new XModel_Original.SQLTableTrigger_Original(table_Name, trigger_Name, trigger_Schema); 
            this.CheckSource = XValue.HashValue.SHA512Hash(this.TRIGGER_SCHEMA);
        }
    }
}
