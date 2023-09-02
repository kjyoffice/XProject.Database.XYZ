namespace XProject.SQLServer.SchemaCompare.UI
{
    public static class Program
    {
        public static string SchemaCompareAppPath
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, "XProject.SQLServer.SchemaCompare.exe");
            }
        }

        // ------------------------------------------------------

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var appPath = Program.SchemaCompareAppPath;

            if (File.Exists(appPath) == true)
            {
                // 프로그램 실행하며 열어야 할 설정 파일
                // The setting file to open while running the program
                var defaultWorkSourceDataFilePath = ((args.Length > 0) ? args[0].Trim() : string.Empty);

                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new MainFrame(defaultWorkSourceDataFilePath));
            }
            else
            {
                var message = (
                    (
                        (XAppConfig.AppSettings.IsStartAppKoreaHanGulLanguage == true) ?
                        "스키마 비교 프로그램이 존재하지 않아 프로그램을 실행할 수 없습니다." :
                        "Not exist schema compare program. so can't run this program."
                    ) + Environment.NewLine + Environment.NewLine + appPath
                );

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}