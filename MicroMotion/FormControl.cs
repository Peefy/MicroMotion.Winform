using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using Modbus.Device;

using MicroMotion.Helpers;
using MicroMotion.Models;
using MicroMotion.Services;
using MicroMotion.Utils;
using MicroMotion.Sqlite;

namespace MicroMotion
{
    public partial class FormControl : Form
    {

        int Index = 0;
        IPdfService PdfService;
        ModbusSerialMaster[] Masters;

        public ModbusSerialMaster MasterNow
        {
            get
            {
                if (Masters == null)
                    return null;
                if (Index < 2)
                    return Masters[1];
                else
                    return Masters[0];
            }
        }

        public Device DeviceNow
        {
            get
            {
                return Device.All[Index];
            }
        }

        public FormControl(int index,ModbusSerialMaster[] masters)
        {
            InitializeComponent();
            Index = index;
            Masters = masters;        
        }

        private void FormControl_Load(object sender, EventArgs e)
        {
            /*try
            {
                bool[] datatmp = MasterNow.ReadCoils(DeviceNow.BatchControllerAddress,
                            AddressHelper.CoilResumeBacth, 1);
                DeviceNow.IsPause = datatmp[0] == false;
            }
            catch (NullReferenceException ex) { }
            catch (TimeoutException ex) { }
            catch (Exception ex)
            {
//                MessageBox.Show("Modbus错误，无法读取仪器是否暂停。详情如下：\r\n\r\n" + ex.ToString());
            }*/


            Init();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ClosingDealData();
        }

        private void ClosingDealData()
        {
            DeviceNow.MaterialName = comboBoxMateriaName.Text;
            DeviceNow.MaterialNameList.Clear();
            
            foreach (var item in comboBoxMateriaName.Items)
            {               
                DeviceNow.MaterialNameList.Add(item.ToString());
            }
            if (DeviceNow.MaterialNameList.Contains(DeviceNow.MaterialName) == false 
                && DeviceNow.MaterialName != "")
                DeviceNow.MaterialNameList.Add(DeviceNow.MaterialName);

            float data = DeviceNow.Goal;
            float.TryParse(textBoxGoal.Text,out data);
            DeviceNow.Goal = data;

            this.DialogResult = DialogResult.OK;
        }

        void Init()
        {
            labelQualityFlow.Text = DeviceNow.QualityFlow.ToString() + " kg/h";
            labelDensity.Text = DeviceNow.Density.ToString() + " kg/m3";
            labelTemperature.Text = DeviceNow.Temperature.ToString() + " ℃";
            labelTotalAmount.Text = DeviceNow.TotalAmount.ToString() + " kg";
            timerRenewUi.Enabled = true;
            labelTypeName.Text = DeviceNow.TypeName;
            textBoxGoal.Text = DeviceNow.Goal.ToString();
            comboBoxMateriaName.Items.Clear();
            foreach (var str in DeviceNow.MaterialNameList)
            {
                if(str != "")
                    comboBoxMateriaName.Items.Add(str);
            }
            comboBoxMateriaName.Text = DeviceNow.MaterialName;
            Device.All[Index].MaterialName = comboBoxMateriaName.Text;
            Device.All[Index].IsShowControlForm = true;
            //btnPause.Text = DeviceNow.IsPause == true ? "批量复位" : "批量暂停";
            //DeviceNow.IsStart = DeviceNow.DO1Code == 1;
        }

