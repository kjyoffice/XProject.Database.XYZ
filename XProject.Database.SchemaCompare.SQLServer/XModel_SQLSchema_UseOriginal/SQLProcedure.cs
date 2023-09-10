using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_UseOriginal
{
    public class SQLProcedure
    {
        public string ROUTINE_NAME { get; private set; }
        public string ROUTINE_DEFINITION { get; private set; }

        // -----------------------------------------------------

        public SQLProcedure(List<XModel_SQLSchema_Original.SQLProcedure> spList)
        {
            var sp1 = spList[0];

            this.ROUTINE_NAME = sp1.ROUTINE_NAME;
            this.ROUTINE_DEFINITION = string.Join(string.Empty, spList.Select(x => x.ROUTINE_DEFINITION)).Trim();
        }
    }
}
