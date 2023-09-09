using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLFunction_Original
    {
        public string FUNCTION_NAME_Original { get; private set; }
        public string FUNCTION_DEFINITION_Original { get; private set; }

        // -----------------------------------------------------

        public SQLFunction_Original(DataRow dr)
        {
            this.FUNCTION_NAME_Original = dr["FUNCTION_NAME"].ToString();
            this.FUNCTION_DEFINITION_Original = dr["FUNCTION_DEFINITION"].ToString();
        }

        public SQLFunction_Original(string function_Name, string function_Definition)
        {
            this.FUNCTION_NAME_Original = function_Name;
            this.FUNCTION_DEFINITION_Original = function_Definition;
        }
    }
}
