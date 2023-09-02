using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.SQLServer.SchemaCompare.XModel
{
    public class TableResult
    {
        public List<SQLTable> ExistTableList { get; private set; }
        public List<SQLTable> NotExistTableList { get; private set; }

        // -----------------------------------

        public TableResult(List<SQLTable> existTableList, List<SQLTable> notExistTableList)
        {
            this.ExistTableList = existTableList;
            this.NotExistTableList = notExistTableList;
        }
    }
}
