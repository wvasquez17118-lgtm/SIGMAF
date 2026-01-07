using SIGMAF.Desktop;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SIGMAF_MenuDemo
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            MenuForm menuForm = new MenuForm();
            menuForm.ShowDialog();
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //btnLogin.Image = LoadIcon("login_iniciar.png");
            //btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            //btnLogin.TextImageRelation = TextImageRelation.ImageBeforeText;
        }
    }
}
