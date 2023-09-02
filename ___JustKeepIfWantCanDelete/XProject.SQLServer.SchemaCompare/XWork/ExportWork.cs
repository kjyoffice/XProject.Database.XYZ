using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XProject.SQLServer.SchemaCompare.XWork
{
    public class ExportWork
    {
        public static void ExportSchema(string directoryPath, string fileName, string sourceContent, string targetContent, bool isKoreaHanGulLanguage)
        {
            if (Directory.Exists(directoryPath) == false)
            {
                Directory.CreateDirectory(directoryPath);
            }

            // 소스서버의 스키마
            // Source server schema
            var sourceFilePath = Path.Combine(directoryPath, (fileName + ".sql"));
            // 저장
            // Save
            File.WriteAllText(sourceFilePath, sourceContent, Encoding.UTF8);

            // 타겟 컨텐츠는 없을 수 있다!
            // Target content may be empty!
            if (targetContent != string.Empty)
            {
                // 타겟 컨텐츠가 있다는 것은 같은 이름에 서로 다른 스키마의 경우임
                // 이럴땐 타겟 스키마도 같이 파일로 내보내고, 소스코드 비교툴을 이용해 어디가 다른지 안내하고자 함
                // Target content means that it is a different schema with the same name.
                // In this case, the target schema is also exported to a file, and the source code comparison tool is used to indicate where it is different.

                // 타겟서버의 스키마
                // ** 타겟서버의 스키마는 적용하지 않고 단순 참조로만 사용 할 것이므로 
                //    따로 폴더를 만들어서 저장, 헷갈리지 않도록 최소화 하는 것을 의도함
                // Target server schema
                // ** The target server schema will not be applied, but will be used only as a simple reference.
                //    Therefore, it is intended to minimize confusion by creating a separate folder and saving it.
                var targetDirectoryPath = Path.Combine(directoryPath, "_TargetReference");
                var targetFilePath = Path.Combine(targetDirectoryPath, (fileName + " - DO_NOT_EXECUTE.sql"));

                if (Directory.Exists(targetDirectoryPath) == false)
                {
                    Directory.CreateDirectory(targetDirectoryPath);
                }

                // 타겟 파일의 실행하지 말라는 경고추가
                // Add a warning not to run the target file
                var doNotExecute = string.Join(
                    Environment.NewLine, 
                    (
                        (isKoreaHanGulLanguage == true) ?
                        (
                            new string[] {
                                "-- 이 스키마를 실행하지 마세요",
                                "-- 이 스키마는 타겟 스키마로 소스 스키마와 변경부분을 비교하기 위함입니다.",
                                string.Empty
                            }
                        ) :
                        (
                            new string[] {
                                "-- Do not run this schema",
                                "-- This schema is for comparing the source schema with the target schema and the changes.",
                                string.Empty
                            }
                        )
                    )
                );

                // 저장
                File.WriteAllText(targetFilePath, (doNotExecute + targetContent), Encoding.UTF8);

                // 이제 VisualStudio Code의 파일 비교기능을 이용해서 뭐가 바뀌었는지 알 수 있도록 하기
                // 이것을 하기 위해 bat파일을 하나 만들어서 저장, 실행하면 VSC에서 파일 비교가 보일것임
                // Now, using the file comparison function of VisualStudio Code, you can see what has changed.
                // To do this, create a bat file and save it, and when you run it, you will see a file comparison in VSC.

                // 헛소리 : 파일비교 기능이 필요했는데.. 만들기엔 부실한 기능, 방법을 찾던 중
                //          커멘드 라인으로 VSC의 파일 비교를 띄울 수 있다는 것을 알았다!
                //          잘됐다 ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ 
                // blah blah blah - ha ha ha

                // 배치파일 만들기
                // Create a batch file
                var batFilePath = Path.Combine(directoryPath, (fileName + " - Diff.bat"));
                var batContentKor = new string[]
                {
                    string.Empty,
                    $"echo ----------------------------",
                    $"echo VisualStudio Code를 통해 스키마를 비교합니다.",
                    $"echo ----------------------------",
                    $"echo {fileName}",
                    $"echo ----------------------------",
                    $"echo 소스 : {sourceFilePath}",
                    $"echo ----------------------------",
                    $"echo 타겟 : {targetFilePath}",
                    $"echo ----------------------------",
                    string.Empty
                };
                var batContentEng = new string[]
                {
                    string.Empty,
                    $"echo ----------------------------",
                    $"echo Compare schemas through VisualStudio Code.",
                    $"echo ----------------------------",
                    $"echo {fileName}",
                    $"echo ----------------------------",
                    $"echo Source : {sourceFilePath}",
                    $"echo ----------------------------",
                    $"echo Target : {targetFilePath}",
                    $"echo ----------------------------",
                    string.Empty
                };
                var batContent = (
                    "@echo off" + Environment.NewLine +
                    string.Join(Environment.NewLine, ((isKoreaHanGulLanguage == true) ? batContentKor : batContentEng)) +
                    $"code -d \"{sourceFilePath}\" \"{targetFilePath}\"" + Environment.NewLine
                );

                // 저장
                // 배치파일은 시스템에서 쓰는 인코딩.
                // Save
                // Batch files are encoded for use by the system.
                File.WriteAllText(batFilePath, batContent, Encoding.Default);
            }
        }

        public static void ExportSchema(string directoryPath, string fileName, string sourceContent, bool isKoreaHanGulLanguage)
        {
            ExportWork.ExportSchema(directoryPath, fileName, sourceContent, string.Empty, isKoreaHanGulLanguage);
        }
    }
}
