using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_DataOriginal
{
    public class SQLFunction
    {
        public string FUNCTION_NAME { get; private set; }
        public string FUNCTION_DEFINITION { get; private set; }

        // -----------------------------------------------------

        public SQLFunction(DataRow dr)
        {
            this.FUNCTION_NAME = dr["FUNCTION_NAME"].ToString();
            this.FUNCTION_DEFINITION = dr["FUNCTION_DEFINITION"].ToString();
        }
    }
}
