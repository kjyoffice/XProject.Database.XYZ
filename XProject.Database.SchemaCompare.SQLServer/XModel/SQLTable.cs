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
        public string TABLE_NAME { get; private set; }
        public SQLTable_Original Original { get; private set; }

        // ---------------------------------------------------

        public SQLTable(DataRow dr)
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            this.Original = new SQLTable_Original(dr);
        }
    }
}
