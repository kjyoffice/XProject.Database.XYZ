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
        public string TABLE_NAME_Original { get; private set; }
        public string CONSTRAINT_NAME_Original { get; private set; }
        public string COLUMN_NAME_Original { get; private set; }
        public string REFERENCE_TABLE_NAME_Original { get; private set; }
        public string REFERENCE_COLUMN_NAME_Original { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableForeignKey_Original(DataRow dr)
        {
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME_Original = dr["CONSTRAINT_NAME"].ToString();
            this.COLUMN_NAME_Original = dr["COLUMN_NAME"].ToString();
            this.REFERENCE_TABLE_NAME_Original = dr["REFERENCE_TABLE_NAME"].ToString();
            this.REFERENCE_COLUMN_NAME_Original = dr["REFERENCE_COLUMN_NAME"].ToString();
            this.NotifyContent = string.Empty;
        }

        public SQLTableForeignKey_Original(string table_Name, string constraint_Name, string column_Name, string reference_Table_Name, string reference_Column_Name)
        {
            this.TABLE_NAME_Original = table_Name;
            this.CONSTRAINT_NAME_Original = constraint_Name;
            this.COLUMN_NAME_Original = column_Name;
            this.REFERENCE_TABLE_NAME_Original = reference_Table_Name;
            this.REFERENCE_COLUMN_NAME_Original = reference_Column_Name;
            this.NotifyContent = $"{constraint_Name} / {column_Name} / {reference_Table_Name} / {reference_Column_Name}";
        }
    }
}

