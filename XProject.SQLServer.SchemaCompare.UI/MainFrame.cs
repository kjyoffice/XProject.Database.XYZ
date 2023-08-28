﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;

namespace XProject.SQLServer.SchemaCompare.UI
{
    public partial class MainFrame : Form
    {
        private string AppTitle { get; set; }
        private string WorkSourceDataFilePath { get; set; }
        private string DefaultWorkSourceDataFilePath { get; set; }

        // ------------------------------------------------------------------------------------------------

        private void ChangeUserManualConnectionString(CheckBox userManual, TextBox rawConnectionString, Label dataSourceTitle, Label userIDTitle, Label passwordTitle, Label initialCatalogTitle, Label rawConnectionStringTitle, CheckBox trust)
        {
            var isManualCS = userManual.Checked;

            dataSourceTitle.Visible = !isManualCS;
            userIDTitle.Visible = !isManualCS;
            passwordTitle.Visible = !isManualCS;
            initialCatalogTitle.Visible = !isManualCS;
            trust.Visible = !isManualCS;

            rawConnectionStringTitle.Visible = isManualCS;
            rawConnectionString.Visible = isManualCS;
        }

        private void ChangeTrustedConnectionStatus(TextBox userID, TextBox password, CheckBox trust, bool isClearValue)
        {
            var isUnTrust = !trust.Checked;

            if (isClearValue == true)
            {
                userID.Clear();
                password.Clear();
            }

            userID.Enabled = isUnTrust;
            password.Enabled = isUnTrust;
        }