        private void textBoxGoal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                float data;
                if (float.TryParse(textBox.Text, out data) == false)
                {
                    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                }
                else
                {
                    DeviceNow.Goal = data;
                }
            }
            catch 
            {
            	
            }
 
        }

        #region Control
        /// <summary>
        /// 批控器不会控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Device.All[Index].MaterialName) == true)
            {
                MessageBox.Show("未填写原料名称");
                return;
            }
            if (MessageBox.Show(string.Format("确定将加料值设置为{0} Kg ？", DeviceNow.Goal), "消息", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (MasterNow != null)
                    {
                        //目标值
                        MasterNow.WriteMultipleRegisters(DeviceNow.BatchControllerAddress,
                            AddressHelper.Goal, ModbusFloatHelper.FloatToUshort(DeviceNow.Goal));

                        if(MessageBox.Show("确定将阀门打开并开始加料？", "消息", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //打开阀门
                            MasterNow.WriteSingleCoil(DeviceNow.BatchControllerAddress,
                                AddressHelper.CoilIsStartBacth, true);
                            DeviceNow.StartTime = DateTime.Now;
                            DeviceNow.IsStart = true;
                            textBoxResidue.Text = "0";
                        }
                    }
                    else
                    {
                        MessageBox.Show("未连接设备！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
 
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            try
            {
                if (MasterNow != null)
                {
                    if(DeviceNow.IsStart == true)
                    {
                        DeviceNow.EndTime = DateTime.Now;
                        MasterNow.WriteSingleCoil(DeviceNow.BatchControllerAddress,
                            AddressHelper.CoilEndBacth, true);
                        DeviceNow.IsStart = false;
                        MessageBox.Show(string.Format("{0} 结束加料！",DeviceNow.TypeName));
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (MasterNow != null)
                {
                    //打开阀门
                    MasterNow.WriteSingleCoil(DeviceNow.BatchControllerAddress,
                        AddressHelper.CoilIsStartBacth, false);
                    DeviceNow.IsPause = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        bool DoIsSameDay()
        {
            var nowDay = DateTime.Now.DayOfYear;
            var lastDay = User.Now.LastGeneratePdfTime.DayOfYear;
            if(nowDay == lastDay)
                return true;
            return false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            SqliteUtil.Instance.InsertData(new DeviceUserSqliteObject()
            {
                UserName = User.Now.Name,
                MaterialName = DeviceNow.MaterialName,
                TypeName = DeviceNow.TypeName,
                QualityFlow = DeviceNow.QualityFlow.ToString(),
                Density = DeviceNow.Density.ToString(),
                Temperature = DeviceNow.Temperature.ToString(),
                TotalAmount = DeviceNow.TotalAmount.ToString(),
                Goal = DeviceNow.Goal.ToString(),
                Real = DeviceNow.Real.ToString(),
                Date = DateTime.Now.ToString("yyyy/MM/dd"),
                StartTime = DeviceNow.StartTime.ToString("yyyy/MM/dd HH:mm:ss"),
                EndTime = DeviceNow.EndTime.ToString("yyyy/MM/dd HH:mm:ss"),
            });

            if (DoIsSameDay() == false)
                DeviceNow.GeneratePdfCount = 0;
            var pdfName = System.DateTime.Now.ToString("yyyyMMdd_") + DeviceNow.TypeName + "_" +
                User.Now.Name + "_" + DeviceNow.GeneratePdfCount.ToString() + ".pdf";
            if (Directory.Exists(ConfigHelper.RepportFileSavePath) == false)
                Directory.CreateDirectory(ConfigHelper.RepportFileSavePath);
            var savePath = Path.Combine(ConfigHelper.RepportFileSavePath,pdfName);
            PdfService = new PdfService();
            try
            {
                if (PdfService.ExportDeviceRepport(Index, savePath) == true)
                {
                    ++DeviceNow.GeneratePdfCount; 
                    User.Now.LastGeneratePdfTime = System.DateTime.Now;
                    MessageBox.Show("生成成功!");
                    try
                    {
                        Process.Start(savePath);
                    }
                    catch
                    {
                        MessageBox.Show("找不到这台电脑上打开pdf的默认程序");
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("生成PDF失败！\r\n可能原因" + ex.Message);
            }

        }

        private void btnHistoryData_Click(object sender, EventArgs e)
        {
            new FormQuery().Show();
        }

        #endregion

        private void timerRenewUi_Tick(object sender, EventArgs e)
        {
            Device.All[Index].MaterialName = comboBoxMateriaName.Text;
            labelQualityFlow.Text = DeviceNow.QualityFlow.ToString() + " kg/h";
            labelDensity.Text = DeviceNow.Density.ToString() + " kg/m3";
            labelTemperature.Text = DeviceNow.Temperature.ToString() + " ℃";
            labelTotalAmount.Text = DeviceNow.TotalAmount.ToString() + " kg";
            textBoxReal.Text = DeviceNow.Real.ToString();
            textBoxResidue.Text = DeviceNow.Residue.ToString();
            this.pictureBoxGIF.Visible = (Device.All[Index].DO1Code != 0) && Device.All[Index].QualityFlow > 0;
        }

        private void AutoCloseControler()
        {
            try
            {
                if (DeviceNow.IsStart == true && DeviceNow.Real > 0 && MasterNow != null)
                {
                    
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeviceNow.IsShowControlForm = false;
            if(PdfService != null)
                PdfService = null;
            if (Masters != null)
            {
                for (int i = 0;i < Masters.Length ;++i )
                {
//                    if (Masters[i] != null)
//                        Masters[i] = null;
                }
            }
        }

        private void comboBoxMateriaName_TextChanged(object sender, EventArgs e)
        {
            Device.All[Index].MaterialName = comboBoxMateriaName.Text;
        }

        private void comboBoxMateriaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device.All[Index].MaterialName = comboBoxMateriaName.Text;
        }

        private void FormControl_Resize(object sender, EventArgs e)
        {
            panel1.Left = (Width - panel1.Width) / 2;
            panel1.Top = (Height - panel1.Height) / 2;
        }

        private void buttonTEST_Click(object sender, EventArgs e)
        {
            this.pictureBoxGIF.Visible = !this.pictureBoxGIF.Visible;
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                if (MasterNow != null && DeviceNow.IsStart == true)
                {

                    MasterNow.WriteSingleCoil(DeviceNow.BatchControllerAddress,
                        AddressHelper.CoilResumeBacth, true);
                    DeviceNow.IsPause = false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (MasterNow != null)
                {
                    MasterNow.WriteSingleCoil(DeviceNow.BatchControllerAddress,
                        AddressHelper.CoilResetReal, true); 
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
