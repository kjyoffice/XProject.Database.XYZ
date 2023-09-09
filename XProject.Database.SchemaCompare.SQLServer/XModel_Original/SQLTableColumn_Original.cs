using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_Original
{
    public class SQLTableColumn_Original
    {
        public string TABLE_NAME_Original { get; private set; }
        public string COLUMN_NAME_Original { get; private set; }
        public string IS_NULLABLE_Original { get; private set; }
        public string DATA_TYPE_Original { get; private set; }
        public string IS_IDENTITY_Original { get; private set; }

        // -----------------------------------------------------

        public SQLTableColumn_Original(DataRow dr) 
        {
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
            this.COLUMN_NAME_Original = dr["COLUMN_NAME"].ToString();
            this.IS_NULLABLE_Original = dr["IS_NULLABLE"].ToString();
            this.DATA_TYPE_Original = dr["DATA_TYPE"].ToString();
            this.IS_IDENTITY_Original = dr["IS_IDENTITY"].ToString();
        }
    }
}
