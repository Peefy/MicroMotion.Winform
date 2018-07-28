namespace MicroMotion
{
    partial class FormQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuery));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTime = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.timePickerStart = new System.Windows.Forms.DateTimePicker();
            this.tabPageTypename = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonTypeName5 = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeName2 = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeName3 = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeName4 = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeName1 = new System.Windows.Forms.RadioButton();
            this.radioButtonTypeName0 = new System.Windows.Forms.RadioButton();
            this.tabPageMatierial = new System.Windows.Forms.TabPage();
            this.comboBoxMatierial = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageUserName = new System.Windows.Forms.TabPage();
            this.comboBoxUserName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPageTime.SuspendLayout();
            this.tabPageTypename.SuspendLayout();
            this.tabPageMatierial.SuspendLayout();
            this.tabPageUserName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTime);
            this.tabControl1.Controls.Add(this.tabPageTypename);
            this.tabControl1.Controls.Add(this.tabPageMatierial);
            this.tabControl1.Controls.Add(this.tabPageUserName);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 97);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTime
            // 
            this.tabPageTime.Controls.Add(this.label2);
            this.tabPageTime.Controls.Add(this.label1);
            this.tabPageTime.Controls.Add(this.timePickerEnd);
            this.tabPageTime.Controls.Add(this.datePickerStart);
            this.tabPageTime.Controls.Add(this.datePickerEnd);
            this.tabPageTime.Controls.Add(this.timePickerStart);
            this.tabPageTime.Location = new System.Drawing.Point(4, 22);
            this.tabPageTime.Name = "tabPageTime";
            this.tabPageTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTime.Size = new System.Drawing.Size(780, 71);
            this.tabPageTime.TabIndex = 0;
            this.tabPageTime.Text = "按时间查询";
            this.tabPageTime.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(423, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 27);
            this.label2.TabIndex = 42;
            this.label2.Text = "结束时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 42;
            this.label1.Text = "起始时间";
            // 
            // timePickerEnd
            // 
            this.timePickerEnd.CalendarMonthBackground = System.Drawing.Color.DarkGray;
            this.timePickerEnd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.timePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerEnd.Location = new System.Drawing.Point(553, 35);
            this.timePickerEnd.Name = "timePickerEnd";
            this.timePickerEnd.ShowUpDown = true;
            this.timePickerEnd.Size = new System.Drawing.Size(188, 23);
            this.timePickerEnd.TabIndex = 40;
            // 
            // datePickerStart
            // 
            this.datePickerStart.CalendarMonthBackground = System.Drawing.Color.DarkGray;
            this.datePickerStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.datePickerStart.Location = new System.Drawing.Point(145, 11);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.Size = new System.Drawing.Size(194, 23);
            this.datePickerStart.TabIndex = 41;
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.CalendarMonthBackground = System.Drawing.Color.DarkGray;
            this.datePickerEnd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.datePickerEnd.Location = new System.Drawing.Point(553, 11);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(188, 23);
            this.datePickerEnd.TabIndex = 41;
            // 
            // timePickerStart
            // 
            this.timePickerStart.CalendarMonthBackground = System.Drawing.Color.DarkGray;
            this.timePickerStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.timePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerStart.Location = new System.Drawing.Point(145, 35);
            this.timePickerStart.Name = "timePickerStart";
            this.timePickerStart.ShowUpDown = true;
            this.timePickerStart.Size = new System.Drawing.Size(194, 23);
            this.timePickerStart.TabIndex = 38;
            this.timePickerStart.Value = new System.DateTime(2017, 5, 25, 0, 0, 0, 0);
            // 
            // tabPageTypename
            // 
            this.tabPageTypename.Controls.Add(this.label5);
            this.tabPageTypename.Controls.Add(this.radioButtonTypeName5);
            this.tabPageTypename.Controls.Add(this.radioButtonTypeName2);
            this.tabPageTypename.Controls.Add(this.radioButtonTypeName3);
            this.tabPageTypename.Controls.Add(this.radioButtonTypeName4);
            this.tabPageTypename.Controls.Add(this.radioButtonTypeName1);
            this.tabPageTypename.Controls.Add(this.radioButtonTypeName0);
            this.tabPageTypename.Location = new System.Drawing.Point(4, 22);
            this.tabPageTypename.Name = "tabPageTypename";
            this.tabPageTypename.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTypename.Size = new System.Drawing.Size(780, 71);
            this.tabPageTypename.TabIndex = 1;
            this.tabPageTypename.Text = "按设备位号查询";
            this.tabPageTypename.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(24, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 27);
            this.label5.TabIndex = 44;
            this.label5.Text = "设备位号选择";
            // 
            // radioButtonTypeName5
            // 
            this.radioButtonTypeName5.AutoSize = true;
            this.radioButtonTypeName5.Font = new System.Drawing.Font("宋体", 13F);
            this.radioButtonTypeName5.Location = new System.Drawing.Point(377, 37);
            this.radioButtonTypeName5.Name = "radioButtonTypeName5";
            this.radioButtonTypeName5.Size = new System.Drawing.Size(71, 22);
            this.radioButtonTypeName5.TabIndex = 0;
            this.radioButtonTypeName5.Tag = "5";
            this.radioButtonTypeName5.Text = "AI-6#";
            this.radioButtonTypeName5.UseVisualStyleBackColor = true;
            // 
            // radioButtonTypeName2
            // 
            this.radioButtonTypeName2.AutoSize = true;
            this.radioButtonTypeName2.Font = new System.Drawing.Font("宋体", 13F);
            this.radioButtonTypeName2.Location = new System.Drawing.Point(377, 9);
            this.radioButtonTypeName2.Name = "radioButtonTypeName2";
            this.radioButtonTypeName2.Size = new System.Drawing.Size(89, 22);
            this.radioButtonTypeName2.TabIndex = 0;
            this.radioButtonTypeName2.Tag = "2";
            this.radioButtonTypeName2.Text = "AI-1404";
            this.radioButtonTypeName2.UseVisualStyleBackColor = true;
            // 
            // radioButtonTypeName3
            // 
            this.radioButtonTypeName3.AutoSize = true;
            this.radioButtonTypeName3.Font = new System.Drawing.Font("宋体", 13F);
            this.radioButtonTypeName3.Location = new System.Drawing.Point(167, 37);
            this.radioButtonTypeName3.Name = "radioButtonTypeName3";
            this.radioButtonTypeName3.Size = new System.Drawing.Size(89, 22);
            this.radioButtonTypeName3.TabIndex = 0;
            this.radioButtonTypeName3.Tag = "3";
            this.radioButtonTypeName3.Text = "AI-1405";
            this.radioButtonTypeName3.UseVisualStyleBackColor = true;
            // 
            // radioButtonTypeName4
            // 
            this.radioButtonTypeName4.AutoSize = true;
            this.radioButtonTypeName4.Font = new System.Drawing.Font("宋体", 13F);
            this.radioButtonTypeName4.Location = new System.Drawing.Point(272, 37);
            this.radioButtonTypeName4.Name = "radioButtonTypeName4";
            this.radioButtonTypeName4.Size = new System.Drawing.Size(89, 22);
            this.radioButtonTypeName4.TabIndex = 0;
            this.radioButtonTypeName4.Tag = "4";
            this.radioButtonTypeName4.Text = "AI-1605";
            this.radioButtonTypeName4.UseVisualStyleBackColor = true;
            // 
            // radioButtonTypeName1
            // 
            this.radioButtonTypeName1.AutoSize = true;
            this.radioButtonTypeName1.Font = new System.Drawing.Font("宋体", 13F);
            this.radioButtonTypeName1.Location = new System.Drawing.Point(272, 9);
            this.radioButtonTypeName1.Name = "radioButtonTypeName1";
            this.radioButtonTypeName1.Size = new System.Drawing.Size(89, 22);
            this.radioButtonTypeName1.TabIndex = 0;
            this.radioButtonTypeName1.Tag = "1";
            this.radioButtonTypeName1.Text = "AI-1402";
            this.radioButtonTypeName1.UseVisualStyleBackColor = true;
            // 
            // radioButtonTypeName0
            // 
            this.radioButtonTypeName0.AutoSize = true;
            this.radioButtonTypeName0.Checked = true;
            this.radioButtonTypeName0.Font = new System.Drawing.Font("宋体", 13F);
            this.radioButtonTypeName0.Location = new System.Drawing.Point(167, 9);
            this.radioButtonTypeName0.Name = "radioButtonTypeName0";
            this.radioButtonTypeName0.Size = new System.Drawing.Size(89, 22);
            this.radioButtonTypeName0.TabIndex = 0;
            this.radioButtonTypeName0.TabStop = true;
            this.radioButtonTypeName0.Tag = "0";
            this.radioButtonTypeName0.Text = "AI-1401";
            this.radioButtonTypeName0.UseVisualStyleBackColor = true;
            // 
            // tabPageMatierial
            // 
            this.tabPageMatierial.Controls.Add(this.comboBoxMatierial);
            this.tabPageMatierial.Controls.Add(this.label3);
            this.tabPageMatierial.Location = new System.Drawing.Point(4, 22);
            this.tabPageMatierial.Name = "tabPageMatierial";
            this.tabPageMatierial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMatierial.Size = new System.Drawing.Size(780, 71);
            this.tabPageMatierial.TabIndex = 2;
            this.tabPageMatierial.Text = "按原料查询";
            this.tabPageMatierial.UseVisualStyleBackColor = true;
            // 
            // comboBoxMatierial
            // 
            this.comboBoxMatierial.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBoxMatierial.FormattingEnabled = true;
            this.comboBoxMatierial.Location = new System.Drawing.Point(133, 22);
            this.comboBoxMatierial.Name = "comboBoxMatierial";
            this.comboBoxMatierial.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMatierial.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 27);
            this.label3.TabIndex = 43;
            this.label3.Text = "原料选择";
            // 
            // tabPageUserName
            // 
            this.tabPageUserName.Controls.Add(this.comboBoxUserName);
            this.tabPageUserName.Controls.Add(this.label4);
            this.tabPageUserName.Location = new System.Drawing.Point(4, 22);
            this.tabPageUserName.Name = "tabPageUserName";
            this.tabPageUserName.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserName.Size = new System.Drawing.Size(780, 71);
            this.tabPageUserName.TabIndex = 3;
            this.tabPageUserName.Text = "按操作员查询";
            this.tabPageUserName.UseVisualStyleBackColor = true;
            // 
            // comboBoxUserName
            // 
            this.comboBoxUserName.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBoxUserName.FormattingEnabled = true;
            this.comboBoxUserName.Location = new System.Drawing.Point(142, 24);
            this.comboBoxUserName.Name = "comboBoxUserName";
            this.comboBoxUserName.Size = new System.Drawing.Size(121, 24);
            this.comboBoxUserName.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 27);
            this.label4.TabIndex = 44;
            this.label4.Text = "操作员选择";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column6});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(928, 531);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "设备位号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "原料名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 130;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "加料量(kg)";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 130;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "加料日期";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 130;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "加料开始时间";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 130;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "加料结束时间";
            this.Column7.Name = "Column7";
            this.Column7.Width = 130;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "操作员";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 130;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 12F);
            this.btnQuery.Location = new System.Drawing.Point(798, 24);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(121, 30);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查 询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("宋体", 12F);
            this.btnExport.Location = new System.Drawing.Point(798, 60);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(121, 30);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "导出为Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FormQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 631);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "历史数据查询";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormQuery_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTime.ResumeLayout(false);
            this.tabPageTime.PerformLayout();
            this.tabPageTypename.ResumeLayout(false);
            this.tabPageTypename.PerformLayout();
            this.tabPageMatierial.ResumeLayout(false);
            this.tabPageMatierial.PerformLayout();
            this.tabPageUserName.ResumeLayout(false);
            this.tabPageUserName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTime;
        private System.Windows.Forms.TabPage tabPageTypename;
        private System.Windows.Forms.TabPage tabPageMatierial;
        private System.Windows.Forms.TabPage tabPageUserName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerEnd;
        private System.Windows.Forms.RadioButton radioButtonTypeName5;
        private System.Windows.Forms.RadioButton radioButtonTypeName2;
        private System.Windows.Forms.RadioButton radioButtonTypeName3;
        private System.Windows.Forms.RadioButton radioButtonTypeName4;
        private System.Windows.Forms.RadioButton radioButtonTypeName1;
        private System.Windows.Forms.RadioButton radioButtonTypeName0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxMatierial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker timePickerEnd;
        private System.Windows.Forms.DateTimePicker timePickerStart;
        private System.Windows.Forms.DateTimePicker datePickerStart;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}