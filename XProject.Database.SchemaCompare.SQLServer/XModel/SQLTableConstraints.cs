using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLTableConstraints
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string TYPE_DESC { get; private set; }
        public string CONSTRAINT_DEFINITION { get; private set; }
        public SQLTableConstraints_Original Original { get; private set; }
        public string CheckSourceHash { get; private set; }

        // -----------------------------------------------------

        public SQLTableConstraints(DataRow dr)
        {
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString().ToUpper();
            this.TYPE_DESC = dr["TYPE_DESC"].ToString().ToUpper();
            this.CONSTRAINT_DEFINITION = dr["CONSTRAINT_DEFINITION"].ToString().ToUpper();
            this.Original = new SQLTableConstraints_Original(dr);
            this.CheckSourceHash = XValue.HashValue.SHA512Hash(this.TYPE_DESC, this.CONSTRAINT_DEFINITION);
        }
    }
}
