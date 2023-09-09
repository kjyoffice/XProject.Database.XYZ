using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLTableIndex
    {
        public XModel_Original.SQLTableIndex_Original Original { get; private set; }
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string INDEX_TYPE { get; private set; }
        public string CLUSTERED_TYPE { get; private set; }
        public int KEY_ORDINAL { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string ORDERBY_TYPE { get; private set; }
        public string CheckSourceHash { get; private set; }

        // -----------------------------------------------------

        public SQLTableIndex(DataRow dr)
        {
            this.Original = new XModel_Original.SQLTableIndex_Original(dr);
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString().ToUpper();
            this.INDEX_TYPE = dr["INDEX_TYPE"].ToString().ToUpper();
            this.CLUSTERED_TYPE = dr["CLUSTERED_TYPE"].ToString().ToUpper();
            this.KEY_ORDINAL = Convert.ToInt32(dr["KEY_ORDINAL"]);
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString().ToUpper();
            this.ORDERBY_TYPE = dr["ORDERBY_TYPE"].ToString().ToUpper();
            this.CheckSourceHash = string.Empty;
        }

        public SQLTableIndex(string table_Name, string constraint_Name, string index_Type, string clustered_Type, int key_Ordinal, string column_Name)
        {
            var index_TypeUse = index_Type.ToUpper();
            var clustered_TypeUse = clustered_Type.ToUpper();
            var column_NameUse = column_Name.ToUpper();

            this.Original = new XModel_Original.SQLTableIndex_Original(table_Name, constraint_Name, index_Type, clustered_Type, key_Ordinal, column_Name);
            this.TABLE_NAME = table_Name.ToUpper();
            this.CONSTRAINT_NAME = constraint_Name.ToUpper();
            this.INDEX_TYPE = index_TypeUse;
            this.CLUSTERED_TYPE = clustered_TypeUse;
            this.KEY_ORDINAL = key_Ordinal;
            this.COLUMN_NAME = column_NameUse;
            this.ORDERBY_TYPE = string.Empty;
            this.CheckSourceHash = XValue.HashValue.SHA512Hash(index_TypeUse, clustered_TypeUse, column_NameUse);
        }
    }
}

