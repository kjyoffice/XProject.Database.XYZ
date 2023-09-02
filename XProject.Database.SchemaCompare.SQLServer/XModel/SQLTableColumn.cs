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
        public string TABLE_NAME_Original { get; private set; }
        public string COLUMN_NAME_Original { get; private set; }
        public string IS_NULLABLE_Original { get; private set; }
        public string DATA_TYPE_Original { get; private set; }
        public string IS_IDENTITY_Original { get; private set; }
        public string CheckSource { get; private set; }
        public string ColumnSchema { get; private set; }
        public string AddColumnSchema { get; private set; }
        public string AlterColumnSchema { get; private set; }

        // -----------------------------------------------------

        private void CreateColumnSchema()
        {
            var sb = new StringBuilder();

            // IDNO INT NOT NULL IDENTITY(1,1)
            // MEMBERID UNIQUEIDENTIFIER NOT NULL
            // MEMBERNAME NVARCHAR(100) NULL

            // 컬럼 이름
            // Column name
            sb.Append((this.COLUMN_NAME_Original + " "));

            // 테이터 형식
            // Data Type
            var dt = this.DATA_TYPE;

            if ((dt == "NUMERIC") || (dt == "DECIMAL"))
            {
                // NUMERIC(18, 0)
                // DECIMAL(18, 0)
                sb.Append($"{dt}({this.PRECISION}, {this.SCALE}) ");
            }
            else if ((dt == "DATETIME2") || (dt == "DATETIMEOFFSET") || (dt == "TIME"))
            {
                // DATETIME2(3)
                // DATETIMEOFFSET(5)
                // TIME(7)
                sb.Append($"{dt}({this.SCALE}) ");
            }
            else if ((dt == "BINARY") || (dt == "CHAR") || (dt == "VARBINARY") || (dt == "VARCHAR") || (dt == "NCHAR") || (dt == "NVARCHAR"))
            {
                // BINARY(50)
                // CHAR(10)
                // VARBINARY(50) / VARBINARY(MAX)
                // VARCHAR(50) / VARCHAR(MAX)
                // NCHAR(10)
                // NVARCHAR(50) / NVARCHAR(MAX)
                var size = (
                    (this.MAX_LENGTH == -1) ?
                    "MAX" : 
                    (
                        (dt.Substring(0, 1) == "N") ?
                        (this.MAX_LENGTH / 2) :
                        this.MAX_LENGTH
                    ).ToString()
                );

                sb.Append($"{dt}({size}) ");
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
                sb.Append((dt + " "));
            }

            // NULL / NOT NULL
            sb.Append((((this.IS_NULLABLE == "YES") ? "NULL" : "NOT NULL") + " "));

            var columnSchema = sb.ToString();
            var identitySchema = (
                (this.IS_IDENTITY == "YES") ?
                $"IDENTITY({this.SEED_VALUE}, {this.INCREMENT_VALUE})" :
                string.Empty
            );
            var identitySchema_Description = (
                (identitySchema != string.Empty) ? 
                $"/* {identitySchema} - Please manual */" : 
                string.Empty
            );

            this.ColumnSchema = (columnSchema + identitySchema);
            this.AddColumnSchema = $"ALTER TABLE {this.TABLE_NAME} ADD {this.ColumnSchema};";
            // 컬럼을 변경할 땐 IDENTITY가 다른 방법으로 해야하는데.. 코드가 길다 -> 직접 하게끔 하자
            // Change column, but IDENTITY is different way.. code is long -> do it yourself
            this.AlterColumnSchema = $"ALTER TABLE {this.TABLE_NAME} ALTER COLUMN {columnSchema}; {identitySchema_Description}";
        }

        // -----------------------------------------------------

        public SQLTableColumn(DataRow dr) 
        {
            // Upper
            this.TABLE_NAME = dr["TABLE_NAME"].ToString().ToUpper();
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString().ToUpper();
            this.IS_NULLABLE = dr["IS_NULLABLE"].ToString().ToUpper();
            this.DATA_TYPE = dr["DATA_TYPE"].ToString().ToUpper();
            this.MAX_LENGTH = Convert.ToInt32(dr["MAX_LENGTH"]);
            this.PRECISION = Convert.ToInt32(dr["PRECISION"]);
            this.SCALE = Convert.ToInt32(dr["SCALE"]);
            this.IS_IDENTITY = dr["IS_IDENTITY"].ToString().ToUpper();
            this.SEED_VALUE = Convert.ToInt32(dr["SEED_VALUE"]);
            this.INCREMENT_VALUE = Convert.ToInt32(dr["INCREMENT_VALUE"]);
            // Original
            this.TABLE_NAME_Original = dr["TABLE_NAME"].ToString();
            this.COLUMN_NAME_Original = dr["COLUMN_NAME"].ToString();
            this.IS_NULLABLE_Original = dr["IS_NULLABLE"].ToString();
            this.DATA_TYPE_Original = dr["DATA_TYPE"].ToString();
            this.IS_IDENTITY_Original = dr["IS_IDENTITY"].ToString();

            this.CheckSource = XValue.HashValue.SHA512Hash(
                this.IS_NULLABLE,
                this.DATA_TYPE,
                this.MAX_LENGTH,
                this.PRECISION,
                this.SCALE,
                this.IS_IDENTITY,
                this.SEED_VALUE,
                this.INCREMENT_VALUE
            );

            this.CreateColumnSchema();
        }
    }
}
