using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MicroMotion.Services;
using MicroMotion.Models;
using MicroMotion.Sqlite;
using MicroMotion.Utils;

namespace MicroMotion
{
    public partial class FormQuery : Form
    {

        IExcelService ExcelService;

        public FormQuery()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {

            radioButtonTypeName0.Text = Device.All[0].TypeName;
            radioButtonTypeName1.Text = Device.All[1].TypeName;
            radioButtonTypeName2.Text = Device.All[2].TypeName;
            radioButtonTypeName3.Text = Device.All[3].TypeName;
            radioButtonTypeName4.Text = Device.All[4].TypeName;
            radioButtonTypeName5.Text = Device.All[5].TypeName;

            foreach (var device in Device.All)
            {
                foreach(var item in device.MaterialNameList)
                {
                    comboBoxMatierial.Items.Add(item);
                }
            }
            
            foreach (var user in User.All)
            {
                comboBoxUserName.Items.Add(user.Name);
            }
            if(comboBoxMatierial.Items.Count > 0)
                comboBoxMatierial.Text = comboBoxMatierial.Items[0].ToString();
            if(comboBoxUserName.Items.Count > 0)
                comboBoxUserName.Text = comboBoxUserName.Items[0].ToString();

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            var index = tabControl1.SelectedIndex;
            switch (index)
            {
                case 0:
                    QueryFormTime();
                    break;
                case 1:
                    QueryFormDeviceName();
                    break;
                case 2:
                    QueryFormMaterial();
                    break;
                case 3:
                    QueryFormUserName();
                    break;
                default: break;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (SqliteUtil.Instance.IsExistData == false)
            {
                MessageBox.Show("没有数据将不予生成");
                return;
            }
            try
            {
                ExcelService = new ExcelService();
                ExcelService.Export(saveFileDialog);
                MessageBox.Show("生成Excel成功！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void QueryFormTime()
        {
            var endDate = datePickerEnd.Value;
            var startDate = datePickerStart.Value;
            DateTime startDateTime = new DateTime(
                   datePickerStart.Value.Year, datePickerStart.Value.Month,
                   datePickerStart.Value.Day, timePickerStart.Value.Hour,
                   timePickerStart.Value.Minute, timePickerStart.Value.Second);

            DateTime endDateTime = new DateTime(
               datePickerEnd.Value.Year, datePickerEnd.Value.Month,
               datePickerEnd.Value.Day, timePickerEnd.Value.Hour,
               timePickerEnd.Value.Minute, timePickerEnd.Value.Second);
            if (startDateTime > endDateTime)
            {
                MessageBox.Show("起始时间不能大于终止时间!");
                return;
            }
            SqliteUtil.Instance.FindDataFromTime(startDateTime, endDateTime);
            if (SqliteUtil.Instance.IsExistData == false)
            {
                MessageBox.Show("查询时间段没有数据");
            }
            RenewDataToUi();
        }

        private void QueryFormDeviceName()
        {
            var index = 0;
            foreach (var control in tabPageTypename.Controls)
            {
                if (control is RadioButton)
                {
                    var radio = control as RadioButton;
                    if (radio.Checked == true)
                    {
                        index = Convert.ToInt32(radio.Tag);
                    }
                }
            }
            SqliteUtil.Instance.FindDataFromTypeName(Device.All[index].TypeName);
            if (SqliteUtil.Instance.IsExistData == false)
            {
                MessageBox.Show("没有查询到数据");
            }
            RenewDataToUi();

        }

        private void QueryFormMaterial()
        {

            if (string.IsNullOrEmpty(comboBoxMatierial.Text) == true)
            {
                MessageBox.Show("请选择一种材料");
            }

            SqliteUtil.Instance.FindDataFromMaterialName(comboBoxMatierial.Text);

            if (SqliteUtil.Instance.IsExistData == false)
            {
                MessageBox.Show("没有查询到数据");
            }
            RenewDataToUi();
        }

        private void QueryFormUserName()
        {
            if (string.IsNullOrEmpty(comboBoxUserName.Text) == true)
            {
                MessageBox.Show("请选择一个用户名");
            }

            SqliteUtil.Instance.FindDataFromUserName(comboBoxUserName.Text);

            if (SqliteUtil.Instance.IsExistData == false)
            {
                MessageBox.Show("没有查询到数据");
            }
            RenewDataToUi();
        }

        void RenewDataToUi()
        {
            dataGridView1.Rows.Clear();
            foreach (var data in SqliteUtil.Instance.Datas)
            {
                dataGridView1.Rows.Add(data.TypeName, data.MaterialName,data.Real, data.Date, data.StartTime,
                    data.EndTime, data.UserName);
            }
        }

        private void FormQuery_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExcelService = null;
        }

    }
}
