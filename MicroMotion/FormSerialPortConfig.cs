using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MicroMotion.Models;
using MicroMotion.Builders;
using MicroMotion.Services;


namespace MicroMotion
{
    public partial class FormSerialPortConfig : Form
    {

        int[] parityIndexs;
        int[] stopBitsindexs;
        int[] baudRateIndexs;
        string[] portNames = new string[]{ "COM*","COM*"};

        void SetGroupBoxRadioSelectIndex(GroupBox groupBox,int index)
        {
            foreach (var control in groupBox.Controls)
            {
                var radio = control as RadioButton;
                var _index = Convert.ToInt32(radio.Tag);
                if (_index == index)
                    radio.Checked = true;
            }
        }

        int GetGroupBoxRadioSelectIndex(GroupBox groupBox)
        {
            foreach (var control in groupBox.Controls)
            {
                var radio = control as RadioButton;
                if (radio.Checked == true)
                {
                    var index = Convert.ToInt32(radio.Tag);
                    return index;
                }
            }
            return 0;
        }

        public FormSerialPortConfig()
        {
            InitializeComponent();
            this.labelHelp.Text = string.Format("总线一：{0}、{1}、{2}、{3}",
                    Device.All[2].TypeName, Device.All[3].TypeName,
                    Device.All[4].TypeName, Device.All[5].TypeName);
            comcmb.Text = "COM*";
            var serialPortBuilder = new SerialPortBuilder();
            serialPortBuilder.FromFiles(out parityIndexs, out stopBitsindexs, out baudRateIndexs);
            SetSerialPortsConfigToGroupBox(0);
        }

        private void FormSerialPortConfig_Load(object sender, EventArgs e)
        {
            LoadSerialPortPara();
            SetGroupBoxRadioSelectIndex(groupBoxParity, parityIndexs[0]);
            SetGroupBoxRadioSelectIndex(groupBoxStopBits, stopBitsindexs[0]);
            SetGroupBoxRadioSelectIndex(groupBoxBaudRate, baudRateIndexs[0]);
            comcmb.Text = portNames[0];


        }
       //private void 

        protected override void OnClosing(CancelEventArgs e)
        {
            var serialPortBuilder = new SerialPortBuilder();
            listBoxSerialPortConfig_SelectedIndexChanged(listBoxSerialPortConfig, null);
            SelectedUiToIndexs();
            serialPortBuilder.SaveToFiles(parityIndexs, stopBitsindexs, baudRateIndexs);
            base.OnClosing(e);
        }

        void SetSerialPortsConfigToGroupBox(int index)
        {
            listBoxSerialPortConfig.SelectedIndex = index;
            listBoxSerialPortConfig_SelectedIndexChanged(listBoxSerialPortConfig, null);
            SetGroupBoxRadioSelectIndex(groupBoxParity, parityIndexs[index]);
            SetGroupBoxRadioSelectIndex(groupBoxStopBits, stopBitsindexs[index]);
            SetGroupBoxRadioSelectIndex(groupBoxBaudRate, baudRateIndexs[index]);

            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comcmb.Items.Clear();
            comcmb.Items.AddRange(ports);
            comcmb.SelectedIndex = comcmb.Items.Count > 0 ? 0 : -1;
            comcmb.SelectedIndex = comcmb.Items.Count > 1 ? index : -1;
            if (comcmb.Items.Count > 1)
            {
                portNames[0] = comcmb.Items[0].ToString();
                portNames[1] = comcmb.Items[1].ToString();
            }

        }

        int lastIndex;
        private void listBoxSerialPortConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listbox = sender as ListBox;
            var index = listbox.SelectedIndex;
            if (lastIndex == index)
                return;
            parityIndexs[1 - index] = GetGroupBoxRadioSelectIndex(groupBoxParity);
            stopBitsindexs[1 - index] = GetGroupBoxRadioSelectIndex(groupBoxStopBits);
            baudRateIndexs[1 - index] = GetGroupBoxRadioSelectIndex(groupBoxBaudRate);
            portNames[1 - index] = comcmb.Text == "" ? "COM*" : comcmb.Text;
            SetGroupBoxRadioSelectIndex(groupBoxParity, parityIndexs[index]);
            SetGroupBoxRadioSelectIndex(groupBoxStopBits, stopBitsindexs[index]);
            SetGroupBoxRadioSelectIndex(groupBoxBaudRate, baudRateIndexs[index]);

