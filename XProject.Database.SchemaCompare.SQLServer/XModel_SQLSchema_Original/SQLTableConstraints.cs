using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_Original
{
    public class SQLTableConstraints
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string TYPE_DESC { get; private set; }
        public string CONSTRAINT_DEFINITION { get; private set; }

        // -----------------------------------------------------

        public SQLTableConstraints(DataRow dr)
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString();
            this.TYPE_DESC = dr["TYPE_DESC"].ToString();
            this.CONSTRAINT_DEFINITION = dr["CONSTRAINT_DEFINITION"].ToString();
        }
    }
}

