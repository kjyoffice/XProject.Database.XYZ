using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLFunction
    {
        public XModel_Original.SQLFunction_Original Original { get; private set; }
        public string FUNCTION_NAME { get; private set; }
        public string FUNCTION_DEFINITION { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        public SQLFunction(DataRow dr)
        {
            this.Original = new XModel_Original.SQLFunction_Original(dr);
            this.FUNCTION_NAME = dr["FUNCTION_NAME"].ToString().ToUpper();
            this.FUNCTION_DEFINITION = dr["FUNCTION_DEFINITION"].ToString().ToUpper();
            this.CheckSource = string.Empty;
        }

        public SQLFunction(string function_Name, string function_Definition)
        {
            var function_DefinitionUse = function_Definition.ToUpper();

            this.Original = new XModel_Original.SQLFunction_Original(function_Name, function_Definition);
            this.FUNCTION_NAME = function_Name.ToUpper();
            this.FUNCTION_DEFINITION = function_DefinitionUse;
            this.CheckSource = XValue.HashValue.SHA512Hash(function_DefinitionUse);
        }
    }
}

