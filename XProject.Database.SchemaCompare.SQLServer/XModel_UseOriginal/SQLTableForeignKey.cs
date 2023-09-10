using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_UseOriginal
{
    public class SQLTableForeignKey
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string REFERENCE_TABLE_NAME { get; private set; }
        public string REFERENCE_COLUMN_NAME { get; private set; }

        // -----------------------------------------------------

        public SQLTableForeignKey(string table_Name, string constraint_Name, IEnumerable<XModel_DataOriginal.SQLTableForeignKey> stfkList)
        {
            var stfk1 = stfkList.First();

            this.TABLE_NAME = table_Name;
            this.CONSTRAINT_NAME = constraint_Name;
            this.COLUMN_NAME = string.Join(", ", stfkList.Select(x => x.COLUMN_NAME));
            this.REFERENCE_TABLE_NAME = stfk1.REFERENCE_TABLE_NAME;
            this.REFERENCE_COLUMN_NAME = string.Join(", ", stfkList.Select(x => x.REFERENCE_COLUMN_NAME));
        }
    }
}

