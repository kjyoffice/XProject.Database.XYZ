using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_DataOriginal
{
    public class SQLProcedure
    {
        public string ROUTINE_NAME { get; private set; }
        public string ROUTINE_DEFINITION { get; private set; }

        // -----------------------------------------------------

        public SQLProcedure(DataRow dr)
        {
            this.ROUTINE_NAME = dr["ROUTINE_NAME"].ToString();
            this.ROUTINE_DEFINITION = dr["ROUTINE_DEFINITION"].ToString();
        }
    }
}
