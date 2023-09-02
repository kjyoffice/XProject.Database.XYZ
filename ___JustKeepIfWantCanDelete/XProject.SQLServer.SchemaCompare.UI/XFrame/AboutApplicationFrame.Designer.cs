namespace XProject.SQLServer.SchemaCompare.UI.XFrame
{
    partial class AboutApplicationFrame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutApplicationFrame));
            CloseAboutApp = new Button();
            DeveloperEmail = new Label();
            SchemaDiffApp = new Button();
            AppVersion = new Label();
            MyGitHub = new Button();
            MainTitle = new Label();
            SuspendLayout();
            // 
            // CloseAboutApp
            // 
            CloseAboutApp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseAboutApp.Location = new Point(352, 210);
            CloseAboutApp.Margin = new Padding(3, 4, 3, 4);
            CloseAboutApp.Name = "CloseAboutApp";
            CloseAboutApp.Size = new Size(120, 38);
            CloseAboutApp.TabIndex = 0;
            CloseAboutApp.Text = "Close";
            CloseAboutApp.UseVisualStyleBackColor = true;
            CloseAboutApp.Click += CloseAboutApp_Click;
            // 
            // DeveloperEmail
            // 
            DeveloperEmail.AutoSize = true;
            DeveloperEmail.Location = new Point(12, 73);
            DeveloperEmail.Name = "DeveloperEmail";
            DeveloperEmail.Size = new Size(121, 15);
            DeveloperEmail.TabIndex = 3;
            DeveloperEmail.Text = "kjyoffice@gmail.com";
            // 
            // SchemaDiffApp
            // 
            SchemaDiffApp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SchemaDiffApp.ImageAlign = ContentAlignment.MiddleRight;
            SchemaDiffApp.Location = new Point(12, 148);
            SchemaDiffApp.Margin = new Padding(3, 4, 3, 4);
            SchemaDiffApp.Name = "SchemaDiffApp";
            SchemaDiffApp.Size = new Size(460, 38);
            SchemaDiffApp.TabIndex = 4;
            SchemaDiffApp.Text = "CompareSchema";
            SchemaDiffApp.TextAlign = ContentAlignment.MiddleLeft;
            SchemaDiffApp.UseVisualStyleBackColor = true;
            SchemaDiffApp.Click += SchemaDiffApp_Click;
            // 
            // AppVersion
            // 
            AppVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AppVersion.AutoSize = true;
            AppVersion.ForeColor = SystemColors.ControlDark;
            AppVersion.Location = new Point(12, 233);
            AppVersion.Name = "AppVersion";
            AppVersion.Size = new Size(44, 15);
            AppVersion.TabIndex = 5;
            AppVersion.Text = "1.0.0.0";
            // 
            // MyGitHub
            // 
            MyGitHub.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MyGitHub.ImageAlign = ContentAlignment.MiddleRight;
            MyGitHub.Location = new Point(12, 102);
            MyGitHub.Margin = new Padding(3, 4, 3, 4);
            MyGitHub.Name = "MyGitHub";
            MyGitHub.Size = new Size(460, 38);
            MyGitHub.TabIndex = 4;
            MyGitHub.Text = "GitHub";
            MyGitHub.TextAlign = ContentAlignment.MiddleLeft;
            MyGitHub.UseVisualStyleBackColor = true;
            MyGitHub.Click += MyGitHub_Click;
            // 
            // MainTitle
            // 
            MainTitle.AutoSize = true;
            MainTitle.Font = new Font("굴림", 18F, FontStyle.Bold, GraphicsUnit.Point);
            MainTitle.Location = new Point(12, 19);
            MainTitle.Name = "MainTitle";
            MainTitle.Size = new Size(108, 24);
            MainTitle.TabIndex = 6;
            MainTitle.Text = "MainTitle";
            // 
            // AboutApplicationFrame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 261);
            Controls.Add(MainTitle);
            Controls.Add(AppVersion);
            Controls.Add(MyGitHub);
            Controls.Add(SchemaDiffApp);
            Controls.Add(DeveloperEmail);
            Controls.Add(CloseAboutApp);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutApplicationFrame";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "AboutApplicationFrame";
            Load += AboutApplicationFrame_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CloseAboutApp;
        private Label DeveloperEmail;
        private Button SchemaDiffApp;
        private Label AppVersion;
        private Button MyGitHub;
        private Label MainTitle;
    }
}