using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_UseOriginal
{
    public class SQLFunction
    {
        public string FUNCTION_NAME { get; private set; }
        public string FUNCTION_DEFINITION { get; private set; }

        // -----------------------------------------------------

        public SQLFunction(List<XModel_SQLSchema_Original.SQLFunction> sfList)
        {
            var sf1 = sfList[0];

            this.FUNCTION_NAME = sf1.FUNCTION_NAME;
            this.FUNCTION_DEFINITION = string.Join(string.Empty, sfList.Select(x => x.FUNCTION_DEFINITION)).Trim();
        }
    }
}
