using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_SourceAndTarget
{
    public class SQLTableForeignKey
    {
        public List<XModel_SQLSchema.SQLTableForeignKey> Source { get; private set; }
        public List<XModel_SQLSchema.SQLTableForeignKey> Target { get; private set; }

        // ----------------------------------------------------

        public SQLTableForeignKey(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.TableForeignKeyList();
            this.Target = target.TableForeignKeyList();
        }
    }
}
