using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_SourceAndTarget
{
    public class SQLTableColumn
    {
        public List<XModel_SQLSchema.SQLTableColumn> Source { get; private set; }
        public List<XModel_SQLSchema.SQLTableColumn> Target { get; private set; }

        // ----------------------------------------------------

        public SQLTableColumn(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.TableColumnList();
            this.Target = target.TableColumnList();
        }
    }
}
