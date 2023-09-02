using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XProject.Database.SchemaCompare.UI
{
    public static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // 프로그램 실행하며 열어야 할 설정 파일
            // The setting file to open while running the program
            var defaultWorkSourceDataFilePath = ((args.Length > 0) ? args[0].Trim() : string.Empty);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrame(defaultWorkSourceDataFilePath));
            // Path.Combine(Environment.CurrentDirectory, "XProject.Database.SchemaCompare.SQLServer.exe");
        }
    }
}
