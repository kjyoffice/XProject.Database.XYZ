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
        public XModel_Original.SQLTableConstraints_Original Original { get; private set; }
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string TYPE_DESC { get; private set; }
        public string CONSTRAINT_DEFINITION { get; private set; }
        public string CheckSourceHash { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableConstraints(DataRow dr)
        {
            var original = new XModel_Original.SQLTableConstraints_Original(dr);
            var type_Desc = dr["TYPE_DESC"].ToString().ToUpper();
            var constraint_Definition = dr["CONSTRAINT_DEFINITION"].ToString().ToUpper();

            this.Original = original;
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString().ToUpper();
            this.TYPE_DESC = type_Desc;
            this.CONSTRAINT_DEFINITION = constraint_Definition;
            this.CheckSourceHash = XValue.HashValue.SHA512Hash(type_Desc, constraint_Definition);
            this.NotifyContent = $"{original.CONSTRAINT_NAME} / {original.TYPE_DESC} / {original.CONSTRAINT_DEFINITION}";
        }
    }
}


