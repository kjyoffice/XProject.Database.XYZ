using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.SQLServer.SchemaCompare.XModel
{
    public class SQLTableForeignKey
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string REFERENCE_TABLE_NAME { get; private set; }
        public string REFERENCE_COLUMN_NAME { get; private set; }
        public string TABLE_NAME_Original { get; private set; }
        public string CONSTRAINT_NAME_Original { get; private set; }
        public string COLUMN_NAME_Original { get; private set; }
        public string REFERENCE_TABLE_NAME_Original { get; private set; }
        public string REFERENCE_COLUMN_NAME_Original { get; private set; }
        public string CheckSourceHash { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableForeignKey(DataRow dr)
        {
            // Upper
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString().ToUpper();
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString().ToUpper();
            this.REFERENCE_TABLE_NAME = dr["REFERENCE_TABLE_NAME"].ToString().ToUpper();
            this.REFERENCE_COLUMN_NAME = dr["REFERENCE_COLUMN_NAME"].ToString().ToUpper();
            // Original
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME_Original = dr["CONSTRAINT_NAME"].ToString();
            this.COLUMN_NAME_Original = dr["COLUMN_NAME"].ToString();
            this.REFERENCE_TABLE_NAME_Original = dr["REFERENCE_TABLE_NAME"].ToString();
            this.REFERENCE_COLUMN_NAME_Original = dr["REFERENCE_COLUMN_NAME"].ToString();

            this.CheckSourceHash = string.Empty;
            this.NotifyContent = string.Empty;
        }

        public SQLTableForeignKey(string table_Name, string constraint_Name, string column_Name, string reference_Table_Name, string reference_Column_Name)
        {
            // Upper
            this.TABLE_NAME = table_Name.ToUpper();
            this.CONSTRAINT_NAME = constraint_Name.ToUpper();
            this.COLUMN_NAME = column_Name.ToUpper();
            this.REFERENCE_TABLE_NAME = reference_Table_Name.ToUpper();
            this.REFERENCE_COLUMN_NAME = reference_Column_Name.ToUpper();
            // Original
            this.TABLE_NAME_Original = table_Name;
            this.CONSTRAINT_NAME_Original = constraint_Name;
            this.COLUMN_NAME_Original = column_Name;
            this.REFERENCE_TABLE_NAME_Original = reference_Table_Name;
            this.REFERENCE_COLUMN_NAME_Original = reference_Column_Name;

            this.CheckSourceHash = XValue.HashValue.SHA512Hash(this.COLUMN_NAME, this.REFERENCE_TABLE_NAME, this.REFERENCE_COLUMN_NAME);
            this.NotifyContent = $"{this.CONSTRAINT_NAME_Original} / {this.COLUMN_NAME_Original} / {this.REFERENCE_TABLE_NAME_Original} / {this.REFERENCE_COLUMN_NAME_Original}";
        }
    }
}
