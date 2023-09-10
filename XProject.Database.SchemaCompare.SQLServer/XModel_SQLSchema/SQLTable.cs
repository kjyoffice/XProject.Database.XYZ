using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema
{
    public class SQLTable
    {
        public XModel_SQLSchema_Original.SQLTable Original { get; private set; }
        public string TABLE_NAME { get; private set; }

        // ---------------------------------------------------

        public SQLTable(XModel_SQLSchema_Original.SQLTable original)
        {
            this.Original = original;
            this.TABLE_NAME = original.TABLE_NAME.ToUpper();
        }
    }
}
