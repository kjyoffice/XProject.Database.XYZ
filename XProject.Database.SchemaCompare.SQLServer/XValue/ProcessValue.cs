using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XProject.Database.SchemaCompare.SQLServer.XValue
{
    public class ProcessValue
    {
        public static string ReportDirectoryPath(string dirPath)
        {
            var result = (
                (dirPath == string.Empty) ?
                Path.Combine(Environment.CurrentDirectory, "Report") :
                Path.GetFullPath(dirPath)
            );

            if (Directory.Exists(result) == false)
            {
                Directory.CreateDirectory(result);
            }

            return result;
        }

        public static string CreateDirectoryPath(string baseDirPath, List<string> subDirNameList)
        {
            subDirNameList.Insert(0, baseDirPath);

            var result = Path.Combine(subDirNameList.ToArray());

            if (Directory.Exists(result) == false)
            {
                Directory.CreateDirectory(result);
            }

            return result;
        }

        public static string CreateDirectoryPath(string baseDirPath, string subDirName)
        {
            return ProcessValue.CreateDirectoryPath(baseDirPath, new List<string>() { subDirName });
        }
    }
}
