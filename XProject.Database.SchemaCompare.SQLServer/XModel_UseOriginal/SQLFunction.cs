using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_UseOriginal
{
    public class SQLFunction
    {
        public string FUNCTION_NAME { get; private set; }
        public string FUNCTION_DEFINITION { get; private set; }

        // -----------------------------------------------------

        public SQLFunction(IEnumerable<XModel_DataOriginal.SQLFunction> sfList)
        {
            this.FUNCTION_NAME = sfList.First().FUNCTION_NAME;
            this.FUNCTION_DEFINITION = string.Join(string.Empty, sfList.Select(x => x.FUNCTION_DEFINITION)).Trim();
        }
    }
}
