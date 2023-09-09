using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace XProject.Database.SchemaCompare.UI.XAppConfig
{
    public class AppSettings
    {
        public static string DefaultReportDirectoryPath
        {
            get
            {
                var defaultReportDirectoryPath = (ConfigurationManager.AppSettings["DefaultReportDirectoryPath"] ?? string.Empty).ToString();
                var result = (
                    (defaultReportDirectoryPath == string.Empty) ?
                    Path.Combine(Environment.CurrentDirectory, "Report") :
                    Path.GetFullPath(defaultReportDirectoryPath)
                );

                if (Directory.Exists(result) == false)
                {
                    Directory.CreateDirectory(result);
                }

                return result;
            }
        }

        public static bool IsAppCloseTimeSaveWorkSourceQuestion
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["IsAppCloseTimeSaveWorkSourceQuestion"]);
            }
        }

        public static bool IsSaveWorkSourceWithPassword
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["IsSaveWorkSourceWithPassword"]);
            }
        }

        public static bool IsSaveWorkSourceBeforeBackupWorkSource
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["IsSaveWorkSourceBeforeBackupWorkSource"]);
            }
        }

        public static bool IsDefaultUserManualConnectionStringMode
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["IsDefaultUserManualConnectionStringMode"]);
            }
        }
    }
}
