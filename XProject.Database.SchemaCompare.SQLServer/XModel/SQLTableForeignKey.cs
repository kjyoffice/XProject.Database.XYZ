using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLTableForeignKey
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string REFERENCE_TABLE_NAME { get; private set; }
        public string REFERENCE_COLUMN_NAME { get; private set; }
        public SQLTableForeignKey_Original Original { get; private set; }
        public string CheckSourceHash { get; private set; }
        
        // -----------------------------------------------------

        public SQLTableForeignKey(DataRow dr)
        {
            // Upper
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString().ToUpper();
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString().ToUpper();
            this.REFERENCE_TABLE_NAME = dr["REFERENCE_TABLE_NAME"].ToString().ToUpper();
            this.REFERENCE_COLUMN_NAME = dr["REFERENCE_COLUMN_NAME"].ToString().ToUpper();
            this.Original = new SQLTableForeignKey_Original(dr);
            this.CheckSourceHash = string.Empty;
        }

        public SQLTableForeignKey(string table_Name, string constraint_Name, string column_Name, string reference_Table_Name, string reference_Column_Name)
        {
            // Upper
            this.TABLE_NAME = table_Name.ToUpper();
            this.CONSTRAINT_NAME = constraint_Name.ToUpper();
            this.COLUMN_NAME = column_Name.ToUpper();
            this.REFERENCE_TABLE_NAME = reference_Table_Name.ToUpper();
            this.REFERENCE_COLUMN_NAME = reference_Column_Name.ToUpper();
            this.Original = new SQLTableForeignKey_Original(table_Name, constraint_Name, column_Name, reference_Table_Name, reference_Column_Name);         
            this.CheckSourceHash = XValue.HashValue.SHA512Hash(this.COLUMN_NAME, this.REFERENCE_TABLE_NAME, this.REFERENCE_COLUMN_NAME);
        }
    }
}
