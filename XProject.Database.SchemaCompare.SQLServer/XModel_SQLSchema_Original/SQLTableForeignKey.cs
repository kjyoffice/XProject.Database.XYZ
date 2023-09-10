using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_Original
{
    public class SQLTableForeignKey
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string REFERENCE_TABLE_NAME { get; private set; }
        public string REFERENCE_COLUMN_NAME { get; private set; }

        // -----------------------------------------------------

        public SQLTableForeignKey(DataRow dr)
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString();
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString();
            this.REFERENCE_TABLE_NAME = dr["REFERENCE_TABLE_NAME"].ToString();
            this.REFERENCE_COLUMN_NAME = dr["REFERENCE_COLUMN_NAME"].ToString();
        }
    }
}

