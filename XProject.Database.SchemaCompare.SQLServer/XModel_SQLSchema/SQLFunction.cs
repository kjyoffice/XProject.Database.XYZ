﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel_SQLSchema
{
    public class SQLFunction
    {
        public XModel_SQLSchema_UseOriginal.SQLFunction Original { get; private set; }
        public string FUNCTION_NAME { get; private set; }
        public string FUNCTION_DEFINITION { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        public SQLFunction(List<XModel_SQLSchema_Original.SQLFunction> sfList)
        {
            var original = new XModel_SQLSchema_UseOriginal.SQLFunction(sfList);
            var function_Definition = original.FUNCTION_DEFINITION.ToUpper();

            this.Original = original;
            this.FUNCTION_NAME = original.FUNCTION_NAME.ToUpper();
            this.FUNCTION_DEFINITION = function_Definition;
            this.CheckSource = XValue.HashValue.SHA512Hash(function_Definition);
        }
    }
}

