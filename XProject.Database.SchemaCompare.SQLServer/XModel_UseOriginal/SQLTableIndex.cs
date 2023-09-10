using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_UseOriginal
{
    public class SQLTableIndex
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string INDEX_TYPE { get; private set; }
        public string CLUSTERED_TYPE { get; private set; }
        public int KEY_ORDINAL { get; private set; }
        public string COLUMN_NAME_And_ORDERBY_TYPE { get; private set; }

        // -----------------------------------------------------

        public SQLTableIndex(string table_Name, string constraint_Name, List<XModel_DataOriginal.SQLTableIndex> stiList)
        {
            var sti1 = stiList[0];

            this.TABLE_NAME = table_Name;
            this.CONSTRAINT_NAME = constraint_Name;
            this.INDEX_TYPE = sti1.INDEX_TYPE;;
            this.CLUSTERED_TYPE = sti1.CLUSTERED_TYPE;
            this.KEY_ORDINAL = sti1.KEY_ORDINAL;
            this.COLUMN_NAME_And_ORDERBY_TYPE = string.Join(", ", stiList.Select(x => (x.COLUMN_NAME + " " + x.ORDERBY_TYPE)));
        }
    }
}
