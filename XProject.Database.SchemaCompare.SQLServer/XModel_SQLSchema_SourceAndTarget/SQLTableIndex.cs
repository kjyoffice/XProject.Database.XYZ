using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_SourceAndTarget
{
    public class SQLTableIndex
    {
        public List<XModel_SQLSchema.SQLTableIndex> Source { get; private set; }
        public List<XModel_SQLSchema.SQLTableIndex> Target { get; private set; }

        // ----------------------------------------------------

        public SQLTableIndex(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.TableIndexList();
            this.Target = target.TableIndexList();
        }
    }
}
