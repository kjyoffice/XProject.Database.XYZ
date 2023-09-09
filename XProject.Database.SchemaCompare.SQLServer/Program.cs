using System;
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
            var sourceServerConnectionString = ((args.Length > 0) ? args[0].Trim() : string.Empty);
            var targetServerConnectionString = ((args.Length > 1) ? args[1].Trim() : string.Empty);
            var reportDirectoryPathSource = ((args.Length > 2) ? args[2].Trim() : string.Empty);
            var isKoreaHanGulLanguage = (((args.Length > 3) ? args[3].Trim() : string.Empty).ToUpper() == "TRUE");
            var isRight = ((sourceServerConnectionString != string.Empty) || (targetServerConnectionString != string.Empty));

            Console.Out.WriteLine("<<< XProject.Database.SchemaCompare.SQLServer >>>");

            if (isRight == true)
            {
                Console.Out.WriteLine(((isKoreaHanGulLanguage == true) ? "잠시만 기다려주세요..." : "Please wait..."));

                // 결과 정보를 저장 할 파일경로 구성
                var reportDirectoryPath = XValue.ProcessValue.ReportDirectoryPath(reportDirectoryPathSource);
                var reportFilePath = Path.Combine(reportDirectoryPath, $"Report - {DateTime.Now.ToString("yyyyMMdd_HHmmss_fffff")}.txt");

                using (var workResult = new StreamWriter(reportFilePath, false, Encoding.UTF8))
                {
                    workResult.AutoFlush = true;

                    try
                    {
                        // 서버 선택
                        var sourceSQL = new XData.SQLWork(sourceServerConnectionString);
                        var targetSQL = new XData.SQLWork(targetServerConnectionString);
                        var schemaDirectory = Path.Combine(Path.GetDirectoryName(reportFilePath), Path.GetFileNameWithoutExtension(reportFilePath));

                        if (isKoreaHanGulLanguage == true)
                        {
                            workResult.WriteLine($"> 리포트 디렉토리 : {reportDirectoryPath}");
                            workResult.WriteLine(string.Empty);
                            workResult.WriteLine($"> 소스서버 : {sourceSQL.ServerInfo}");
                            workResult.WriteLine($"> 타겟서버 : {targetSQL.ServerInfo}");
                            workResult.WriteLine(string.Empty);
                            workResult.WriteLine($"*** \"소스서버의 스키마가 타겟서버로 적용된다.\"의 개념으로 이해하면 됩니다.");
                            workResult.WriteLine(string.Empty);
                        }
                        else
                        {
                            workResult.WriteLine($"> Report directory : {reportDirectoryPath}");
                            workResult.WriteLine(string.Empty);
                            workResult.WriteLine($"> Source server : {sourceSQL.ServerInfo}");
                            workResult.WriteLine($"> Target server : {targetSQL.ServerInfo}");
                            workResult.WriteLine(string.Empty);
                            workResult.WriteLine($"*** Understanding the concept of \"The schema of the source server is applied to the target server.\"");
                            workResult.WriteLine(string.Empty);
                        }

                        workResult.WriteLine($"------------------------- START : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff")} -------------------------");

                        sourceSQL.DefaultSetting();
                        targetSQL.DefaultSetting();

                        XWork.TableCompare.ExecuteNow(sourceSQL, targetSQL, workResult.WriteLine, schemaDirectory, isKoreaHanGulLanguage);
                        XWork.ProcedureCompare.ExecuteNow(sourceSQL, targetSQL, workResult.WriteLine, schemaDirectory, isKoreaHanGulLanguage);
                        XWork.FunctionCompare.ExecuteNow(sourceSQL, targetSQL, workResult.WriteLine, schemaDirectory, isKoreaHanGulLanguage);

                        workResult.WriteLine(string.Empty);
                        workResult.WriteLine($"------------------------- END : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff")} -------------------------");

                        // 아웃풋 되는 스키마가 없으면 아예 폴더가 만들어지지 않는다
                        if (Directory.Exists(schemaDirectory) == true)
                        {
                            workResult.WriteLine(string.Empty);

                            if (isKoreaHanGulLanguage == true)
                            {
                                workResult.WriteLine("*** 아래 폴더에 스키마 파일이 있으니 확인 해주세요.");
                                workResult.WriteLine(schemaDirectory);
                                workResult.WriteLine(string.Empty);
                                workResult.WriteLine("*** 변경된 스키마의 비교를 위해 ALTER 디렉토리에 Diff 이름을 가지는 배치파일이 있습니다.");
                                workResult.WriteLine("    배치파일을 실행하게 되면 VisualStudio Code를 통해 변경된 스키마의 비교가 가능합니다.");
                                workResult.WriteLine("    혹시 VisualStudio Code가 설치되어 있지 않다면 아래의 URL을 통해 설치 파일을 다운로드 할 수 있습니다.");
                            }
                            else
                            {
                                workResult.WriteLine("*** There are schema files in the folder below, so please check.");
                                workResult.WriteLine(schemaDirectory);
                                workResult.WriteLine(string.Empty);
                                workResult.WriteLine("*** Change schema comparison, there is a batch file named Diff in the ALTER directory.");
                                workResult.WriteLine("    If you run the batch file, you can compare the changed schema through VisualStudio Code.");
                                workResult.WriteLine("    If VisualStudio Code is not installed, you can download the installation file through the URL below.");
                            }

                            workResult.WriteLine(string.Empty);
                            workResult.WriteLine("    https://code.visualstudio.com/");
                        }
                    }
                    catch (Exception ex)
                    {
                        workResult.WriteLine(string.Empty);
                        workResult.WriteLine("------------------------- ERROR -------------------------");
                        workResult.WriteLine(ex.Message);
                        workResult.WriteLine(ex.StackTrace);
                        
                        throw;
                    }
                    finally
                    {
                        workResult.Close();
                    }
                }

                // 결과 보기
                Process.Start("notepad.exe", reportFilePath);
            }
            else
            {
                if (isKoreaHanGulLanguage == true)
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
                else
                {
                    Console.Out.WriteLine("Not exist execution command.");
                    Console.Out.WriteLine(string.Empty);
                    Console.Out.WriteLine("> XProject.Database.SchemaCompare.SQLServer.exe [SourceServer] [TargetServer] {ReportDirectoryPath} {IsKoreaHanGulLanguage}");
                    Console.Out.WriteLine(string.Empty);
                    Console.Out.WriteLine("- SourcerServer : Source server connection string (required)");
                    Console.Out.WriteLine("- TargetServer : Target server connection string (required)");
                    Console.Out.WriteLine("- ReportDirectoryPath : Directory path to store comparison results");
                    Console.Out.WriteLine("- IsKoreaHanGulLanguage : Display korea hangul text (True : HanGul / False : English)");
                    Console.Out.WriteLine(string.Empty);
                    Console.Out.WriteLine("It is the concept of \"The schema of the source server is applied to the target server.\"");
                }
            }
        }
    }
}
