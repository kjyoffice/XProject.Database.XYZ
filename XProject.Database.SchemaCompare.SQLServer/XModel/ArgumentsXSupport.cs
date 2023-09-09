using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class ArgumentsXSupport
    {
        public string SourceServerConnectionString { get; private set; }
        public string TargetServerConnectionString { get; private set; }
        public string ReportDirectoryPathSource { get; private set; }
        public bool IsExistServerConnectionString { get; private set; }

        // -------------------------------------------------------

        public ArgumentsXSupport(string[] args)
        {
            var argsUse = new List<string>();
            argsUse.AddRange(args.Select(x => x.Trim()));
            argsUse.AddRange(Enumerable.Range(0, 10).Select(x => string.Empty));

            var sourceServerConnectionString = argsUse[0];
            var targetServerConnectionString = argsUse[1];

            this.SourceServerConnectionString = sourceServerConnectionString;
            this.TargetServerConnectionString = targetServerConnectionString;
            this.ReportDirectoryPathSource = argsUse[2];
            this.IsExistServerConnectionString = ((sourceServerConnectionString != string.Empty) && (targetServerConnectionString != string.Empty));
        }
    }
}
