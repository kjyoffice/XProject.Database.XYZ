﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace XProject.Database.SchemaCompare.SQLServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // SourceServer의 정보를 기준으로 TargetServer와 Schema를 비교
            //
            // SourceServer : 최신버젼의 서버 연결 문자열
            // TargetServer : 비교대상의 서버 연결 문자열
            // 
            // 예>
            //  - SourceServer에 Schema가 있고 TargetServer에 Schema가 없음 -> Notify
            //  - SourceServer에 Schema가 있고 TargetServer에 Schema가 있는데 다름 -> Notify
            //  - SourceServer에 Schema가 없고 TargetServer에 Schema가 있음 -> Skip
            var axs = new XModel.ArgumentsXSupport(args);

            Console.Out.WriteLine("<<< XProject.Database.SchemaCompare.SQLServer >>>");

            if (axs.IsExistServerConnectionString == true)
            {
                var pxs = new XModel.ProcessXSupport(axs);

                Console.Out.WriteLine("잠시만 기다려주세요...");

                try
                {
                    pxs.StartSupport();

                    pxs.WriteReport($"> 리포트 디렉토리 : {pxs.ReportDirectoryPath}");
                    pxs.WriteReport(string.Empty);
                    pxs.WriteReport($"> 소스서버 : {pxs.SourceServerInfo}");
                    pxs.WriteReport($"> 타겟서버 : {pxs.TargetServerInfo}");
                    pxs.WriteReport(string.Empty);
                    pxs.WriteReport($"*** \"소스서버의 스키마가 타겟서버로 적용된다.\"의 개념으로 이해하면 됩니다.");
                    pxs.WriteReport(string.Empty);

                    pxs.WriteReportCutBar("START");

                    pxs.DefaultSetting();

                    XWork.TableCompare.ExecuteNow(pxs);
                    XWork.ProcedureCompare.ExecuteNow(pxs);
                    XWork.FunctionCompare.ExecuteNow(pxs);

                    pxs.WriteReportCutBar("END");

                    // 아웃풋 되는 스키마가 없으면 아예 폴더가 만들어지지 않는다
                    if (Directory.Exists(pxs.SchemaDirectory) == true)
                    {
                        pxs.WriteReport(string.Empty);
                        pxs.WriteReport("*** 아래 폴더에 스키마 파일이 있으니 확인 해주세요.");
                        pxs.WriteReport(pxs.SchemaDirectory);
                        pxs.WriteReport(string.Empty);
                        pxs.WriteReport("*** 변경된 스키마의 비교를 위해 ALTER 디렉토리에 Diff 이름을 가지는 배치파일이 있습니다.");
                        pxs.WriteReport("    배치파일을 실행하게 되면 VisualStudio Code를 통해 변경된 스키마의 비교가 가능합니다.");
                        pxs.WriteReport("    혹시 VisualStudio Code가 설치되어 있지 않다면 아래의 URL을 통해 설치 파일을 다운로드 할 수 있습니다.");
                        pxs.WriteReport(string.Empty);
                        pxs.WriteReport("    https://code.visualstudio.com/");
                    }
                }
                catch (Exception ex)
                {
                    pxs.WriteReport(string.Empty, ex);
                }
                finally
                {
                    pxs.SupportEnd();
                }

                // 결과 보기
                Process.Start("notepad.exe", pxs.ReportFilePath);
            }
            else
            {
                Console.Out.WriteLine("실행 명령이 없습니다.");
                Console.Out.WriteLine(string.Empty);
                Console.Out.WriteLine("> XProject.Database.SchemaCompare.SQLServer.exe [SourceServer] [TargetServer] {ReportDirectoryPath} {IsKoreaHanGulLanguage}");
                Console.Out.WriteLine(string.Empty);
                Console.Out.WriteLine("- SourceServer : 소스서버 연결 문자열 (필수)");
                Console.Out.WriteLine("- TargetServer : 타겟서버 연결 문자열 (필수)");
                Console.Out.WriteLine("- ReportDirectoryPath : 비교 결과를 저정하는 디렉토리 경로");
                Console.Out.WriteLine("- IsKoreaHanGulLanguage : 한글로 표시할건지 여부 (True : 한글 / False : 영문)");
                Console.Out.WriteLine(string.Empty);
                Console.Out.WriteLine("\"소스서버의 스키마가 타겟서버로 적용된다.\"의 개념입니다.");
            }
        }
    }
}
