namespace XProject.SQLServer.SchemaCompare.UI
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
            SSG_UserIDTitle = new Label();
            SSG_DataSourceTitle = new Label();
            RDG_ReportDirectoryPath = new TextBox();
            RDG_ChangeReportDirectory = new Button();
            RDG_OpenReportDirectory = new Button();
            SSG_DataSource = new TextBox();
            ReportDirectoryGroup = new GroupBox();
            MainToolStripBar = new ToolStrip();
            MTSB_NewWorkSource = new ToolStripButton();
            MTSB_CutBar1 = new ToolStripSeparator();
            MTSB_OpenWorkSource = new ToolStripButton();
            MTSB_SaveWorkSource = new ToolStripButton();
            MTSB_CutBar2 = new ToolStripSeparator();
            MTSB_AboutApplication = new ToolStripButton();
            MTSB_CloseApplication = new ToolStripButton();
            SourceServerGroup = new GroupBox();
            SSG_RawConnectionString = new TextBox();
            SSG_UserManualConnectionString = new CheckBox();
            SSG_InitialCatalogTitle = new Label();
            SSG_ConnectTest = new Button();
            SSG_PasswordTitle = new Label();
            SSG_TrustedConnection = new CheckBox();
            SSG_Password = new TextBox();
            SSG_InitialCatalog = new TextBox();
            SSG_UserID = new TextBox();
            SSG_RawConnectionStringTitle = new Label();
            TargetServerGroup = new GroupBox();
            TSG_RawConnectionString = new TextBox();
            TSG_UserManualConnectionString = new CheckBox();
            TSG_InitialCatalogTitle = new Label();
            TSG_ConnectTest = new Button();
            TSG_PasswordTitle = new Label();
            TSG_UserIDTitle = new Label();
            TSG_DataSourceTitle = new Label();
            TSG_TrustedConnection = new CheckBox();
            TSG_Password = new TextBox();
            TSG_InitialCatalog = new TextBox();
            TSG_UserID = new TextBox();
            TSG_DataSource = new TextBox();
            TSG_RawConnectionStringTitle = new Label();
            JustNotify1 = new Label();
            SwapSourceAndTargetServer = new Button();
            ExecuteCompare = new Button();
            RDG_ChangeReportDirectoryDialog = new FolderBrowserDialog();
            MTSB_SaveWorkSourceSaveDialog = new SaveFileDialog();
            MTSB_OpenWorkSourceFileOpenDialog = new OpenFileDialog();
            IsUIKoreanLanguage = new CheckBox();
            ReportDirectoryGroup.SuspendLayout();
            MainToolStripBar.SuspendLayout();
            SourceServerGroup.SuspendLayout();
            TargetServerGroup.SuspendLayout();
            SuspendLayout();
            // 
            // SSG_UserIDTitle
            // 
            SSG_UserIDTitle.AutoSize = true;
            SSG_UserIDTitle.Location = new Point(6, 112);
            SSG_UserIDTitle.Name = "SSG_UserIDTitle";
            SSG_UserIDTitle.Size = new Size(19, 15);
            SSG_UserIDTitle.TabIndex = 1;
            SSG_UserIDTitle.Text = "ID";
            // 
            // SSG_DataSourceTitle
            // 
            SSG_DataSourceTitle.AutoSize = true;
            SSG_DataSourceTitle.Location = new Point(6, 54);
            SSG_DataSourceTitle.Name = "SSG_DataSourceTitle";
            SSG_DataSourceTitle.Size = new Size(40, 15);
            SSG_DataSourceTitle.TabIndex = 1;
            SSG_DataSourceTitle.Text = "Server";
            // 
            // RDG_ReportDirectoryPath
            // 
            RDG_ReportDirectoryPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            RDG_ReportDirectoryPath.Location = new Point(6, 24);
            RDG_ReportDirectoryPath.Margin = new Padding(3, 4, 3, 4);
            RDG_ReportDirectoryPath.Name = "RDG_ReportDirectoryPath";
            RDG_ReportDirectoryPath.ReadOnly = true;
            RDG_ReportDirectoryPath.Size = new Size(936, 23);
            RDG_ReportDirectoryPath.TabIndex = 2;
            // 
            // RDG_ChangeReportDirectory
            // 
            RDG_ChangeReportDirectory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RDG_ChangeReportDirectory.Location = new Point(948, 15);
            RDG_ChangeReportDirectory.Margin = new Padding(3, 4, 3, 4);
            RDG_ChangeReportDirectory.Name = "RDG_ChangeReportDirectory";
            RDG_ChangeReportDirectory.Size = new Size(100, 32);
            RDG_ChangeReportDirectory.TabIndex = 0;
            RDG_ChangeReportDirectory.Text = "...";
            RDG_ChangeReportDirectory.TextImageRelation = TextImageRelation.ImageBeforeText;
            RDG_ChangeReportDirectory.UseVisualStyleBackColor = true;
            RDG_ChangeReportDirectory.Click += RDG_ChangeReportDirectory_Click;
            // 
            // RDG_OpenReportDirectory
            // 
            RDG_OpenReportDirectory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RDG_OpenReportDirectory.Location = new Point(1054, 15);
            RDG_OpenReportDirectory.Margin = new Padding(3, 4, 3, 4);
            RDG_OpenReportDirectory.Name = "RDG_OpenReportDirectory";
            RDG_OpenReportDirectory.Size = new Size(100, 32);
            RDG_OpenReportDirectory.TabIndex = 0;
            RDG_OpenReportDirectory.Text = "Open";
            RDG_OpenReportDirectory.TextImageRelation = TextImageRelation.ImageBeforeText;
            RDG_OpenReportDirectory.UseVisualStyleBackColor = true;
            RDG_OpenReportDirectory.Click += RDG_OpenReportDirectory_Click;
            // 
            // SSG_DataSource
            // 
            SSG_DataSource.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SSG_DataSource.Location = new Point(108, 51);
            SSG_DataSource.Margin = new Padding(3, 4, 3, 4);
            SSG_DataSource.Name = "SSG_DataSource";
            SSG_DataSource.Size = new Size(386, 23);
            SSG_DataSource.TabIndex = 100;
            // 
            // ReportDirectoryGroup
            // 
            ReportDirectoryGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ReportDirectoryGroup.Controls.Add(RDG_ReportDirectoryPath);
            ReportDirectoryGroup.Controls.Add(RDG_ChangeReportDirectory);
            ReportDirectoryGroup.Controls.Add(RDG_OpenReportDirectory);
            ReportDirectoryGroup.Location = new Point(12, 34);
            ReportDirectoryGroup.Margin = new Padding(3, 4, 3, 4);
            ReportDirectoryGroup.Name = "ReportDirectoryGroup";
            ReportDirectoryGroup.Padding = new Padding(3, 4, 3, 4);
            ReportDirectoryGroup.Size = new Size(1160, 57);
            ReportDirectoryGroup.TabIndex = 3;
            ReportDirectoryGroup.TabStop = false;
            ReportDirectoryGroup.Text = "ReportDirectory";
            // 
            // MainToolStripBar
            // 
            MainToolStripBar.GripStyle = ToolStripGripStyle.Hidden;
            MainToolStripBar.Items.AddRange(new ToolStripItem[] { MTSB_NewWorkSource, MTSB_CutBar1, MTSB_OpenWorkSource, MTSB_SaveWorkSource, MTSB_CutBar2, MTSB_AboutApplication, MTSB_CloseApplication });
            MainToolStripBar.Location = new Point(0, 0);
            MainToolStripBar.Name = "MainToolStripBar";
            MainToolStripBar.Size = new Size(1184, 25);
            MainToolStripBar.TabIndex = 5;
            // 
            // MTSB_NewWorkSource
            // 
            MTSB_NewWorkSource.ImageTransparentColor = Color.Magenta;
            MTSB_NewWorkSource.Name = "MTSB_NewWorkSource";
            MTSB_NewWorkSource.Size = new Size(35, 22);
            MTSB_NewWorkSource.Text = "New";
            MTSB_NewWorkSource.Click += MTSB_NewWorkSource_Click;
            // 
            // MTSB_CutBar1
            // 
            MTSB_CutBar1.Name = "MTSB_CutBar1";
            MTSB_CutBar1.Size = new Size(6, 25);
            // 
            // MTSB_OpenWorkSource
            // 
            MTSB_OpenWorkSource.ImageTransparentColor = Color.Magenta;
            MTSB_OpenWorkSource.Name = "MTSB_OpenWorkSource";
            MTSB_OpenWorkSource.Size = new Size(40, 22);
            MTSB_OpenWorkSource.Text = "Open";
            MTSB_OpenWorkSource.Click += MTSB_OpenWorkSource_Click;
            // 
            // MTSB_SaveWorkSource
            // 
            MTSB_SaveWorkSource.ImageTransparentColor = Color.Magenta;
            MTSB_SaveWorkSource.Name = "MTSB_SaveWorkSource";
            MTSB_SaveWorkSource.Size = new Size(36, 22);
            MTSB_SaveWorkSource.Text = "Save";
            MTSB_SaveWorkSource.Click += MTSB_SaveWorkSource_Click;
            // 
            // MTSB_CutBar2
            // 
            MTSB_CutBar2.Name = "MTSB_CutBar2";
            MTSB_CutBar2.Size = new Size(6, 25);
            // 
            // MTSB_AboutApplication
            // 
            MTSB_AboutApplication.Alignment = ToolStripItemAlignment.Right;
            MTSB_AboutApplication.ImageTransparentColor = Color.Magenta;
            MTSB_AboutApplication.Name = "MTSB_AboutApplication";
            MTSB_AboutApplication.Size = new Size(44, 22);
            MTSB_AboutApplication.Text = "About";
            MTSB_AboutApplication.Click += MTSB_AboutApplication_Click;
            // 
            // MTSB_CloseApplication
            // 
            MTSB_CloseApplication.ImageTransparentColor = Color.Magenta;
            MTSB_CloseApplication.Name = "MTSB_CloseApplication";
            MTSB_CloseApplication.Size = new Size(30, 22);
            MTSB_CloseApplication.Text = "Exit";
            MTSB_CloseApplication.Click += MTSB_CloseApplication_Click;
            // 
            // SourceServerGroup
            // 
            SourceServerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            SourceServerGroup.Controls.Add(SSG_RawConnectionString);
            SourceServerGroup.Controls.Add(SSG_UserManualConnectionString);
            SourceServerGroup.Controls.Add(SSG_InitialCatalogTitle);
            SourceServerGroup.Controls.Add(SSG_ConnectTest);
            SourceServerGroup.Controls.Add(SSG_PasswordTitle);
            SourceServerGroup.Controls.Add(SSG_UserIDTitle);
            SourceServerGroup.Controls.Add(SSG_DataSourceTitle);
            SourceServerGroup.Controls.Add(SSG_TrustedConnection);
            SourceServerGroup.Controls.Add(SSG_Password);
            SourceServerGroup.Controls.Add(SSG_InitialCatalog);
            SourceServerGroup.Controls.Add(SSG_UserID);
            SourceServerGroup.Controls.Add(SSG_DataSource);
            SourceServerGroup.Controls.Add(SSG_RawConnectionStringTitle);
            SourceServerGroup.Location = new Point(12, 99);
            SourceServerGroup.Margin = new Padding(3, 4, 3, 4);
            SourceServerGroup.Name = "SourceServerGroup";
            SourceServerGroup.Padding = new Padding(3, 4, 3, 4);
            SourceServerGroup.Size = new Size(500, 272);
            SourceServerGroup.TabIndex = 6;
            SourceServerGroup.TabStop = false;
            SourceServerGroup.Text = "SourceServer";
            // 
            // SSG_RawConnectionString
            // 
            SSG_RawConnectionString.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SSG_RawConnectionString.Location = new Point(108, 52);
            SSG_RawConnectionString.Margin = new Padding(3, 4, 3, 4);
            SSG_RawConnectionString.Multiline = true;
            SSG_RawConnectionString.Name = "SSG_RawConnectionString";
            SSG_RawConnectionString.ScrollBars = ScrollBars.Both;
            SSG_RawConnectionString.Size = new Size(386, 143);
            SSG_RawConnectionString.TabIndex = 10;
            // 
            // SSG_UserManualConnectionString
            // 
            SSG_UserManualConnectionString.AutoSize = true;
            SSG_UserManualConnectionString.Location = new Point(108, 24);
            SSG_UserManualConnectionString.Margin = new Padding(3, 4, 3, 4);
            SSG_UserManualConnectionString.Name = "SSG_UserManualConnectionString";
            SSG_UserManualConnectionString.Size = new Size(66, 19);
            SSG_UserManualConnectionString.TabIndex = 10;
            SSG_UserManualConnectionString.Text = "Manual";
            SSG_UserManualConnectionString.UseVisualStyleBackColor = true;
            SSG_UserManualConnectionString.Click += SSG_UserManualConnectionString_Click;
            // 
            // SSG_InitialCatalogTitle
            // 
            SSG_InitialCatalogTitle.AutoSize = true;
            SSG_InitialCatalogTitle.Location = new Point(6, 174);
            SSG_InitialCatalogTitle.Name = "SSG_InitialCatalogTitle";
            SSG_InitialCatalogTitle.Size = new Size(55, 15);
            SSG_InitialCatalogTitle.TabIndex = 10;
            SSG_InitialCatalogTitle.Text = "DBName";
            // 
            // SSG_ConnectTest
            // 
            SSG_ConnectTest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SSG_ConnectTest.Location = new Point(108, 214);
            SSG_ConnectTest.Margin = new Padding(3, 4, 3, 4);
            SSG_ConnectTest.Name = "SSG_ConnectTest";
            SSG_ConnectTest.Size = new Size(386, 50);
            SSG_ConnectTest.TabIndex = 104;
            SSG_ConnectTest.Text = "ConnTest";
            SSG_ConnectTest.TextImageRelation = TextImageRelation.ImageBeforeText;
            SSG_ConnectTest.UseVisualStyleBackColor = true;
            SSG_ConnectTest.Click += SSG_ConnectTest_Click;
            // 
            // SSG_PasswordTitle
            // 
            SSG_PasswordTitle.AutoSize = true;
            SSG_PasswordTitle.Location = new Point(6, 143);
            SSG_PasswordTitle.Name = "SSG_PasswordTitle";
            SSG_PasswordTitle.Size = new Size(25, 15);
            SSG_PasswordTitle.TabIndex = 1;
            SSG_PasswordTitle.Text = "PW";
            // 
            // SSG_TrustedConnection
            // 
            SSG_TrustedConnection.AutoSize = true;
            SSG_TrustedConnection.Location = new Point(108, 82);
            SSG_TrustedConnection.Margin = new Padding(3, 4, 3, 4);
            SSG_TrustedConnection.Name = "SSG_TrustedConnection";
            SSG_TrustedConnection.Size = new Size(78, 19);
            SSG_TrustedConnection.TabIndex = 3;
            SSG_TrustedConnection.Text = "TrustAuth";
            SSG_TrustedConnection.UseVisualStyleBackColor = true;
            SSG_TrustedConnection.Click += SSG_TrustedConnection_Click;
            // 
            // SSG_Password
            // 
            SSG_Password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SSG_Password.Location = new Point(108, 140);
            SSG_Password.Margin = new Padding(3, 4, 3, 4);
            SSG_Password.Name = "SSG_Password";
            SSG_Password.Size = new Size(386, 23);
            SSG_Password.TabIndex = 102;
            SSG_Password.UseSystemPasswordChar = true;
            // 
            // SSG_InitialCatalog
            // 
            SSG_InitialCatalog.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SSG_InitialCatalog.Location = new Point(108, 171);
            SSG_InitialCatalog.Margin = new Padding(3, 4, 3, 4);
            SSG_InitialCatalog.Name = "SSG_InitialCatalog";
            SSG_InitialCatalog.Size = new Size(386, 23);
            SSG_InitialCatalog.TabIndex = 103;
            // 
            // SSG_UserID
            // 
            SSG_UserID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SSG_UserID.Location = new Point(108, 109);
            SSG_UserID.Margin = new Padding(3, 4, 3, 4);
            SSG_UserID.Name = "SSG_UserID";
            SSG_UserID.Size = new Size(386, 23);
            SSG_UserID.TabIndex = 101;
            // 
            // SSG_RawConnectionStringTitle
            // 
            SSG_RawConnectionStringTitle.AutoSize = true;
            SSG_RawConnectionStringTitle.Location = new Point(6, 55);
            SSG_RawConnectionStringTitle.Name = "SSG_RawConnectionStringTitle";
            SSG_RawConnectionStringTitle.Size = new Size(51, 15);
            SSG_RawConnectionStringTitle.TabIndex = 10;
            SSG_RawConnectionStringTitle.Text = "ConnStr";
            // 
            // TargetServerGroup
            // 
            TargetServerGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            TargetServerGroup.Controls.Add(TSG_RawConnectionString);
            TargetServerGroup.Controls.Add(TSG_UserManualConnectionString);
            TargetServerGroup.Controls.Add(TSG_InitialCatalogTitle);
            TargetServerGroup.Controls.Add(TSG_ConnectTest);
            TargetServerGroup.Controls.Add(TSG_PasswordTitle);
            TargetServerGroup.Controls.Add(TSG_UserIDTitle);
            TargetServerGroup.Controls.Add(TSG_DataSourceTitle);
            TargetServerGroup.Controls.Add(TSG_TrustedConnection);
            TargetServerGroup.Controls.Add(TSG_Password);
            TargetServerGroup.Controls.Add(TSG_InitialCatalog);
            TargetServerGroup.Controls.Add(TSG_UserID);
            TargetServerGroup.Controls.Add(TSG_DataSource);
            TargetServerGroup.Controls.Add(TSG_RawConnectionStringTitle);
            TargetServerGroup.Location = new Point(672, 99);
            TargetServerGroup.Margin = new Padding(3, 4, 3, 4);
            TargetServerGroup.Name = "TargetServerGroup";
            TargetServerGroup.Padding = new Padding(3, 4, 3, 4);
            TargetServerGroup.Size = new Size(500, 272);
            TargetServerGroup.TabIndex = 6;
            TargetServerGroup.TabStop = false;
            TargetServerGroup.Text = "TargetServer";
            // 
            // TSG_RawConnectionString
            // 
            TSG_RawConnectionString.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TSG_RawConnectionString.Location = new Point(108, 52);
            TSG_RawConnectionString.Margin = new Padding(3, 4, 3, 4);
            TSG_RawConnectionString.Multiline = true;
            TSG_RawConnectionString.Name = "TSG_RawConnectionString";
            TSG_RawConnectionString.ScrollBars = ScrollBars.Both;
            TSG_RawConnectionString.Size = new Size(386, 143);
            TSG_RawConnectionString.TabIndex = 10;
            // 
            // TSG_UserManualConnectionString
            // 
            TSG_UserManualConnectionString.AutoSize = true;
            TSG_UserManualConnectionString.Location = new Point(108, 24);
            TSG_UserManualConnectionString.Margin = new Padding(3, 4, 3, 4);
            TSG_UserManualConnectionString.Name = "TSG_UserManualConnectionString";
            TSG_UserManualConnectionString.Size = new Size(66, 19);
            TSG_UserManualConnectionString.TabIndex = 10;
            TSG_UserManualConnectionString.Text = "Manual";
            TSG_UserManualConnectionString.UseVisualStyleBackColor = true;
            TSG_UserManualConnectionString.Click += TSG_UserManualConnectionString_Click;
            // 
            // TSG_InitialCatalogTitle
            // 
            TSG_InitialCatalogTitle.AutoSize = true;
            TSG_InitialCatalogTitle.Location = new Point(6, 174);
            TSG_InitialCatalogTitle.Name = "TSG_InitialCatalogTitle";
            TSG_InitialCatalogTitle.Size = new Size(55, 15);
            TSG_InitialCatalogTitle.TabIndex = 10;
            TSG_InitialCatalogTitle.Text = "DBName";
            // 
            // TSG_ConnectTest
            // 
            TSG_ConnectTest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TSG_ConnectTest.Location = new Point(108, 214);
            TSG_ConnectTest.Margin = new Padding(3, 4, 3, 4);
            TSG_ConnectTest.Name = "TSG_ConnectTest";
            TSG_ConnectTest.Size = new Size(386, 50);
            TSG_ConnectTest.TabIndex = 109;
            TSG_ConnectTest.Text = "ConnTest";
            TSG_ConnectTest.TextImageRelation = TextImageRelation.ImageBeforeText;
            TSG_ConnectTest.UseVisualStyleBackColor = true;
            TSG_ConnectTest.Click += TSG_ConnectTest_Click;
            // 
            // TSG_PasswordTitle
            // 
            TSG_PasswordTitle.AutoSize = true;
            TSG_PasswordTitle.Location = new Point(6, 143);
            TSG_PasswordTitle.Name = "TSG_PasswordTitle";
            TSG_PasswordTitle.Size = new Size(25, 15);
            TSG_PasswordTitle.TabIndex = 1;
            TSG_PasswordTitle.Text = "PW";
            // 
            // TSG_UserIDTitle
            // 
            TSG_UserIDTitle.AutoSize = true;
            TSG_UserIDTitle.Location = new Point(6, 112);
            TSG_UserIDTitle.Name = "TSG_UserIDTitle";
            TSG_UserIDTitle.Size = new Size(19, 15);
            TSG_UserIDTitle.TabIndex = 1;
            TSG_UserIDTitle.Text = "ID";
            // 
            // TSG_DataSourceTitle
            // 
            TSG_DataSourceTitle.AutoSize = true;
            TSG_DataSourceTitle.Location = new Point(6, 54);
            TSG_DataSourceTitle.Name = "TSG_DataSourceTitle";
            TSG_DataSourceTitle.Size = new Size(40, 15);
            TSG_DataSourceTitle.TabIndex = 1;
            TSG_DataSourceTitle.Text = "Server";
            // 
            // TSG_TrustedConnection
            // 
            TSG_TrustedConnection.AutoSize = true;
            TSG_TrustedConnection.Location = new Point(108, 82);
            TSG_TrustedConnection.Margin = new Padding(3, 4, 3, 4);
            TSG_TrustedConnection.Name = "TSG_TrustedConnection";
            TSG_TrustedConnection.Size = new Size(78, 19);
            TSG_TrustedConnection.TabIndex = 3;
            TSG_TrustedConnection.Text = "TrustAuth";
            TSG_TrustedConnection.UseVisualStyleBackColor = true;
            TSG_TrustedConnection.Click += TSG_TrustedConnection_Click;
            // 
            // TSG_Password
            // 
            TSG_Password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TSG_Password.Location = new Point(108, 140);
            TSG_Password.Margin = new Padding(3, 4, 3, 4);
            TSG_Password.Name = "TSG_Password";
            TSG_Password.Size = new Size(386, 23);
            TSG_Password.TabIndex = 107;
            TSG_Password.UseSystemPasswordChar = true;
            // 
            // TSG_InitialCatalog
            // 
            TSG_InitialCatalog.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TSG_InitialCatalog.Location = new Point(108, 171);
            TSG_InitialCatalog.Margin = new Padding(3, 4, 3, 4);
            TSG_InitialCatalog.Name = "TSG_InitialCatalog";
            TSG_InitialCatalog.Size = new Size(386, 23);
            TSG_InitialCatalog.TabIndex = 108;
            // 
            // TSG_UserID
            // 
            TSG_UserID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TSG_UserID.Location = new Point(108, 109);
            TSG_UserID.Margin = new Padding(3, 4, 3, 4);
            TSG_UserID.Name = "TSG_UserID";
            TSG_UserID.Size = new Size(386, 23);
            TSG_UserID.TabIndex = 106;
            // 
            // TSG_DataSource
            // 
            TSG_DataSource.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TSG_DataSource.Location = new Point(108, 51);
            TSG_DataSource.Margin = new Padding(3, 4, 3, 4);
            TSG_DataSource.Name = "TSG_DataSource";
            TSG_DataSource.Size = new Size(386, 23);
            TSG_DataSource.TabIndex = 105;
            // 
            // TSG_RawConnectionStringTitle
            // 
            TSG_RawConnectionStringTitle.AutoSize = true;
            TSG_RawConnectionStringTitle.Location = new Point(6, 54);
            TSG_RawConnectionStringTitle.Name = "TSG_RawConnectionStringTitle";
            TSG_RawConnectionStringTitle.Size = new Size(51, 15);
            TSG_RawConnectionStringTitle.TabIndex = 10;
            TSG_RawConnectionStringTitle.Text = "ConnStr";
            // 
            // JustNotify1
            // 
            JustNotify1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            JustNotify1.AutoSize = true;
            JustNotify1.ForeColor = Color.Blue;
            JustNotify1.Location = new Point(670, 389);
            JustNotify1.Margin = new Padding(0);
            JustNotify1.Name = "JustNotify1";
            JustNotify1.Size = new Size(67, 15);
            JustNotify1.TabIndex = 7;
            JustNotify1.Text = "JustNotify1";
            // 
            // SwapSourceAndTargetServer
            // 
            SwapSourceAndTargetServer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            SwapSourceAndTargetServer.Location = new Point(542, 99);
            SwapSourceAndTargetServer.Margin = new Padding(3, 4, 3, 4);
            SwapSourceAndTargetServer.Name = "SwapSourceAndTargetServer";
            SwapSourceAndTargetServer.Size = new Size(100, 272);
            SwapSourceAndTargetServer.TabIndex = 8;
            SwapSourceAndTargetServer.Text = "Swap";
            SwapSourceAndTargetServer.TextImageRelation = TextImageRelation.ImageBeforeText;
            SwapSourceAndTargetServer.UseVisualStyleBackColor = true;
            SwapSourceAndTargetServer.Click += SwapSourceAndTargetServer_Click;
            // 
            // ExecuteCompare
            // 
            ExecuteCompare.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ExecuteCompare.Location = new Point(670, 408);
            ExecuteCompare.Margin = new Padding(3, 4, 3, 4);
            ExecuteCompare.Name = "ExecuteCompare";
            ExecuteCompare.Size = new Size(502, 70);
            ExecuteCompare.TabIndex = 110;
            ExecuteCompare.Text = "Start";
            ExecuteCompare.TextImageRelation = TextImageRelation.ImageBeforeText;
            ExecuteCompare.UseVisualStyleBackColor = true;
            ExecuteCompare.Click += ExecuteCompare_Click;
            // 
            // MTSB_SaveWorkSourceSaveDialog
            // 
            MTSB_SaveWorkSourceSaveDialog.DefaultExt = "json";
            MTSB_SaveWorkSourceSaveDialog.Filter = "JSON (*.json)|*.json";
            MTSB_SaveWorkSourceSaveDialog.Title = "저장";
            // 
            // MTSB_OpenWorkSourceFileOpenDialog
            // 
            MTSB_OpenWorkSourceFileOpenDialog.DefaultExt = "json";
            MTSB_OpenWorkSourceFileOpenDialog.Filter = "JSON (*.json)|*.json";
            MTSB_OpenWorkSourceFileOpenDialog.Title = "열기";
            // 
            // IsUIKoreanLanguage
            // 
            IsUIKoreanLanguage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            IsUIKoreanLanguage.AutoSize = true;
            IsUIKoreanLanguage.Location = new Point(12, 459);
            IsUIKoreanLanguage.Margin = new Padding(3, 4, 3, 4);
            IsUIKoreanLanguage.Name = "IsUIKoreanLanguage";
            IsUIKoreanLanguage.Size = new Size(115, 19);
            IsUIKoreanLanguage.TabIndex = 111;
            IsUIKoreanLanguage.Text = "KoreanLanguage";
            IsUIKoreanLanguage.UseVisualStyleBackColor = true;
            IsUIKoreanLanguage.Click += IsUIKoreanLanguage_Click;
            // 
            // MainFrame
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 491);
            Controls.Add(IsUIKoreanLanguage);
            Controls.Add(ExecuteCompare);
            Controls.Add(SwapSourceAndTargetServer);
            Controls.Add(JustNotify1);
            Controls.Add(TargetServerGroup);
            Controls.Add(SourceServerGroup);
            Controls.Add(MainToolStripBar);
            Controls.Add(ReportDirectoryGroup);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1200, 530);
            Name = "MainFrame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainTitle";
            FormClosing += MainFrame_FormClosing;
            Load += MainFrame_Load;
            Shown += MainFrame_Shown;
            DragDrop += MainFrame_DragDrop;
            DragEnter += MainFrame_DragEnter;
            KeyDown += MainFrame_KeyDown;
            ReportDirectoryGroup.ResumeLayout(false);
            ReportDirectoryGroup.PerformLayout();
            MainToolStripBar.ResumeLayout(false);
            MainToolStripBar.PerformLayout();
            SourceServerGroup.ResumeLayout(false);
            SourceServerGroup.PerformLayout();
            TargetServerGroup.ResumeLayout(false);
            TargetServerGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label SSG_UserIDTitle;
        private Label SSG_DataSourceTitle;
        private TextBox RDG_ReportDirectoryPath;
        private Button RDG_ChangeReportDirectory;
        private Button RDG_OpenReportDirectory;
        private TextBox SSG_DataSource;
        private GroupBox ReportDirectoryGroup;
        private ToolStrip MainToolStripBar;
        private ToolStripSeparator MTSB_CutBar1;
        private GroupBox SourceServerGroup;
        private Button SSG_ConnectTest;
        private CheckBox SSG_TrustedConnection;
        private TextBox SSG_Password;
        private TextBox SSG_UserID;
        private Label SSG_PasswordTitle;
        private GroupBox TargetServerGroup;
        private Button TSG_ConnectTest;
        private CheckBox TSG_TrustedConnection;
        private Label TSG_DataSourceTitle;
        private TextBox TSG_Password;
        private TextBox TSG_UserID;
        private TextBox TSG_DataSource;
        private Label TSG_PasswordTitle;
        private Label TSG_UserIDTitle;
        private Label JustNotify1;
        private Button SwapSourceAndTargetServer;
        private ToolStripButton MTSB_NewWorkSource;
        private ToolStripButton MTSB_SaveWorkSource;
        private ToolStripButton MTSB_OpenWorkSource;
        private ToolStripButton MTSB_CloseApplication;
        private Button ExecuteCompare;
        private FolderBrowserDialog RDG_ChangeReportDirectoryDialog;
        private Label SSG_InitialCatalogTitle;
        private TextBox SSG_InitialCatalog;
        private Label TSG_InitialCatalogTitle;
        private TextBox TSG_InitialCatalog;
        private CheckBox SSG_UserManualConnectionString;
        private CheckBox TSG_UserManualConnectionString;
        private TextBox SSG_RawConnectionString;
        private TextBox TSG_RawConnectionString;
        private Label SSG_RawConnectionStringTitle;
        private Label TSG_RawConnectionStringTitle;
        private SaveFileDialog MTSB_SaveWorkSourceSaveDialog;
        private OpenFileDialog MTSB_OpenWorkSourceFileOpenDialog;
        private ToolStripSeparator MTSB_CutBar2;
        private ToolStripButton MTSB_AboutApplication;
        private CheckBox IsUIKoreanLanguage;
    }
}

