using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.SQLServer.SchemaCompare.XModel
{
    public class SQLTableIndex
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string INDEX_TYPE { get; private set; }
        public string CLUSTERED_TYPE { get; private set; }
        public int KEY_ORDINAL { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string ORDERBY_TYPE { get; private set; }
        public string TABLE_NAME_Original { get; private set; }
        public string CONSTRAINT_NAME_Original { get; private set; }
        public string INDEX_TYPE_Original { get; private set; }
        public string CLUSTERED_TYPE_Original { get; private set; }
        public string COLUMN_NAME_Original { get; private set; }
        public string ORDERBY_TYPE_Original { get; private set; }
        public string CheckSourceHash { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableIndex(DataRow dr)
        {
            // Upper
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString().ToUpper();
            this.INDEX_TYPE = dr["INDEX_TYPE"].ToString().ToUpper();
            this.CLUSTERED_TYPE = dr["CLUSTERED_TYPE"].ToString().ToUpper();
            this.KEY_ORDINAL = Convert.ToInt32(dr["KEY_ORDINAL"]);
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString().ToUpper();
            this.ORDERBY_TYPE = dr["ORDERBY_TYPE"].ToString().ToUpper();
            // Original
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME_Original = dr["CONSTRAINT_NAME"].ToString();
            this.INDEX_TYPE_Original = dr["INDEX_TYPE"].ToString();
            this.CLUSTERED_TYPE_Original = dr["CLUSTERED_TYPE"].ToString();
            this.COLUMN_NAME_Original = dr["COLUMN_NAME"].ToString();
            this.ORDERBY_TYPE_Original = dr["ORDERBY_TYPE"].ToString();

            this.CheckSourceHash = string.Empty;
            this.NotifyContent = string.Empty;
        }

        public SQLTableIndex(string table_Name, string constraint_Name, string index_Type, string clustered_Type, int key_Ordinal, string column_Name)
        {
            // Upper
            this.TABLE_NAME = table_Name.ToUpper();
            this.CONSTRAINT_NAME = constraint_Name.ToUpper();
            this.INDEX_TYPE = index_Type.ToUpper();
            this.CLUSTERED_TYPE = clustered_Type.ToUpper();
            this.KEY_ORDINAL = key_Ordinal;
            this.COLUMN_NAME = column_Name.ToUpper();
            this.ORDERBY_TYPE = string.Empty;
            // Original
            this.TABLE_NAME_Original = table_Name;
            this.CONSTRAINT_NAME_Original = constraint_Name;
            this.INDEX_TYPE_Original = index_Type;
            this.CLUSTERED_TYPE_Original = clustered_Type;
            this.COLUMN_NAME_Original = column_Name;
            this.ORDERBY_TYPE_Original = string.Empty;

            this.CheckSourceHash = XValue.HashValue.SHA512Hash(this.INDEX_TYPE, this.CLUSTERED_TYPE, this.COLUMN_NAME);
            this.NotifyContent = $"{this.CONSTRAINT_NAME_Original} / {this.CLUSTERED_TYPE_Original} / {this.INDEX_TYPE_Original} / {this.COLUMN_NAME_Original}";
        }
    }
}
