using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema
{
    public class SQLTableForeignKey
    {
        public XModel_UseOriginal.SQLTableForeignKey Original { get; private set; }
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string REFERENCE_TABLE_NAME { get; private set; }
        public string REFERENCE_COLUMN_NAME { get; private set; }
        public string CheckSourceHash { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableForeignKey(string table_Name, string constraint_Name, List<XModel_SQLSchema_Original.SQLTableForeignKey> stfkList)
        {
            var original = new XModel_UseOriginal.SQLTableForeignKey(table_Name, constraint_Name, stfkList);
            var column_Name = original.COLUMN_NAME.ToUpper();
            var reference_Table_Name = original.REFERENCE_TABLE_NAME.ToUpper();
            var reference_Column_Name = original.REFERENCE_COLUMN_NAME.ToUpper();

            this.Original = original;
            this.TABLE_NAME = table_Name.ToUpper();
            this.CONSTRAINT_NAME = constraint_Name.ToUpper();
            this.COLUMN_NAME = column_Name;
            this.REFERENCE_TABLE_NAME = reference_Table_Name;
            this.REFERENCE_COLUMN_NAME = reference_Column_Name;     
            this.CheckSourceHash = XValue.HashValue.SHA512Hash(column_Name, reference_Table_Name, reference_Column_Name);
            this.NotifyContent = $"{original.CONSTRAINT_NAME} / {original.COLUMN_NAME} / {original.REFERENCE_TABLE_NAME} / {original.REFERENCE_COLUMN_NAME}";
        }
    }
}

