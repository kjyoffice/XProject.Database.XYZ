using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLProcedure
    {
        public string ROUTINE_NAME { get; private set; }
        public string ROUTINE_DEFINITION { get; private set; }
        public string ROUTINE_NAME_Original { get; private set; }
        public string ROUTINE_DEFINITION_Original { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        public SQLProcedure(DataRow dr)
        {
            // Upper
            this.ROUTINE_NAME = dr["ROUTINE_NAME"].ToString().ToUpper();
            this.ROUTINE_DEFINITION = dr["ROUTINE_DEFINITION"].ToString().ToUpper();
            // Original
            this.ROUTINE_NAME_Original = dr["ROUTINE_NAME"].ToString();
            this.ROUTINE_DEFINITION_Original = dr["ROUTINE_DEFINITION"].ToString();

            this.CheckSource = string.Empty;
        }

        public SQLProcedure(string routine_Name, string routine_Definition)
        {
            // Upper
            this.ROUTINE_NAME = routine_Name.ToUpper();
            this.ROUTINE_DEFINITION = routine_Definition.ToUpper();
            // Original
            this.ROUTINE_NAME_Original = routine_Name;
            this.ROUTINE_DEFINITION_Original = routine_Definition;

            this.CheckSource = XValue.HashValue.SHA512Hash(this.ROUTINE_DEFINITION);
        }
    }
}
