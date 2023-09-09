﻿using System;
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
            var tableResult = TableCompare.Table(pxs.SourceSQL.TableList(), pxs.TargetSQL.TableList());
            // 컬럼 리스트
            var sourceColumnList = pxs.SourceSQL.TableColumnList();
            var targetColumnList = pxs.TargetSQL.TableColumnList();
            // 인덱스 리스트
            var sourceIndexList = pxs.SourceSQL.TableIndexList();
            var targetIndexList = pxs.TargetSQL.TableIndexList();
            // 참조키 리스트
            var sourceForeignKeyList = pxs.SourceSQL.TableForeignKeyList();
            var targetForeignKeyList = pxs.TargetSQL.TableForeignKeyList();
            // 제약조건 리스트
            var sourceConstraintList = pxs.SourceSQL.TableConstraintsList();
            var targetConstraintList = pxs.TargetSQL.TableConstraintsList();
            // 트리거 리스트
            var sourceTriggerList = pxs.SourceSQL.TableTriggerList();
            var targetTriggerList = pxs.TargetSQL.TableTriggerList();

            // 존재하지 않는 테이블
            pxs.WriteReport(string.Empty);
            pxs.WriteReport(((pxs.IsKoreaHanGulLanguage == true) ? "<<<<<<<<<< 존재하지 않는 테이블 >>>>>>>>>>" : "<<<<<<<<<< Not exist table >>>>>>>>>>"));
            pxs.WriteReport(string.Join(Environment.NewLine, tableResult.NotExistTableList.Select(x => x.TABLE_NAME_Original)));

            // 테이블 비교
            pxs.WriteReport(string.Empty);
            pxs.WriteReport(((pxs.IsKoreaHanGulLanguage == true) ? "<<<<<<<<<< 존재하는 테이블 >>>>>>>>>>" : "<<<<<<<<<< Exist table >>>>>>>>>>"));
            foreach (var table in tableResult.ExistTableList)
            {
                // crt : Compare Result Text
                var crtColumn = ((pxs.IsKoreaHanGulLanguage == true) ? "컬럼 (COLUMN)" : "Column (COLUMN)");
                var crtIndex = ((pxs.IsKoreaHanGulLanguage == true) ? "인덱스 (PRIMARY KEY / INDEX / UNIQUE)" : "Index (PRIMARY KEY / INDEX / UNIQUE)");
                var crtFK = ((pxs.IsKoreaHanGulLanguage == true) ? "외래키 (FOREIGN KEY)" : "Foreign Key (FOREIGN KEY)");
                var crtConstraint = ((pxs.IsKoreaHanGulLanguage == true) ? "제약조건 (CHECK, DEFAULT)" : "Constraint (CHECK, DEFAULT)");
                var crtTrigger = ((pxs.IsKoreaHanGulLanguage == true) ? "트리거 (TRIGGER)" : "Trigger (TRIGGER)");
                var compareResult = new Dictionary<string, string>() {
                    { crtColumn, TableCompare.TableColumn(sourceColumnList, targetColumnList, table.TABLE_NAME, pxs) },
                    { crtIndex, TableCompare.TableIndex(sourceIndexList, targetIndexList, table.TABLE_NAME, pxs) },
                    { crtFK, TableCompare.TableForeignKey(sourceForeignKeyList, targetForeignKeyList, table.TABLE_NAME, pxs) },
                    { crtConstraint, TableCompare.TableConstraints(sourceConstraintList, targetConstraintList, table.TABLE_NAME, pxs) },
                    { crtTrigger, TableCompare.TableTrigger(sourceTriggerList, targetTriggerList, table.TABLE_NAME, pxs) }
                }.Where(x => (x.Value != string.Empty));

                // 차이가 있는 테이블만 뿌린다
                if (compareResult.Count() > 0)
                {
                    // 테이블 이름 뿌리고
                    pxs.WriteReport(string.Empty);
                    pxs.WriteReport($">>>>>>>>>> {table.TABLE_NAME_Original}");

                    foreach (var kvp in compareResult)
                    {
                        pxs.WriteReport(string.Empty);
                        pxs.WriteReport($"----- {kvp.Key} -----");
                        pxs.WriteReport(kvp.Value);
                    }
                }
            }
        }

        private static XModel.TableResult Table(List<XModel.SQLTable> sourceAllDataList, List<XModel.SQLTable> targetAllDataList)
        {
            // 테이블 리스트 가져와서 소스를 기준으로 LEFT OUTER JOIN
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
                compareResult.Where(x => (x.Target != null)).Select(x => x.Source).ToList(),
                // 타겟에 존재하지 않는 테이블 리스트
                compareResult.Where(x => (x.Target == null)).Select(x => x.Source).ToList()
            );

            return result;
        }

        private static string TableColumn(List<XModel.SQLTableColumn> sourceAllDataList, List<XModel.SQLTableColumn> targetAllDataList, string tableName, XModel.ProcessXSupport pxs)
        {
            // 테이블 이름으로 검색된 컬럼 리스트
            var sourceDataList = sourceAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
            var targetDataList = targetAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
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
                        x.Source.COLUMN_NAME_Original + " : " + 
                        (
                            (x.Target == null) ? 
                            (((pxs.IsKoreaHanGulLanguage == true) ? "컬럼 없음" : "Not exist column") + " : " + x.Source.ColumnSchema) : 
                            (
                                ((pxs.IsKoreaHanGulLanguage == true) ? "컬럼이 다름" : "Different column") + Environment.NewLine + 
                                "- " + ((pxs.IsKoreaHanGulLanguage == true) ? "소스" : "Source") + " : " + x.Source.ColumnSchema + Environment.NewLine +
                                "- " + ((pxs.IsKoreaHanGulLanguage == true) ? "타겟" : "Target") + " : " + x.Target.ColumnSchema
                            )
                        )
                    )
                );
            var result = string.Join(Environment.NewLine, compareResultList);

            return result;
        }

        private static string TableIndex(List<XModel.SQLTableIndex> sourceAllDataList, List<XModel.SQLTableIndex> targetAllDataList, string tableName, XModel.ProcessXSupport pxs)
        {
            // 테이블 이름으로 검색된 인덱스 리스트
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
            var matchNameOnlyList = matchNameList.Select(x => x.Source.CONSTRAINT_NAME).Distinct();
            var unMatchNameList = matchNameList.Where(x => (x.Source.CheckSourceHash != x.Target.CheckSourceHash));
            // INNER JOIN에 포함 안된거 가져오기 - NOT IN
            var sourceNotInNameList = sourceDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var targetNotInNameList = targetDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var sb = new StringBuilder();

            if (unMatchNameList.Count() > 0)
            {
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "***** 이름은 같지만 속성이 다름" : "***** Name is same but attribute is different"));
                sb.AppendLine(
                    string.Join(
                        Environment.NewLine,
                        unMatchNameList.Select(
                            x => (
                                "- " + ((pxs.IsKoreaHanGulLanguage == true) ? "소스" : "Source") + " : " + x.Source.NotifyContent + Environment.NewLine +
                                "- " + ((pxs.IsKoreaHanGulLanguage == true) ? "타겟" : "Target") + " : " + x.Target.NotifyContent + Environment.NewLine
                            )
                        )
                    )
                );
            }

            if ((sourceNotInNameList.Count() > 0) || (targetNotInNameList.Count() > 0))
            {
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "***** 이름이 다름 (같은거지만 랜덤의 이름으로 다를 수 있음)" : "***** Name is different (same but can be different with random name)"));
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "*** 소스" : "*** Source"));
                sb.AppendLine(string.Join(Environment.NewLine, sourceNotInNameList.Select(x => ("- " + x.NotifyContent))));
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "*** 타겟" : "*** Target"));
                sb.AppendLine(string.Join(Environment.NewLine, targetNotInNameList.Select(x => ("- "+ x.NotifyContent))));
            }

            var result = sb.ToString();

            return result;
        }

        private static string TableForeignKey(List<XModel.SQLTableForeignKey> sourceAllDataList, List<XModel.SQLTableForeignKey> targetAllDataList, string tableName, XModel.ProcessXSupport pxs)
        {
            // 테이블 이름으로 외래키 리스트 받기 
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
            var matchNameOnlyList = matchNameList.Select(x => x.Source.CONSTRAINT_NAME).Distinct();
            // INNER JOIN에 포함 안된거 가져오기 - NOT IN
            var sourceNotInNameList = sourceDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var targetNotInNameList = targetDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var sb = new StringBuilder();

            if (unMatchNameList.Count() > 0)
            {
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "***** 이름은 같지만 속성이 다름" : "***** Name is same but attribute is different"));
                sb.AppendLine(
                    string.Join(
                        Environment.NewLine,
                        unMatchNameList.Select(
                            x => (
                                "- " + ((pxs.IsKoreaHanGulLanguage == true) ? "소스 속성" : "Source attribute") + " : " + x.Source.NotifyContent + Environment.NewLine +
                                "- " + ((pxs.IsKoreaHanGulLanguage == true) ? "타겟 속성" : "Target attribute") + " : " + x.Target.NotifyContent + Environment.NewLine
                            )
                        )
                    )
                );
            }

            if ((sourceNotInNameList.Count() > 0) || (targetNotInNameList.Count() > 0))
            {
                sb.AppendLine((pxs.IsKoreaHanGulLanguage == true) ? "***** 이름이 다름 (같은거지만 랜덤의 이름으로 다를 수 있음)" : "***** Name is different (same but can be different with random name)");
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "*** 소스" : "*** Source"));
                sb.AppendLine(string.Join(Environment.NewLine, sourceNotInNameList.Select(x => ("- " + x.NotifyContent))));
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "*** 타겟" : "*** Target"));
                sb.AppendLine(string.Join(Environment.NewLine, targetNotInNameList.Select(x => ("- " + x.NotifyContent))));
            }

            var result = sb.ToString();

            return result;
        }

        private static string TableConstraints(List<XModel.SQLTableConstraints> sourceAllDataList, List<XModel.SQLTableConstraints> targetAllDataList, string tableName, XModel.ProcessXSupport pxs)
        {
            // 테이블 이름으로 검색된 제약조건 리스트
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
            var matchNameOnlyList = matchNameList.Select(x => x.Source.CONSTRAINT_NAME).Distinct();
            // INNER JOIN에 포함 안된거 가져오기 - NOT IN
            var sourceNotInNameList = sourceDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var targetNotInNameList = targetDataList.Where(x => (matchNameOnlyList.Contains(x.CONSTRAINT_NAME) == false));
            var sb = new StringBuilder();

            if (unMatchNameList.Count() > 0)
            {
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "***** 이름은 같지만 속성이 다름" : "***** Name is same but attribute is different"));
                sb.AppendLine(
                    string.Join(
                        Environment.NewLine,
                        unMatchNameList.Select(
                            x => (
                                $"- " + ((pxs.IsKoreaHanGulLanguage == true) ? "소스 속성" : "Source attribute") + " : " + x.Source.NotifyContent + Environment.NewLine +
                                $"- " + ((pxs.IsKoreaHanGulLanguage == true) ? "타겟 속성" : "Target attribute") + " : " + x.Target.NotifyContent + Environment.NewLine
                            )
                        )
                    )
                );
            }

            if ((sourceNotInNameList.Count() > 0) || (targetNotInNameList.Count() > 0))
            {
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "***** 이름이 다름 (같은거지만 랜덤의 이름으로 다를 수 있음)" : "***** Name is different (same but can be different with random name)"));
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "소스" : "Source"));
                sb.AppendLine(string.Join(Environment.NewLine, sourceNotInNameList.Select(x => ("- " + x.NotifyContent))));
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "타겟" : "Target"));
                sb.AppendLine(string.Join(Environment.NewLine, targetNotInNameList.Select(x => ("- " + x.NotifyContent))));
            }

            var result = sb.ToString();

            return result;
        }

        private static string TableTrigger(List<XModel.SQLTableTrigger> sourceAllDataList, List<XModel.SQLTableTrigger> targetAllDataList, string tableName, XModel.ProcessXSupport pxs)
        {
            // 테이블 이름으로 검색된 트리거 리스트
            var sourceDataList = sourceAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
            var targetDataList = targetAllDataList.Where(x => (x.TABLE_NAME == tableName)).ToList();
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
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "***** 존재하지 않음" : "***** Not exist"));
                sb.AppendLine(string.Join(Environment.NewLine, existTriggerList.Select(x => x.Source.TRIGGER_NAME_Original)));

                // CREATE TRIGGER 스키마 내보내기
                existTriggerList.ForEach(
                    x =>
                    ExportWork.ExportSchema(
                        pxs,
                        Path.Combine(pxs.SchemaDirectory, "TRIGGER", tableName, "CREATE"),
                        x.Source.TRIGGER_NAME_Original, 
                        x.Source.TRIGGER_SCHEMA_Original,
                        string.Empty
                    )
                );
            }

            if (existTriggerList.Count > 0)
            {
                // 존재하지만 다른 트리거
                sb.AppendLine(string.Empty);
                sb.AppendLine(((pxs.IsKoreaHanGulLanguage == true) ? "***** 이름은 같지만 스키마가 다름" : "***** Name is same but schema is different"));
                sb.AppendLine(string.Join(Environment.NewLine, existTriggerList.Select(x => x.Source.TRIGGER_NAME_Original)));

                // CREATE TRIGGER 스키마 내보내기
                existTriggerList.ForEach(
                    x =>
                    ExportWork.ExportSchema(
                        pxs,
                        Path.Combine(pxs.SchemaDirectory, "TRIGGER", tableName, "ALTER"),
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
