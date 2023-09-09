using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XProject.Database.SchemaCompare.SQLServer.XModel
{
    public class ProcessXSupport
    {
        private ArgumentsXSupport AXS { get; set; }
        public string ReportDirectoryPath { get; private set; }
        public string ReportFilePath { get; private set; }
        public string SchemaDirectory { get; private set; }
        private StreamWriter ReportStreamWriter { get; set; }
        public XData.SQLWork SourceSQL { get; private set; }
        public XData.SQLWork TargetSQL { get; private set; }

        // -------------------------------------------------------

        public ProcessXSupport(ArgumentsXSupport axs)
        {
            // 결과 정보를 저장 할 파일경로 구성
            var reportDirectoryPath = XValue.ProcessValue.ReportDirectoryPath(axs.ReportDirectoryPathSource);
            var reportFilePath = Path.Combine(reportDirectoryPath, $"Report - {DateTime.Now.ToString("yyyyMMdd_HHmmss_fffff")}.txt");

            this.AXS = axs;
            this.ReportDirectoryPath = reportDirectoryPath;
            this.ReportFilePath = reportFilePath;
            this.SchemaDirectory = Path.Combine(Path.GetDirectoryName(reportFilePath), Path.GetFileNameWithoutExtension(reportFilePath));
            this.ReportStreamWriter = null;
            this.SourceSQL = null;
            this.TargetSQL = null;
        }

        public void StartSupport()
        {
            var axs = this.AXS;
            var reportFilePath = this.ReportFilePath;
            var sw = new StreamWriter(reportFilePath, false, Encoding.UTF8);
            sw.AutoFlush = true;

            this.ReportStreamWriter = sw;
            // 서버 선택
            this.SourceSQL = new XData.SQLWork(axs.SourceServerConnectionString);
            this.TargetSQL = new XData.SQLWork(axs.TargetServerConnectionString);
        }

        public void WriteReport(string message)
        {
            var sw = this.ReportStreamWriter;

            if (sw != null)
            {
                sw.WriteLine(message);
            }
        }

        public void WriteReportCutBar(string title)
        {
            var sw = this.ReportStreamWriter;

            if (sw != null)
            {
                sw.WriteLine(string.Empty);
                sw.WriteLine($"------------------------- {title} : {DateTime.Now:yyyy-MM-dd HH:mm:ss.fffff} -------------------------");
            }
        }

        public void WriteReport(string message, Exception ex)
        {
            var sw = this.ReportStreamWriter;

            if (sw != null)
            {
                sw.WriteLine(message);
                sw.WriteLine(string.Empty);
                sw.WriteLine("------------------------- ERROR -------------------------");
                sw.WriteLine(ex.Message);
                sw.WriteLine(ex.StackTrace);
            }
        }

        public void SupportEnd()
        {
            var sw = this.ReportStreamWriter;

            if (sw != null)
            {
                sw.Close();
                sw.Dispose();
            }
        }
    }
}
