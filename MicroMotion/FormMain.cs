using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

using Microsoft.VisualBasic.PowerPacks;

using Modbus.Device;

using MicroMotion.Models;
using MicroMotion.Builders;
using MicroMotion.Services;
using MicroMotion.Helpers;
using MicroMotion.Sqlite;
using MicroMotion.Utils;

namespace MicroMotion
{
    public partial class FormMain : Form
    {

        const int SerialPortNum = 2;
        const int GroupNum = 6;

        Dictionary<float, int> LabelFontPtAndHeight = new Dictionary<float, int>();
        List<GroupBox> GroupBoxs;
        ModbusSerialMaster[] ModbusMasters = new ModbusSerialMaster[SerialPortNum];
        SerialPort[] SerialPorts = new SerialPort[SerialPortNum];
        IFileSerivce FileService;

        /// <summary>
        /// 是否完成开机自检
        /// </summary>
        bool SelfCheckFlag = false;
        int DeviceOnlineCount = 0;

        /// <summary>
        /// 主窗口是否在前，用于切换主窗口和分窗口
        /// </summary>
        bool IsMainFormActive = true;

        FormControl[] formControls = new FormControl[GroupNum];

        public FormMain()
        {
            InitializeComponent();
            Init();   
        }

        #region ContentInit

        public void Init()
        {
            FileService = new FileService();
            this.WindowState = FormWindowState.Maximized;
            LabelFontPtAndHeightInit();
            if (Directory.Exists(ConfigHelper.RepportFileSavePath) == false)
                Directory.CreateDirectory(ConfigHelper.RepportFileSavePath);
            保存路径ToolStripMenuItem.Enabled = User.Now.IsManager;
            仪表位号ToolStripMenuItem.Enabled = User.Now.IsManager;
            labelIsManager.Text = "操作人员：" + (User.Now.IsManager ? "管理员 " : "用户 ") + User.Now.Name;
            GroupBoxInit();
            SerialPortInit();
            RenewAllDevicesUi();
        }
        /// <summary>
        /// label的font大小与label的height对应关系
        /// </summary>
        public void LabelFontPtAndHeightInit()
        {
            LabelFontPtAndHeight.Add(10f, 14);
            LabelFontPtAndHeight.Add(11f, 15);
            LabelFontPtAndHeight.Add(12f, 16);
            LabelFontPtAndHeight.Add(13f, 18);
            LabelFontPtAndHeight.Add(14f, 19);
            LabelFontPtAndHeight.Add(15f, 20);
            LabelFontPtAndHeight.Add(16f, 22);
            LabelFontPtAndHeight.Add(17f, 23);
            LabelFontPtAndHeight.Add(18f, 24);
            LabelFontPtAndHeight.Add(19f, 26);
            LabelFontPtAndHeight.Add(20f, 27);
            LabelFontPtAndHeight.Add(21f, 28);
            LabelFontPtAndHeight.Add(22f, 30);
            LabelFontPtAndHeight.Add(23f, 31);
            LabelFontPtAndHeight.Add(24f, 33);
            LabelFontPtAndHeight.Add(25f, 34);
            LabelFontPtAndHeight.Add(26f, 35);
            LabelFontPtAndHeight.Add(27f, 36);
            LabelFontPtAndHeight.Add(28f, 38);
            LabelFontPtAndHeight.Add(29f, 39);
            LabelFontPtAndHeight.Add(30f, 40);
        }

        #endregion

        #region SerialPortAndModbusMaster

        public void SerialPortInit()
        {
            SerialPorts = new SerialPortBuilder().FromFiles();
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            if (ports.Length > 1)
            {
                SerialPorts[0].PortName = ports[0];
                SerialPorts[1].PortName = ports[1];
            }
            else if (ports.Length == 1)
            {
                SerialPorts[0].PortName = ports[0];
                SerialPorts[1].PortName = "COM*";
            }
            else
            {
                SerialPorts[0].PortName = "COM*";
                SerialPorts[1].PortName = "COM*";
            }
        }

        void ModbusClosingDispose()
        {
            if (ModbusMasters != null)
            {
                for (int i = 0; i < ModbusMasters.Length; ++i)
                {
                    if (ModbusMasters[i] != null)
                    {
                        ModbusMasters[i].Dispose();
                        ModbusMasters[i] = null;
                    }
                }
            }
        }

