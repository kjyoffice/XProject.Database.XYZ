using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.UI.XModel
{
    public class WorkSourceData
    {
        [Newtonsoft.Json.JsonProperty("reportDirectoryPath")]
        public string ReportDirectoryPath { get; set; }
        [Newtonsoft.Json.JsonProperty("databaseType")]
        public string DatabaseType { get; set; }
        [Newtonsoft.Json.JsonProperty("isUIKoreanLanguage")]
        public bool IsUIKoreanLanguage { get; set; }
        [Newtonsoft.Json.JsonProperty("sourceServer")]
        public WorkSourceServer SourceServer { get; set; }
        [Newtonsoft.Json.JsonProperty("targetServer")]
        public WorkSourceServer TargetServer { get; set; }
    }
}
