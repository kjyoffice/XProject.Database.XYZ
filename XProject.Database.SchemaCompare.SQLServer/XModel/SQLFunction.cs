using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLFunction
    {
        public XModel_UseOriginal.SQLFunction Original { get; private set; }
        public string FUNCTION_NAME { get; private set; }
        public string FUNCTION_DEFINITION { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        // 원본 데이터는, 이름이 같고 스키마가 다른 N개의 ROW이다 
        // 그로인해 데이터를 이름을 기준으로 그룹해서 스키마를 합치고 이 클래스로 넘어온다
        public SQLFunction(string function_Name, string function_Definition)
        {
            var function_DefinitionUse = function_Definition.ToUpper();

            this.Original = new XModel_UseOriginal.SQLFunction(function_Name, function_Definition);
            this.FUNCTION_NAME = function_Name.ToUpper();
            this.FUNCTION_DEFINITION = function_DefinitionUse;
            this.CheckSource = XValue.HashValue.SHA512Hash(function_DefinitionUse);
        }
    }
}

