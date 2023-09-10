using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_SourceAndTarget
{
    public class SQLTableConstraints
    {
        public List<XModel_SQLSchema.SQLTableConstraints> Source { get; private set; }
        public List<XModel_SQLSchema.SQLTableConstraints> Target { get; private set; }

        // ----------------------------------------------------

        public SQLTableConstraints(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.TableConstraintsList();
            this.Target = target.TableConstraintsList();
        }
    }
}
