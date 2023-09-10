using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_Original
{
    public class SQLTableColumn
    {
        public string TABLE_NAME { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string IS_NULLABLE { get; private set; }
        public string DATA_TYPE { get; private set; }
        public int MAX_LENGTH { get; private set; }
        public int PRECISION { get; private set; }
        public int SCALE { get; private set; }
        public string IS_IDENTITY { get; private set; }
        public int SEED_VALUE { get; private set; }
        public int INCREMENT_VALUE { get; private set; }

        // -----------------------------------------------------

        public SQLTableColumn(DataRow dr) 
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString();
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString();
            this.IS_NULLABLE = dr["IS_NULLABLE"].ToString();
            this.DATA_TYPE = dr["DATA_TYPE"].ToString();
            this.MAX_LENGTH = Convert.ToInt32(dr["MAX_LENGTH"]);
            this.PRECISION = Convert.ToInt32(dr["PRECISION"]);
            this.SCALE = Convert.ToInt32(dr["SCALE"]);
            this.IS_IDENTITY = dr["IS_IDENTITY"].ToString();
            this.SEED_VALUE = Convert.ToInt32(dr["SEED_VALUE"]);
            this.INCREMENT_VALUE = Convert.ToInt32(dr["INCREMENT_VALUE"]);
        }
    }
}
