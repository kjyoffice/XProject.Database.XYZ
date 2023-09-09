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
        public XModel_DataOriginal.SQLTableConstraints Original { get; private set; }
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string TYPE_DESC { get; private set; }
        public string CONSTRAINT_DEFINITION { get; private set; }
        public string CheckSourceHash { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableConstraints(XModel_DataOriginal.SQLTableConstraints original)
        {
            var type_Desc = original.TYPE_DESC.ToUpper();
            var constraint_Definition = original.CONSTRAINT_DEFINITION.ToUpper();

            this.Original = original;
            this.TABLE_NAME = original.TABLE_NAME.ToUpper();
            this.CONSTRAINT_NAME = original.CONSTRAINT_NAME.ToUpper();
            this.TYPE_DESC = type_Desc;
            this.CONSTRAINT_DEFINITION = constraint_Definition;
            this.CheckSourceHash = XValue.HashValue.SHA512Hash(type_Desc, constraint_Definition);
            this.NotifyContent = $"{original.CONSTRAINT_NAME} / {original.TYPE_DESC} / {original.CONSTRAINT_DEFINITION}";
        }
    }
}


