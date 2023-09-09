using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_Original
{
    public class SQLTableForeignKey_Original
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string REFERENCE_TABLE_NAME { get; private set; }
        public string REFERENCE_COLUMN_NAME { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableForeignKey_Original(DataRow dr)
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString();
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString();
            this.REFERENCE_TABLE_NAME = dr["REFERENCE_TABLE_NAME"].ToString();
            this.REFERENCE_COLUMN_NAME = dr["REFERENCE_COLUMN_NAME"].ToString();
            this.NotifyContent = string.Empty;
        }

        public SQLTableForeignKey_Original(string table_Name, string constraint_Name, string column_Name, string reference_Table_Name, string reference_Column_Name)
        {
            this.TABLE_NAME = table_Name;
            this.CONSTRAINT_NAME = constraint_Name;
            this.COLUMN_NAME = column_Name;
            this.REFERENCE_TABLE_NAME = reference_Table_Name;
            this.REFERENCE_COLUMN_NAME = reference_Column_Name;
            this.NotifyContent = $"{constraint_Name} / {column_Name} / {reference_Table_Name} / {reference_Column_Name}";
        }
    }
}

