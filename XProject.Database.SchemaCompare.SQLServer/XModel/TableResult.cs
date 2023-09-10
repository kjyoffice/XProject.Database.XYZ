using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class TableResult
    {
        public List<XModel_SQLSchema.SQLTable> ExistTableList { get; private set; }
        public List<XModel_SQLSchema.SQLTable> NotExistTableList { get; private set; }

        // -----------------------------------

        public TableResult(List<XModel_SQLSchema.SQLTable> existTableList, List<XModel_SQLSchema.SQLTable> notExistTableList)
        {
            this.ExistTableList = existTableList;
            this.NotExistTableList = notExistTableList;
        }
    }
}
