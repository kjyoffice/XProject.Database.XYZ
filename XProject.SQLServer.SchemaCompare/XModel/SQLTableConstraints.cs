using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.SQLServer.SchemaCompare.XModel
{
    public class SQLTableConstraints
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string TYPE_DESC { get; private set; }
        public string CONSTRAINT_DEFINITION { get; private set; }
        public string TABLE_NAME_Original { get; private set; }
        public string CONSTRAINT_NAME_Original { get; private set; }
        public string TYPE_DESC_Original { get; private set; }
        public string CONSTRAINT_DEFINITION_Original { get; private set; }
        public string CheckSourceHash { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableConstraints(DataRow dr)
        {
            // Upper
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString().ToUpper();
            this.TYPE_DESC = dr["TYPE_DESC"].ToString().ToUpper();
            this.CONSTRAINT_DEFINITION = dr["CONSTRAINT_DEFINITION"].ToString().ToUpper();
            // Original
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME_Original = dr["CONSTRAINT_NAME"].ToString();
            this.TYPE_DESC_Original = dr["TYPE_DESC"].ToString();
            this.CONSTRAINT_DEFINITION_Original = dr["CONSTRAINT_DEFINITION"].ToString();

            this.CheckSourceHash = XValue.HashValue.SHA512Hash(this.TYPE_DESC, this.CONSTRAINT_DEFINITION);
            this.NotifyContent = $"{this.CONSTRAINT_NAME_Original} / {this.TYPE_DESC_Original} / {this.CONSTRAINT_DEFINITION_Original}";
        }
    }
}
