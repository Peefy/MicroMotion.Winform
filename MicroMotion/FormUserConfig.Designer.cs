namespace MicroMotion
{
    partial class FormUserConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserConfig));
            this.groupBoxUserList = new System.Windows.Forms.GroupBox();
            this.UserListBox = new System.Windows.Forms.ListBox();
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.checkBoxIsUserManeger = new System.Windows.Forms.CheckBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAgainPassWord = new System.Windows.Forms.TextBox();
            this.textBoxNewPassWord = new System.Windows.Forms.TextBox();
            this.textBoxOldPassWord = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBoxUserList.SuspendLayout();
            this.groupBoxUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUserList
            // 
            this.groupBoxUserList.Controls.Add(this.UserListBox);
            this.groupBoxUserList.Location = new System.Drawing.Point(13, 13);
            this.groupBoxUserList.Name = "groupBoxUserList";
            this.groupBoxUserList.Size = new System.Drawing.Size(200, 223);
            this.groupBoxUserList.TabIndex = 0;
            this.groupBoxUserList.TabStop = false;
            this.groupBoxUserList.Text = "用户列表";
            // 
            // UserListBox
            // 
            this.UserListBox.FormattingEnabled = true;
            this.UserListBox.ItemHeight = 12;
            this.UserListBox.Location = new System.Drawing.Point(16, 21);
            this.UserListBox.Name = "UserListBox";
            this.UserListBox.Size = new System.Drawing.Size(164, 184);
            this.UserListBox.TabIndex = 0;
            this.UserListBox.SelectedIndexChanged += new System.EventHandler(this.UserListBox_SelectedIndexChanged);
            // 
            // groupBoxUser
            // 
            this.groupBoxUser.Controls.Add(this.checkBoxIsUserManeger);
            this.groupBoxUser.Controls.Add(this.btnChange);
            this.groupBoxUser.Controls.Add(this.btnDelete);
            this.groupBoxUser.Controls.Add(this.btnAdd);
            this.groupBoxUser.Controls.Add(this.label4);
            this.groupBoxUser.Controls.Add(this.label3);
            this.groupBoxUser.Controls.Add(this.label2);
            this.groupBoxUser.Controls.Add(this.label1);
            this.groupBoxUser.Controls.Add(this.textBoxAgainPassWord);
            this.groupBoxUser.Controls.Add(this.textBoxNewPassWord);
            this.groupBoxUser.Controls.Add(this.textBoxOldPassWord);
            this.groupBoxUser.Controls.Add(this.textBoxUserName);
            this.groupBoxUser.Location = new System.Drawing.Point(227, 13);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Size = new System.Drawing.Size(200, 223);
            this.groupBoxUser.TabIndex = 0;
            this.groupBoxUser.TabStop = false;
            this.groupBoxUser.Text = "用户信息";
            // 
            // checkBoxIsUserManeger
            // 
            this.checkBoxIsUserManeger.AutoSize = true;
            this.checkBoxIsUserManeger.Location = new System.Drawing.Point(76, 164);
            this.checkBoxIsUserManeger.Name = "checkBoxIsUserManeger";
            this.checkBoxIsUserManeger.Size = new System.Drawing.Size(108, 16);
            this.checkBoxIsUserManeger.TabIndex = 3;
            this.checkBoxIsUserManeger.Text = "是否管理员帐号";
            this.checkBoxIsUserManeger.UseVisualStyleBackColor = true;
            this.checkBoxIsUserManeger.CheckedChanged += new System.EventHandler(this.checkBoxIsUserManeger_CheckedChanged);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(133, 187);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(51, 23);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "修改";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(76, 187);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(51, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(19, 187);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "确认密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "新密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "旧密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名";
            // 
            // textBoxAgainPassWord
            // 
            this.textBoxAgainPassWord.Location = new System.Drawing.Point(76, 134);
            this.textBoxAgainPassWord.Name = "textBoxAgainPassWord";
            this.textBoxAgainPassWord.Size = new System.Drawing.Size(108, 21);
            this.textBoxAgainPassWord.TabIndex = 0;
            this.textBoxAgainPassWord.UseSystemPasswordChar = true;
            // 
            // textBoxNewPassWord
            // 
            this.textBoxNewPassWord.Location = new System.Drawing.Point(76, 107);
            this.textBoxNewPassWord.Name = "textBoxNewPassWord";
            this.textBoxNewPassWord.Size = new System.Drawing.Size(108, 21);
            this.textBoxNewPassWord.TabIndex = 0;
            this.textBoxNewPassWord.UseSystemPasswordChar = true;
            // 
            // textBoxOldPassWord
            // 
            this.textBoxOldPassWord.Enabled = false;
            this.textBoxOldPassWord.Location = new System.Drawing.Point(76, 77);
            this.textBoxOldPassWord.Name = "textBoxOldPassWord";
            this.textBoxOldPassWord.Size = new System.Drawing.Size(108, 21);
            this.textBoxOldPassWord.TabIndex = 0;
            this.textBoxOldPassWord.UseSystemPasswordChar = true;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(76, 31);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(108, 21);
            this.textBoxUserName.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(352, 242);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 33);
            this.button4.TabIndex = 2;
            this.button4.Text = "确定";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("宋体", 12F);
            this.labelStatus.Location = new System.Drawing.Point(12, 243);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(168, 32);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "您不是管理员用户\r\n没有权限进行用户管理";
            // 
            // FormUserConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 282);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBoxUser);
            this.Controls.Add(this.groupBoxUserList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUserConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormUserConfig_FormClosed);
            this.groupBoxUserList.ResumeLayout(false);
            this.groupBoxUser.ResumeLayout(false);
            this.groupBoxUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUserList;
        private System.Windows.Forms.ListBox UserListBox;
        private System.Windows.Forms.GroupBox groupBoxUser;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAgainPassWord;
        private System.Windows.Forms.TextBox textBoxNewPassWord;
        private System.Windows.Forms.TextBox textBoxOldPassWord;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.CheckBox checkBoxIsUserManeger;
    }
}