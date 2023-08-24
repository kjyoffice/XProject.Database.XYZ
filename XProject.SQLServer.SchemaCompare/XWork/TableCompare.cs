using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace XProject.SQLServer.SchemaCompare.XWork
{
    public class TableCompare
    {
        public static void ExecuteNow(XData.SQLWork sourceSQL, XData.SQLWork targetSQL, Action<string> workResult, string schemaDirectory)
        {
            // 테이블 리스트 비교 결과
            // Table list compare result
            var tableResult = TableCompare.Table(sourceSQL.TableList(), targetSQL.TableList());
            // 컬럼 리스트
            // Column list
            var sourceColumnList = sourceSQL.TableColumnList();
            var targetColumnList = targetSQL.TableColumnList();
            // 인덱스 리스트
            // Index list
            var sourceIndexList = sourceSQL.TableIndexList();
            var targetIndexList = targetSQL.TableIndexList();
            // 참조키 리스트
            // Foreign key list
            var sourceForeignKeyList = sourceSQL.TableForeignKeyList();
            var targetForeignKeyList = targetSQL.TableForeignKeyList();
            // 제약조건 리스트
            // Constraints list
            var sourceConstraintList = sourceSQL.TableConstraintsList();
            var targetConstraintList = targetSQL.TableConstraintsList();
            // 트리거 리스트
            // Trigger list
            var sourceTriggerList = sourceSQL.TableTriggerList();
            var targetTriggerList = targetSQL.TableTriggerList();

            // 존재하지 않는 테이블
            // Not exist table
            workResult(string.Empty);
            workResult("<<<<<<<<<< 존재하지 않는 테이블 >>>>>>>>>>");
            workResult("<<<<<<<<<< Not exist table >>>>>>>>>>");
            workResult(string.Join(Environment.NewLine, tableResult.NotExistTableList.Select(x => x.TABLE_NAME_Original)));

            // 테이블 비교
            // Table compare
            workResult(string.Empty);
            workResult("<<<<<<<<<< 존재하는 테이블 >>>>>>>>>>");
            workResult("<<<<<<<<<< Exist table >>>>>>>>>>");
            foreach (var table in tableResult.ExistTableList)
            {
                var compareResult = new Dictionary<string, string>() {
                    { "컬럼 (COLUMN)", TableCompare.TableColumn(sourceColumnList, targetColumnList, table.TABLE_NAME) },
                    { "인덱스 (PRIMARY KEY / INDEX / UNIQUE)", TableCompare.TableIndex(sourceIndexList, targetIndexList, table.TABLE_NAME) },
                    { "외래키 (FOREIGN KEY)", TableCompare.TableForeignKey(sourceForeignKeyList, targetForeignKeyList, table.TABLE_NAME) },
                    { "제약조건 (CHECK, DEFAULT)", TableCompare.TableConstraints(sourceConstraintList, targetConstraintList, table.TABLE_NAME) },
                    { "트리거 (TRIGGER)", TableCompare.TableTrigger(sourceTriggerList, targetTriggerList, table.TABLE_NAME, schemaDirectory) }
                }.Where(x => (x.Value != string.Empty));

                // 차이가 있는 테이블만 뿌린다
                // Only show different table
                if (compareResult.Count() > 0)
                {
                    // 테이블 이름 뿌리고
                    // Show table name
                    workResult(string.Empty);
                    workResult($">>>>>>>>>> {table.TABLE_NAME_Original}");

                    foreach (var kvp in compareResult)
                    {
                        workResult(string.Empty);
                        workResult($"----- {kvp.Key} -----");
                        workResult(kvp.Value);
                    }
                }
            }
        }

        private static XModel.TableResult Table(List<XModel.SQLTable> sourceAllDataList, List<XModel.SQLTable> targetAllDataList)
        {
            // 테이블 리스트 가져와서 소스를 기준으로 LEFT OUTER JOIN
            // Get table list and LEFT OUTER JOIN with source
            var compareResult = sourceAllDataList.GroupJoin(
                targetAllDataList,
                x => x.TABLE_NAME,
                y => y.TABLE_NAME,
                (x, y) => new
                {
                    Source = x,
                    Target = y.FirstOrDefault()
                }
            ).ToList();
            var result = new XModel.TableResult(
                // 타겟에 존재하는 테이블 - 즉 양쪽 다 있다
                // Exist table in target - both exist
                compareResult.Where(x => (x.Target != null)).Select(x => x.Source).ToList(),
                // 타겟에 존재하지 않는 테이블 리스트
                // Not exist table in target
                compareResult.Where(x => (x.Target == null)).Select(x => x.Source).ToList()
            );

            return result;
        }

        private static string TableColumn(List<XModel.SQLTableColumn> sourceAllDataList, List<XModel.SQLTableColumn> targetAllDataList, string tableName)
        {
            // 테이블 이름으로 검색된 컬럼 리스트
            // Column list searched by table name
            var sourceDataList = sourceAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
            var targetDataList = targetAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
            // 컬럼 정보는 1:1로 매칭되므로 LEFT OUTER JOIN진행
            // Column information is matched 1:1 so LEFT OUTER JOIN
            var compareResultList = sourceDataList.GroupJoin(
                    targetDataList,
                    x => x.COLUMN_NAME,
                    y => y.COLUMN_NAME,
                    (x, y) => new
                    {
                        Source = x,
                        Target = y.FirstOrDefault()
                    }
                )
                .Where(x => (
                        (x.Target == null) ||
                        (
                            (x.Target != null) &&
                            (x.Source.CheckSource != x.Target.CheckSource)
                        )
                    )
                )
                .Select(
                    x => (
                        x.Source.COLUMN_NAME_Original + " : " + 
                        (
                            (x.Target == null) ? 
                            ("컬럼 없음(Not exist column) - " + x.Source.ColumnSchema) : 
                            (
                                "컬럼이 다름(Different column)" + Environment.NewLine + 
                                "- 소스(Source) : " + x.Source.ColumnSchema + Environment.NewLine +
                                "- 타겟(Target) : " + x.Target.ColumnSchema
                            )
                        )
                    )
                );
            var result = string.Join(Environment.NewLine, compareResultList);

            return result;
        }

        private static string TableIndex(List<XModel.SQLTableIndex> sourceAllDataList, List<XModel.SQLTableIndex> targetAllDataList, string tableName)
        {
            // 테이블 이름으로 검색된 인덱스 리스트
            // Index list searched by table name
            var sourceDataList = sourceAllDataList.Where(x => (x.TABLE_NAME == tableName));
            var targetDataList = targetAllDataList.Where(x => (x.TABLE_NAME == tableName));
            // INNER JOIN 
            var matchNameList = sourceDataList.Join(
                targetDataList,
                x => x.CONSTRAINT_NAME,
                y => y.CONSTRAINT_NAME,
                (x, y) => new
                {
                    Source = x,
                    Target = y
                }
            );
            // INNER JOIN된거 이름만 가져오기
            // Get only name of INNER JOIN
            var matchNameOnlyList = matchNameList.Select(x => x.Source.CONSTRAINT_NAME).Distinct();
            var unMatchNameList = matchNameList.Where(x => (x.Source.CheckSourceHash != x.Target.CheckSourceHash));
            // INNER JOIN에 포함 안된거 가져오기 - NOT IN
            // Get not included in INNER JOIN - NOT IN
            var sourceNotInNameList = sourceDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var targetNotInNameList = targetDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var sb = new StringBuilder();

            if (unMatchNameList.Count() > 0)
            {
                sb.AppendLine("***** 이름은 같지만 속성이 다름");
                sb.AppendLine("***** Name is same but attribute is different");
                sb.AppendLine(
                    string.Join(
                        Environment.NewLine,
                        unMatchNameList.Select(
                            x => (
                                $"- 소스(Source) : {x.Source.NotifyContent}" + Environment.NewLine +
                                $"- 타겟(Target) : {x.Target.NotifyContent}" + Environment.NewLine
                            )
                        )
                    )
                );
            }

            if ((sourceNotInNameList.Count() > 0) || (targetNotInNameList.Count() > 0))
            {
                sb.AppendLine("***** 이름이 다름 (같은거지만 랜덤의 이름으로 다를 수 있음) ");
                sb.AppendLine("***** Name is different (same but can be different with random name) ");
                sb.AppendLine("*** 소스(Source)");
                sb.AppendLine(string.Join(Environment.NewLine, sourceNotInNameList.Select(x => ("- " + x.NotifyContent))));
                sb.AppendLine("*** 타겟(Target)");
                sb.AppendLine(string.Join(Environment.NewLine, targetNotInNameList.Select(x => ("- "+ x.NotifyContent))));
            }

            var result = sb.ToString();

            return result;
        }

        private static string TableForeignKey(List<XModel.SQLTableForeignKey> sourceAllDataList, List<XModel.SQLTableForeignKey> targetAllDataList, string tableName)
        {
            // 테이블 이름으로 외래키 리스트 받기 
            // Get foreign key list by table name
            var sourceDataList = sourceAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
            var targetDataList = targetAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
            // INNER JOIN 
            var matchNameList = sourceDataList.Join(
                targetDataList,
                x => x.CONSTRAINT_NAME,
                y => y.CONSTRAINT_NAME,
                (x, y) => new
                {
                    Source = x,
                    Target = y
                }
            );
            var unMatchNameList = matchNameList.Where(x => (x.Source.CheckSourceHash != x.Target.CheckSourceHash));
            // INNER JOIN된거 이름만 가져오기
            // Get only name of INNER JOIN
            var matchNameOnlyList = matchNameList.Select(x => x.Source.CONSTRAINT_NAME).Distinct();
            // INNER JOIN에 포함 안된거 가져오기 - NOT IN
            // Get not included in INNER JOIN - NOT IN
            var sourceNotInNameList = sourceDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var targetNotInNameList = targetDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var sb = new StringBuilder();

            if (unMatchNameList.Count() > 0)
            {
                sb.AppendLine("***** 이름은 같지만 속성이 다름");
                sb.AppendLine("***** Name is same but attribute is different");
                sb.AppendLine(
                    string.Join(
                        Environment.NewLine,
                        unMatchNameList.Select(
                            x => (
                                $"- 소스 속성(Source attribute) : {x.Source.NotifyContent}" + Environment.NewLine +
                                $"- 타겟 속성(Target attribute) : {x.Target.NotifyContent}" + Environment.NewLine
                            )
                        )
                    )
                );
            }

            if ((sourceNotInNameList.Count() > 0) || (targetNotInNameList.Count() > 0))
            {
                sb.AppendLine("***** 이름이 다름 (같은거지만 랜덤의 이름으로 다를 수 있음) ");
                sb.AppendLine("***** Name is different (same but can be different with random name) ");
                sb.AppendLine("*** 소스(Source)");
                sb.AppendLine(string.Join(Environment.NewLine, sourceNotInNameList.Select(x => ("- " + x.NotifyContent))));
                sb.AppendLine("*** 타겟(Target)");
                sb.AppendLine(string.Join(Environment.NewLine, targetNotInNameList.Select(x => ("- " + x.NotifyContent))));
            }

            var result = sb.ToString();

            return result;
        }

        private static string TableConstraints(List<XModel.SQLTableConstraints> sourceAllDataList, List<XModel.SQLTableConstraints> targetAllDataList, string tableName)
        {
            // 테이블 이름으로 검색된 제약조건 리스트
            // Constraint list searched by table name
            var sourceDataList = sourceAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
            var targetDataList = targetAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
            // INNER JOIN 
            var matchNameList = sourceDataList.Join(
                targetDataList,
                x => x.CONSTRAINT_NAME,
                y => y.CONSTRAINT_NAME,
                (x, y) => new
                {
                    Source = x,
                    Target = y
                }
            );
            var unMatchNameList = matchNameList.Where(x => (x.Source.CheckSourceHash != x.Target.CheckSourceHash));
            // INNER JOIN된거 이름만 가져오기
            // Get only name of INNER JOIN
            var matchNameOnlyList = matchNameList.Select(x => x.Source.CONSTRAINT_NAME).Distinct();
            // INNER JOIN에 포함 안된거 가져오기 - NOT IN
            // Get not included in INNER JOIN - NOT IN
            var sourceNotInNameList = sourceDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var targetNotInNameList = targetDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var sb = new StringBuilder();

            if (unMatchNameList.Count() > 0)
            {
                sb.AppendLine("***** 이름은 같지만 속성이 다름");
                sb.AppendLine("***** Name is same but attribute is different");
                sb.AppendLine(
                    string.Join(
                        Environment.NewLine,
                        unMatchNameList.Select(
                            x => (
                                $"- 소스 속성(Source attribute) : {x.Source.NotifyContent}" + Environment.NewLine +
                                $"- 타겟 속성(Target attribute) : {x.Target.NotifyContent}" + Environment.NewLine
                            )
                        )
                    )
                );
            }

            if ((sourceNotInNameList.Count() > 0) || (targetNotInNameList.Count() > 0))
            {
                sb.AppendLine("***** 이름이 다름 (같은거지만 랜덤의 이름으로 다를 수 있음) ");
                sb.AppendLine("***** Name is different (same but can be different with random name) ");
                sb.AppendLine("*** 소스(Source)");
                sb.AppendLine(string.Join(Environment.NewLine, sourceNotInNameList.Select(x => ("- " + x.NotifyContent))));
                sb.AppendLine("*** 타겟(Target)");
                sb.AppendLine(string.Join(Environment.NewLine, targetNotInNameList.Select(x => ("- " + x.NotifyContent))));
            }

            var result = sb.ToString();

            return result;
        }

        private static string TableTrigger(List<XModel.SQLTableTrigger> sourceAllDataList, List<XModel.SQLTableTrigger> targetAllDataList, string tableName, string schemaDirectory)
        {
            // 테이블 이름으로 검색된 트리거 리스트
            // Trigger list searched by table name
            var sourceDataList = sourceAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
            var targetDataList = targetAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
            // 트리거 정보는 1:1로 매칭되므로 LEFT OUTER JOIN진행
            // Trigger information is matched 1:1, so LEFT OUTER JOIN is performed
            var compareResultList = sourceDataList.GroupJoin(
                targetDataList,
                x => x.TRIGGER_NAME,
                y => y.TRIGGER_NAME,
                (x, y) => new
                {
                    Source = x,
                    Target = y.FirstOrDefault()
                }
            );
            // 타겟에 존재하는 트리거 - 즉 양쪽 다 있다
            // Trigger that exists in target - that is, both sides exist
            var existTriggerList = compareResultList.Where(x => ((x.Target != null) && (x.Source.CheckSource != x.Target.CheckSource))).ToList();
            // 타겟에 존재하지 않는 트리거 리스트
            // Trigger list not existing in target
            var notExistTriggerList = compareResultList.Where(x => (x.Target == null)).ToList();
            var sb = new StringBuilder();

            if (notExistTriggerList.Count > 0)
            {
                // 존재하지 않는 트리거
                // Trigger that does not exist
                sb.AppendLine(string.Empty);
                sb.AppendLine("***** 존재하지 않음");
                sb.AppendLine("***** Not exist");
                sb.AppendLine(string.Join(Environment.NewLine, existTriggerList.Select(x => x.Source.TRIGGER_NAME_Original)));

                // CREATE TRIGGER 스키마 내보내기
                // Export CREATE TRIGGER schema
                existTriggerList.ForEach(
                    x =>
                    ExportWork.ExportSchema(
                        Path.Combine(schemaDirectory, "TRIGGER", tableName, "CREATE"),
                        x.Source.TRIGGER_NAME_Original, 
                        x.Source.TRIGGER_SCHEMA_Original
                    )
                );
            }

            if (existTriggerList.Count > 0)
            {
                // 존재하지만 다른 트리거
                // Trigger that exists but is different
                sb.AppendLine(string.Empty);
                sb.AppendLine("***** 이름은 같지만 스키마가 다름");
                sb.AppendLine("***** Name is same but schema is different");
                sb.AppendLine(string.Join(Environment.NewLine, existTriggerList.Select(x => x.Source.TRIGGER_NAME_Original)));

                // CREATE TRIGGER 스키마 내보내기
                // Export CREATE TRIGGER schema
                existTriggerList.ForEach(
                    x =>
                    ExportWork.ExportSchema(
                        Path.Combine(schemaDirectory, "TRIGGER", tableName, "ALTER"),
                        x.Source.TRIGGER_NAME_Original,
                        x.Source.TRIGGER_SCHEMA_Original,
                        x.Target.TRIGGER_SCHEMA_Original
                    )
                );
            }

            var result = sb.ToString();

            return result;
        }
    }
}
