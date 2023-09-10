using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_Original
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

        // -----------------------------------------------------

        public SQLTableIndex(DataRow dr)
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString();
            this.INDEX_TYPE = dr["INDEX_TYPE"].ToString();
            this.CLUSTERED_TYPE = dr["CLUSTERED_TYPE"].ToString();
            this.KEY_ORDINAL = Convert.ToInt32(dr["KEY_ORDINAL"]);
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString();
            this.ORDERBY_TYPE = dr["ORDERBY_TYPE"].ToString();
        }
    }
}

