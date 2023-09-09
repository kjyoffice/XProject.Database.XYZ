using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class SQLTableColumn
    {
        public XModel_Original.SQLTableColumn_Original Original { get; private set; }
        public string TABLE_NAME { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string IS_NULLABLE { get; private set; }
        public string DATA_TYPE { get; private set; }
        public int MAX_LENGTH { get; private set; }
        public int PRECISION { get; private set; }
        public int SCALE { get; private set; }
        public string IS_IDENTITY { get; private set; }
        public int SEED_VALUE { get; private set; }
        public int INCREMENT_VALUE { get; private set; }
        public string CheckSource { get; private set; }
        public string ColumnSchema { get; private set; }
        public string AddColumnSchema { get; private set; }
        public string AlterColumnSchema { get; private set; }

        // -----------------------------------------------------

        private void CreateColumnSchema(XModel_Original.SQLTableColumn_Original original, string table_Name, string data_Type, int precision, int scale, int max_Length, string is_Nullable, string is_Identity, int seed_Value, int increment_Value)
        {
            var sb = new StringBuilder();

            // IDNO INT NOT NULL IDENTITY(1,1)
            // MEMBERID UNIQUEIDENTIFIER NOT NULL
            // MEMBERNAME NVARCHAR(100) NULL

            // 컬럼 이름
            sb.Append((original.COLUMN_NAME + " "));

            // 테이터 형식
            if ((data_Type == "NUMERIC") || (data_Type == "DECIMAL"))
            {
                // NUMERIC(18, 0)
                // DECIMAL(18, 0)
                sb.Append($"{data_Type}({precision}, {scale}) ");
            }
            else if ((data_Type == "DATETIME2") || (data_Type == "DATETIMEOFFSET") || (data_Type == "TIME"))
            {
                // DATETIME2(3)
                // DATETIMEOFFSET(5)
                // TIME(7)
                sb.Append($"{data_Type}({scale}) ");
            }
            else if ((data_Type == "BINARY") || (data_Type == "CHAR") || (data_Type == "VARBINARY") || (data_Type == "VARCHAR") || (data_Type == "NCHAR") || (data_Type == "NVARCHAR"))
            {
                // BINARY(50)
                // CHAR(10)
                // VARBINARY(50) / VARBINARY(MAX)
                // VARCHAR(50) / VARCHAR(MAX)
                // NCHAR(10)
                // NVARCHAR(50) / NVARCHAR(MAX)
                var size = (
                    (max_Length == -1) ?
                    "MAX" : 
                    (
                        (data_Type.Substring(0, 1) == "N") ?
                        (max_Length / 2) :
                        max_Length
                    ).ToString()
                );

                sb.Append($"{data_Type}({size}) ");
            }
            else
            {
                // BIGINT
                // BIT
                // DATE
                // DATETIME
                // FLOAT
                // GEOGRAPHY
                // GEOMETRY
                // HIERARCHYID
                // IMAGE
                // INT
                // MONEY
                // REAL
                // SMALLDATETIME
                // SMALLINT
                // SMALLMONEY
                // SQL_VARIANT
                // TEXT
                // TIMESTAMP
                // TINYINT
                // UNIQUEIDENTIFIER
                // XML
                // NTEXT
                sb.Append((data_Type + " "));
            }

            // NULL / NOT NULL
            sb.Append((((is_Nullable == "YES") ? "NULL" : "NOT NULL") + " "));

            var columnSchema = sb.ToString();
            var identitySchema = (
                (is_Identity == "YES") ?
                $"IDENTITY({seed_Value}, {increment_Value})" :
                string.Empty
            );
            var identitySchema_Description = (
                (identitySchema != string.Empty) ? 
                $"/* {identitySchema} - Please manual */" : 
                string.Empty
            );
            var columnSchemaAndIdentity = (columnSchema + identitySchema);

            this.ColumnSchema = columnSchemaAndIdentity;
            this.AddColumnSchema = $"ALTER TABLE {table_Name} ADD {columnSchemaAndIdentity};";
            // 컬럼을 변경할 땐 IDENTITY가 다른 방법으로 해야하는데.. 코드가 길다 -> 직접 하게끔 하자
            this.AlterColumnSchema = $"ALTER TABLE {table_Name} ALTER COLUMN {columnSchema}; {identitySchema_Description}";
        }

        // -----------------------------------------------------

        public SQLTableColumn(DataRow dr)
        {
            var original = new XModel_Original.SQLTableColumn_Original(dr);
            var table_Name = dr["TABLE_NAME"].ToString().ToUpper();
            var column_Name = dr["COLUMN_NAME"].ToString().ToUpper();
            var is_Nullable = dr["IS_NULLABLE"].ToString().ToUpper();
            var data_Type = dr["DATA_TYPE"].ToString().ToUpper();
            var max_Length = Convert.ToInt32(dr["MAX_LENGTH"]);
            var precision = Convert.ToInt32(dr["PRECISION"]);
            var scale = Convert.ToInt32(dr["SCALE"]);
            var is_Identity = dr["IS_IDENTITY"].ToString().ToUpper();
            var seed_Value = Convert.ToInt32(dr["SEED_VALUE"]);
            var increment_Value = Convert.ToInt32(dr["INCREMENT_VALUE"]);

            this.Original = original;
            this.TABLE_NAME = table_Name;
            this.COLUMN_NAME = column_Name;
            this.IS_NULLABLE = is_Nullable;
            this.DATA_TYPE = data_Type;
            this.MAX_LENGTH = max_Length;
            this.PRECISION = precision;
            this.SCALE = scale;
            this.IS_IDENTITY = is_Identity;
            this.SEED_VALUE = seed_Value;
            this.INCREMENT_VALUE = increment_Value;
            this.CheckSource = XValue.HashValue.SHA512Hash(is_Nullable, data_Type, max_Length, precision, scale, is_Identity, seed_Value, increment_Value);
            this.CreateColumnSchema(original, table_Name, data_Type, precision, scale, max_Length, is_Nullable, is_Identity, seed_Value, increment_Value);
        }
    }
}