        private void GetDeviceInfoFormIndex(int index)
        {
            ModbusSerialMaster master;
            if (index < 2)
            {
                master = ModbusMasters[1];
            }
            else
            {
                master = ModbusMasters[0];
            }
            ///读取变送器;
            var datas = master.ReadHoldingRegisters(Device.All[index].Transducer2700Address,
                AddressHelper.QualityFlow, (ushort)(AddressHelper.NumberUnitOfFloat * 3));

            Device.All[index].QualityFlow = ModbusFloatHelper.UshortToFloat(datas, 0, 3);
            Device.All[index].Density = ModbusFloatHelper.UshortToFloat(datas, 2, 1);
            Device.All[index].Temperature = ModbusFloatHelper.UshortToFloat(datas, 4, 1);

            datas = master.ReadHoldingRegisters(Device.All[index].Transducer2700Address,
                AddressHelper.TotalAmount, (ushort)(AddressHelper.NumberUnitOfFloat * 1));
            Device.All[index].TotalAmount = ModbusFloatHelper.UshortToFloat(datas, 0, 3);
            ///读取批控器
            datas = master.ReadHoldingRegisters(Device.All[index].BatchControllerAddress,
                AddressHelper.Real, (ushort)(AddressHelper.NumberUnitOfFloat * 1));
            Device.All[index].Real = ModbusFloatHelper.UshortToFloat(datas, 0, 3);

            datas = master.ReadHoldingRegisters(Device.All[index].BatchControllerAddress,
                AddressHelper.DO1, (ushort)(AddressHelper.NumberUnitOfWord * 1));

            Device.All[index].DO1Code = datas[0];

            if(Device.All[index].IsStart == true && Device.All[index].Real > 0)
            {
                var results = master.ReadCoils(Device.All[index].BatchControllerAddress,
                        AddressHelper.CoilEndBacth, 1);
                if (results[0] == true)
                {
                    Device.All[index].EndTime = DateTime.Now;
                    master.WriteSingleCoil(Device.All[index].BatchControllerAddress,
                        AddressHelper.CoilEndBacth, true);
                    Device.All[index].IsStart = false;
                    MessageBox.Show(string.Format("{0} 结束加料！", Device.All[index].TypeName));
                }
            }

        }

