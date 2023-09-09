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
        public XModel_DataOriginal.SQLTableColumn Original { get; private set; }
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

        private void CreateColumnSchema(XModel_DataOriginal.SQLTableColumn original, string data_Type, string is_Nullable, string is_Identity)
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
                sb.Append($"{data_Type}({original.PRECISION}, {original.SCALE}) ");
            }
            else if ((data_Type == "DATETIME2") || (data_Type == "DATETIMEOFFSET") || (data_Type == "TIME"))
            {
                // DATETIME2(3)
                // DATETIMEOFFSET(5)
                // TIME(7)
                sb.Append($"{data_Type}({original.SCALE}) ");
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
                    (original.MAX_LENGTH == -1) ?
                    "MAX" : 
                    (
                        (data_Type.Substring(0, 1) == "N") ?
                        (original.MAX_LENGTH / 2) :
                        original.MAX_LENGTH
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
                $"IDENTITY({original.SEED_VALUE}, {original.INCREMENT_VALUE})" :
                string.Empty
            );
            var identitySchema_Description = (
                (identitySchema != string.Empty) ? 
                $"/* {identitySchema} - Please manual */" : 
                string.Empty
            );
            var columnSchemaAndIdentity = (columnSchema + identitySchema);

            this.ColumnSchema = columnSchemaAndIdentity;
            this.AddColumnSchema = $"ALTER TABLE {original.TABLE_NAME} ADD {columnSchemaAndIdentity};";
            // 컬럼을 변경할 땐 IDENTITY가 다른 방법으로 해야하는데.. 코드가 길다 -> 직접 하게끔 하자
            this.AlterColumnSchema = $"ALTER TABLE {original.TABLE_NAME} ALTER COLUMN {columnSchema}; {identitySchema_Description}";
        }

        // -----------------------------------------------------

        public SQLTableColumn(XModel_DataOriginal.SQLTableColumn original)
        {
            var is_Nullable = original.IS_NULLABLE.ToUpper();
            var data_Type = original.DATA_TYPE.ToUpper();
            var is_Identity = original.IS_IDENTITY.ToUpper();

            this.Original = original;
            this.TABLE_NAME = original.TABLE_NAME.ToUpper();
            this.COLUMN_NAME = original.COLUMN_NAME.ToUpper();
            this.IS_NULLABLE = is_Nullable;
            this.DATA_TYPE = data_Type;
            this.MAX_LENGTH = original.MAX_LENGTH;
            this.PRECISION = original.PRECISION;
            this.SCALE = original.SCALE;
            this.IS_IDENTITY = is_Identity;
            this.SEED_VALUE = original.SEED_VALUE;
            this.INCREMENT_VALUE = original.INCREMENT_VALUE;
            this.CheckSource = XValue.HashValue.SHA512Hash(is_Nullable, data_Type, original.MAX_LENGTH, original.PRECISION, original.SCALE, is_Identity, original.SEED_VALUE, original.INCREMENT_VALUE);
            this.CreateColumnSchema(original, data_Type, is_Nullable, is_Identity);
        }
    }
}

