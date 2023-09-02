using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.UI.XValue
{
    public class ProcessValue
    {
        public static XModel.DatabaseTypeItem DatabaseType_SQLServer
        {
            get
            {
                return new XModel.DatabaseTypeItem("SQLServer");
            }
        }

        public static XModel.DatabaseTypeItem DatabaseType_MySQL
        {
            get
            {
                return new XModel.DatabaseTypeItem("MySQL");
            }
        }

        public static XModel.DatabaseTypeItem DatabaseType_PostgreSQL
        {
            get
            {
                return new XModel.DatabaseTypeItem("PostgreSQL");
            }
        }

        public static List<XModel.DatabaseTypeItem> DatabaseTypeList
        {
            get
            {
                return new List<XModel.DatabaseTypeItem>()
                {
                    ProcessValue.DatabaseType_SQLServer,
                    ProcessValue.DatabaseType_MySQL,
                    ProcessValue.DatabaseType_PostgreSQL
                };
            }
        }
    }
}
