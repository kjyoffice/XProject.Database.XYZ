using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_DataOriginal
{
    public class SQLTableColumn
    {
        public string TABLE_NAME { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string IS_NULLABLE { get; private set; }
        public string DATA_TYPE { get; private set; }
        public string IS_IDENTITY { get; private set; }

        // -----------------------------------------------------

        public SQLTableColumn(DataRow dr) 
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString();
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString();
            this.IS_NULLABLE = dr["IS_NULLABLE"].ToString();
            this.DATA_TYPE = dr["DATA_TYPE"].ToString();
            this.IS_IDENTITY = dr["IS_IDENTITY"].ToString();
        }
    }
}
