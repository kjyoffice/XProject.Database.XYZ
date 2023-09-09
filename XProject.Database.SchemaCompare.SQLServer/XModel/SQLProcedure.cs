using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLProcedure
    {
        public XModel_UseOriginal.SQLProcedure Original { get; private set; }
        public string ROUTINE_NAME { get; private set; }
        public string ROUTINE_DEFINITION { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        // 원본 데이터는, 이름이 같고 스키마가 다른 N개의 ROW이다 
        // 그로인해 데이터를 이름을 기준으로 그룹해서 스키마를 합치고 이 클래스로 넘어온다
        public SQLProcedure(string routine_Name, string routine_Definition)
        {
            var routine_DefinitionUse = routine_Definition.ToUpper();

            this.Original = new XModel_UseOriginal.SQLProcedure(routine_Name, routine_Definition);
            this.ROUTINE_NAME = routine_Name.ToUpper();
            this.ROUTINE_DEFINITION = routine_DefinitionUse;
            this.CheckSource = XValue.HashValue.SHA512Hash(routine_DefinitionUse);
        }
    }
}

