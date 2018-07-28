namespace MicroMotion
{
    partial class FormSerialPortConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSerialPortConfig));
            this.groupBoxParity = new System.Windows.Forms.GroupBox();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.groupBoxStopBits = new System.Windows.Forms.GroupBox();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.groupBoxBaudRate = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comcmb = new System.Windows.Forms.ComboBox();
            this.btnRenew = new System.Windows.Forms.Button();
            this.listBoxSerialPortConfig = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelHelp = new System.Windows.Forms.Label();
            this.groupBoxParity.SuspendLayout();
            this.groupBoxStopBits.SuspendLayout();
            this.groupBoxBaudRate.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxParity
            // 
            this.groupBoxParity.Controls.Add(this.radioButton12);
            this.groupBoxParity.Controls.Add(this.radioButton11);
            this.groupBoxParity.Controls.Add(this.radioButton10);
            this.groupBoxParity.Location = new System.Drawing.Point(129, 11);
            this.groupBoxParity.Name = "groupBoxParity";
            this.groupBoxParity.Size = new System.Drawing.Size(100, 111);
            this.groupBoxParity.TabIndex = 0;
            this.groupBoxParity.TabStop = false;
            this.groupBoxParity.Text = "校验";
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(10, 85);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(59, 16);
            this.radioButton12.TabIndex = 0;
            this.radioButton12.Tag = "2";
            this.radioButton12.Text = "偶校验";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(10, 55);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(59, 16);
            this.radioButton11.TabIndex = 0;
            this.radioButton11.Tag = "1";
            this.radioButton11.Text = "奇校验";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Checked = true;
            this.radioButton10.Location = new System.Drawing.Point(10, 25);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(59, 16);
            this.radioButton10.TabIndex = 0;
            this.radioButton10.TabStop = true;
            this.radioButton10.Tag = "0";
            this.radioButton10.Text = "无校验";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // groupBoxStopBits
            // 
            this.groupBoxStopBits.Controls.Add(this.radioButton9);
            this.groupBoxStopBits.Controls.Add(this.radioButton7);
            this.groupBoxStopBits.Location = new System.Drawing.Point(246, 12);
            this.groupBoxStopBits.Name = "groupBoxStopBits";
            this.groupBoxStopBits.Size = new System.Drawing.Size(102, 110);
            this.groupBoxStopBits.TabIndex = 0;
            this.groupBoxStopBits.TabStop = false;
            this.groupBoxStopBits.Text = "停止位";
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(12, 54);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(77, 16);
            this.radioButton9.TabIndex = 0;
            this.radioButton9.Tag = "2";
            this.radioButton9.Text = "2个停止位";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Checked = true;
            this.radioButton7.Location = new System.Drawing.Point(12, 25);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(77, 16);
            this.radioButton7.TabIndex = 0;
            this.radioButton7.TabStop = true;
            this.radioButton7.Tag = "0";
            this.radioButton7.Text = "1个停止位";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // groupBoxBaudRate
            // 
            this.groupBoxBaudRate.Controls.Add(this.radioButton6);
            this.groupBoxBaudRate.Controls.Add(this.radioButton5);
            this.groupBoxBaudRate.Controls.Add(this.radioButton4);
            this.groupBoxBaudRate.Controls.Add(this.radioButton3);
            this.groupBoxBaudRate.Controls.Add(this.radioButton2);
            this.groupBoxBaudRate.Controls.Add(this.radioButton1);
            this.groupBoxBaudRate.Location = new System.Drawing.Point(363, 11);
            this.groupBoxBaudRate.Name = "groupBoxBaudRate";
            this.groupBoxBaudRate.Size = new System.Drawing.Size(102, 200);
            this.groupBoxBaudRate.TabIndex = 0;
            this.groupBoxBaudRate.TabStop = false;
            this.groupBoxBaudRate.Text = "波特率";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(16, 175);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(53, 16);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.Tag = "5";
            this.radioButton6.Text = "38400";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(16, 145);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(53, 16);
            this.radioButton5.TabIndex = 0;
            this.radioButton5.Tag = "4";
            this.radioButton5.Text = "19200";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(16, 115);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(47, 16);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Tag = "3";
            this.radioButton4.Text = "9600";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(16, 85);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.Tag = "2";
            this.radioButton3.Text = "4800";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 55);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Tag = "1";
            this.radioButton2.Text = "2400";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "0";
            this.radioButton1.Text = "1200";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comcmb);
            this.groupBox4.Controls.Add(this.btnRenew);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(100, 110);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "串口";
            // 
            // comcmb
            // 
            this.comcmb.FormattingEnabled = true;
            this.comcmb.Location = new System.Drawing.Point(18, 65);
            this.comcmb.Name = "comcmb";
            this.comcmb.Size = new System.Drawing.Size(70, 20);
            this.comcmb.TabIndex = 1;
            // 
            // btnRenew
            // 
            this.btnRenew.Location = new System.Drawing.Point(18, 23);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(70, 23);
            this.btnRenew.TabIndex = 0;
            this.btnRenew.Text = "刷新";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // listBoxSerialPortConfig
            // 
            this.listBoxSerialPortConfig.FormattingEnabled = true;
            this.listBoxSerialPortConfig.ItemHeight = 12;
            this.listBoxSerialPortConfig.Items.AddRange(new object[] {
            "总线一",
            "总线二"});
            this.listBoxSerialPortConfig.Location = new System.Drawing.Point(485, 12);
            this.listBoxSerialPortConfig.Name = "listBoxSerialPortConfig";
            this.listBoxSerialPortConfig.Size = new System.Drawing.Size(78, 100);
            this.listBoxSerialPortConfig.TabIndex = 1;
            this.listBoxSerialPortConfig.SelectedIndexChanged += new System.EventHandler(this.listBoxSerialPortConfig_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(485, 123);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(78, 35);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "连接";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(485, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Location = new System.Drawing.Point(26, 146);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(245, 12);
            this.labelHelp.TabIndex = 1;
            this.labelHelp.Text = "总线一：AI-1404、AI-1405、AI-1605、AI-6#";
            // 
            // FormSerialPortConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 218);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.listBoxSerialPortConfig);
            this.Controls.Add(this.groupBoxBaudRate);
            this.Controls.Add(this.groupBoxStopBits);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBoxParity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSerialPortConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSerialPortConfig_FormClosing);
            this.Load += new System.EventHandler(this.FormSerialPortConfig_Load);
            this.groupBoxParity.ResumeLayout(false);
            this.groupBoxParity.PerformLayout();
            this.groupBoxStopBits.ResumeLayout(false);
            this.groupBoxStopBits.PerformLayout();
            this.groupBoxBaudRate.ResumeLayout(false);
            this.groupBoxBaudRate.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxParity;
        private System.Windows.Forms.GroupBox groupBoxStopBits;
        private System.Windows.Forms.GroupBox groupBoxBaudRate;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comcmb;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.ListBox listBoxSerialPortConfig;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.Label labelHelp;
    }
}