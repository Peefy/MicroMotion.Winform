using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MicroMotion.Models;

namespace MicroMotion
{
    public partial class FormLogin : Form
    {

        bool FirstFlag = true;

        public FormLogin()
        {
            InitializeComponent();
            btnLogin.Focus();
            User.Init();
            chkSavePWD.Checked = User.IsSavePassWord;
            txbUserName.Text = User.Now.Name;
            txbPassWord.Text = User.IsSavePassWord ? User.Now.Password : "";
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txbPassWord.Select();
        }

        #region DragMove

        Point mPoint = new Point();

        private void FormLogin_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                var nowPosition = MousePosition;
                nowPosition.Offset(-mPoint.X, -mPoint.Y);
                Location = nowPosition;
            }
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {           
            base.OnClosing(e);
        }

        private delegate void VoidDelegate();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = txbUserName.Text;
            var passWord = txbPassWord.Text;
            var isChecked = chkSavePWD.Checked;
            if (User.Login(userName, passWord,isChecked) == true)
            {
                labelloginIng.Visible = true;
                FirstFlag = false;
                chkSavePWD.Enabled = false;
                btnLogin.Enabled = false;
                btnExit.Enabled = false;
                txbPassWord.Enabled = false;
                txbUserName.Enabled = false;
                new Thread(new ThreadStart(ShowMainForm)).Start();
            }
            else
            {
                MessageBox.Show("帐号或者密码错误！");
                txbPassWord.Focus();
            }
            
        }

        void ShowMainForm()
        {
            Thread.Sleep(500);
            if (this.InvokeRequired)
            {
                this.Invoke(new VoidDelegate(ShowMainForm));
            }
            else
            {
                new FormMain().Show();
                this.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            Application.ExitThread();
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
            if (e.KeyCode == Keys.Tab)
            {
                txbPassWord.Select();
            }
        }

    }
}
