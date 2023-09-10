using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema_SourceAndTarget
{
    public class SQLTableTrigger
    {
        public List<XModel_SQLSchema.SQLTableTrigger> Source { get; private set; }
        public List<XModel_SQLSchema.SQLTableTrigger> Target { get; private set; }

        // ----------------------------------------------------

        public SQLTableTrigger(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.TableTriggerList();
            this.Target = target.TableTriggerList();
        }
    }
}
