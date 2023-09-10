using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace XProject.Database.SchemaCompare.SQLServer.XWork
{
    public class TableCompare
    {
        public static void ExecuteNow(XModel.ProcessXSupport pxs)
        {
            // 테이블 리스트 비교 결과
            var tableResult = TableCompare.Table(pxs);
            // 컬럼 리스트
            var allColumnList = pxs.TableColumnList();
            // 인덱스 리스트
            var allIndexList = pxs.TableIndexList();
            // 참조키 리스트
            var allForeignKeyList = pxs.TableForeignKeyList();
            // 제약조건 리스트
            var allConstraintList = pxs.TableConstraintsList();
            // 트리거 리스트
            var allTriggerList = pxs.TableTriggerList();

            // 존재하지 않는 테이블
            pxs.WriteReport(string.Empty);
            pxs.WriteReport("<<<<<<<<<< 존재하지 않는 테이블 >>>>>>>>>>");
            pxs.WriteReport(string.Join(Environment.NewLine, tableResult.NotExistTableList.Select(x => x.Original.TABLE_NAME)));

            // 테이블 비교
            pxs.WriteReport(string.Empty);
            pxs.WriteReport("<<<<<<<<<< 존재하는 테이블 >>>>>>>>>>");

            foreach (var table in tableResult.ExistTableList)
            {
                var compareResult = new Dictionary<string, string>() {
                    { "컬럼 (COLUMN)", TableCompare.TableColumn(pxs, table.TABLE_NAME, allColumnList) },
                    { "인덱스 (PRIMARY KEY / INDEX / UNIQUE)", TableCompare.TableIndex(pxs, table.TABLE_NAME, allIndexList) },
                    { "외래키 (FOREIGN KEY)", TableCompare.TableForeignKey(pxs, table.TABLE_NAME, allForeignKeyList) },
                    { "제약조건 (CHECK, DEFAULT)", TableCompare.TableConstraints(pxs, table.TABLE_NAME, allConstraintList) },
                    { "트리거 (TRIGGER)", TableCompare.TableTrigger(pxs, table.TABLE_NAME, allTriggerList) }
                }.Where(x => (x.Value != string.Empty));

                // 차이가 있는 테이블만 뿌린다
                if (compareResult.Count() > 0)
                {
                    // 테이블 이름 뿌리고
                    pxs.WriteReport(string.Empty);
                    pxs.WriteReport($">>>>>>>>>> {table.Original.TABLE_NAME}");

                    foreach (var kvp in compareResult)
                    {
                        pxs.WriteReport(string.Empty);
                        pxs.WriteReport($"----- {kvp.Key} -----");
                        pxs.WriteReport(kvp.Value);
                    }
                }
            }
        }

        private static XModel.TableResult Table(XModel.ProcessXSupport pxs)
        {
            // 테이블 리스트 가져와서 소스를 기준으로 LEFT OUTER JOIN
            var sat = pxs.TableList();
            var compareResult = sat.Source.GroupJoin(
                sat.Target,
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
                compareResult.Where(x => (x.Target != null)).Select(x => x.Source).ToList(),
                // 타겟에 존재하지 않는 테이블 리스트
                compareResult.Where(x => (x.Target == null)).Select(x => x.Source).ToList()
            );

            return result;
        }

        private static string TableColumn(XModel.ProcessXSupport pxs, string tableName, XModel_SQLSchema_SourceAndTarget.SQLTableColumn satstc)
        {
            // 테이블 이름으로 검색된 컬럼 리스트
            var sourceDataList = satstc.Source.Where(x => (x.TABLE_NAME == tableName)).ToList();
            var targetDataList = satstc.Target.Where(x => (x.TABLE_NAME == tableName)).ToList();
            // 컬럼 정보는 1:1로 매칭되므로 LEFT OUTER JOIN진행
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
                        x.Source.Original.COLUMN_NAME + " : " + 
                        (
                            (x.Target == null) ? 
                            ("컬럼 없음 : " + x.Source.ColumnSchema) : 
                            (
                                "컬럼이 다름" + Environment.NewLine + 
                                "- 소스 : " + x.Source.ColumnSchema + Environment.NewLine +
                                "- 타겟 : " + x.Target.ColumnSchema
                            )
                        )
                    )
                );
            var result = string.Join(Environment.NewLine, compareResultList);

            return result;
        }

        private static string TableIndex(XModel.ProcessXSupport pxs, string tableName, XModel_SQLSchema_SourceAndTarget.SQLTableIndex satsti)
        {
            // 테이블 이름으로 검색된 인덱스 리스트
            var sourceDataList = satsti.Source.Where(x => (x.TABLE_NAME == tableName));
            var targetDataList = satsti.Target.Where(x => (x.TABLE_NAME == tableName));
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
            var matchNameOnlyList = matchNameList.Select(x => x.Source.CONSTRAINT_NAME).Distinct();
            var unMatchNameList = matchNameList.Where(x => (x.Source.CheckSourceHash != x.Target.CheckSourceHash));
            // INNER JOIN에 포함 안된거 가져오기 - NOT IN
            var sourceNotInNameList = sourceDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var targetNotInNameList = targetDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var sb = new StringBuilder();

            if (unMatchNameList.Count() > 0)
            {
                sb.AppendLine("***** 이름은 같지만 속성이 다름");
                sb.AppendLine(
                    string.Join(
                        Environment.NewLine,
                        unMatchNameList.Select(
                            x => (
                                "- 소스 : " + x.Source.NotifyContent + Environment.NewLine +
                                "- 타겟 : " + x.Target.NotifyContent + Environment.NewLine
                            )
                        )
                    )
                );
            }

            if ((sourceNotInNameList.Count() > 0) || (targetNotInNameList.Count() > 0))
            {
                sb.AppendLine("***** 이름이 다름 (같은거지만 랜덤의 이름으로 다를 수 있음)");
                sb.AppendLine("*** 소스");
                sb.AppendLine(string.Join(Environment.NewLine, sourceNotInNameList.Select(x => ("- " + x.NotifyContent))));
                sb.AppendLine("*** 타겟");
                sb.AppendLine(string.Join(Environment.NewLine, targetNotInNameList.Select(x => ("- "+ x.NotifyContent))));
            }

            var result = sb.ToString();

            return result;
        }

        private static string TableForeignKey(XModel.ProcessXSupport pxs, string tableName, XModel_SQLSchema_SourceAndTarget.SQLTableForeignKey satstfk)
        {
            // 테이블 이름으로 외래키 리스트 받기 
            var sourceDataList = satstfk.Source.Where(x => (x.TABLE_NAME == tableName)).ToList();
            var targetDataList = satstfk.Target.Where(x => (x.TABLE_NAME == tableName)).ToList();
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
            var matchNameOnlyList = matchNameList.Select(x => x.Source.CONSTRAINT_NAME).Distinct();
            // INNER JOIN에 포함 안된거 가져오기 - NOT IN
            var sourceNotInNameList = sourceDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var targetNotInNameList = targetDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var sb = new StringBuilder();

            if (unMatchNameList.Count() > 0)
            {
                sb.AppendLine("***** 이름은 같지만 속성이 다름");
                sb.AppendLine(
                    string.Join(
                        Environment.NewLine,
                        unMatchNameList.Select(
                            x => (
                                "- 소스 속성 : " + x.Source.NotifyContent + Environment.NewLine +
                                "- 타겟 속성 : " + x.Target.NotifyContent + Environment.NewLine
                            )
                        )
                    )
                );
            }

            if ((sourceNotInNameList.Count() > 0) || (targetNotInNameList.Count() > 0))
            {
                sb.AppendLine("***** 이름이 다름 (같은거지만 랜덤의 이름으로 다를 수 있음)");
                sb.AppendLine("*** 소스");
                sb.AppendLine(string.Join(Environment.NewLine, sourceNotInNameList.Select(x => ("- " + x.NotifyContent))));
                sb.AppendLine("*** 타겟");
                sb.AppendLine(string.Join(Environment.NewLine, targetNotInNameList.Select(x => ("- " + x.NotifyContent))));
            }

            var result = sb.ToString();

            return result;
        }

        private static string TableConstraints(XModel.ProcessXSupport pxs, string tableName, XModel_SQLSchema_SourceAndTarget.SQLTableConstraints satstc)
        {
            // 테이블 이름으로 검색된 제약조건 리스트
            var sourceDataList = satstc.Source.Where(x => (x.TABLE_NAME == tableName)).ToList();
            var targetDataList = satstc.Target.Where(x => (x.TABLE_NAME == tableName)).ToList();
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
            var matchNameOnlyList = matchNameList.Select(x => x.Source.CONSTRAINT_NAME).Distinct();
            // INNER JOIN에 포함 안된거 가져오기 - NOT IN
            var sourceNotInNameList = sourceDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var targetNotInNameList = targetDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var sb = new StringBuilder();

            if (unMatchNameList.Count() > 0)
            {
                sb.AppendLine("***** 이름은 같지만 속성이 다름");
                sb.AppendLine(
                    string.Join(
                        Environment.NewLine,
                        unMatchNameList.Select(
                            x => (
                                $"- 소스 속성 : " + x.Source.NotifyContent + Environment.NewLine +
                                $"- 타겟 속성 : " + x.Target.NotifyContent + Environment.NewLine
                            )
                        )
                    )
                );
            }

            if ((sourceNotInNameList.Count() > 0) || (targetNotInNameList.Count() > 0))
            {
                sb.AppendLine("***** 이름이 다름 (같은거지만 랜덤의 이름으로 다를 수 있음)");
                sb.AppendLine("소스");
                sb.AppendLine(string.Join(Environment.NewLine, sourceNotInNameList.Select(x => ("- " + x.NotifyContent))));
                sb.AppendLine("타겟");
                sb.AppendLine(string.Join(Environment.NewLine, targetNotInNameList.Select(x => ("- " + x.NotifyContent))));
            }

            var result = sb.ToString();

            return result;
        }

        private static string TableTrigger(XModel.ProcessXSupport pxs, string tableName, XModel_SQLSchema_SourceAndTarget.SQLTableTrigger satstt)
        {
            // 테이블 이름으로 검색된 트리거 리스트
            var sourceDataList = satstt.Source.Where(x => (x.TABLE_NAME == tableName)).ToList();
            var targetDataList = satstt.Target.Where(x => (x.TABLE_NAME == tableName)).ToList();
            // 트리거 정보는 1:1로 매칭되므로 LEFT OUTER JOIN진행
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
            var existTriggerList = compareResultList.Where(x => ((x.Target != null) && (x.Source.CheckSource != x.Target.CheckSource))).ToList();
            // 타겟에 존재하지 않는 트리거 리스트
            var notExistTriggerList = compareResultList.Where(x => (x.Target == null)).ToList();
            var sb = new StringBuilder();

            if (notExistTriggerList.Count > 0)
            {
                // 존재하지 않는 트리거
                sb.AppendLine(string.Empty);
                sb.AppendLine("***** 존재하지 않음");
                sb.AppendLine(string.Join(Environment.NewLine, existTriggerList.Select(x => x.Source.Original.TRIGGER_NAME)));

                // CREATE TRIGGER 스키마 내보내기
                existTriggerList.ForEach(
                    x =>
                    ExportWork.ExportSchema(
                        pxs,
                        new List<string>() { "TRIGGER", tableName, "CREATE" },
                        x.Source.Original.TRIGGER_NAME, 
                        x.Source.Original.TRIGGER_SCHEMA,
                        string.Empty
                    )
                );
            }

            if (existTriggerList.Count > 0)
            {
                // 존재하지만 다른 트리거
                sb.AppendLine(string.Empty);
                sb.AppendLine("***** 이름은 같지만 스키마가 다름");
                sb.AppendLine(string.Join(Environment.NewLine, existTriggerList.Select(x => x.Source.Original.TRIGGER_NAME)));

                // CREATE TRIGGER 스키마 내보내기
                existTriggerList.ForEach(
                    x =>
                    ExportWork.ExportSchema(
                        pxs,
                        new List<string>() { "TRIGGER", tableName, "ALTER" },
                        x.Source.Original.TRIGGER_NAME,
                        x.Source.Original.TRIGGER_SCHEMA,
                        x.Target.Original.TRIGGER_SCHEMA
                    )
                );
            }

            var result = sb.ToString();

            return result;
        }
    }
}
