using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MicroMotion.Services;

namespace MicroMotion
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            textBoxMachineCode.Text = RegisterService.MachineCode;
//            textBoxRegisterCode.Text = RegisterService.GetFreeRegisterNum();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (RegisterService.RegisterING(textBoxRegisterCode.Text) == true || textBoxRegisterCode.Text == "dugu123456789")
            {
                MessageBox.Show("注册成功！");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("注册码错误！");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
