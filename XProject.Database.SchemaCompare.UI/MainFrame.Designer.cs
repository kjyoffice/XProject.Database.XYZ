namespace XProject.Database.SchemaCompare.UI
{
    partial class MainFrame
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.SSG_UserIDTitle = new System.Windows.Forms.Label();
            this.SSG_DataSourceTitle = new System.Windows.Forms.Label();
            this.RDG_ReportDirectoryPath = new System.Windows.Forms.TextBox();
            this.RDG_ChangeReportDirectory = new System.Windows.Forms.Button();
            this.RDG_OpenReportDirectory = new System.Windows.Forms.Button();
            this.SSG_DataSource = new System.Windows.Forms.TextBox();
            this.ReportDirectoryGroup = new System.Windows.Forms.GroupBox();
            this.MainToolStripBar = new System.Windows.Forms.ToolStrip();
            this.MTSB_NewWorkSource = new System.Windows.Forms.ToolStripButton();
            this.MTSB_CutBar1 = new System.Windows.Forms.ToolStripSeparator();
            this.MTSB_OpenWorkSource = new System.Windows.Forms.ToolStripButton();
            this.MTSB_SaveWorkSource = new System.Windows.Forms.ToolStripButton();
            this.MTSB_CutBar2 = new System.Windows.Forms.ToolStripSeparator();
            this.MTSB_AboutApplication = new System.Windows.Forms.ToolStripButton();
            this.MTSB_CloseApplication = new System.Windows.Forms.ToolStripButton();
            this.MTSB_CutBar3 = new System.Windows.Forms.ToolStripSeparator();
            this.MTSB_IsUIKoreanLanguage = new System.Windows.Forms.ToolStripButton();
            this.SourceServerGroup = new System.Windows.Forms.GroupBox();
            this.SSG_RawConnectionString = new System.Windows.Forms.TextBox();
            this.SSG_CopyToTSG = new System.Windows.Forms.Button();
            this.SSG_UserManualConnectionString = new System.Windows.Forms.CheckBox();
            this.SSG_InitialCatalogTitle = new System.Windows.Forms.Label();
            this.SSG_ConnectTest = new System.Windows.Forms.Button();
            this.SSG_PasswordTitle = new System.Windows.Forms.Label();
            this.SSG_TrustedConnection = new System.Windows.Forms.CheckBox();
            this.SSG_Password = new System.Windows.Forms.TextBox();
            this.SSG_InitialCatalog = new System.Windows.Forms.TextBox();
            this.SSG_UserID = new System.Windows.Forms.TextBox();
            this.SSG_RawConnectionStringTitle = new System.Windows.Forms.Label();
            this.TargetServerGroup = new System.Windows.Forms.GroupBox();
            this.TSG_RawConnectionString = new System.Windows.Forms.TextBox();
            this.TSG_CopyToSSG = new System.Windows.Forms.Button();
            this.TSG_UserManualConnectionString = new System.Windows.Forms.CheckBox();
            this.TSG_InitialCatalogTitle = new System.Windows.Forms.Label();
            this.TSG_ConnectTest = new System.Windows.Forms.Button();
            this.TSG_PasswordTitle = new System.Windows.Forms.Label();
            this.TSG_UserIDTitle = new System.Windows.Forms.Label();
            this.TSG_DataSourceTitle = new System.Windows.Forms.Label();
            this.TSG_TrustedConnection = new System.Windows.Forms.CheckBox();
            this.TSG_Password = new System.Windows.Forms.TextBox();
            this.TSG_InitialCatalog = new System.Windows.Forms.TextBox();
            this.TSG_UserID = new System.Windows.Forms.TextBox();
            this.TSG_DataSource = new System.Windows.Forms.TextBox();
            this.TSG_RawConnectionStringTitle = new System.Windows.Forms.Label();
            this.JustNotify1 = new System.Windows.Forms.Label();
            this.SwapSourceAndTargetServer = new System.Windows.Forms.Button();
            this.ExecuteCompare = new System.Windows.Forms.Button();
            this.RDG_ChangeReportDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.MTSB_SaveWorkSourceSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.MTSB_OpenWorkSourceFileOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.ViewExecuteCompareCommand = new System.Windows.Forms.Button();
            this.DatabaseListGroup = new System.Windows.Forms.GroupBox();
            this.DLG_PostgreSQL = new System.Windows.Forms.RadioButton();
            this.DLG_MySQL = new System.Windows.Forms.RadioButton();
            this.DLG_SQLServer = new System.Windows.Forms.RadioButton();
            this.ReportDirectoryGroup.SuspendLayout();
            this.MainToolStripBar.SuspendLayout();
            this.SourceServerGroup.SuspendLayout();
            this.TargetServerGroup.SuspendLayout();
            this.DatabaseListGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // SSG_UserIDTitle
            // 
            this.SSG_UserIDTitle.AutoSize = true;
            this.SSG_UserIDTitle.Location = new System.Drawing.Point(6, 100);
            this.SSG_UserIDTitle.Name = "SSG_UserIDTitle";
            this.SSG_UserIDTitle.Size = new System.Drawing.Size(16, 12);
            this.SSG_UserIDTitle.TabIndex = 1;
            this.SSG_UserIDTitle.Text = "ID";
            // 
            // SSG_DataSourceTitle
            // 
            this.SSG_DataSourceTitle.AutoSize = true;
            this.SSG_DataSourceTitle.Location = new System.Drawing.Point(6, 43);
            this.SSG_DataSourceTitle.Name = "SSG_DataSourceTitle";
            this.SSG_DataSourceTitle.Size = new System.Drawing.Size(41, 12);
            this.SSG_DataSourceTitle.TabIndex = 1;
            this.SSG_DataSourceTitle.Text = "Server";
            // 
            // RDG_ReportDirectoryPath
            // 
            this.RDG_ReportDirectoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RDG_ReportDirectoryPath.Location = new System.Drawing.Point(6, 19);
            this.RDG_ReportDirectoryPath.Name = "RDG_ReportDirectoryPath";
            this.RDG_ReportDirectoryPath.ReadOnly = true;
            this.RDG_ReportDirectoryPath.Size = new System.Drawing.Size(936, 21);
            this.RDG_ReportDirectoryPath.TabIndex = 2;
            // 
            // RDG_ChangeReportDirectory
            // 
            this.RDG_ChangeReportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RDG_ChangeReportDirectory.Location = new System.Drawing.Point(948, 12);
            this.RDG_ChangeReportDirectory.Name = "RDG_ChangeReportDirectory";
            this.RDG_ChangeReportDirectory.Size = new System.Drawing.Size(100, 26);
            this.RDG_ChangeReportDirectory.TabIndex = 0;
            this.RDG_ChangeReportDirectory.Text = "...";
            this.RDG_ChangeReportDirectory.UseVisualStyleBackColor = true;
            this.RDG_ChangeReportDirectory.Click += new System.EventHandler(this.RDG_ChangeReportDirectory_Click);
            // 
            // RDG_OpenReportDirectory
            // 
            this.RDG_OpenReportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RDG_OpenReportDirectory.Location = new System.Drawing.Point(1054, 12);
            this.RDG_OpenReportDirectory.Name = "RDG_OpenReportDirectory";
            this.RDG_OpenReportDirectory.Size = new System.Drawing.Size(100, 26);
            this.RDG_OpenReportDirectory.TabIndex = 0;
            this.RDG_OpenReportDirectory.Text = "Open";
            this.RDG_OpenReportDirectory.UseVisualStyleBackColor = true;
            this.RDG_OpenReportDirectory.Click += new System.EventHandler(this.RDG_OpenReportDirectory_Click);
            // 
            // SSG_DataSource
            // 
            this.SSG_DataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SSG_DataSource.Location = new System.Drawing.Point(108, 41);
            this.SSG_DataSource.Name = "SSG_DataSource";
            this.SSG_DataSource.Size = new System.Drawing.Size(386, 21);
            this.SSG_DataSource.TabIndex = 100;
            // 
            // ReportDirectoryGroup
            // 
            this.ReportDirectoryGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportDirectoryGroup.Controls.Add(this.RDG_ReportDirectoryPath);
            this.ReportDirectoryGroup.Controls.Add(this.RDG_ChangeReportDirectory);
            this.ReportDirectoryGroup.Controls.Add(this.RDG_OpenReportDirectory);
            this.ReportDirectoryGroup.Location = new System.Drawing.Point(12, 27);
            this.ReportDirectoryGroup.Name = "ReportDirectoryGroup";
            this.ReportDirectoryGroup.Size = new System.Drawing.Size(1160, 46);
            this.ReportDirectoryGroup.TabIndex = 3;
            this.ReportDirectoryGroup.TabStop = false;
            this.ReportDirectoryGroup.Text = "ReportDirectory";
            // 
            // MainToolStripBar
            // 
            this.MainToolStripBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainToolStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MTSB_NewWorkSource,
            this.MTSB_CutBar1,
            this.MTSB_OpenWorkSource,
            this.MTSB_SaveWorkSource,
            this.MTSB_CutBar2,
            this.MTSB_AboutApplication,
            this.MTSB_CloseApplication,
            this.MTSB_CutBar3,
            this.MTSB_IsUIKoreanLanguage});
            this.MainToolStripBar.Location = new System.Drawing.Point(0, 0);
            this.MainToolStripBar.Name = "MainToolStripBar";
            this.MainToolStripBar.Size = new System.Drawing.Size(1184, 25);
            this.MainToolStripBar.TabIndex = 5;
            // 
            // MTSB_NewWorkSource
            // 
            this.MTSB_NewWorkSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MTSB_NewWorkSource.Name = "MTSB_NewWorkSource";
            this.MTSB_NewWorkSource.Size = new System.Drawing.Size(35, 22);
            this.MTSB_NewWorkSource.Text = "New";
            this.MTSB_NewWorkSource.Click += new System.EventHandler(this.MTSB_NewWorkSource_Click);
            // 
            // MTSB_CutBar1
            // 
            this.MTSB_CutBar1.Name = "MTSB_CutBar1";
            this.MTSB_CutBar1.Size = new System.Drawing.Size(6, 25);
            // 
            // MTSB_OpenWorkSource
            // 
            this.MTSB_OpenWorkSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MTSB_OpenWorkSource.Name = "MTSB_OpenWorkSource";
            this.MTSB_OpenWorkSource.Size = new System.Drawing.Size(40, 22);
            this.MTSB_OpenWorkSource.Text = "Open";
            this.MTSB_OpenWorkSource.Click += new System.EventHandler(this.MTSB_OpenWorkSource_Click);
            // 
            // MTSB_SaveWorkSource
            // 
            this.MTSB_SaveWorkSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MTSB_SaveWorkSource.Name = "MTSB_SaveWorkSource";
            this.MTSB_SaveWorkSource.Size = new System.Drawing.Size(36, 22);
            this.MTSB_SaveWorkSource.Text = "Save";
            this.MTSB_SaveWorkSource.Click += new System.EventHandler(this.MTSB_SaveWorkSource_Click);
            // 
            // MTSB_CutBar2
            // 
            this.MTSB_CutBar2.Name = "MTSB_CutBar2";
            this.MTSB_CutBar2.Size = new System.Drawing.Size(6, 25);
            // 
            // MTSB_AboutApplication
            // 
            this.MTSB_AboutApplication.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MTSB_AboutApplication.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MTSB_AboutApplication.Name = "MTSB_AboutApplication";
            this.MTSB_AboutApplication.Size = new System.Drawing.Size(44, 22);
            this.MTSB_AboutApplication.Text = "About";
            this.MTSB_AboutApplication.Click += new System.EventHandler(this.MTSB_AboutApplication_Click);
            // 
            // MTSB_CloseApplication
            // 
            this.MTSB_CloseApplication.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MTSB_CloseApplication.Name = "MTSB_CloseApplication";
            this.MTSB_CloseApplication.Size = new System.Drawing.Size(30, 22);
            this.MTSB_CloseApplication.Text = "Exit";
            this.MTSB_CloseApplication.Click += new System.EventHandler(this.MTSB_CloseApplication_Click);
            // 
            // MTSB_CutBar3
            // 
            this.MTSB_CutBar3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MTSB_CutBar3.Name = "MTSB_CutBar3";
            this.MTSB_CutBar3.Size = new System.Drawing.Size(6, 25);
            // 
            // MTSB_IsUIKoreanLanguage
            // 
            this.MTSB_IsUIKoreanLanguage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MTSB_IsUIKoreanLanguage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MTSB_IsUIKoreanLanguage.Image = ((System.Drawing.Image)(resources.GetObject("MTSB_IsUIKoreanLanguage.Image")));
            this.MTSB_IsUIKoreanLanguage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MTSB_IsUIKoreanLanguage.Name = "MTSB_IsUIKoreanLanguage";
            this.MTSB_IsUIKoreanLanguage.Size = new System.Drawing.Size(100, 22);
            this.MTSB_IsUIKoreanLanguage.Text = "KoreanLanguage";
            this.MTSB_IsUIKoreanLanguage.Click += new System.EventHandler(this.MTSB_IsUIKoreanLanguage_Click);
            // 
            // SourceServerGroup
            // 
            this.SourceServerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SourceServerGroup.Controls.Add(this.SSG_RawConnectionString);
            this.SourceServerGroup.Controls.Add(this.SSG_CopyToTSG);
            this.SourceServerGroup.Controls.Add(this.SSG_UserManualConnectionString);
            this.SourceServerGroup.Controls.Add(this.SSG_InitialCatalogTitle);
            this.SourceServerGroup.Controls.Add(this.SSG_ConnectTest);
            this.SourceServerGroup.Controls.Add(this.SSG_PasswordTitle);
            this.SourceServerGroup.Controls.Add(this.SSG_UserIDTitle);
            this.SourceServerGroup.Controls.Add(this.SSG_DataSourceTitle);
            this.SourceServerGroup.Controls.Add(this.SSG_TrustedConnection);
            this.SourceServerGroup.Controls.Add(this.SSG_Password);
            this.SourceServerGroup.Controls.Add(this.SSG_InitialCatalog);
            this.SourceServerGroup.Controls.Add(this.SSG_UserID);
            this.SourceServerGroup.Controls.Add(this.SSG_DataSource);
            this.SourceServerGroup.Controls.Add(this.SSG_RawConnectionStringTitle);
            this.SourceServerGroup.Location = new System.Drawing.Point(12, 133);
            this.SourceServerGroup.Name = "SourceServerGroup";
            this.SourceServerGroup.Size = new System.Drawing.Size(500, 288);
            this.SourceServerGroup.TabIndex = 6;
            this.SourceServerGroup.TabStop = false;
            this.SourceServerGroup.Text = "SourceServer";
            // 
            // SSG_RawConnectionString
            // 
            this.SSG_RawConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SSG_RawConnectionString.Location = new System.Drawing.Point(108, 41);
            this.SSG_RawConnectionString.Multiline = true;
            this.SSG_RawConnectionString.Name = "SSG_RawConnectionString";
            this.SSG_RawConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SSG_RawConnectionString.Size = new System.Drawing.Size(386, 138);
            this.SSG_RawConnectionString.TabIndex = 10;
            // 
            // SSG_CopyToTSG
            // 
            this.SSG_CopyToTSG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SSG_CopyToTSG.Location = new System.Drawing.Point(108, 253);
            this.SSG_CopyToTSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SSG_CopyToTSG.Name = "SSG_CopyToTSG";
            this.SSG_CopyToTSG.Size = new System.Drawing.Size(386, 30);
            this.SSG_CopyToTSG.TabIndex = 105;
            this.SSG_CopyToTSG.Text = "CopyToTarget";
            this.SSG_CopyToTSG.UseVisualStyleBackColor = true;
            this.SSG_CopyToTSG.Click += new System.EventHandler(this.SSG_CopyToTSG_Click);
            // 
            // SSG_UserManualConnectionString
            // 
            this.SSG_UserManualConnectionString.AutoSize = true;
            this.SSG_UserManualConnectionString.Location = new System.Drawing.Point(108, 19);
            this.SSG_UserManualConnectionString.Name = "SSG_UserManualConnectionString";
            this.SSG_UserManualConnectionString.Size = new System.Drawing.Size(66, 16);
            this.SSG_UserManualConnectionString.TabIndex = 10;
            this.SSG_UserManualConnectionString.Text = "Manual";
            this.SSG_UserManualConnectionString.UseVisualStyleBackColor = true;
            this.SSG_UserManualConnectionString.Click += new System.EventHandler(this.SSG_UserManualConnectionString_Click);
            // 
            // SSG_InitialCatalogTitle
            // 
            this.SSG_InitialCatalogTitle.AutoSize = true;
            this.SSG_InitialCatalogTitle.Location = new System.Drawing.Point(6, 160);
            this.SSG_InitialCatalogTitle.Name = "SSG_InitialCatalogTitle";
            this.SSG_InitialCatalogTitle.Size = new System.Drawing.Size(55, 12);
            this.SSG_InitialCatalogTitle.TabIndex = 10;
            this.SSG_InitialCatalogTitle.Text = "DBName";
            // 
            // SSG_ConnectTest
            // 
            this.SSG_ConnectTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SSG_ConnectTest.Location = new System.Drawing.Point(108, 185);
            this.SSG_ConnectTest.Name = "SSG_ConnectTest";
            this.SSG_ConnectTest.Size = new System.Drawing.Size(386, 63);
            this.SSG_ConnectTest.TabIndex = 104;
            this.SSG_ConnectTest.Text = "ConnTest";
            this.SSG_ConnectTest.UseVisualStyleBackColor = true;
            this.SSG_ConnectTest.Click += new System.EventHandler(this.SSG_ConnectTest_Click);
            // 
            // SSG_PasswordTitle
            // 
            this.SSG_PasswordTitle.AutoSize = true;
            this.SSG_PasswordTitle.Location = new System.Drawing.Point(6, 130);
            this.SSG_PasswordTitle.Name = "SSG_PasswordTitle";
            this.SSG_PasswordTitle.Size = new System.Drawing.Size(23, 12);
            this.SSG_PasswordTitle.TabIndex = 1;
            this.SSG_PasswordTitle.Text = "PW";
            // 
            // SSG_TrustedConnection
            // 
            this.SSG_TrustedConnection.AutoSize = true;
            this.SSG_TrustedConnection.Location = new System.Drawing.Point(108, 71);
            this.SSG_TrustedConnection.Name = "SSG_TrustedConnection";
            this.SSG_TrustedConnection.Size = new System.Drawing.Size(78, 16);
            this.SSG_TrustedConnection.TabIndex = 3;
            this.SSG_TrustedConnection.Text = "TrustAuth";
            this.SSG_TrustedConnection.UseVisualStyleBackColor = true;
            this.SSG_TrustedConnection.Click += new System.EventHandler(this.SSG_TrustedConnection_Click);
            // 
            // SSG_Password
            // 
            this.SSG_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SSG_Password.Location = new System.Drawing.Point(108, 127);
            this.SSG_Password.Name = "SSG_Password";
            this.SSG_Password.Size = new System.Drawing.Size(386, 21);
            this.SSG_Password.TabIndex = 102;
            this.SSG_Password.UseSystemPasswordChar = true;
            // 
            // SSG_InitialCatalog
            // 
            this.SSG_InitialCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SSG_InitialCatalog.Location = new System.Drawing.Point(108, 157);
            this.SSG_InitialCatalog.Name = "SSG_InitialCatalog";
            this.SSG_InitialCatalog.Size = new System.Drawing.Size(386, 21);
            this.SSG_InitialCatalog.TabIndex = 103;
            // 
            // SSG_UserID
            // 
            this.SSG_UserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SSG_UserID.Location = new System.Drawing.Point(108, 97);
            this.SSG_UserID.Name = "SSG_UserID";
            this.SSG_UserID.Size = new System.Drawing.Size(386, 21);
            this.SSG_UserID.TabIndex = 101;
            // 
            // SSG_RawConnectionStringTitle
            // 
            this.SSG_RawConnectionStringTitle.AutoSize = true;
            this.SSG_RawConnectionStringTitle.Location = new System.Drawing.Point(6, 44);
            this.SSG_RawConnectionStringTitle.Name = "SSG_RawConnectionStringTitle";
            this.SSG_RawConnectionStringTitle.Size = new System.Drawing.Size(50, 12);
            this.SSG_RawConnectionStringTitle.TabIndex = 10;
            this.SSG_RawConnectionStringTitle.Text = "ConnStr";
            // 
            // TargetServerGroup
            // 
            this.TargetServerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetServerGroup.Controls.Add(this.TSG_RawConnectionString);
            this.TargetServerGroup.Controls.Add(this.TSG_CopyToSSG);
            this.TargetServerGroup.Controls.Add(this.TSG_UserManualConnectionString);
            this.TargetServerGroup.Controls.Add(this.TSG_InitialCatalogTitle);
            this.TargetServerGroup.Controls.Add(this.TSG_ConnectTest);
            this.TargetServerGroup.Controls.Add(this.TSG_PasswordTitle);
            this.TargetServerGroup.Controls.Add(this.TSG_UserIDTitle);
            this.TargetServerGroup.Controls.Add(this.TSG_DataSourceTitle);
            this.TargetServerGroup.Controls.Add(this.TSG_TrustedConnection);
            this.TargetServerGroup.Controls.Add(this.TSG_Password);
            this.TargetServerGroup.Controls.Add(this.TSG_InitialCatalog);
            this.TargetServerGroup.Controls.Add(this.TSG_UserID);
            this.TargetServerGroup.Controls.Add(this.TSG_DataSource);
            this.TargetServerGroup.Controls.Add(this.TSG_RawConnectionStringTitle);
            this.TargetServerGroup.Location = new System.Drawing.Point(672, 133);
            this.TargetServerGroup.Name = "TargetServerGroup";
            this.TargetServerGroup.Size = new System.Drawing.Size(500, 288);
            this.TargetServerGroup.TabIndex = 6;
            this.TargetServerGroup.TabStop = false;
            this.TargetServerGroup.Text = "TargetServer";
            // 
            // TSG_RawConnectionString
            // 
            this.TSG_RawConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TSG_RawConnectionString.Location = new System.Drawing.Point(108, 41);
            this.TSG_RawConnectionString.Multiline = true;
            this.TSG_RawConnectionString.Name = "TSG_RawConnectionString";
            this.TSG_RawConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TSG_RawConnectionString.Size = new System.Drawing.Size(386, 138);
            this.TSG_RawConnectionString.TabIndex = 10;
            // 
            // TSG_CopyToSSG
            // 
            this.TSG_CopyToSSG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TSG_CopyToSSG.Location = new System.Drawing.Point(108, 253);
            this.TSG_CopyToSSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TSG_CopyToSSG.Name = "TSG_CopyToSSG";
            this.TSG_CopyToSSG.Size = new System.Drawing.Size(386, 30);
            this.TSG_CopyToSSG.TabIndex = 110;
            this.TSG_CopyToSSG.Text = "CopyToSource";
            this.TSG_CopyToSSG.UseVisualStyleBackColor = true;
            this.TSG_CopyToSSG.Click += new System.EventHandler(this.TSG_CopyToSSG_Click);
            // 
            // TSG_UserManualConnectionString
            // 
            this.TSG_UserManualConnectionString.AutoSize = true;
            this.TSG_UserManualConnectionString.Location = new System.Drawing.Point(108, 19);
            this.TSG_UserManualConnectionString.Name = "TSG_UserManualConnectionString";
            this.TSG_UserManualConnectionString.Size = new System.Drawing.Size(66, 16);
            this.TSG_UserManualConnectionString.TabIndex = 10;
            this.TSG_UserManualConnectionString.Text = "Manual";
            this.TSG_UserManualConnectionString.UseVisualStyleBackColor = true;
            this.TSG_UserManualConnectionString.Click += new System.EventHandler(this.TSG_UserManualConnectionString_Click);
            // 
            // TSG_InitialCatalogTitle
            // 
            this.TSG_InitialCatalogTitle.AutoSize = true;
            this.TSG_InitialCatalogTitle.Location = new System.Drawing.Point(6, 160);
            this.TSG_InitialCatalogTitle.Name = "TSG_InitialCatalogTitle";
            this.TSG_InitialCatalogTitle.Size = new System.Drawing.Size(55, 12);
            this.TSG_InitialCatalogTitle.TabIndex = 10;
            this.TSG_InitialCatalogTitle.Text = "DBName";
            // 
            // TSG_ConnectTest
            // 
            this.TSG_ConnectTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TSG_ConnectTest.Location = new System.Drawing.Point(108, 185);
            this.TSG_ConnectTest.Name = "TSG_ConnectTest";
            this.TSG_ConnectTest.Size = new System.Drawing.Size(386, 63);
            this.TSG_ConnectTest.TabIndex = 109;
            this.TSG_ConnectTest.Text = "ConnTest";
            this.TSG_ConnectTest.UseVisualStyleBackColor = true;
            this.TSG_ConnectTest.Click += new System.EventHandler(this.TSG_ConnectTest_Click);
            // 
            // TSG_PasswordTitle
            // 
            this.TSG_PasswordTitle.AutoSize = true;
            this.TSG_PasswordTitle.Location = new System.Drawing.Point(6, 130);
            this.TSG_PasswordTitle.Name = "TSG_PasswordTitle";
            this.TSG_PasswordTitle.Size = new System.Drawing.Size(23, 12);
            this.TSG_PasswordTitle.TabIndex = 1;
            this.TSG_PasswordTitle.Text = "PW";
            // 
            // TSG_UserIDTitle
            // 
            this.TSG_UserIDTitle.AutoSize = true;
            this.TSG_UserIDTitle.Location = new System.Drawing.Point(6, 100);
            this.TSG_UserIDTitle.Name = "TSG_UserIDTitle";
            this.TSG_UserIDTitle.Size = new System.Drawing.Size(16, 12);
            this.TSG_UserIDTitle.TabIndex = 1;
            this.TSG_UserIDTitle.Text = "ID";
            // 
            // TSG_DataSourceTitle
            // 
            this.TSG_DataSourceTitle.AutoSize = true;
            this.TSG_DataSourceTitle.Location = new System.Drawing.Point(6, 43);
            this.TSG_DataSourceTitle.Name = "TSG_DataSourceTitle";
            this.TSG_DataSourceTitle.Size = new System.Drawing.Size(41, 12);
            this.TSG_DataSourceTitle.TabIndex = 1;
            this.TSG_DataSourceTitle.Text = "Server";
            // 
            // TSG_TrustedConnection
            // 
            this.TSG_TrustedConnection.AutoSize = true;
            this.TSG_TrustedConnection.Location = new System.Drawing.Point(108, 71);
            this.TSG_TrustedConnection.Name = "TSG_TrustedConnection";
            this.TSG_TrustedConnection.Size = new System.Drawing.Size(78, 16);
            this.TSG_TrustedConnection.TabIndex = 3;
            this.TSG_TrustedConnection.Text = "TrustAuth";
            this.TSG_TrustedConnection.UseVisualStyleBackColor = true;
            this.TSG_TrustedConnection.Click += new System.EventHandler(this.TSG_TrustedConnection_Click);
            // 
            // TSG_Password
            // 
            this.TSG_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TSG_Password.Location = new System.Drawing.Point(108, 127);
            this.TSG_Password.Name = "TSG_Password";
            this.TSG_Password.Size = new System.Drawing.Size(386, 21);
            this.TSG_Password.TabIndex = 107;
            this.TSG_Password.UseSystemPasswordChar = true;
            // 
            // TSG_InitialCatalog
            // 
            this.TSG_InitialCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TSG_InitialCatalog.Location = new System.Drawing.Point(108, 157);
            this.TSG_InitialCatalog.Name = "TSG_InitialCatalog";
            this.TSG_InitialCatalog.Size = new System.Drawing.Size(386, 21);
            this.TSG_InitialCatalog.TabIndex = 108;
            // 
            // TSG_UserID
            // 
            this.TSG_UserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TSG_UserID.Location = new System.Drawing.Point(108, 97);
            this.TSG_UserID.Name = "TSG_UserID";
            this.TSG_UserID.Size = new System.Drawing.Size(386, 21);
            this.TSG_UserID.TabIndex = 106;
            // 
            // TSG_DataSource
            // 
            this.TSG_DataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TSG_DataSource.Location = new System.Drawing.Point(108, 41);
            this.TSG_DataSource.Name = "TSG_DataSource";
            this.TSG_DataSource.Size = new System.Drawing.Size(386, 21);
            this.TSG_DataSource.TabIndex = 105;
            // 
            // TSG_RawConnectionStringTitle
            // 
            this.TSG_RawConnectionStringTitle.AutoSize = true;
            this.TSG_RawConnectionStringTitle.Location = new System.Drawing.Point(6, 43);
            this.TSG_RawConnectionStringTitle.Name = "TSG_RawConnectionStringTitle";
            this.TSG_RawConnectionStringTitle.Size = new System.Drawing.Size(50, 12);
            this.TSG_RawConnectionStringTitle.TabIndex = 10;
            this.TSG_RawConnectionStringTitle.Text = "ConnStr";
            // 
            // JustNotify1
            // 
            this.JustNotify1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.JustNotify1.AutoSize = true;
            this.JustNotify1.ForeColor = System.Drawing.Color.Blue;
            this.JustNotify1.Location = new System.Drawing.Point(12, 438);
            this.JustNotify1.Margin = new System.Windows.Forms.Padding(0);
            this.JustNotify1.Name = "JustNotify1";
            this.JustNotify1.Size = new System.Drawing.Size(66, 12);
            this.JustNotify1.TabIndex = 7;
            this.JustNotify1.Text = "JustNotify1";
            // 
            // SwapSourceAndTargetServer
            // 
            this.SwapSourceAndTargetServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.SwapSourceAndTargetServer.Location = new System.Drawing.Point(542, 133);
            this.SwapSourceAndTargetServer.Name = "SwapSourceAndTargetServer";
            this.SwapSourceAndTargetServer.Size = new System.Drawing.Size(100, 288);
            this.SwapSourceAndTargetServer.TabIndex = 8;
            this.SwapSourceAndTargetServer.Text = "Swap";
            this.SwapSourceAndTargetServer.UseVisualStyleBackColor = true;
            this.SwapSourceAndTargetServer.Click += new System.EventHandler(this.SwapSourceAndTargetServer_Click);
            // 
            // ExecuteCompare
            // 
            this.ExecuteCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteCompare.Location = new System.Drawing.Point(12, 453);
            this.ExecuteCompare.Name = "ExecuteCompare";
            this.ExecuteCompare.Size = new System.Drawing.Size(1160, 66);
            this.ExecuteCompare.TabIndex = 110;
            this.ExecuteCompare.Text = "Start";
            this.ExecuteCompare.UseVisualStyleBackColor = true;
            this.ExecuteCompare.Click += new System.EventHandler(this.ExecuteCompare_Click);
            // 
            // MTSB_SaveWorkSourceSaveDialog
            // 
            this.MTSB_SaveWorkSourceSaveDialog.DefaultExt = "json";
            this.MTSB_SaveWorkSourceSaveDialog.Filter = "JSON (*.json)|*.json";
            this.MTSB_SaveWorkSourceSaveDialog.Title = "저장";
            // 
            // MTSB_OpenWorkSourceFileOpenDialog
            // 
            this.MTSB_OpenWorkSourceFileOpenDialog.DefaultExt = "json";
            this.MTSB_OpenWorkSourceFileOpenDialog.Filter = "JSON (*.json)|*.json";
            this.MTSB_OpenWorkSourceFileOpenDialog.Title = "열기";
            // 
            // ViewExecuteCompareCommand
            // 
            this.ViewExecuteCompareCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewExecuteCompareCommand.Location = new System.Drawing.Point(12, 525);
            this.ViewExecuteCompareCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ViewExecuteCompareCommand.Name = "ViewExecuteCompareCommand";
            this.ViewExecuteCompareCommand.Size = new System.Drawing.Size(1160, 26);
            this.ViewExecuteCompareCommand.TabIndex = 112;
            this.ViewExecuteCompareCommand.Tag = "TRUE";
            this.ViewExecuteCompareCommand.Text = "ViewStartCommand";
            this.ViewExecuteCompareCommand.UseVisualStyleBackColor = true;
            this.ViewExecuteCompareCommand.Click += new System.EventHandler(this.ExecuteCompare_Click);
            // 
            // DatabaseListGroup
            // 
            this.DatabaseListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabaseListGroup.Controls.Add(this.DLG_PostgreSQL);
            this.DatabaseListGroup.Controls.Add(this.DLG_MySQL);
            this.DatabaseListGroup.Controls.Add(this.DLG_SQLServer);
            this.DatabaseListGroup.Location = new System.Drawing.Point(12, 79);
            this.DatabaseListGroup.Name = "DatabaseListGroup";
            this.DatabaseListGroup.Size = new System.Drawing.Size(1160, 48);
            this.DatabaseListGroup.TabIndex = 113;
            this.DatabaseListGroup.TabStop = false;
            this.DatabaseListGroup.Text = "DatabaseList";
            // 
            // DLG_PostgreSQL
            // 
            this.DLG_PostgreSQL.AutoSize = true;
            this.DLG_PostgreSQL.Location = new System.Drawing.Point(168, 20);
            this.DLG_PostgreSQL.Name = "DLG_PostgreSQL";
            this.DLG_PostgreSQL.Size = new System.Drawing.Size(90, 16);
            this.DLG_PostgreSQL.TabIndex = 2;
            this.DLG_PostgreSQL.TabStop = true;
            this.DLG_PostgreSQL.Text = "PostgreSQL";
            this.DLG_PostgreSQL.UseVisualStyleBackColor = true;
            this.DLG_PostgreSQL.Click += new System.EventHandler(this.DLG_DatabaseTypeX_Click);
            // 
            // DLG_MySQL
            // 
            this.DLG_MySQL.AutoSize = true;
            this.DLG_MySQL.Location = new System.Drawing.Point(97, 20);
            this.DLG_MySQL.Name = "DLG_MySQL";
            this.DLG_MySQL.Size = new System.Drawing.Size(65, 16);
            this.DLG_MySQL.TabIndex = 1;
            this.DLG_MySQL.TabStop = true;
            this.DLG_MySQL.Text = "MySQL";
            this.DLG_MySQL.UseVisualStyleBackColor = true;
            this.DLG_MySQL.Click += new System.EventHandler(this.DLG_DatabaseTypeX_Click);
            // 
            // DLG_SQLServer
            // 
            this.DLG_SQLServer.AutoSize = true;
            this.DLG_SQLServer.Location = new System.Drawing.Point(8, 20);
            this.DLG_SQLServer.Name = "DLG_SQLServer";
            this.DLG_SQLServer.Size = new System.Drawing.Size(83, 16);
            this.DLG_SQLServer.TabIndex = 0;
            this.DLG_SQLServer.TabStop = true;
            this.DLG_SQLServer.Text = "SQLServer";
            this.DLG_SQLServer.UseVisualStyleBackColor = true;
            this.DLG_SQLServer.Click += new System.EventHandler(this.DLG_DatabaseTypeX_Click);
            // 
            // MainFrame
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.DatabaseListGroup);
            this.Controls.Add(this.ViewExecuteCompareCommand);
            this.Controls.Add(this.ExecuteCompare);
            this.Controls.Add(this.SwapSourceAndTargetServer);
            this.Controls.Add(this.JustNotify1);
            this.Controls.Add(this.TargetServerGroup);
            this.Controls.Add(this.SourceServerGroup);
            this.Controls.Add(this.MainToolStripBar);
            this.Controls.Add(this.ReportDirectoryGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainTitle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrame_FormClosing);
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.Shown += new System.EventHandler(this.MainFrame_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainFrame_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainFrame_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFrame_KeyDown);
            this.ReportDirectoryGroup.ResumeLayout(false);
            this.ReportDirectoryGroup.PerformLayout();
            this.MainToolStripBar.ResumeLayout(false);
            this.MainToolStripBar.PerformLayout();
            this.SourceServerGroup.ResumeLayout(false);
            this.SourceServerGroup.PerformLayout();
            this.TargetServerGroup.ResumeLayout(false);
            this.TargetServerGroup.PerformLayout();
            this.DatabaseListGroup.ResumeLayout(false);
            this.DatabaseListGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label SSG_UserIDTitle;
        private System.Windows.Forms.Label SSG_DataSourceTitle;
        private System.Windows.Forms.TextBox RDG_ReportDirectoryPath;
        private System.Windows.Forms.Button RDG_ChangeReportDirectory;
        private System.Windows.Forms.Button RDG_OpenReportDirectory;
        private System.Windows.Forms.TextBox SSG_DataSource;
        private System.Windows.Forms.GroupBox ReportDirectoryGroup;
        private System.Windows.Forms.ToolStrip MainToolStripBar;
        private System.Windows.Forms.ToolStripSeparator MTSB_CutBar1;
        private System.Windows.Forms.GroupBox SourceServerGroup;
        private System.Windows.Forms.Button SSG_ConnectTest;
        private System.Windows.Forms.CheckBox SSG_TrustedConnection;
        private System.Windows.Forms.TextBox SSG_Password;
        private System.Windows.Forms.TextBox SSG_UserID;
        private System.Windows.Forms.Label SSG_PasswordTitle;
        private System.Windows.Forms.GroupBox TargetServerGroup;
        private System.Windows.Forms.Button TSG_ConnectTest;
        private System.Windows.Forms.CheckBox TSG_TrustedConnection;
        private System.Windows.Forms.Label TSG_DataSourceTitle;
        private System.Windows.Forms.TextBox TSG_Password;
        private System.Windows.Forms.TextBox TSG_UserID;
        private System.Windows.Forms.TextBox TSG_DataSource;
        private System.Windows.Forms.Label TSG_PasswordTitle;
        private System.Windows.Forms.Label TSG_UserIDTitle;
        private System.Windows.Forms.Label JustNotify1;
        private System.Windows.Forms.Button SwapSourceAndTargetServer;
        private System.Windows.Forms.ToolStripButton MTSB_NewWorkSource;
        private System.Windows.Forms.ToolStripButton MTSB_SaveWorkSource;
        private System.Windows.Forms.ToolStripButton MTSB_OpenWorkSource;
        private System.Windows.Forms.ToolStripButton MTSB_CloseApplication;
        private System.Windows.Forms.Button ExecuteCompare;
        private System.Windows.Forms.FolderBrowserDialog RDG_ChangeReportDirectoryDialog;
        private System.Windows.Forms.Label SSG_InitialCatalogTitle;
        private System.Windows.Forms.TextBox SSG_InitialCatalog;
        private System.Windows.Forms.Label TSG_InitialCatalogTitle;
        private System.Windows.Forms.TextBox TSG_InitialCatalog;
        private System.Windows.Forms.CheckBox SSG_UserManualConnectionString;
        private System.Windows.Forms.CheckBox TSG_UserManualConnectionString;
        private System.Windows.Forms.TextBox SSG_RawConnectionString;
        private System.Windows.Forms.TextBox TSG_RawConnectionString;
        private System.Windows.Forms.Label SSG_RawConnectionStringTitle;
        private System.Windows.Forms.Label TSG_RawConnectionStringTitle;
        private System.Windows.Forms.SaveFileDialog MTSB_SaveWorkSourceSaveDialog;
        private System.Windows.Forms.OpenFileDialog MTSB_OpenWorkSourceFileOpenDialog;
        private System.Windows.Forms.ToolStripSeparator MTSB_CutBar2;
        private System.Windows.Forms.ToolStripButton MTSB_AboutApplication;
        private System.Windows.Forms.Button ViewExecuteCompareCommand;
        private System.Windows.Forms.ToolStripButton MTSB_IsUIKoreanLanguage;
        private System.Windows.Forms.ToolStripSeparator MTSB_CutBar3;
        private System.Windows.Forms.Button SSG_CopyToTSG;
        private System.Windows.Forms.Button TSG_CopyToSSG;
        private System.Windows.Forms.GroupBox DatabaseListGroup;
        private System.Windows.Forms.RadioButton DLG_SQLServer;
        private System.Windows.Forms.RadioButton DLG_MySQL;
        private System.Windows.Forms.RadioButton DLG_PostgreSQL;
    }
}

