using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_SourceAndTarget
{
    public class SQLTable
    {
        public List<XModel_SQLSchema.SQLTable> Source { get; private set; }
        public List<XModel_SQLSchema.SQLTable> Target { get; private set; }

        // ----------------------------------------------------

        public SQLTable(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.TableList();
            this.Target = target.TableList();
        }
    }
}
