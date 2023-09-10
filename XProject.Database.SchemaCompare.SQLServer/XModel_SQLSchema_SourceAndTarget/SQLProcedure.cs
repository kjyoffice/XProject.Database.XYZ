using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_SourceAndTarget
{
    public class SQLProcedure
    {
        public List<XModel_SQLSchema.SQLProcedure> Source { get; private set; }
        public List<XModel_SQLSchema.SQLProcedure> Target { get; private set; }

        // ----------------------------------------------------

        public SQLProcedure(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.ProcedureList();
            this.Target = target.ProcedureList();
        }
    }
}
