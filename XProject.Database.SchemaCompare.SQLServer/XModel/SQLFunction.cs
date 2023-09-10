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
        public XModel_UseOriginal.SQLFunction Original { get; private set; }
        public string FUNCTION_NAME { get; private set; }
        public string FUNCTION_DEFINITION { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        public SQLFunction(List<XModel_DataOriginal.SQLFunction> sfList)
        {
            var original = new XModel_UseOriginal.SQLFunction(sfList);
            var function_Definition = original.FUNCTION_DEFINITION.ToUpper();

            this.Original = original;
            this.FUNCTION_NAME = original.FUNCTION_NAME.ToUpper();
            this.FUNCTION_DEFINITION = function_Definition;
            this.CheckSource = XValue.HashValue.SHA512Hash(function_Definition);
        }
    }
}

