using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLTable
    {
        public XModel_Original.SQLTable_Original Original { get; private set; }
        public string TABLE_NAME { get; private set; }

        // ---------------------------------------------------

        public SQLTable(DataRow dr)
        {
            this.Original = new XModel_Original.SQLTable_Original(dr);
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
        }
    }
}
