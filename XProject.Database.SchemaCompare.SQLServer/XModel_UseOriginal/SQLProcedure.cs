using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_UseOriginal
{
    public class SQLProcedure
    {
        public string ROUTINE_NAME { get; private set; }
        public string ROUTINE_DEFINITION { get; private set; }

        // -----------------------------------------------------

        public SQLProcedure(string routine_Name, string routine_Definition)
        {
            this.ROUTINE_NAME = routine_Name;
            this.ROUTINE_DEFINITION = routine_Definition;
        }
    }
}
