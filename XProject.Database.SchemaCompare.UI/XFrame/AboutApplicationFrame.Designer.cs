namespace XProject.Database.SchemaCompare.UI.XFrame
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
            this.CloseAboutApp = new System.Windows.Forms.Button();
            this.DeveloperEmail = new System.Windows.Forms.Label();
            this.SchemaDiffApp = new System.Windows.Forms.Button();
            this.MyGitHub = new System.Windows.Forms.Button();
            this.MainTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseAboutApp
            // 
            this.CloseAboutApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseAboutApp.Location = new System.Drawing.Point(352, 168);
            this.CloseAboutApp.Name = "CloseAboutApp";
            this.CloseAboutApp.Size = new System.Drawing.Size(120, 30);
            this.CloseAboutApp.TabIndex = 0;
            this.CloseAboutApp.Text = "Close";
            this.CloseAboutApp.UseVisualStyleBackColor = true;
            this.CloseAboutApp.Click += new System.EventHandler(this.CloseAboutApp_Click);
            // 
            // DeveloperEmail
            // 
            this.DeveloperEmail.AutoSize = true;
            this.DeveloperEmail.Location = new System.Drawing.Point(12, 58);
            this.DeveloperEmail.Name = "DeveloperEmail";
            this.DeveloperEmail.Size = new System.Drawing.Size(123, 12);
            this.DeveloperEmail.TabIndex = 3;
            this.DeveloperEmail.Text = "kjyoffice@gmail.com";
            // 
            // SchemaDiffApp
            // 
            this.SchemaDiffApp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SchemaDiffApp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SchemaDiffApp.Location = new System.Drawing.Point(12, 118);
            this.SchemaDiffApp.Name = "SchemaDiffApp";
            this.SchemaDiffApp.Size = new System.Drawing.Size(460, 30);
            this.SchemaDiffApp.TabIndex = 4;
            this.SchemaDiffApp.Text = "CompareSchema";
            this.SchemaDiffApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SchemaDiffApp.UseVisualStyleBackColor = true;
            this.SchemaDiffApp.Click += new System.EventHandler(this.SchemaDiffApp_Click);
            // 
            // MyGitHub
            // 
            this.MyGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyGitHub.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MyGitHub.Location = new System.Drawing.Point(12, 82);
            this.MyGitHub.Name = "MyGitHub";
            this.MyGitHub.Size = new System.Drawing.Size(460, 30);
            this.MyGitHub.TabIndex = 4;
            this.MyGitHub.Text = "GitHub";
            this.MyGitHub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MyGitHub.UseVisualStyleBackColor = true;
            this.MyGitHub.Click += new System.EventHandler(this.MyGitHub_Click);
            // 
            // MainTitle
            // 
            this.MainTitle.AutoSize = true;
            this.MainTitle.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold);
            this.MainTitle.Location = new System.Drawing.Point(12, 15);
            this.MainTitle.Name = "MainTitle";
            this.MainTitle.Size = new System.Drawing.Size(108, 24);
            this.MainTitle.TabIndex = 6;
            this.MainTitle.Text = "MainTitle";
            // 
            // AboutApplicationFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 209);
            this.Controls.Add(this.MainTitle);
            this.Controls.Add(this.MyGitHub);
            this.Controls.Add(this.SchemaDiffApp);
            this.Controls.Add(this.DeveloperEmail);
            this.Controls.Add(this.CloseAboutApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutApplicationFrame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutApplicationFrame";
            this.Load += new System.EventHandler(this.AboutApplicationFrame_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseAboutApp;
        private System.Windows.Forms.Label DeveloperEmail;
        private System.Windows.Forms.Button SchemaDiffApp;
        private System.Windows.Forms.Button MyGitHub;
        private System.Windows.Forms.Label MainTitle;
    }
}