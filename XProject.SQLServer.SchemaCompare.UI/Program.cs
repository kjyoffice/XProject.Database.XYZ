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
                // ���α׷� �����ϸ� ����� �� ���� ����
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
                        "��Ű�� �� ���α׷��� �������� �ʾ� ���α׷��� ������ �� �����ϴ�." :
                        "Not exist schema compare program. so can't run this program."
                    ) + Environment.NewLine + Environment.NewLine + appPath
                );

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}