        private void ConnectTest(TextBox dataSource, TextBox userID, TextBox password, TextBox initialCatalog, TextBox rawConnectionString, CheckBox userManual, CheckBox trust, CheckBox isUIKorLang)
        {
            if (this.ConnectionValueCheck(dataSource, userID, password, initialCatalog, rawConnectionString, userManual, trust, isUIKorLang) == true)
            {
                var connectionString = this.CreateConnectionString(dataSource, userID, password, initialCatalog, rawConnectionString, userManual, trust);

                if (connectionString != string.Empty)
                {
                    this.Cursor = Cursors.WaitCursor;

                    using (var sc = new SqlConnection(connectionString))
                    {
                        // 연결 테스트
                        // Connect test
                        try
                        {
                            var message = ((isUIKorLang.Checked == true) ? "서버에 연결 가능합니다." : "Server connect test OK.");

                            sc.Open();

                            MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {

                            var message = (((isUIKorLang.Checked == true) ? "서버에 연결할 수 없습니다." : "Server connect is failed") + Environment.NewLine + Environment.NewLine + ex.Message);

                            MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (sc.State != ConnectionState.Closed)
                            {
                                sc.Close();
                            }
                        }
                    }

                    this.Cursor = Cursors.Default;
                }
                else
                {
                    var message = ((isUIKorLang.Checked == true) ? "연결 문자열이 없습니다." : "Not exist connectionstring");

                    MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ConnectionValueCheck(TextBox dataSource, TextBox userID, TextBox password, TextBox initialCatalog, TextBox rawConnectionString, CheckBox userManual, CheckBox trust, CheckBox isUIKorLang)
        {
            var result = false;
            var isTrust = trust.Checked;

            dataSource.Text = dataSource.Text.Trim();
            userID.Text = userID.Text.Trim();
            password.Text = password.Text.Trim();
            initialCatalog.Text = initialCatalog.Text.Trim();
            rawConnectionString.Text = rawConnectionString.Text.Trim();

            if (userManual.Checked == true)
            {
                if (rawConnectionString.Text != string.Empty)
                {
                    result = true;
                }
                else
                {
                    var message = ((isUIKorLang.Checked == true) ? "연결문자열을 입력하세요." : "Please input server connectionstring.");

                    MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rawConnectionString.Focus();
                }
            }
            else
            {
                if (dataSource.Text != string.Empty)
                {
                    if ((isTrust == true) || ((isTrust == false) && (userID.Text != string.Empty)))
                    {
                        if ((isTrust == true) || ((isTrust == false) && (password.Text != string.Empty)))
                        {
                            if (initialCatalog.Text != string.Empty)
                            {
                                result = true;
                            }
                            else
                            {
                                var message = ((isUIKorLang.Checked == true) ? "데이터베이스를 입력하세요." : "Please input database.");

                                MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                initialCatalog.Focus();
                            }
                        }
                        else
                        {
                            var message = ((isUIKorLang.Checked == true) ? "서버 로그인 비밀번호를 입력하세요." : "Please input server login password.");

                            MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            password.Focus();
                        }
                    }
                    else
                    {
                        var message = ((isUIKorLang.Checked == true) ? "서버 로그인 아이디를 입력하세요." : "Please input server login id.");

                        MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        userID.Focus();
                    }
                }
                else
                {
                    var message = ((isUIKorLang.Checked == true) ? "서버를 입력하세요." : "Please input server.");

                    MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataSource.Focus();
                }
            }

            return result;
        }

        private string CreateConnectionString(TextBox dataSource, TextBox userID, TextBox password, TextBox initialCatalog, TextBox rawConnectionString, CheckBox userManual, CheckBox trust)
        {
            var result = string.Empty;

            if (userManual.Checked == true)
            {
                result = rawConnectionString.Text.Trim();
            }
            else
            {
                var scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = dataSource.Text.Trim();
                scsb.InitialCatalog = initialCatalog.Text.Trim();

                if (trust.Checked == true)
                {
                    scsb.IntegratedSecurity = true;
                }
                else
                {
                    scsb.UserID = userID.Text.Trim();
                    scsb.Password = password.Text.Trim();
                }

                result = scsb.ConnectionString;
            }

            return result;
        }

        private void ChangeWorkSourceDataFilePath(string filePath)
        {
            this.WorkSourceDataFilePath = filePath;
            this.Text = (this.AppTitle + ((filePath != string.Empty) ? (" - " + Path.GetFileName(filePath)) : ""));
            this.MTSB_SaveWorkSource.Enabled = (filePath != string.Empty);
        }

        private void ChangeUserManualConnectionString_SSG()
        {
            this.ChangeUserManualConnectionString(this.SSG_UserManualConnectionString, this.SSG_RawConnectionString, this.SSG_DataSourceTitle, this.SSG_UserIDTitle, this.SSG_PasswordTitle, this.SSG_InitialCatalogTitle, this.SSG_RawConnectionStringTitle, this.SSG_TrustedConnection);
        }

        private void ChangeUserManualConnectionString_TSG()
        {
            this.ChangeUserManualConnectionString(this.TSG_UserManualConnectionString, this.TSG_RawConnectionString, this.TSG_DataSourceTitle, this.TSG_UserIDTitle, this.TSG_PasswordTitle, this.TSG_InitialCatalogTitle, this.TSG_RawConnectionStringTitle, this.TSG_TrustedConnection);
        }

        private void ChangeTrustedConnectionStatus_SSG(bool isClearValue)
        {
            this.ChangeTrustedConnectionStatus(this.SSG_UserID, this.SSG_Password, this.SSG_TrustedConnection, isClearValue);
        }

        private void ChangeTrustedConnectionStatus_TSG(bool isClearValue)
        {
            this.ChangeTrustedConnectionStatus(this.TSG_UserID, this.TSG_Password, this.TSG_TrustedConnection, isClearValue);
        }

        private void AppLoadingTimeOpenDefaultWorkSourceDataFile()
        {
            // 프로그램 로드시 열어야 할 설정파일이 지정됐다면 열자
            // Program started with default work source data file path, open it
            if (this.DefaultWorkSourceDataFilePath != string.Empty)
            {
                this.MTSB_OpenWorkSourceFileOpenDialog.FileName = this.DefaultWorkSourceDataFilePath;
                this.MTSB_OpenWorkSource_Click(null, null);
            }
        }

        // ------------------------------------------------------------------------------------------------

        public MainFrame(string defaultWorkSourceDataFilePath)
        {
            // 프로그램 실행하며 열어야 할 설정 파일이 지정됐을 수 있으니 경로로 지정
            // Program started with default work source data file path, set it
            this.DefaultWorkSourceDataFilePath = defaultWorkSourceDataFilePath;

            this.InitializeComponent();
            this.IsUIKoreanLanguage.Checked = XAppConfig.AppSettings.IsStartAppKoreaHanGulLanguage;
            this.IsUIKoreanLanguage_Click(null, null);
            this.MTSB_NewWorkSource_Click(null, null);
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            this.AppLoadingTimeOpenDefaultWorkSourceDataFile();
        }

        private void MainFrame_Shown(object sender, EventArgs e)
        {
            //>
        }

        private void MainFrame_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainFrame_DragDrop(object sender, DragEventArgs e)
        {
            var isUIKorLang = this.IsUIKoreanLanguage;
            var dndFiles = (e.Data.GetData(DataFormats.FileDrop) as string[]);

            if (dndFiles.Length == 1)
            {
                this.MTSB_OpenWorkSourceFileOpenDialog.FileName = dndFiles[0];
                this.MTSB_OpenWorkSource_Click(null, null);
            }
            else
            {
                var message = ((isUIKorLang.Checked == true) ? "1개의 파일만 가능합니다." : "Allow only one file.");

                MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            if ((e.CloseReason == CloseReason.UserClosing) && (MessageBox.Show("종료 하시겠습니까?", this.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if ((XAppConfig.AppSettings.AppCloseTimeSaveWorkSourceQuestion == true) && (MessageBox.Show("종료 전 현재 설정을 저장하시겠습니까?", this.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    this.MTSB_SaveWorkSource_Click(null, null);
                }
            }
            else
            {
                e.Cancel = true;
            }
            */
            var isUIKorLang = this.IsUIKoreanLanguage;
            var message = ((isUIKorLang.Checked == true) ? "종료 전 현재 설정을 저장하시겠습니까?" : "Exit program before save this setting?");

            if ((XAppConfig.AppSettings.IsAppCloseTimeSaveWorkSourceQuestion == true) && (MessageBox.Show(message, this.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                this.MTSB_SaveWorkSource_Click(null, null);
            }
        }

        private void MTSB_NewWorkSource_Click(object sender, EventArgs e)
        {
            var isUIKorLang = this.IsUIKoreanLanguage;
            var message = ((isUIKorLang.Checked == true) ? "현재 내용을 모두 지우시겠습니까?" : "Clear all this information?");

            if ((sender == null) || ((sender != null) && (MessageBox.Show(message, this.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)))
            {
                var reportPath = XAppConfig.AppSettings.DefaultReportDirectoryPath;
                var isDefaultUserManualConnectionStringMode = XAppConfig.AppSettings.IsDefaultUserManualConnectionStringMode;

                this.ChangeWorkSourceDataFilePath(string.Empty);

                // RGD
                this.RDG_ReportDirectoryPath.Text = reportPath;
                this.RDG_ChangeReportDirectoryDialog.SelectedPath = reportPath;

                // SSG
                this.SSG_DataSourceTitle.Visible = true;
                this.SSG_DataSource.Clear();

                this.SSG_UserIDTitle.Visible = true;
                this.SSG_UserID.Clear();
                this.SSG_UserID.Enabled = true;

                this.SSG_PasswordTitle.Visible = true;
                this.SSG_Password.Clear();
                this.SSG_Password.Enabled = true;

                this.SSG_InitialCatalogTitle.Visible = true;
                this.SSG_InitialCatalog.Clear();

                this.SSG_RawConnectionStringTitle.Visible = false;
                this.SSG_RawConnectionString.Clear();
                this.SSG_RawConnectionString.Visible = false;

                this.SSG_UserManualConnectionString.Checked = isDefaultUserManualConnectionStringMode;

                this.SSG_TrustedConnection.Checked = false;
                this.SSG_TrustedConnection.Visible = true;

                this.ChangeUserManualConnectionString_SSG();
                this.ChangeTrustedConnectionStatus_SSG(true);

                // TSG
                this.TSG_DataSourceTitle.Visible = true;
                this.TSG_DataSource.Clear();

                this.TSG_UserIDTitle.Visible = true;
                this.TSG_UserID.Clear();
                this.TSG_UserID.Enabled = true;

                this.TSG_PasswordTitle.Visible = true;
                this.TSG_Password.Clear();
                this.TSG_Password.Enabled = true;

                this.TSG_InitialCatalogTitle.Visible = true;
                this.TSG_InitialCatalog.Clear();

                this.TSG_RawConnectionStringTitle.Visible = false;
                this.TSG_RawConnectionString.Clear();
                this.TSG_RawConnectionString.Visible = false;

                this.TSG_UserManualConnectionString.Checked = isDefaultUserManualConnectionStringMode;

                this.TSG_TrustedConnection.Checked = false;
                this.TSG_TrustedConnection.Visible = true;

                this.ChangeUserManualConnectionString_TSG();
                this.ChangeTrustedConnectionStatus_TSG(true);
            }
        }

        private void MTSB_SaveWorkSource_Click(object sender, EventArgs e)
        {
            var isUIKorLang = this.IsUIKoreanLanguage.Checked;
            var saveFilePath = this.WorkSourceDataFilePath;

            // 이미 저장된 파일경로가 있으면 재사용하고 없으면 파일 선택하라고 한다 
            // Already saved file path is reused, or if not, select a file
            if (saveFilePath == string.Empty)
            {
                if (this.MTSB_SaveWorkSourceSaveDialog.ShowDialog() == DialogResult.OK)
                {
                    saveFilePath = this.MTSB_SaveWorkSourceSaveDialog.FileName;
                }
            }

            if (saveFilePath != string.Empty)
            {
                // 저장내용 생성
                // Create save content
                var wsd = new XModel.WorkSourceData();
                wsd.ReportDirectoryPath = this.RDG_ReportDirectoryPath.Text.Trim();
                wsd.IsUIKoreanLanguage = this.IsUIKoreanLanguage.Checked;
                // SSG
                wsd.SourceServer = new XModel.WorkSourceServer();
                wsd.SourceServer.DataSource = this.SSG_DataSource.Text.Trim();
                wsd.SourceServer.UserID = this.SSG_UserID.Text.Trim();
                wsd.SourceServer.Password = this.SSG_Password.Text.Trim();
                wsd.SourceServer.InitialCatalog = this.SSG_InitialCatalog.Text.Trim();
                wsd.SourceServer.RawConnectionString = this.SSG_RawConnectionString.Text.Trim();
                wsd.SourceServer.UserManualConnectionString = this.SSG_UserManualConnectionString.Checked;
                wsd.SourceServer.TrustedConnection = this.SSG_TrustedConnection.Checked;
                // TSG
                wsd.TargetServer = new XModel.WorkSourceServer();
                wsd.TargetServer.DataSource = this.TSG_DataSource.Text.Trim();
                wsd.TargetServer.UserID = this.TSG_UserID.Text.Trim();
                wsd.TargetServer.Password = this.TSG_Password.Text.Trim();
                wsd.TargetServer.InitialCatalog = this.TSG_InitialCatalog.Text.Trim();
                wsd.TargetServer.RawConnectionString = this.TSG_RawConnectionString.Text.Trim();
                wsd.TargetServer.UserManualConnectionString = this.TSG_UserManualConnectionString.Checked;
                wsd.TargetServer.TrustedConnection = this.TSG_TrustedConnection.Checked;

                // 비번 저장안한다면 비번 날리기
                // If you do not save your password, throw your password
                if (XAppConfig.AppSettings.IsSaveWorkSourceWithPassword == false)
                {
                    // SSG
                    wsd.SourceServer.Password = string.Empty;

                    // 연결 문자열내 비번이 있을 수 있다
                    // There may be a password in the connection string
                    if (wsd.SourceServer.RawConnectionString != string.Empty)
                    {
                        var scsb = new SqlConnectionStringBuilder(wsd.SourceServer.RawConnectionString);
                        scsb.Password = string.Empty;

                        wsd.SourceServer.RawConnectionString = scsb.ConnectionString;
                    }

                    // TSG
                    wsd.TargetServer.Password = string.Empty;

                    // 연결 문자열내 비번이 있을 수 있다
                    // There may be a password in the connection string
                    if (wsd.TargetServer.RawConnectionString != string.Empty)
                    {
                        var scsb = new SqlConnectionStringBuilder(wsd.TargetServer.RawConnectionString);
                        scsb.Password = string.Empty;

                        wsd.TargetServer.RawConnectionString = scsb.ConnectionString;
                    }
                }

                // JSON 만들기
                // Create JSON
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(
                    wsd,
                    new Newtonsoft.Json.JsonSerializerSettings()
                    {
                        Formatting = Newtonsoft.Json.Formatting.Indented,
                        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                    }
                );

                // 만약 파일이 있으면 백업한다
                // If there is a file, back it up
                if ((XAppConfig.AppSettings.IsSaveWorkSourceBeforeBackupWorkSource == true) && (File.Exists(saveFilePath) == true))
                {
                    var dirPath = Path.Combine(Path.GetDirectoryName(saveFilePath), "WorkSourceBackup");
                    var fileName = (Path.GetFileNameWithoutExtension(saveFilePath) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fffff") + Path.GetExtension(saveFilePath) + ".bak");
                    var backupFilePath = Path.Combine(dirPath, fileName);

                    if (Directory.Exists(dirPath) == false)
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    File.Copy(saveFilePath, backupFilePath);
                }

                // 파일 저장
                // File save
                File.WriteAllText(saveFilePath, json, Encoding.UTF8);

                // 폼 타이틀에 파일명 표시
                // Display file name in form title
                this.ChangeWorkSourceDataFilePath(saveFilePath);

                var message = ((isUIKorLang == true) ? "현재의 설정을 저장했습니다." : "Saved this setting");

                MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MTSB_SaveWorkSource_ClearSaveFilePath_Click(object sender, EventArgs e)
        {
            var isUIKorLang = this.IsUIKoreanLanguage;
            var message = ((isUIKorLang.Checked == true) ? "매번 자동으로 저장되는 정보를 지우겠습니까?" : "Cancel anytime save information?");

            if (MessageBox.Show(message, this.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.ChangeWorkSourceDataFilePath(string.Empty);
            }
        }

        private void MTSB_OpenWorkSource_Click(object sender, EventArgs e)
        {
            var isUIKorLang = this.IsUIKoreanLanguage;
            var isOpenSuccess = false;

            // 드래그 앤 드롭으로도 이거 호출되니 파일 체크해야 함
            // Drag and drop also calls this, so you need to check the file
            if ((sender == null) || ((sender != null) && (this.MTSB_OpenWorkSourceFileOpenDialog.ShowDialog() == DialogResult.OK)))
            {
                var openFilePath = this.MTSB_OpenWorkSourceFileOpenDialog.FileName;

                if ((openFilePath != string.Empty) && (File.Exists(openFilePath) == true))
                {
                    if (Path.GetExtension(openFilePath).ToLower() == ".json")
                    {
                        // JSON만 지원하지만 엉뚱한 파일 넣을 수도 있다 =_=
                        // Only JSON is supported, but you can put in the wrong file = _ =
                        try
                        {
                            // JSON 읽기
                            // Read JSON
                            var json = File.ReadAllText(openFilePath, Encoding.UTF8);

                            // 모델에 데이터 넣기
                            // Put data in the model
                            var wsd = Newtonsoft.Json.JsonConvert.DeserializeObject<XModel.WorkSourceData>(json);

                            this.RDG_ReportDirectoryPath.Text = wsd.ReportDirectoryPath;
                            isUIKorLang.Checked = wsd.IsUIKoreanLanguage;

                            // SSG
                            this.SSG_DataSource.Text = wsd.SourceServer.DataSource;
                            this.SSG_UserID.Text = wsd.SourceServer.UserID;
                            this.SSG_Password.Text = wsd.SourceServer.Password;
                            this.SSG_InitialCatalog.Text = wsd.SourceServer.InitialCatalog;
                            this.SSG_RawConnectionString.Text = wsd.SourceServer.RawConnectionString;
                            this.SSG_UserManualConnectionString.Checked = wsd.SourceServer.UserManualConnectionString;
                            this.SSG_TrustedConnection.Checked = wsd.SourceServer.TrustedConnection;
                            this.ChangeUserManualConnectionString_SSG();
                            this.ChangeTrustedConnectionStatus_SSG(false);

                            // TSG
                            this.TSG_DataSource.Text = wsd.TargetServer.DataSource;
                            this.TSG_UserID.Text = wsd.TargetServer.UserID;
                            this.TSG_Password.Text = wsd.TargetServer.Password;
                            this.TSG_InitialCatalog.Text = wsd.TargetServer.InitialCatalog;
                            this.TSG_RawConnectionString.Text = wsd.TargetServer.RawConnectionString;
                            this.TSG_UserManualConnectionString.Checked = wsd.TargetServer.UserManualConnectionString;
                            this.TSG_TrustedConnection.Checked = wsd.TargetServer.TrustedConnection;
                            this.ChangeUserManualConnectionString_TSG();
                            this.ChangeTrustedConnectionStatus_TSG(false);

                            this.ChangeWorkSourceDataFilePath(openFilePath);

                            isOpenSuccess = true;
                        }
                        catch (Exception ex)
                        {
                            var message = (((isUIKorLang.Checked == true) ? "지원하지 않는 파일입니다." : "Not support file.") + Environment.NewLine + Environment.NewLine + ex.Message);

                            MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        var message = ((isUIKorLang.Checked == true) ? "지원하지 않는 파일형식 입니다." : "Not supported file format.");

                        MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var message = ((isUIKorLang.Checked == true) ? "열려고 하는 파일이 없습니다." : "Not exist try open file.");

                    MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // 혹시나 파일열기 실패하면 선택된 파일정보 지우기
            // If you fail to open the file, delete the selected file information
            if (isOpenSuccess == false)
            {
                this.MTSB_OpenWorkSourceFileOpenDialog.FileName = string.Empty;
            }
        }

        private void MTSB_CloseApplication_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MTSB_AboutApplication_Click(object sender, EventArgs e)
        {
            var isUIKorLang = this.IsUIKoreanLanguage;

            using (var aaf = new XFrame.AboutApplicationFrame(isUIKorLang.Checked))
            {
                aaf.ShowDialog();
            }
        }

        private void RDG_ChangeReportDirectory_Click(object sender, EventArgs e)
        {
            if (this.RDG_ChangeReportDirectoryDialog.ShowDialog() == DialogResult.OK)
            {
                this.RDG_ReportDirectoryPath.Text = this.RDG_ChangeReportDirectoryDialog.SelectedPath;
            }
        }

        private void RDG_OpenReportDirectory_Click(object sender, EventArgs e)
        {
            var isUIKorLang = this.IsUIKoreanLanguage;
            var reportPath = this.RDG_ReportDirectoryPath.Text;

            if (Directory.Exists(reportPath) == true)
            {
                Process.Start("explorer.exe", reportPath);
            }
            else
            {
                var message = ((isUIKorLang.Checked == true) ? "디렉토리가 존재하지 않습니다." : "Not exist directory.");

                MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SSG_UserManualConnectionString_Click(object sender, EventArgs e)
        {
            this.ChangeUserManualConnectionString_SSG();
        }

        private void SSG_TrustedConnection_Click(object sender, EventArgs e)
        {
            this.ChangeTrustedConnectionStatus_SSG(true);
        }

        private void SSG_ConnectTest_Click(object sender, EventArgs e)
        {
            this.ConnectTest(this.SSG_DataSource, this.SSG_UserID, this.SSG_Password, this.SSG_InitialCatalog, this.SSG_RawConnectionString, this.SSG_UserManualConnectionString, this.SSG_TrustedConnection, this.IsUIKoreanLanguage);
        }

        private void TSG_UserManualConnectionString_Click(object sender, EventArgs e)
        {
            this.ChangeUserManualConnectionString_TSG();
        }

        private void TSG_TrustedConnection_Click(object sender, EventArgs e)
        {
            this.ChangeTrustedConnectionStatus_TSG(true);
        }

        private void TSG_ConnectTest_Click(object sender, EventArgs e)
        {
            this.ConnectTest(this.TSG_DataSource, this.TSG_UserID, this.TSG_Password, this.TSG_InitialCatalog, this.TSG_RawConnectionString, this.TSG_UserManualConnectionString, this.TSG_TrustedConnection, this.IsUIKoreanLanguage);
        }

        private void SwapSourceAndTargetServer_Click(object sender, EventArgs e)
        {
            // SSG
            var dataSource = this.SSG_DataSource.Text.Trim();
            var userID = this.SSG_UserID.Text.Trim();
            var password = this.SSG_Password.Text.Trim();
            var initialCatalog = this.SSG_InitialCatalog.Text.Trim();
            var rawConnectionString = this.SSG_RawConnectionString.Text.Trim();
            var userManual = this.SSG_UserManualConnectionString.Checked;
            var trush = this.SSG_TrustedConnection.Checked;

            // SSG <- TSG
            this.SSG_DataSource.Text = this.TSG_DataSource.Text.Trim();
            this.SSG_UserID.Text = this.TSG_UserID.Text.Trim();
            this.SSG_Password.Text = this.TSG_Password.Text.Trim();
            this.SSG_InitialCatalog.Text = this.TSG_InitialCatalog.Text.Trim();
            this.SSG_RawConnectionString.Text = this.TSG_RawConnectionString.Text.Trim();
            this.SSG_UserManualConnectionString.Checked = this.TSG_UserManualConnectionString.Checked;
            this.SSG_TrustedConnection.Checked = this.TSG_TrustedConnection.Checked;
            this.ChangeUserManualConnectionString_SSG();
            this.ChangeTrustedConnectionStatus_SSG(false);

            // TSG <- SSG
            this.TSG_DataSource.Text = dataSource;
            this.TSG_UserID.Text = userID;
            this.TSG_Password.Text = password;
            this.TSG_InitialCatalog.Text = initialCatalog;
            this.TSG_RawConnectionString.Text = rawConnectionString;
            this.TSG_UserManualConnectionString.Checked = userManual;
            this.TSG_TrustedConnection.Checked = trush;
            this.ChangeUserManualConnectionString_TSG();
            this.ChangeTrustedConnectionStatus_TSG(false);
        }

        private void ExecuteCompare_Click(object sender, EventArgs e)
        {
            var isViewCommand = (((sender as Button)?.Tag ?? string.Empty).ToString().ToUpper() == "TRUE");
            var isUIKorLang = this.IsUIKoreanLanguage;
            var isSSGSuccess = this.ConnectionValueCheck(this.SSG_DataSource, this.SSG_UserID, this.SSG_Password, this.SSG_InitialCatalog, this.SSG_RawConnectionString, this.SSG_UserManualConnectionString, this.SSG_TrustedConnection, isUIKorLang);
            var isTSGSuccess = ((isSSGSuccess == true) && this.ConnectionValueCheck(this.TSG_DataSource, this.TSG_UserID, this.TSG_Password, this.TSG_InitialCatalog, this.TSG_RawConnectionString, this.TSG_UserManualConnectionString, this.TSG_TrustedConnection, isUIKorLang) == true);

            if ((isSSGSuccess == true) && (isTSGSuccess == true))
            {
                var reportPath = this.RDG_ReportDirectoryPath.Text.Trim();

                if (Directory.Exists(reportPath) == true)
                {
                    var ssgCS = this.CreateConnectionString(this.SSG_DataSource, this.SSG_UserID, this.SSG_Password, this.SSG_InitialCatalog, this.SSG_RawConnectionString, this.SSG_UserManualConnectionString, this.SSG_TrustedConnection);
                    var tsgCS = this.CreateConnectionString(this.TSG_DataSource, this.TSG_UserID, this.TSG_Password, this.TSG_InitialCatalog, this.TSG_RawConnectionString, this.TSG_UserManualConnectionString, this.TSG_TrustedConnection);

                    if (ssgCS.ToLower() != tsgCS.ToLower())
                    {
                        var appPath = Program.SchemaCompareAppPath;

                        if (File.Exists(appPath) == true)
                        {
                            var appParameter = $"\"{ssgCS}\" \"{tsgCS}\" \"{reportPath}\" \"{isUIKorLang.Checked}\"";

                            if (isViewCommand == true)
                            {
                                var message = (
                                    (
                                        (isUIKorLang.Checked == true) ?
                                        "Ctrl + C 눌러서 현재 대화상자 내용을 복사할 수 있습니다." :
                                        "Press Ctrl + C, copy to this dialog content"
                                    ) + 
                                    Environment.NewLine +
                                    "--------------------------------------------------" + 
                                    Environment.NewLine +
                                    (appPath + " " + appParameter)
                                );

                                MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                var message = ((isUIKorLang.Checked == true) ? "스키마 비교를 시작 하시겠습니까?" : "Start schema compare?");

                                if (MessageBox.Show(message, this.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    // 실행
                                    Process.Start(appPath, appParameter);
                                }
                            }
                        }
                        else
                        {
                            var message = ((isUIKorLang.Checked == true) ? "스키마 비교 프로그램이 존재하지 않습니다." : "Not exist schema compare program.");

                            MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        var message = ((isUIKorLang.Checked == true) ? "소스서버와 타겟서버의 연결문자열이 동일합니다." : "Same connectionstring to source server and target server.");

                        MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var message = ((isUIKorLang.Checked == true) ? "디렉토리가 존재하지 않습니다." : "Not exist directory.");

                    MessageBox.Show(message, this.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void IsUIKoreanLanguage_Click(object sender, EventArgs e)
        {
            var isUIKorLang = this.IsUIKoreanLanguage;
            var appTitle = ((isUIKorLang.Checked == true) ? "SQL Server 스키마 비교" : "SQL Server Schema Compare");

            this.AppTitle = appTitle;
            this.Text = appTitle;

            if (isUIKorLang.Checked == true)
            {
                // 영문이었다가 한글로 바뀜
                // English -> Korean
                // 얘는 이 체크박스 바꾸면 영문으로 바뀐다고 알리기 위한거니 텍스트 반대로 씀
                // This checkbox is for notifying that the text is changed to English when the checkbox is changed.
                isUIKorLang.Text = "현재 한글, 영문으로 변경";
            }
            else
            {
                // 한글이었다가 영문으로 바뀜
                // Korean -> English
                // 얘는 이 체크박스 바꾸면 한글로 바뀐다고 알리기 위한거니 텍스트 반대로 씀
                // This checkbox is for notifying that the text is changed to Korean when the checkbox is changed.
                isUIKorLang.Text = "Now is english, change to korean";
            }

            if (isUIKorLang.Checked == true)
            {
                // 영문이었다가 한글로 바뀜
                // English -> Korean
                this.JustNotify1.Text = "\"소스서버의 스키마가 타겟서버로 적용된다.\"의 개념입니다.";
                this.MTSB_NewWorkSource.Text = "새 비교";
                this.MTSB_OpenWorkSource.Text = "열기";
                this.MTSB_SaveWorkSource.Text = "저장";
                this.MTSB_CloseApplication.Text = "종료";
                this.MTSB_AboutApplication.Text = "정보";
                this.ReportDirectoryGroup.Text = "리포트 디렉토리";
                this.RDG_OpenReportDirectory.Text = "열기";
                this.SwapSourceAndTargetServer.Text = "바꾸기";
                this.ExecuteCompare.Text = "비교 시작";
                this.ViewExecuteCompareCommand.Text = "비교 시작 명령";
                this.MTSB_OpenWorkSourceFileOpenDialog.Title = "열기";
                this.MTSB_SaveWorkSourceSaveDialog.Title = "저장";

                this.SourceServerGroup.Text = "소스서버";
                this.SSG_DataSourceTitle.Text = "서버";
                this.SSG_RawConnectionStringTitle.Text = "연결문자열";
                this.SSG_UserIDTitle.Text = "아이디";
                this.SSG_PasswordTitle.Text = "비밀번호";
                this.SSG_InitialCatalogTitle.Text = "데이터베이스";
                this.SSG_UserManualConnectionString.Text = "직접 입력";
                this.SSG_TrustedConnection.Text = "윈도우 인증";
                this.SSG_ConnectTest.Text = "연결 테스트";

                this.TargetServerGroup.Text = "타겟서버";
                this.TSG_DataSourceTitle.Text = "서버";
                this.TSG_RawConnectionStringTitle.Text = "연결문자열";
                this.TSG_UserIDTitle.Text = "아이디";
                this.TSG_PasswordTitle.Text = "비밀번호";
                this.TSG_InitialCatalogTitle.Text = "데이터베이스";
                this.TSG_UserManualConnectionString.Text = "직접 입력";
                this.TSG_TrustedConnection.Text = "윈도우 인증";
                this.TSG_ConnectTest.Text = "연결 테스트";
            }
            else
            {
                // 한글이었다가 영문으로 바뀜
                // Korean -> English
                this.JustNotify1.Text = "The schema of the SourceServer is applied to the TargetServer.";
                this.MTSB_NewWorkSource.Text = "New";
                this.MTSB_OpenWorkSource.Text = "Open";
                this.MTSB_SaveWorkSource.Text = "Save";
                this.MTSB_CloseApplication.Text = "Exit";
                this.MTSB_AboutApplication.Text = "About";
                this.ReportDirectoryGroup.Text = "Report directory";
                this.RDG_OpenReportDirectory.Text = "Open";
                this.SwapSourceAndTargetServer.Text = "Swap";
                this.ExecuteCompare.Text = "Start Compare";
                this.ViewExecuteCompareCommand.Text = "Start Compare Command";
                this.MTSB_OpenWorkSourceFileOpenDialog.Title = "Open";
                this.MTSB_SaveWorkSourceSaveDialog.Title = "Save";

                this.SourceServerGroup.Text = "SourceServer";
                this.SSG_DataSourceTitle.Text = "Server";
                this.SSG_RawConnectionStringTitle.Text = $"Connection{Environment.NewLine}String";
                this.SSG_UserIDTitle.Text = "ID";
                this.SSG_PasswordTitle.Text = "Password";
                this.SSG_InitialCatalogTitle.Text = "Database";
                this.SSG_UserManualConnectionString.Text = "Manual";
                this.SSG_TrustedConnection.Text = "Trusted";
                this.SSG_ConnectTest.Text = "Connect Test";

                this.TargetServerGroup.Text = "TargetServer";
                this.TSG_DataSourceTitle.Text = "Server";
                this.TSG_RawConnectionStringTitle.Text = $"Connection{Environment.NewLine}String";
                this.TSG_UserIDTitle.Text = "ID";
                this.TSG_PasswordTitle.Text = "Password";
                this.TSG_InitialCatalogTitle.Text = "Database";
                this.TSG_UserManualConnectionString.Text = "Manual";
                this.TSG_TrustedConnection.Text = "Trusted";
                this.TSG_ConnectTest.Text = "Connect Test";
            }
        }

        private void MainFrame_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control == true) && (e.KeyCode == Keys.N))
            {
                this.MTSB_NewWorkSource_Click(null, null);
            }
            else if ((e.Control == true) && (e.KeyCode == Keys.O))
            {
                this.MTSB_OpenWorkSource_Click(sender, null);
            }
            else if (((e.Control == true) && (e.KeyCode == Keys.S)) && (this.MTSB_SaveWorkSource.Enabled == true))
            {
                this.MTSB_SaveWorkSource_Click(null, null);
            }
            else if ((e.Control == true) && (e.KeyCode == Keys.W))
            {
                this.MTSB_CloseApplication_Click(null, null);
            }
        }
    }
}
