using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace XProject.Database.SchemaCompare.UI.XFrame
{
    public partial class AboutApplicationFrame : Form
    {
        public AboutApplicationFrame()
        {
            this.InitializeComponent();
            this.Text = "정보";
            this.MainTitle.Text = "정보";
            this.SchemaDiffApp.Text = "스키마 비교 : VisualStudio Code";
            this.CloseAboutApp.Text = "확인";
        }

        private void AboutApplicationFrame_Load(object sender, EventArgs e)
        {
            //>
        }

        private void AboutApplicationFrame_Shown(object sender, EventArgs e)
        {
            //>
        }

        private void CloseAboutApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MyGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.github.com/kjyoffice");
        }

        private void SchemaDiffApp_Click(object sender, EventArgs e)
        {
            Process.Start("https://code.visualstudio.com");
        }
    }
}
