﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace XProject.Database.SchemaCompare.SQLServer.XWork
{
    public class FunctionCompare
    {
        public static void ExecuteNow(XModel.ProcessXSupport pxs)
        {
            // 함수 리스트 가져와서 소스를 기준으로 LEFT OUTER JOIN
            var compareResult = pxs.SourceSQL.FunctionList().GroupJoin(
                pxs.TargetSQL.FunctionList(),
                x => x.FUNCTION_NAME,
                y => y.FUNCTION_NAME,
                (x, y) => new
                {
                    Source = x,
                    Target = y.FirstOrDefault()
                }
            );
            // 타겟에 존재하는 함수 - 즉 양쪽 다 있다
            var existFunctionList = compareResult.Where(x => ((x.Target != null) && (x.Source.CheckSource != x.Target.CheckSource))).ToList();
            // 타겟에 존재하지 않는 함수 리스트
            var notExistFunctionList = compareResult.Where(x => (x.Target == null)).ToList();

            // 존재하지 않는 함수만
            pxs.WriteReport(string.Empty);
            pxs.WriteReport(((pxs.IsKoreaHanGulLanguage == true) ? "<<<<<<<<<< 존재하지 않는 함수 >>>>>>>>>>" : "<<<<<<<<<< Not exist function >>>>>>>>>>"));
            pxs.WriteReport(string.Join(Environment.NewLine, notExistFunctionList.Select(x => x.Source.FUNCTION_NAME_Original)));

            // CREATE FUNCTION 스키마 내보내기
            notExistFunctionList.ForEach(
                x =>
                ExportWork.ExportSchema(
                    pxs,
                    Path.Combine(pxs.SchemaDirectory, "FUNCTION", "CREATE"),
                    x.Source.FUNCTION_NAME_Original,
                    x.Source.FUNCTION_DEFINITION_Original,
                    string.Empty
                )
            );

            // 존재하지만 다른 함수
            pxs.WriteReport(string.Empty);
            pxs.WriteReport(((pxs.IsKoreaHanGulLanguage == true) ? "<<<<<<<<<< 존재하지만 스키마가 다른 함수 >>>>>>>>>>" : "<<<<<<<<<< Exist function but different >>>>>>>>>>"));
            pxs.WriteReport(string.Join(Environment.NewLine, existFunctionList.Select(x => x.Source.FUNCTION_NAME_Original)));

            // CREATE FUNCTION 스키마 내보내기
            existFunctionList.ForEach(
                x =>
                ExportWork.ExportSchema(
                    pxs,
                    Path.Combine(pxs.SchemaDirectory, "FUNCTION", "ALTER"),
                    x.Source.FUNCTION_NAME_Original,
                    x.Source.FUNCTION_DEFINITION_Original,
                    x.Target.FUNCTION_DEFINITION_Original
                )
            );
        }
    }
}
