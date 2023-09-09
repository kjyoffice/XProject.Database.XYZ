using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLTable_Original
    {
        public string TABLE_NAME_Original { get; private set; }

        // ---------------------------------------------------

        public SQLTable_Original(DataRow dr)
        {
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
        }
    }
}
