using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XProject.SQLServer.SchemaCompare.XValue
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
    }
}
