using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Database.SchemaCompare.UI.XModel
{
    public class DatabaseTypeItem
    {
        public string TypeID { get; private set; }
        public string DisplayTypeID { get; private set; }

        // -----------------------------------------------------------

        public DatabaseTypeItem(string displayTypeID)
        {
            this.TypeID = displayTypeID.ToUpper();
            this.DisplayTypeID = displayTypeID;
        }

        public bool IsMatch(string typeID)
        {
            return (this.TypeID == typeID);
        }
    }
}
