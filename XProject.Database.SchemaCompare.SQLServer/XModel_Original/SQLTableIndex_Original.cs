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
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string INDEX_TYPE { get; private set; }
        public string CLUSTERED_TYPE { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string ORDERBY_TYPE { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableIndex_Original(DataRow dr)
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString();
            this.INDEX_TYPE = dr["INDEX_TYPE"].ToString();
            this.CLUSTERED_TYPE = dr["CLUSTERED_TYPE"].ToString();
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString();
            this.ORDERBY_TYPE = dr["ORDERBY_TYPE"].ToString();
            this.NotifyContent = string.Empty;
        }

        public SQLTableIndex_Original(string table_Name, string constraint_Name, string index_Type, string clustered_Type, int key_Ordinal, string column_Name)
        {
            this.TABLE_NAME = table_Name;
            this.CONSTRAINT_NAME = constraint_Name;
            this.INDEX_TYPE = index_Type;
            this.CLUSTERED_TYPE = clustered_Type;
            this.COLUMN_NAME = column_Name;
            this.ORDERBY_TYPE = string.Empty;
            this.NotifyContent = $"{constraint_Name} / {clustered_Type} / {index_Type} / {column_Name}";
        }
    }
}