            comcmb.Text = portNames[index];

            lastIndex = index;
            if (index == 0)
                this.labelHelp.Text = string.Format("总线一：{0}、{1}、{2}、{3}",
                    Device.All[2].TypeName, Device.All[3].TypeName,
                    Device.All[4].TypeName, Device.All[5].TypeName);
            else if (index == 1)
                this.labelHelp.Text = string.Format("总线二：{0}、{1}",
                    Device.All[0].TypeName,Device.All[1].TypeName);
        }

        public SerialPort[] SerialPorts
        {
            get
            {
                return new SerialPort[]
                {
                    new SerialPortBuilder()
                    {
                        ParityIndex = parityIndexs[0],
                        StopBitsIndex = stopBitsindexs[0],
                        BaudRateIndex = baudRateIndexs[0],
                        PortName = portNames[0] == "" ? "COM*" : portNames[0],
                    }.FormIndex,
                    new SerialPortBuilder()
                    {
                        ParityIndex = parityIndexs[1],
                        StopBitsIndex = stopBitsindexs[1],
                        BaudRateIndex = baudRateIndexs[1],
                        PortName = portNames[1] == "" ? "COM*" : portNames[1],
                    }.FormIndex,
                };
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            SetSerialPortsConfigToGroupBox(listBoxSerialPortConfig.SelectedIndex);
        }

        void SelectedUiToIndexs()
        {
            var index = listBoxSerialPortConfig.SelectedIndex;
            parityIndexs[index] = GetGroupBoxRadioSelectIndex(groupBoxParity);
            stopBitsindexs[index] = GetGroupBoxRadioSelectIndex(groupBoxStopBits);
            baudRateIndexs[index] = GetGroupBoxRadioSelectIndex(groupBoxBaudRate);
            portNames[index] = comcmb.Text == "" ? "COM*" : comcmb.Text;
        }

        private void FormSerialPortConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSerialPortPara();
        }
        private void SaveSerialPortPara()
        {
            try
            {
                //string pathAndname = 
                FileStream savefile = new FileStream("SerialPara.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(savefile);


                sw.WriteLine(portNames[0]);
                sw.WriteLine(parityIndexs[0]);
                sw.WriteLine(stopBitsindexs[0]);
                sw.WriteLine(baudRateIndexs[0]);

                sw.WriteLine(portNames[1]);
                sw.WriteLine(parityIndexs[1]);
                sw.WriteLine(stopBitsindexs[1]);
                sw.WriteLine(baudRateIndexs[1]);

                sw.Close();
                savefile.Close();
            }
            catch 
            {
                //MessageBox.Show(ex.ToString());
            }

        }
        private void LoadSerialPortPara()
        {
            try
            {
                FileStream loadfile = new FileStream("SerialPara.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(loadfile);
                portNames[0] = sr.ReadLine();
                parityIndexs[0] = Convert.ToInt32(sr.ReadLine());
                stopBitsindexs[0] = Convert.ToInt32(sr.ReadLine());
                baudRateIndexs[0] = Convert.ToInt32(sr.ReadLine());

                portNames[1] = sr.ReadLine();
                parityIndexs[1] = Convert.ToInt32(sr.ReadLine());
                stopBitsindexs[1] = Convert.ToInt32(sr.ReadLine());
                baudRateIndexs[1] = Convert.ToInt32(sr.ReadLine());

                sr.Close();
                loadfile.Close();
            }
            catch (EntryPointNotFoundException) { }
            catch (Exception) 
            { 
                //MessageBox.Show(ex.ToString()); 
            }

        }


    }
}
