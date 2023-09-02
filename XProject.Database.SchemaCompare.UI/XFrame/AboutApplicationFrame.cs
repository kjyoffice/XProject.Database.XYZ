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
        public AboutApplicationFrame(bool isHanGulLanguage)
        {
            var mainTitle = ((isHanGulLanguage == true) ? "정보" : "About");

            this.InitializeComponent();

            this.Text = mainTitle;
            this.MainTitle.Text = mainTitle;
            this.SchemaDiffApp.Text = (((isHanGulLanguage == true) ? "스키마 비교" : "Compare schema") + " : VisualStudio Code");
            this.CloseAboutApp.Text = ((isHanGulLanguage == true) ? "확인" : "OK");
        }

        private void AboutApplicationFrame_Load(object sender, EventArgs e)
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

        private void AboutApplicationFrame_Load_1(object sender, EventArgs e)
        {

        }
    }
}
