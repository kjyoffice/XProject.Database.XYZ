using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.UI.XValue
{
    public class ProcessValue
    {
        public static string DatabaseType_SQLServer
        {
            get
            {
                return "SQLServer";
            }
        }

        public static string DatabaseType_MySQL
        {
            get
            {
                return "MySQL";
            }
        }

        public static List<string> DatabaseTypeList
        {
            get
            {
                return new List<string>()
                {
                    ProcessValue.DatabaseType_SQLServer,
                    ProcessValue.DatabaseType_MySQL
                };
            }
        }
    }
}
