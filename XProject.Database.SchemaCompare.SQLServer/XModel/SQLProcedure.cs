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
        public XModel_UseOriginal.SQLProcedure Original { get; private set; }
        public string ROUTINE_NAME { get; private set; }
        public string ROUTINE_DEFINITION { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        public SQLProcedure(List<XModel_DataOriginal.SQLProcedure> spList)
        {
            var original = new XModel_UseOriginal.SQLProcedure(spList);
            var routine_Definition = original.ROUTINE_DEFINITION.ToUpper();

            this.Original = original;
            this.ROUTINE_NAME = original.ROUTINE_NAME.ToUpper();
            this.ROUTINE_DEFINITION = routine_Definition;
            this.CheckSource = XValue.HashValue.SHA512Hash(routine_Definition);
        }
    }
}

