using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLTableConstraints_Original
    {
        public string TABLE_NAME_Original { get; private set; }
        public string CONSTRAINT_NAME_Original { get; private set; }
        public string TYPE_DESC_Original { get; private set; }
        public string CONSTRAINT_DEFINITION_Original { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableConstraints_Original(DataRow dr)
        {
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME_Original = dr["CONSTRAINT_NAME"].ToString();
            this.TYPE_DESC_Original = dr["TYPE_DESC"].ToString();
            this.CONSTRAINT_DEFINITION_Original = dr["CONSTRAINT_DEFINITION"].ToString();
            this.NotifyContent = $"{this.CONSTRAINT_NAME_Original} / {this.TYPE_DESC_Original} / {this.CONSTRAINT_DEFINITION_Original}";
        }
    }
}
