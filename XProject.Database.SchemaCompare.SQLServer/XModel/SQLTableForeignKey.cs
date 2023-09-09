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
        public XModel_Original.SQLTableForeignKey_Original Original { get; private set; }
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string REFERENCE_TABLE_NAME { get; private set; }
        public string REFERENCE_COLUMN_NAME { get; private set; }
        public string CheckSourceHash { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        //public SQLTableForeignKey(DataRow dr)
        //{
        //    this.Original = new XModel_Original.SQLTableForeignKey_Original(dr);
        //    this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
        //    this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString().ToUpper();
        //    this.COLUMN_NAME = dr["COLUMN_NAME"].ToString().ToUpper();
        //    this.REFERENCE_TABLE_NAME = dr["REFERENCE_TABLE_NAME"].ToString().ToUpper();
        //    this.REFERENCE_COLUMN_NAME = dr["REFERENCE_COLUMN_NAME"].ToString().ToUpper();
        //    this.CheckSourceHash = string.Empty;
        //    this.NotifyContent = string.Empty;
        //}

                //.Select(
                //    x => new XModel.SQLTableForeignKey(
                //        x.Key.TABLE_NAME,
                //        x.Key.CONSTRAINT_NAME,
                //        string.Join(", ", x.Select(y => y.COLUMN_NAME)),
                //        x.First().REFERENCE_TABLE_NAME,
                //        string.Join(", ", x.Select(y => y.REFERENCE_COLUMN_NAME))
                //    )
                //)
                //.ToList();

        public SQLTableForeignKey(string table_Name, string constraint_Name, string column_Name, string reference_Table_Name, string reference_Column_Name)
        {
            var original = new XModel_Original.SQLTableForeignKey_Original(table_Name, constraint_Name, column_Name, reference_Table_Name, reference_Column_Name);
            var column_NameUse = column_Name.ToUpper();
            var reference_Table_NameUse = reference_Table_Name.ToUpper();
            var reference_Column_NameUse = reference_Column_Name.ToUpper();

            this.Original = original;
            this.TABLE_NAME = table_Name.ToUpper();
            this.CONSTRAINT_NAME = constraint_Name.ToUpper();
            this.COLUMN_NAME = column_NameUse;
            this.REFERENCE_TABLE_NAME = reference_Table_NameUse;
            this.REFERENCE_COLUMN_NAME = reference_Column_NameUse;     
            this.CheckSourceHash = XValue.HashValue.SHA512Hash(column_NameUse, reference_Table_NameUse, reference_Column_NameUse);
            this.NotifyContent = $"{original.CONSTRAINT_NAME} / {original.COLUMN_NAME} / {original.REFERENCE_TABLE_NAME} / {original.REFERENCE_COLUMN_NAME}";
        }
    }
}

