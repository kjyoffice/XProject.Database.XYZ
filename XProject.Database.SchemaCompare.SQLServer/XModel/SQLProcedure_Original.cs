using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLProcedure_Original
    {
        public string ROUTINE_NAME_Original { get; private set; }
        public string ROUTINE_DEFINITION_Original { get; private set; }

        // -----------------------------------------------------

        public SQLProcedure_Original(DataRow dr)
        {
            this.ROUTINE_NAME_Original = dr["ROUTINE_NAME"].ToString();
            this.ROUTINE_DEFINITION_Original = dr["ROUTINE_DEFINITION"].ToString();
        }

        public SQLProcedure_Original(string routine_Name, string routine_Definition)
        {
            this.ROUTINE_NAME_Original = routine_Name;
            this.ROUTINE_DEFINITION_Original = routine_Definition;
        }
    }
}
