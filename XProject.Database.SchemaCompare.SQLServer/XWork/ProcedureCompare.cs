﻿using System;
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
        public static void ExecuteNow(XModel.ProcessXSupport pxs)
        {
            // 프로시저 리스트 가져와서 소스를 기준으로 LEFT OUTER JOIN
            var satsp = pxs.ProcedureList();
            var compareResult = satsp.Source.GroupJoin(
                satsp.Target,
                x => x.ROUTINE_NAME,
                y => y.ROUTINE_NAME,
                (x, y) => new
                {
                    Source = x,
                    Target = y.FirstOrDefault()
                }
            );
            // 타겟에 존재하는 프로시저 - 즉 양쪽 다 있다
            var existProcedureList = compareResult.Where(x => ((x.Target != null) && (x.Source.CheckSource != x.Target.CheckSource))).ToList();
            // 타겟에 존재하지 않는 프로시저 리스트
            var notExistProcedureList = compareResult.Where(x => (x.Target == null)).ToList();

            // 존재하지 않는 프로시저만
            pxs.WriteReport(string.Empty);
            pxs.WriteReport("<<<<<<<<<< 존재하지 않는 프로시저 >>>>>>>>>>");
            pxs.WriteReport(string.Join(Environment.NewLine, notExistProcedureList.Select(x => x.Source.Original.ROUTINE_NAME)));

            // CREATE PROCEDURE 스키마 내보내기
            notExistProcedureList.ForEach(
                x =>
                ExportWork.ExportSchema(
                    pxs,
                    new List<string>() { "PROCEDURE", "CREATE" },
                    x.Source.Original.ROUTINE_NAME, 
                    x.Source.Original.ROUTINE_DEFINITION,
                    string.Empty
                )
            );

            // 존재하지만 다른 프로시저
            pxs.WriteReport(string.Empty);
            pxs.WriteReport("<<<<<<<<<< 존재하지만 스키마가 다른 프로시저 >>>>>>>>>>");
            pxs.WriteReport(string.Join(Environment.NewLine, existProcedureList.Select(x => x.Source.Original.ROUTINE_NAME)));

            // CREATE PROCEDURE 스키마 내보내기
            existProcedureList.ForEach(
                x =>
                ExportWork.ExportSchema(
                    pxs,
                    new List<string>() { "PROCEDURE", "ALTER" },
                    x.Source.Original.ROUTINE_NAME, 
                    x.Source.Original.ROUTINE_DEFINITION,
                    x.Target.Original.ROUTINE_DEFINITION
                )
            );
        }
    }
}
