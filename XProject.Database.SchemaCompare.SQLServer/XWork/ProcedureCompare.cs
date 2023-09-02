using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace XProject.Database.SchemaCompare.SQLServer.XWork
{
    public class ProcedureCompare
    {
        public static void ExecuteNow(XData.SQLWork sourceSQL, XData.SQLWork targetSQL, Action<string> workResult, string schemaDirectory, bool isKoreaHanGulLanguage)
        {
            // 프로시저 리스트 가져와서 소스를 기준으로 LEFT OUTER JOIN
            // Get procedure list and LEFT OUTER JOIN with source
            var compareResult = sourceSQL.ProcedureList().GroupJoin(
                targetSQL.ProcedureList(),
                x => x.ROUTINE_NAME,
                y => y.ROUTINE_NAME,
                (x, y) => new
                {
                    Source = x,
                    Target = y.FirstOrDefault()
                }
            );
            // 타겟에 존재하는 프로시저 - 즉 양쪽 다 있다
            // Exist procedure list in target - both side
            var existProcedureList = compareResult.Where(x => ((x.Target != null) && (x.Source.CheckSource != x.Target.CheckSource))).ToList();
            // 타겟에 존재하지 않는 프로시저 리스트
            // Not exist procedure list in target
            var notExistProcedureList = compareResult.Where(x => (x.Target == null)).ToList();

            // 존재하지 않는 프로시저만
            // Not exist procedure only
            workResult(string.Empty);
            workResult(((isKoreaHanGulLanguage == true) ? "<<<<<<<<<< 존재하지 않는 프로시저 >>>>>>>>>>" : "<<<<<<<<<< Not exist procedure >>>>>>>>>>"));
            workResult(string.Join(Environment.NewLine, notExistProcedureList.Select(x => x.Source.ROUTINE_NAME_Original)));

            // CREATE PROCEDURE 스키마 내보내기
            // Export CREATE PROCEDURE schema
            notExistProcedureList.ForEach(
                x =>
                ExportWork.ExportSchema(
                    Path.Combine(schemaDirectory, "PROCEDURE", "CREATE"),
                    x.Source.ROUTINE_NAME_Original, 
                    x.Source.ROUTINE_DEFINITION_Original,
                    isKoreaHanGulLanguage
                )
            );

            // 존재하지만 다른 프로시저
            // Exist procedure but different
            workResult(string.Empty);
            workResult(((isKoreaHanGulLanguage == true) ? "<<<<<<<<<< 존재하지만 스키마가 다른 프로시저 >>>>>>>>>>" : "<<<<<<<<<< Exist procedure but different >>>>>>>>>>"));
            workResult(string.Join(Environment.NewLine, existProcedureList.Select(x => x.Source.ROUTINE_NAME_Original)));

            // CREATE PROCEDURE 스키마 내보내기
            // Export CREATE PROCEDURE schema
            existProcedureList.ForEach(
                x =>
                ExportWork.ExportSchema(
                    Path.Combine(schemaDirectory, "PROCEDURE", "ALTER"),
                    x.Source.ROUTINE_NAME_Original, 
                    x.Source.ROUTINE_DEFINITION_Original,
                    x.Target.ROUTINE_DEFINITION_Original,
                    isKoreaHanGulLanguage
                )
            );
        }
    }
}
