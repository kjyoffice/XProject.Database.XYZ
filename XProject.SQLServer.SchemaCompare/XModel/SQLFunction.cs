using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.SQLServer.SchemaCompare.XModel
{
    public class SQLFunction
    {
        public string FUNCTION_NAME { get; private set; }
        public string FUNCTION_DEFINITION { get; private set; }
        public string FUNCTION_NAME_Original { get; private set; }
        public string FUNCTION_DEFINITION_Original { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        public SQLFunction(DataRow dr)
        {
            // Upper
            this.FUNCTION_NAME = dr["FUNCTION_NAME"].ToString().ToUpper();
            this.FUNCTION_DEFINITION = dr["FUNCTION_DEFINITION"].ToString().ToUpper();
            // Original
            this.FUNCTION_NAME_Original = dr["FUNCTION_NAME"].ToString();
            this.FUNCTION_DEFINITION_Original = dr["FUNCTION_DEFINITION"].ToString();

            this.CheckSource = string.Empty;
        }

        public SQLFunction(string function_Name, string function_Definition)
        {
            // Upper
            this.FUNCTION_NAME = function_Name.ToUpper();
            this.FUNCTION_DEFINITION = function_Definition.ToUpper();
            // Original
            this.FUNCTION_NAME_Original = function_Name;
            this.FUNCTION_DEFINITION_Original = function_Definition;

            this.CheckSource = XValue.HashValue.SHA512Hash(this.FUNCTION_DEFINITION);
        }
    }
}