        bool isShowInfoBox;
       // int deviceIndex;
        private void timerGetData_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Device.Count; ++i)
            {
                try
                {
                    if (SelfCheckFlag == true && Device.All[i].IsConnect == false)
                        continue;
                    GetDeviceInfoFormIndex(i);
                    Device.All[i].FlowMeterStatus = true;
                    Device.All[i].BatchControllerStatus = true;

                    //RenewAllDevicesUi();
                    RenewDeviceDataUi(i);
                    labelStatus.Text = "通信正常";
                    timerSave.Enabled = true;
                    isShowInfoBox = false;
                    Device.All[i].IsConnect = true;
                    DeviceOnlineCount++;
                }
                catch (Exception exception)
                {

                    Device.All[i].FlowMeterStatus = false;
                    Device.All[i].BatchControllerStatus = false;
                    //RenewAllDevicesUi();
                    RenewDeviceDataUi(i);
                    if (exception.Source.Equals("System"))
                    {
                        if (!isShowInfoBox)
                        {
                            isShowInfoBox = true;
                           // MessageBox.Show(DateTime.Now.ToString() + " " + "通信超时");
                        }
                        if (SelfCheckFlag == false)//未完成自检
                            Device.All[i].IsConnect = false;
                        if (SelfCheckFlag == true)//完成自检
                            labelStatus.Text = "通信超时  " + i.ToString();
                    }
                    else if (exception.Source.Equals("nModbusPC"))
                    {
                        string str = exception.Message;
                        int FunctionCode;
                        string ExceptionCode;
                        str = str.Remove(0, str.IndexOf("\r\n", StringComparison.Ordinal) + 17);
                        FunctionCode = Convert.ToInt16(str.Remove(str.IndexOf("\r\n", StringComparison.Ordinal)));
                        str = str.Remove(0, str.IndexOf("\r\n", StringComparison.Ordinal) + 17);
                        ExceptionCode = str.Remove(str.IndexOf("-", StringComparison.Ordinal));
                        if (SelfCheckFlag == true)//完成自检
                        {
                            switch (ExceptionCode.Trim())
                            {
                                case "1":
                                    labelStatus.Text = "通信异常：非法的通信功能码";
                                    break;
                                case "2":
                                    labelStatus.Text = "通信异常：非法的数据地址";
                                    break;
                                case "3":
                                    labelStatus.Text = "通信异常：非法的数据值";
                                    break;
                                case "4":
                                    labelStatus.Text = "从机故障";
                                    break;

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(exception.ToString());
                    }
                }
            }

            if (!SelfCheckFlag)
            {
                SelfCheckFlag = true;
                labelStatus.Text = "检测到总线上有" + DeviceOnlineCount.ToString() + "个设备";
            }
        }

        #endregion

        #region FormEvent

        protected override void OnClosing(CancelEventArgs e)
        {
            
            base.OnClosing(e);
            FileService.SaveUserConfig();
            SqliteUtil.Instance.Dispose();
            ModbusClosingDispose();

        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ChangeGroupBoxContentLocation();
            JudgeIsRegister();
            通信参数ToolStripMenuItem_Click(null, null);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FileService.ReadUserConfig();
            RenewAllDevicesUi();
        }

        #endregion

        #region FormSizeChanged

        private void panelTotal_Resize(object sender, EventArgs e)
        {
            var panel = (Panel)sender;
            panelTop.Height = panelBottom.Height = panel.Height / 2;
        }

        private void panelTop_Resize(object sender, EventArgs e)
        {
            var panel = (Panel)sender;
            panel5.Width = panel6.Width = panel.Width / 3;
        }

        private void panelBottom_Resize(object sender, EventArgs e)
        {
            var panel = (Panel)sender;
            panel4.Width = panel7.Width = panel.Width / 3;
        }

        private void ChangeGroupBoxContentLocation()
        {
            for (int i = 0; i < GroupBoxs.Count; ++i)
            {
                var groupbox = GroupBoxs[i];
                var control = groupbox.Controls[0];
                control.Width = groupbox.Width - 15;
                control.Height = groupbox.Height - 35;
                control.Left = (groupbox.Width - control.Width) / 2;
                control.Top = (groupbox.Height - control.Height) / 2 + 15;
                JudgePanelLabelFontAndSize(i);
            }
        }

        private void JudgePanelLabelFontAndSize(int index)
        {
            var top = 12;
            var leftOne = 0;
            var leftTwo = 0;
            var topOne = 0;
            var topTwo = 0;
            var width = 0;
            var height = 0;
            var splite = 11;
            var control = GroupBoxs[index].Controls[0];
            var panel = control as Panel;
            panel.AutoScroll = false;
            var font = 1f;
            foreach (var con in control.Controls)
            {
                if (con is Label)
                {
                    var label = con as Label;
                    var tag = Convert.ToInt32(label.Tag);
                    if (tag >= 1 && tag <= 8)
                    {
                        if (tag <= 4)
                        {
                            label.Top = top + control.Height * (tag - 1) / splite;
                            label.Left = control.Width / 3;
                        }
                        else
                        {
                            label.Top = top + control.Height * (tag) / splite;
                            label.Left = control.Width / 3;
                        }

                        var _height = control.Height / splite;
                        //修改字体大小会卡
                        foreach (var pt in LabelFontPtAndHeight)
                        {
                            if (_height >= pt.Value)
                                font = pt.Key - 6;
                        }
                        label.Font = new Font("宋体", font);
                    }
                    if (tag == 99)
                    {
                        label.Font = new Font("宋体", font);
                        label.Top = top + control.Height * 9 / splite;
                        label.Left = control.Width / 3;
                        width = label.Width;
                        height = label.Height;
                        leftOne = label.Left;
                        topOne = label.Top;
                    }
                    else if (tag == 100)
                    {
                        label.Font = new Font("宋体", font);
                        label.Top = top + control.Height * 9 / splite;
                        label.Left = control.Width * 2 / 3;
                        leftTwo = label.Left;
                        topTwo = label.Top;
                    }
                }
                if (con is PictureBox)
                {
                    var pic = con as PictureBox;
                    var tag = Convert.ToInt32(pic.Tag);
                    pic.Width = control.Width / 3 - 30;
                    pic.Left = 15;
                    switch (tag)
                    {
                        case 1:
                            pic.Top = top;
                            pic.Height = (int)(control.Height * 3 / splite);
                            break;
                        case 2:
                            pic.Top = (int)(top + control.Height * 3.5 / splite);
                            pic.Height = (int)(control.Height * 3 / splite);
                            break;
                        case 3:
                            pic.Top = (int)(top + control.Height * 7 / splite);
                            pic.Height = (int)(control.Height * 3 / splite);
                            break;
                    }
                }
            }
            switch (index)
            {
                case 0:
                    ovalShape1.Left = leftOne + 3 + width;
                    ovalShape1.Top = topOne + height / 2 - 10;
                    ovalShape2.Left = leftTwo + 3 + width;
                    ovalShape2.Top = topTwo + height / 2 - 10;
                    break;
                case 1:
                    ovalShape4.Left = leftOne + 3 + width;
                    ovalShape4.Top = topOne + height / 2 - 10;
                    ovalShape3.Left = leftTwo + 3 + width;
                    ovalShape3.Top = topTwo + height / 2 - 10;
                    break;
                case 2:
                    ovalShape6.Left = leftOne + 3 + width;
                    ovalShape6.Top = topOne + height / 2 - 10;
                    ovalShape5.Left = leftTwo + 3 + width;
                    ovalShape5.Top = topTwo + height / 2 - 10;
                    break;
                case 3:
                    ovalShape8.Left = leftOne + 3 + width;
                    ovalShape8.Top = topOne + height / 2 - 10;
                    ovalShape7.Left = leftTwo + 3 + width;
                    ovalShape7.Top = topTwo + height / 2 - 10;
                    break;
                case 4:
                    ovalShape10.Left = leftOne + 3 + width;
                    ovalShape10.Top = topOne + height / 2 - 10;
                    ovalShape9.Left = leftTwo + 3 + width;
                    ovalShape9.Top = topTwo + height / 2 - 10;
                    break;
                case 5:
                    ovalShape12.Left = leftOne + 3 + width;
                    ovalShape12.Top = topOne + height / 2 - 10;
                    ovalShape11.Left = leftTwo + 3 + width;
                    ovalShape11.Top = topTwo + height / 2 - 10;
                    break;
            }
            //panel.AutoScroll = true;
        }
        #endregion

        #region Register

        void JudgeIsRegister()
        {
            if (RegisterService.IsRegister() == false)
            {
                var form = new FormRegister();
                if (form.ShowDialog() != DialogResult.OK)
                {
                    Application.Exit();
                    Application.ExitThread();
                }
            }
        }

        #endregion
        
        #region MenuStrip菜单 

        #region 开始

        #region 连接

        private void 连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SelfCheckFlag = false;  //复位自检标志
                DeviceOnlineCount = 0;

                if (SerialPorts[0].IsOpen == true)
                    return;
                //SerialPortInit();
                for (int i = 0; i < 2; ++i)
                {
                    SerialPorts[i].Open();
                    ModbusMasters[i] = ModbusSerialMaster.CreateRtu(SerialPorts[i]);
                    ModbusMasters[i].Transport.Retries = 0;
                    ModbusMasters[i].Transport.ReadTimeout = 300;
                }
                timerGetData.Enabled = true;
                MessageBox.Show("连接成功");
                labelStatus.Text = "连接成功";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("串口打开失败!\r\n可能原因：" + ex.Message);
            }
        }

        private void toolStripButtonConnect_Click(object sender, EventArgs e)
        {
            连接ToolStripMenuItem_Click(null, null);
        }

        #endregion
        #region 断开

        private void 断开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                timerSave.Enabled = false;
                timerGetData.Enabled = false;
                for (int i = 0; i < Device.All.Count; i++)
                {
                    Device.All[i].BatchControllerStatus = false;
                    Device.All[i].FlowMeterStatus = false;
                }
                for (int i = 0; i < 2; ++i)
                {
                    if(ModbusMasters[i] != null)
                        ModbusMasters[i] = null;
                    if (SerialPorts[i] != null)
                    {
                        SerialPorts[i].Close();
                        SerialPorts[i].Dispose();            
                    }
                }
                MessageBox.Show("断开连接");
                labelStatus.Text = "未连接";
                Application.ExitThread();
                Application.Exit();
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

        }

        private void toolStripButtonDisConnect_Click(object sender, EventArgs e)
        {
            断开ToolStripMenuItem_Click(null, null);
        }

        #endregion

        #endregion

        #region 设置

        #region 通信参数

        private void 通信参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSerialPortConfig form = new FormSerialPortConfig();
            DialogResult dialogResult =  form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                SerialPorts = form.SerialPorts;
                连接ToolStripMenuItem_Click(null, null);
            }
            else if (dialogResult == System.Windows.Forms.DialogResult.Abort)
            {
                SerialPorts = form.SerialPorts;
            }

        }

        #endregion
        #region 仪表位号

        private void 仪表位号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormMeterAddressConfig();
            if (form.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0;i<Device.All.Count ; ++i)
                {
                    Device.All[i].BatchControllerAddress = form.SetAddress[2 * i];
                    Device.All[i].Transducer2700Address = form.SetAddress[2 * i + 1];
                }
            }
        }

        #endregion
        #region 保存路径

        private void 保存路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormSavePathConfig();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        #endregion

        #endregion

        #region 查询

        #region 历史数据

        private void 历史数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormQuery().Show();
        }

        private void toolStripButtonQuery_Click(object sender, EventArgs e)
        {
            历史数据ToolStripMenuItem_Click(null, null);
        }

        #endregion
        #region 报告管理

        private void 报告管理ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(ConfigHelper.RepportFileSavePath);
            }
            catch 
            {
                MessageBox.Show("报告的路径不存在");
            }
        }

        private void toolStripButtonPdf_Click(object sender, EventArgs e)
        {
            报告管理ToolStripMenuItem_Click_1(null, null);
        }

        #endregion

        #endregion

        #region 用户

        #region 用户管理

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormUserConfig();
            if (form.ShowDialog() == DialogResult.OK)
            {
                User.SaveAll();
            }
        }

        private void toolStripButtonUser_Click(object sender, EventArgs e)
        {
            用户管理ToolStripMenuItem_Click(null, null);
        }

        #endregion

        #endregion

        #region 帮助

        #region 操作说明


        private void 操作说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormIntroduction().Show();
        }

        #endregion


        #region 版本

        private void 版本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormVersion().Show();
        }

        #endregion

        #endregion

        #region 总览

        private void 总览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsMainFormActive)
            {
                IsMainFormActive = !IsMainFormActive;

                for (int i = 0; i < GroupNum; i++)
                {
                    if (formControls[i] == null)
                        continue;
                    if (formControls[i].IsDisposed)
                        continue;
                    formControls[i].Activate();
                }
            }
            else
            {
                IsMainFormActive = !IsMainFormActive;
            }
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            IsMainFormActive = true;
        }

        #endregion

        #endregion

        #region Timer

        private void timerTime_Tick(object sender, EventArgs e)
        {
            labelTime.Text = "系统时间：" + DateTime.Now.ToString();
            RenewAllDevicesUi();
        }

        #endregion

        #region Device

        private void GroupBoxInit()
        {
            GroupBoxs = new List<GroupBox>()
            {
                groupBox1,groupBox2,groupBox3,groupBox4,groupBox5,groupBox6,
            };
            for (int i = 0; i < GroupBoxs.Count; ++i)
                GroupBoxs[i].Text = Device.All[i].TypeName;
            foreach (var groupBox in GroupBoxs)
            {
                groupBox.Resize += (sender, e) =>
                {
                    ChangeGroupBoxContentLocation();
                };
                groupBox.MouseDown += (sender, e) =>
                {
                    var group = sender as GroupBox;
                    var index = Convert.ToInt32(group.Tag);
                    if (formControls[index] == null)
                        formControls[index] = new FormControl(index, ModbusMasters);
                    if(formControls[index].IsDisposed)
                        formControls[index] = new FormControl(index, ModbusMasters);
                    formControls[index].Show();
                    for (int i = 0; i < GroupNum; i++)
                    {
                        if (formControls[i] == null)
                            continue;
                        if (formControls[i].IsDisposed)
                            continue;
                        formControls[i].Activate();
                    }
                    formControls[index].Activate();
                    IsMainFormActive = false;
                };
                groupBox.Controls[0].MouseDown += (sender, e) =>
                {
                    var panel = sender as Panel;
                    var index = Convert.ToInt32(panel.Tag);
                    if (formControls[index] == null)
                        formControls[index] = new FormControl(index, ModbusMasters);
                    if (formControls[index].IsDisposed)
                        formControls[index] = new FormControl(index, ModbusMasters);
                    formControls[index].Show();
                    for (int i = 0; i < GroupNum; i++)
                    {
                        if (formControls[i] == null)
                            continue;
                        if (formControls[i].IsDisposed)
                            continue;
                        formControls[i].Activate();
                    }
                    formControls[index].Activate();
                    IsMainFormActive = false;
                };
            }
        }

        void RenewDeviceDataUi(int index)
        {
            foreach (var control in GroupBoxs[index].Controls[0].Controls)
            {
                if (control is Label)
                {
                    var label = control as Label;
                    var tag = Convert.ToInt32(label.Tag);
                    switch (tag)
                    {
                        case 1:
                            label.Text = "原 料名 称 " + Device.All[index].MaterialName;
                            break;
                        case 2:
                            label.Text = "加料目标值 " + Device.All[index].Goal.ToString() + " kg";
                            break;
                        case 3:
                            label.Text = "实  际  值 " +  Device.All[index].Real.ToString() + " kg";
                            break;
                        case 4:
                            label.Text = "剩  余  值 " + Device.All[index].Residue.ToString() + " kg";
                            break;
                        case 5:
                            label.Text = "质 量流 量 " + Device.All[index].QualityFlow.ToString() + " kg/h";
                            break;
                        case 6:
                            label.Text = "密      度 " + Device.All[index].Density.ToString() + " kg/m3";
                            break;
                        case 7:
                            label.Text = "温      度 " + Device.All[index].Temperature.ToString() + " ℃";
                            break;
                        case 8:
                            label.Text = "总 累积 量 " + Device.All[index].TotalAmount.ToString() + " kg";
                            break;
                    }
                }
            }
            switch (index)
            {
                case 0:
                    ovalShape1.BackColor = Device.All[index].FlowMeterStatus == true ?
                        Color.Lime : Color.Red;
                    ovalShape2.BackColor = Device.All[index].BatchControllerStatus == true ?
                        Color.Lime : Color.Red;
                    break;
                case 1: 
                    ovalShape4.BackColor = Device.All[index].FlowMeterStatus == true ?
                        Color.Lime : Color.Red;
                    ovalShape3.BackColor = Device.All[index].BatchControllerStatus == true ?
                        Color.Lime : Color.Red;
                    break;
                case 2: 
                    ovalShape6.BackColor = Device.All[index].FlowMeterStatus == true ?
                        Color.Lime : Color.Red;
                    ovalShape5.BackColor = Device.All[index].BatchControllerStatus == true ?
                        Color.Lime : Color.Red;
                    break;
                case 3: 
                    ovalShape8.BackColor = Device.All[index].FlowMeterStatus == true ?
                        Color.Lime : Color.Red;
                    ovalShape7.BackColor = Device.All[index].BatchControllerStatus == true ?
                        Color.Lime : Color.Red;
                    break;
                case 4: 
                    ovalShape10.BackColor = Device.All[index].FlowMeterStatus == true ?
                        Color.Lime : Color.Red;
                    ovalShape9.BackColor = Device.All[index].BatchControllerStatus == true ?
                        Color.Lime : Color.Red;
                    break;
                case 5: 
                    ovalShape12.BackColor = Device.All[index].FlowMeterStatus == true ?
                        Color.Lime : Color.Red;
                    ovalShape11.BackColor = Device.All[index].BatchControllerStatus == true ?
                        Color.Lime : Color.Red;
                    break;
            }
        }

        void RenewAllDevicesUi()
        {
            for (int i = 0; i < Device.Count; ++i)
                RenewDeviceDataUi(i);
        }

        #endregion

        #region DataSaveAndQuery

        private void timerSave_Tick(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
