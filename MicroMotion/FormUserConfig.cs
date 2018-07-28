using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MicroMotion.Models;

namespace MicroMotion
{
    public partial class FormUserConfig : Form
    {
        public FormUserConfig()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            UserListBox.Items.Clear();
            var isManager = User.Now.IsManager;
            labelStatus.Visible = !isManager;
            groupBoxUser.Enabled = groupBoxUserList.Enabled = isManager;

            if (isManager == true)
            {
                foreach (var user in User.All)
                {
                    UserListBox.Items.Add(user.Name);
                }
                UserListBox.SelectedIndex = UserListBox.Items.Count > 0 ? 0: -1;
            }

        }

        private void UserListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listbox = sender as ListBox;
            var index = listbox.SelectedIndex;
            textBoxUserName.Text = User.All[index].Name;
            textBoxOldPassWord.Text = User.All[index].Password;
            checkBoxIsUserManeger.Checked = User.All[index].IsUserManager;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (JudgeNewPassWord() == false)
                return;
            if (JudgeIsFullUsers() == false)
                return;
            if (JudgeIsExsitName() == false)
                return;
            var name = textBoxUserName.Text;
            var passWord = textBoxNewPassWord.Text;
            UserListBox.Items.Add(name);
            User.All.Add(new User() 
            {
                Name = name,
                Password = passWord,
            });
            User.SaveAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (JudgeIsSelected() == false)
                return;
            var index = UserListBox.SelectedIndex;
            User.All.RemoveAt(index);
            RenewUserListBox();
            UserListBox.SelectedIndex = index - 1;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (JudgeIsSelected() == false)
                return;
            if (JudgeNewPassWord() == false)
                return;
            var index = UserListBox.SelectedIndex;
            var name = textBoxUserName.Text;
            var passWord = textBoxNewPassWord.Text;
            User.All.RemoveAt(index);
            User.All.Insert(index, new User() 
            {
                Name = name,
                Password = passWord,
            });
            RenewUserListBox();
            UserListBox.SelectedIndex = index;
            MessageBox.Show("修改用户成功！");
        }

        bool JudgeNewPassWord()
        {
            if (string.IsNullOrEmpty(textBoxNewPassWord.Text) == true ||
                string.IsNullOrEmpty(textBoxAgainPassWord.Text) == true ||
                    string.IsNullOrEmpty(textBoxUserName.Text) == true)
            {
                MessageBox.Show("用户名或密码不能为空");
                return false;
            }
            if (string.Equals(textBoxAgainPassWord.Text,
                textBoxNewPassWord.Text) == false)
            {
                MessageBox.Show("两次输入新密码不一致");
                return false;
            }
            return true;
        }

        bool JudgeIsSelected()
        {
            if (UserListBox.SelectedIndex < 0)
            {
                MessageBox.Show("请选择一个用户！");
                return false;
            }
            return true;
        }

        bool JudgeIsFullUsers()
        {
            if (User.IsFullUsers == true)
            {
                MessageBox.Show(string.Format("用户数量上限为{0}个",User.MaxUserNum));
                return false;
            }
            return true;
        }

        bool JudgeIsExsitName()
        {
            var name = textBoxUserName.Text;
            foreach (var user in User.All)
            {
                if (user.Name == name)
                {
                    MessageBox.Show("用户名已存在，请修改用户名");
                    return false;
                }
            }
            return true;
        }

        public void RenewUserListBox()
        {
            UserListBox.Items.Clear();
            foreach (var user in User.All)
            {
                UserListBox.Items.Add(user.Name);
            }
            UserListBox.SelectedIndex = UserListBox.Items.Count > 0 ? 0 : -1;
        }

        private void FormUserConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            User.SaveAll();
        }

        private void checkBoxIsUserManeger_CheckedChanged(object sender, EventArgs e)
        {
            if (JudgeIsSelected() == false)
                return;
            var checkBox = sender as CheckBox;
            User.All[UserListBox.SelectedIndex].IsUserManager = checkBox.Checked;
        }

    }
}
