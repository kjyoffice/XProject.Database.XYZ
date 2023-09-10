using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema
{
    public class SQLTableTrigger
    {
        public XModel_UseOriginal.SQLTableTrigger Original { get; private set; }
        public string TABLE_NAME { get; private set; }
        public string TRIGGER_NAME { get; private set; }
        public string TRIGGER_SCHEMA { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        public SQLTableTrigger(string table_Name, string trigger_Name, List<XModel_DataOriginal.SQLTableTrigger> sttList)
        {
            var original = new XModel_UseOriginal.SQLTableTrigger(table_Name, trigger_Name, sttList);
            var trigger_Schema = original.TRIGGER_SCHEMA.ToUpper();

            this.Original = original;
            this.TABLE_NAME = original.TABLE_NAME.ToUpper();
            this.TRIGGER_NAME = original.TRIGGER_NAME.ToUpper();
            this.TRIGGER_SCHEMA = trigger_Schema;
            this.CheckSource = XValue.HashValue.SHA512Hash(trigger_Schema);
        }
    }
}

