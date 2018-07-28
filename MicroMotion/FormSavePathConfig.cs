using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MicroMotion.Helpers;

namespace MicroMotion
{
    public partial class FormSavePathConfig : Form
    {
        public FormSavePathConfig()
        {
            InitializeComponent();
            textBoxSavePath.Text = ConfigHelper.RepportFileSavePath;
        }

        private void btnChangePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog.SelectedPath;

                textBoxSavePath.Text = path;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ConfigHelper.RepportFileSavePath = textBoxSavePath.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
