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
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string TYPE_DESC { get; private set; }
        public string CONSTRAINT_DEFINITION { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableConstraints_Original(DataRow dr)
        {
            var constraint_Name = dr["CONSTRAINT_NAME"].ToString();
            var type_Desc = dr["TYPE_DESC"].ToString();
            var constraint_Definition = dr["CONSTRAINT_DEFINITION"].ToString();

            this.TABLE_NAME = dr["TABLE_NAME"].ToString();
            this.CONSTRAINT_NAME = constraint_Name;
            this.TYPE_DESC = type_Desc;
            this.CONSTRAINT_DEFINITION = constraint_Definition;
            this.NotifyContent = $"{constraint_Name} / {type_Desc} / {constraint_Definition}";
        }
    }
}

