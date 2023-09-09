using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_Original
{
    public class SQLTableIndex_Original
    {
        public string TABLE_NAME_Original { get; private set; }
        public string CONSTRAINT_NAME_Original { get; private set; }
        public string INDEX_TYPE_Original { get; private set; }
        public string CLUSTERED_TYPE_Original { get; private set; }
        public string COLUMN_NAME_Original { get; private set; }
        public string ORDERBY_TYPE_Original { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableIndex_Original(DataRow dr)
        {
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME_Original = dr["CONSTRAINT_NAME"].ToString();
            this.INDEX_TYPE_Original = dr["INDEX_TYPE"].ToString();
            this.CLUSTERED_TYPE_Original = dr["CLUSTERED_TYPE"].ToString();
            this.COLUMN_NAME_Original = dr["COLUMN_NAME"].ToString();
            this.ORDERBY_TYPE_Original = dr["ORDERBY_TYPE"].ToString();
            this.NotifyContent = string.Empty;
        }

        public SQLTableIndex_Original(string table_Name, string constraint_Name, string index_Type, string clustered_Type, int key_Ordinal, string column_Name)
        {
            this.TABLE_NAME_Original = table_Name;
            this.CONSTRAINT_NAME_Original = constraint_Name;
            this.INDEX_TYPE_Original = index_Type;
            this.CLUSTERED_TYPE_Original = clustered_Type;
            this.COLUMN_NAME_Original = column_Name;
            this.ORDERBY_TYPE_Original = string.Empty;
            this.NotifyContent = $"{constraint_Name} / {clustered_Type} / {index_Type} / {column_Name}";
        }
    }
}

