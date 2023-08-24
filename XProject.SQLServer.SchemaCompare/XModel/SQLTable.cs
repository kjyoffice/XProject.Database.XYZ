using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.SQLServer.SchemaCompare.XModel
{
    public class SQLTable
    {
        public string TABLE_NAME { get; private set; }
        public string TABLE_NAME_Original { get; private set; }

        // ---------------------------------------------------

        public SQLTable(DataRow dr)
        {
            // Upper
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            // Original
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
        }
    }
}
