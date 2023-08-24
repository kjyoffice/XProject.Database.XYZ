using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace XProject.SQLServer.SchemaCompare.XWork
{
    public class FunctionCompare
    {
        public static void ExecuteNow(XData.SQLWork sourceSQL, XData.SQLWork targetSQL, Action<string> workResult, string schemaDirectory)
        {
            // 함수 리스트 가져와서 소스를 기준으로 LEFT OUTER JOIN
            // Get Function List and LEFT OUTER JOIN with source
            var compareResult = sourceSQL.FunctionList().GroupJoin(
                targetSQL.FunctionList(),
                x => x.FUNCTION_NAME,
                y => y.FUNCTION_NAME,
                (x, y) => new
                {
                    Source = x,
                    Target = y.FirstOrDefault()
                }
            );
            // 타겟에 존재하는 함수 - 즉 양쪽 다 있다
            // Exist target server function - Both Source and Target
            var existFunctionList = compareResult.Where(x => ((x.Target != null) && (x.Source.CheckSource != x.Target.CheckSource))).ToList();
            // 타겟에 존재하지 않는 함수 리스트
            // Not exist target server function
            var notExistFunctionList = compareResult.Where(x => (x.Target == null)).ToList();

            // 존재하지 않는 함수만
            // Not exist function
            workResult(string.Empty);
            workResult("<<<<<<<<<< 존재하지 않는 함수 >>>>>>>>>>");
            workResult("<<<<<<<<<< Not exist function >>>>>>>>>>");
            workResult(string.Join(Environment.NewLine, notExistFunctionList.Select(x => x.Source.FUNCTION_NAME_Original)));

            // CREATE FUNCTION 스키마 내보내기
            // Export CREATE FUNCTION schema
            notExistFunctionList.ForEach(
                x =>
                ExportWork.ExportSchema(
                    Path.Combine(schemaDirectory, "FUNCTION", "CREATE"),
                    x.Source.FUNCTION_NAME_Original,
                    x.Source.FUNCTION_DEFINITION_Original
                )
            );

            // 존재하지만 다른 함수
            // Exist function but different
            workResult(string.Empty);
            workResult("<<<<<<<<<< 존재하지만 스키마가 다른 함수 >>>>>>>>>>");
            workResult("<<<<<<<<<< Exist function but different >>>>>>>>>>");
            workResult(string.Join(Environment.NewLine, existFunctionList.Select(x => x.Source.FUNCTION_NAME_Original)));

            // CREATE FUNCTION 스키마 내보내기
            // Export CREATE FUNCTION schema
            existFunctionList.ForEach(
                x =>
                ExportWork.ExportSchema(
                    Path.Combine(schemaDirectory, "FUNCTION", "ALTER"),
                    x.Source.FUNCTION_NAME_Original,
                    x.Source.FUNCTION_DEFINITION_Original,
                    x.Target.FUNCTION_DEFINITION_Original
                )
            );
        }
    }
}
