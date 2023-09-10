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
        private XData.SQLWork SourceSQL { get; set; }
        private XData.SQLWork TargetSQL { get; set; }
        public string SourceServerInfo { get; private set; }
        public string TargetServerInfo { get; private set; }

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
            this.SourceServerInfo = string.Empty;
            this.TargetSQL = null;
            this.TargetServerInfo = string.Empty;
        }

        public void StartSupport()
        {
            var axs = this.AXS;
            var reportFilePath = this.ReportFilePath;
            
            var sw = new StreamWriter(reportFilePath, false, Encoding.UTF8);
            sw.AutoFlush = true;

            // 서버 선택
            var source = new XData.SQLWork(axs.SourceServerConnectionString);
            var target = new XData.SQLWork(axs.TargetServerConnectionString);

            this.ReportStreamWriter = sw;
            // 서버 선택
            this.SourceSQL = source;
            this.TargetSQL = target;
            this.SourceServerInfo = source.ServerInfo;
            this.TargetServerInfo = target.ServerInfo;
        }

        public void WriteReport(string message)
        {
            var sw = this.ReportStreamWriter;

            sw.WriteLine(message);
        }

        public void WriteReportCutBar(string title)
        {
            var sw = this.ReportStreamWriter;

            sw.WriteLine(string.Empty);
            sw.WriteLine($"------------------------- {title} : {DateTime.Now:yyyy-MM-dd HH:mm:ss.fffff} -------------------------");
        }

        public void WriteReport(string message, Exception ex)
        {
            var sw = this.ReportStreamWriter;

            sw.WriteLine(message);
            sw.WriteLine(string.Empty);
            sw.WriteLine("------------------------- ERROR -------------------------");
            sw.WriteLine(ex.Message);
            sw.WriteLine(ex.StackTrace);
        }

        public void SupportEnd()
        {
            var sw = this.ReportStreamWriter;

            sw.Close();
            sw.Dispose();
        }

        public void DefaultSetting()
        {
            this.SourceSQL.DefaultSetting();
            this.TargetSQL.DefaultSetting();
        }

        public XModel_SQLSchema_SourceAndTarget.SQLTable TableList()
        {
            return new XModel_SQLSchema_SourceAndTarget.SQLTable(this.SourceSQL, this.TargetSQL);
        }

        public XModel_SQLSchema_SourceAndTarget.SQLTableColumn TableColumnList()
        {
            return new XModel_SQLSchema_SourceAndTarget.SQLTableColumn(this.SourceSQL, this.TargetSQL);
        }

        public XModel_SQLSchema_SourceAndTarget.SQLTableIndex TableIndexList()
        {
            return new XModel_SQLSchema_SourceAndTarget.SQLTableIndex(this.SourceSQL, this.TargetSQL);
        }

        public XModel_SQLSchema_SourceAndTarget.SQLTableForeignKey TableForeignKeyList()
        {
            return new XModel_SQLSchema_SourceAndTarget.SQLTableForeignKey(this.SourceSQL, this.TargetSQL);
        }

        public XModel_SQLSchema_SourceAndTarget.SQLTableConstraints TableConstraintsList()
        {
            return new XModel_SQLSchema_SourceAndTarget.SQLTableConstraints(this.SourceSQL, this.TargetSQL);
        }

        public XModel_SQLSchema_SourceAndTarget.SQLTableTrigger TableTriggerList()
        {
            return new XModel_SQLSchema_SourceAndTarget.SQLTableTrigger(this.SourceSQL, this.TargetSQL);
        }

        public XModel_SQLSchema_SourceAndTarget.SQLProcedure ProcedureList()
        {
            return new XModel_SQLSchema_SourceAndTarget.SQLProcedure(this.SourceSQL, this.TargetSQL);
        }

        public XModel_SQLSchema_SourceAndTarget.SQLFunction FunctionList()
        {
            return new XModel_SQLSchema_SourceAndTarget.SQLFunction(this.SourceSQL, this.TargetSQL);
        }
    }
}
