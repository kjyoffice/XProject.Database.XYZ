using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_Original
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
            var constraint_Name = dr["CONSTRAINT_NAME"].ToString();
            var type_Desc = dr["TYPE_DESC"].ToString();
            var constraint_Definition = dr["CONSTRAINT_DEFINITION"].ToString();

            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME_Original = constraint_Name;
            this.TYPE_DESC_Original = type_Desc;
            this.CONSTRAINT_DEFINITION_Original = constraint_Definition;
            this.NotifyContent = $"{constraint_Name} / {type_Desc} / {constraint_Definition}";
        }
    }
}

