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
        public XModel_Original.SQLTableIndex_Original Original { get; private set; }
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
            var index_TypeUse = index_Type.ToUpper();
            var clustered_TypeUse = clustered_Type.ToUpper();
            var column_NameUse = column_Name.ToUpper();

            this.Original = original;
            this.TABLE_NAME = table_Name.ToUpper();
            this.CONSTRAINT_NAME = constraint_Name.ToUpper();
            this.INDEX_TYPE = index_TypeUse;
            this.CLUSTERED_TYPE = clustered_TypeUse;
            this.KEY_ORDINAL = key_Ordinal;
            this.COLUMN_NAME_And_ORDERBY_TYPE = column_NameUse;
            this.CheckSourceHash = XValue.HashValue.SHA512Hash(index_TypeUse, clustered_TypeUse, column_NameUse);
            this.NotifyContent = $"{original.CONSTRAINT_NAME} / {original.CLUSTERED_TYPE} / {original.INDEX_TYPE} / {original.COLUMN_NAME}";
        }
    }
}

