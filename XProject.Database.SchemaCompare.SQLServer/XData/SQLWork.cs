using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace XProject.Database.SchemaCompare.SQLServer.XData
{
    public class SQLWork
    {
        private SqlConnectionStringBuilder ConnectionString { get; set; }
        private IEnumerable<XModel_DataOriginal.SQLTable> TableData { get; set; }
        private IEnumerable<XModel_DataOriginal.SQLTableColumn> TableColumnData { get; set; }
        private IEnumerable<XModel_DataOriginal.SQLTableIndex> TableIndexData { get; set; }
        private IEnumerable<XModel_DataOriginal.SQLTableForeignKey> TableForeignKeyData { get; set; }
        private IEnumerable<XModel_DataOriginal.SQLTableConstraints> TableConstraintsData { get; set; }
        private IEnumerable<XModel_DataOriginal.SQLTableTrigger> TableTriggerData { get; set; }
        private IEnumerable<XModel_DataOriginal.SQLProcedure> ProcedureData { get; set; }
        private IEnumerable<XModel_DataOriginal.SQLFunction> FunctionData { get; set; }
        
        // ---------------------------------

        public string ServerInfo
        {
            get
            {
                return (this.ConnectionString.DataSource + " / " + this.ConnectionString.InitialCatalog);
            }
        }

        // ---------------------------------

        private DataSet ExecuteDataSet(string query)
        {
            var result = new DataSet();

            using (var sc = new SqlConnection(this.ConnectionString.ConnectionString))
            {
                using (var cmd = new SqlCommand(query, sc))
                {
                    cmd.CommandType = CommandType.Text;

                    using (var sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(result, "TABLE1");
                    }
                }
            }

            return result;
        }

        // ---------------------------------

        public SQLWork(string connectionString)
        {
            this.ConnectionString = new SqlConnectionStringBuilder(connectionString);
            this.TableData = null;
            this.TableColumnData = null;
            this.TableIndexData = null;
            this.TableForeignKeyData = null;
            this.TableConstraintsData = null;
            this.TableTriggerData = null;
            this.ProcedureData = null;
            this.FunctionData = null;
        }

        public void DefaultSetting()
        {
            // 테이블
            var tableList = @"
                SELECT
                [NAME] AS TABLE_NAME
                FROM [SYS].[TABLES]
                WHERE (IS_MS_SHIPPED = 0)
                ORDER BY [NAME] ASC;
            ";
            // 컬럼
            var tableColumnList = @"
                SELECT
                A.[NAME] AS TABLE_NAME,
                B.[NAME] AS COLUMN_NAME,
                (
                    CASE B.IS_NULLABLE
                        WHEN 1 THEN N'YES'
                        ELSE N'NO'
                    END
                ) AS IS_NULLABLE,
                C.[NAME] AS DATA_TYPE,
                B.MAX_LENGTH,
                B.[PRECISION],
                B.SCALE,
                (
                    CASE B.IS_IDENTITY
                        WHEN 1 THEN N'YES'
                        ELSE N'NO'
                    END
                ) AS IS_IDENTITY,
                ISNULL(D.SEED_VALUE, 0) AS SEED_VALUE,
                ISNULL(D.INCREMENT_VALUE, 0) AS INCREMENT_VALUE
                FROM [SYS].[TABLES] AS A
                INNER JOIN [SYS].[COLUMNS] AS B ON (A.[OBJECT_ID] = B.[OBJECT_ID])
                INNER JOIN [SYS].[TYPES] AS C ON (
                    (B.SYSTEM_TYPE_ID = C.SYSTEM_TYPE_ID)
                    AND (B.USER_TYPE_ID = C.USER_TYPE_ID)
                )
                LEFT OUTER JOIN [SYS].[IDENTITY_COLUMNS] AS D ON (
                    (B.[OBJECT_ID] = D.[OBJECT_ID])
                    AND (B.[NAME] = D.[NAME])
                )
                WHERE (A.IS_MS_SHIPPED = 0)
                ORDER BY A.[NAME] ASC,
                B.COLUMN_ID ASC;
            ";
            // 인덱스
            var tableIndexList = @"
                SELECT 
                D.[NAME] AS TABLE_NAME,
                A.[NAME] AS CONSTRAINT_NAME,
                (
                    CASE 
                        WHEN ((A.IS_PRIMARY_KEY = 1) AND (A.IS_UNIQUE = 1)) THEN N'PRIMARY KEY'
                        WHEN ((A.IS_PRIMARY_KEY = 0) AND (A.IS_UNIQUE = 1)) THEN N'UNIQUE'
                        ELSE N'INDEX'
                    END
                ) AS INDEX_TYPE,
                A.[TYPE_DESC] AS CLUSTERED_TYPE,
                B.KEY_ORDINAL,
                C.[NAME] AS COLUMN_NAME,						
                (
                    CASE
                        WHEN (B.IS_DESCENDING_KEY = 1) THEN N'DESC'
                        ELSE N'ASC'
                    END
                ) AS ORDERBY_TYPE
                FROM  [SYS].[INDEXES] AS A 
                INNER JOIN [SYS].[INDEX_COLUMNS] AS B ON (
                    (A.[OBJECT_ID] = B.[OBJECT_ID])
                    AND (A.INDEX_ID = B.INDEX_ID)
                )
                INNER JOIN [SYS].[COLUMNS] AS C ON (
                    (B.[OBJECT_ID] = C.[OBJECT_ID]) 
                    AND (B.COLUMN_ID = C.COLUMN_ID)
                )
                INNER JOIN [SYS].[TABLES] AS D ON (A.[OBJECT_ID] = D.[OBJECT_ID])
                WHERE (D.IS_MS_SHIPPED = 0) 
                ORDER BY D.[NAME] ASC, 
                A.IS_PRIMARY_KEY DESC,
                A.[NAME] ASC,
                A.INDEX_ID ASC,
                B.KEY_ORDINAL ASC;
            ";
            // 외래키
            var tableForeignKeyList = @"
                SELECT 
                D.[NAME] AS TABLE_NAME,
                A.[NAME] AS CONSTRAINT_NAME,
                C.[NAME] AS COLUMN_NAME,
                F.[NAME] AS REFERENCE_TABLE_NAME,
                E.[NAME] AS REFERENCE_COLUMN_NAME
                FROM  [SYS].[FOREIGN_KEYS] AS A 
                INNER JOIN [SYS].[FOREIGN_KEY_COLUMNS] AS B ON (A.[OBJECT_ID] = B.CONSTRAINT_OBJECT_ID)
                INNER JOIN [SYS].[COLUMNS] AS C ON (
                    (B.PARENT_OBJECT_ID = C.[OBJECT_ID]) 
                    AND (B.PARENT_COLUMN_ID = C.COLUMN_ID)
                )
                INNER JOIN [SYS].[TABLES] AS D ON (A.PARENT_OBJECT_ID = D.[OBJECT_ID])
                INNER JOIN [SYS].[COLUMNS] AS E ON (
                    (B.REFERENCED_OBJECT_ID = E.[OBJECT_ID]) 
                    AND (B.REFERENCED_COLUMN_ID = E.COLUMN_ID)
                )
                INNER JOIN [SYS].[TABLES] AS F ON (A.REFERENCED_OBJECT_ID = F.[OBJECT_ID])
                WHERE (A.IS_MS_SHIPPED = 0)
                AND (D.IS_MS_SHIPPED = 0)
                AND (F.IS_MS_SHIPPED = 0)
                ORDER BY D.[NAME] ASC, 
                A.[NAME] ASC,
                B.PARENT_COLUMN_ID ASC,
                B.REFERENCED_COLUMN_ID ASC;
            ";
            // 제약조건
            var tableConstraintsList = @"
                SELECT
                A.TABLE_NAME AS TABLE_NAME,
                A.CONSTRAINT_NAME AS CONSTRAINT_NAME,
                A.[TYPE_DESC] AS [TYPE_DESC],
                A.CONSTRAINT_DEFINITION AS CONSTRAINT_DEFINITION
                FROM
                (
                    -- 기본값
	                SELECT 
	                B.[NAME] AS TABLE_NAME,
	                A.[NAME] AS CONSTRAINT_NAME,
	                A.[TYPE_DESC] AS [TYPE_DESC],
	                A.[DEFINITION] AS CONSTRAINT_DEFINITION
	                FROM [SYS].[DEFAULT_CONSTRAINTS] AS A
	                INNER JOIN [SYS].[TABLES] AS B ON (A.PARENT_OBJECT_ID = B.[OBJECT_ID])
	                WHERE (A.IS_MS_SHIPPED = 0)
	                AND (B.IS_MS_SHIPPED = 0)
	                UNION ALL
                    -- 체크
	                SELECT 
	                B.[NAME] AS TABLE_NAME,
	                A.[NAME] AS CONSTRAINT_NAME,
	                A.[TYPE_DESC] AS [TYPE_DESC],
	                A.[DEFINITION] AS CONSTRAINT_DEFINITION
	                FROM [SYS].[CHECK_CONSTRAINTS] AS A
	                INNER JOIN [SYS].[TABLES] AS B ON (A.PARENT_OBJECT_ID = B.[OBJECT_ID])
	                WHERE (A.IS_MS_SHIPPED = 0)
	                AND (B.IS_MS_SHIPPED = 0)
                ) AS A
                ORDER BY A.TABLE_NAME ASC,
                A.CONSTRAINT_NAME ASC;
            ";
            // 트리거
            var tableTriggerList = @"
                SELECT 
                B.[NAME] AS TABLE_NAME,
                A.[NAME] AS TRIGGER_NAME,
                C.[TEXT] AS TRIGGER_SCHEMA
                FROM [SYS].[TRIGGERS] AS A
                INNER JOIN [SYS].[TABLES] AS B ON (A.PARENT_ID = B.[OBJECT_ID])
                INNER JOIN [SYS].[SYSCOMMENTS] AS C ON (A.[OBJECT_ID] = C.ID)
                WHERE (A.IS_MS_SHIPPED = 0)
                AND (B.IS_MS_SHIPPED = 0)
                ORDER BY B.[NAME] ASC,
                A.[NAME] ASC,
                C.COLID ASC;
            ";
            // 프로시저
            var procedureList = @"
                SELECT 
                A.[NAME] AS ROUTINE_NAME,
                B.[TEXT] AS ROUTINE_DEFINITION
                FROM [SYS].[PROCEDURES] AS A
                INNER JOIN [SYS].[SYSCOMMENTS] AS B ON (A.[OBJECT_ID] = B.ID)
                WHERE (A.IS_MS_SHIPPED = 0)
                ORDER BY A.[NAME] ASC,
                B.COLID ASC;
            ";
            // 함수
            var functionList = @"
                -- FN / SQL_SCALAR_FUNCTION
                -- IF / SQL_INLINE_TABLE_VALUED_FUNCTION
                -- TF / SQL_TABLE_VALUED_FUNCTION
                SELECT 
                A.[NAME] AS FUNCTION_NAME,
                B.[TEXT] AS FUNCTION_DEFINITION
                FROM [SYS].[OBJECTS] AS A
                INNER JOIN [SYS].[SYSCOMMENTS] AS B ON (A.[OBJECT_ID] = B.ID)
                WHERE (A.[TYPE] IN (N'FN', N'IF', N'TF'))
                AND (A.IS_MS_SHIPPED = 0)
                ORDER BY A.[TYPE] ASC,
                A.[NAME] ASC,
                B.COLID ASC;
            ";
            // 쿼리를 1개로 묶고
            var query = string.Join(
                Environment.NewLine,
                new string[] {
                    tableList,
                    tableColumnList,
                    tableIndexList,
                    tableForeignKeyList,
                    tableConstraintsList,
                    tableTriggerList,
                    procedureList,
                    functionList
                }
            );
            // 쿼리 실행
            var eds = this.ExecuteDataSet(query);
            this.TableData = eds.Tables["TABLE1"].Rows.Cast<DataRow>().Select(x => new XModel_DataOriginal.SQLTable(x));
            this.TableColumnData = eds.Tables["TABLE11"].Rows.Cast<DataRow>().Select(x => new XModel_DataOriginal.SQLTableColumn(x));
            this.TableIndexData = eds.Tables["TABLE12"].Rows.Cast<DataRow>().Select(x => new XModel_DataOriginal.SQLTableIndex(x));
            this.TableForeignKeyData = eds.Tables["TABLE13"].Rows.Cast<DataRow>().Select(x => new XModel_DataOriginal.SQLTableForeignKey(x));
            this.TableConstraintsData = eds.Tables["TABLE14"].Rows.Cast<DataRow>().Select(x => new XModel_DataOriginal.SQLTableConstraints(x));
            this.TableTriggerData = eds.Tables["TABLE15"].Rows.Cast<DataRow>().Select(x => new XModel_DataOriginal.SQLTableTrigger(x));
            this.ProcedureData = eds.Tables["TABLE16"].Rows.Cast<DataRow>().Select(x => new XModel_DataOriginal.SQLProcedure(x));
            this.FunctionData = eds.Tables["TABLE17"].Rows.Cast<DataRow>().Select(x => new XModel_DataOriginal.SQLFunction(x));
        }

        public List<XModel.SQLTable> TableList()
        {
            return this.TableData.Select(x => new XModel.SQLTable(x)).ToList();
        }

        public List<XModel.SQLTableColumn> TableColumnList()
        {
            return this.TableColumnData.Select(x => new XModel.SQLTableColumn(x)).ToList();
        }

        public List<XModel.SQLTableIndex> TableIndexList()
        {
            // 인덱스 : 기본키, (클러스트/넌클러스트) 인덱스, 유니크
            return this.TableIndexData.GroupBy(
                    x => new {
                        x.TABLE_NAME,
                        x.CONSTRAINT_NAME
                    }
                )
                .Select(
                    x => new XModel.SQLTableIndex(
                        x.Key.TABLE_NAME,
                        x.Key.CONSTRAINT_NAME,
                        x.First().INDEX_TYPE,
                        x.First().CLUSTERED_TYPE,
                        x.First().KEY_ORDINAL,
                        string.Join(", ", x.Select(y => (y.COLUMN_NAME + " " + y.ORDERBY_TYPE)))
                    )
                ).ToList();
        }

        public List<XModel.SQLTableForeignKey> TableForeignKeyList()
        {
            // 외래키
            return TableForeignKeyData.GroupBy(
                    x => new
                    {
                        x.TABLE_NAME,
                        x.CONSTRAINT_NAME
                    }
                )
                .Select(
                    x => new XModel.SQLTableForeignKey(
                        x.Key.TABLE_NAME,
                        x.Key.CONSTRAINT_NAME,
                        string.Join(", ", x.Select(y => y.COLUMN_NAME)),
                        x.First().REFERENCE_TABLE_NAME,
                        string.Join(", ", x.Select(y => y.REFERENCE_COLUMN_NAME))
                    )
                )
                .ToList();
        }

        public List<XModel.SQLTableConstraints> TableConstraintsList()
        {
            // 제약조건 : 체크, 기본값
            return this.TableConstraintsData.Select(x => new XModel.SQLTableConstraints(x)).ToList();
        }

        public List<XModel.SQLTableTrigger> TableTriggerList()
        {
            // 트리거
            // 긴 트리거 내용인 경우 COLID를 순서대로 n개의 ROW에 스키마가 저장
            // 그로인해 트리거 이름당 1개의 SCHEMA로 만들기 위함
            return this.TableTriggerData.GroupBy(
                    x => new
                    {
                        x.TABLE_NAME,
                        x.TRIGGER_NAME
                    }
                )
                .Select(
                    x => new XModel.SQLTableTrigger(
                        x.Key.TABLE_NAME, 
                        x.Key.TRIGGER_NAME,
                        string.Join(string.Empty, x.Select(y => y.TRIGGER_SCHEMA)).Trim()
                    )
                ).ToList();
        }

        public List<XModel.SQLProcedure> ProcedureList()
        {
            // 프로시저
            return this.ProcedureData.GroupBy(x => x.ROUTINE_NAME)
                .Select(
                    x => new XModel.SQLProcedure(
                        x.Key,
                        string.Join(string.Empty, x.Select(y => y.ROUTINE_DEFINITION)).Trim()
                    )
                ).ToList();
        }

        public List<XModel.SQLFunction> FunctionList()
        {
            // 함수
            return this.FunctionData.GroupBy(x => x.FUNCTION_NAME)
                .Select(
                    x => new XModel.SQLFunction(
                        x.Key,
                        string.Join(string.Empty, x.Select(y => y.FUNCTION_DEFINITION)).Trim()
                    )
                ).ToList();
        }
    }
}
