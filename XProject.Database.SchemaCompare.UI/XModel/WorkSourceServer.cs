using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.UI.XModel
{
    public class WorkSourceServer
    {
        [Newtonsoft.Json.JsonProperty("dataSource")]
        public string DataSource { get; set; }
        [Newtonsoft.Json.JsonProperty("userID")]
        public string UserID { get; set; }
        [Newtonsoft.Json.JsonProperty("password")]
        public string Password { get; set; }
        [Newtonsoft.Json.JsonProperty("initialCatalog")]
        public string InitialCatalog { get; set; }
        [Newtonsoft.Json.JsonProperty("rawConnectionString")]
        public string RawConnectionString { get; set; }
        [Newtonsoft.Json.JsonProperty("userManualConnectionString")]
        public bool UserManualConnectionString { get; set; }
        [Newtonsoft.Json.JsonProperty("trustedConnection")]
        public bool TrustedConnection { get; set; }
    }
}
