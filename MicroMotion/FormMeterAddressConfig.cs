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
    public partial class FormMeterAddressConfig : Form
    {

        public byte[] SetAddress;

        public FormMeterAddressConfig()
        {
            InitializeComponent();

            labelTypeName0.Text = Device.All[0].TypeName;
            labelTypeName1.Text = Device.All[1].TypeName;
            labelTypeName2.Text = Device.All[2].TypeName;
            labelTypeName3.Text = Device.All[3].TypeName;
            labelTypeName4.Text = Device.All[4].TypeName;
            labelTypeName5.Text = Device.All[5].TypeName;

            numericUpDown1.Value = Device.All[0].BatchControllerAddress;
            numericUpDown2.Value = Device.All[0].Transducer2700Address;
            numericUpDown3.Value = Device.All[1].BatchControllerAddress;
            numericUpDown4.Value = Device.All[1].Transducer2700Address;
            numericUpDown5.Value = Device.All[2].BatchControllerAddress;
            numericUpDown6.Value = Device.All[2].Transducer2700Address;
            numericUpDown7.Value = Device.All[3].BatchControllerAddress;
            numericUpDown8.Value = Device.All[3].Transducer2700Address;
            numericUpDown9.Value = Device.All[4].BatchControllerAddress;
            numericUpDown10.Value = Device.All[4].Transducer2700Address;
            numericUpDown11.Value = Device.All[5].BatchControllerAddress;
            numericUpDown12.Value = Device.All[5].Transducer2700Address;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SetAddress = new byte[]
            {
                Convert.ToByte(numericUpDown1.Value),
                Convert.ToByte(numericUpDown2.Value),
                Convert.ToByte(numericUpDown3.Value),
                Convert.ToByte(numericUpDown4.Value),
                Convert.ToByte(numericUpDown5.Value),
                Convert.ToByte(numericUpDown6.Value),
                Convert.ToByte(numericUpDown7.Value),
                Convert.ToByte(numericUpDown8.Value),
                Convert.ToByte(numericUpDown9.Value),
                Convert.ToByte(numericUpDown10.Value),
                Convert.ToByte(numericUpDown11.Value),
                Convert.ToByte(numericUpDown12.Value),
            };
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGetBack_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 2;
            numericUpDown3.Value = 3;
            numericUpDown4.Value = 4;
            numericUpDown5.Value = 5;
            numericUpDown6.Value = 6;
            numericUpDown7.Value = 7;
            numericUpDown8.Value = 8;
            numericUpDown9.Value = 9;
            numericUpDown10.Value = 10;
            numericUpDown11.Value = 11;
            numericUpDown12.Value = 12;
        }
    }
}
