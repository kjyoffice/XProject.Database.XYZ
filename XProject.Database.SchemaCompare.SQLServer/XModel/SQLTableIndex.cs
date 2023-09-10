using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLTableIndex
    {
        public XModel_UseOriginal.SQLTableIndex Original { get; private set; }
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string INDEX_TYPE { get; private set; }
        public string CLUSTERED_TYPE { get; private set; }
        public int KEY_ORDINAL { get; private set; }
        public string COLUMN_NAME_And_ORDERBY_TYPE { get; private set; }
        public string CheckSourceHash { get; private set; }
        public string NotifyContent { get; private set; }

        // -----------------------------------------------------

        public SQLTableIndex(string table_Name, string constraint_Name, IEnumerable<XModel_DataOriginal.SQLTableIndex> stiList)
        {
            var original = new XModel_UseOriginal.SQLTableIndex(table_Name, constraint_Name, stiList);
            var index_Type = original.INDEX_TYPE.ToUpper();
            var clustered_Type = original.CLUSTERED_TYPE.ToUpper();
            var column_Name_And_OrderBy_Type = original.COLUMN_NAME_And_ORDERBY_TYPE.ToUpper();

            this.Original = original;
            this.TABLE_NAME = original.TABLE_NAME.ToUpper();
            this.CONSTRAINT_NAME = original.CONSTRAINT_NAME.ToUpper();
            this.INDEX_TYPE = index_Type;
            this.CLUSTERED_TYPE = clustered_Type;
            this.KEY_ORDINAL = original.KEY_ORDINAL;
            this.COLUMN_NAME_And_ORDERBY_TYPE = column_Name_And_OrderBy_Type;
            this.CheckSourceHash = XValue.HashValue.SHA512Hash(index_Type, clustered_Type, column_Name_And_OrderBy_Type);
            this.NotifyContent = $"{original.CONSTRAINT_NAME} / {original.CLUSTERED_TYPE} / {original.INDEX_TYPE} / {original.COLUMN_NAME_And_ORDERBY_TYPE}";
        }
    }
}

