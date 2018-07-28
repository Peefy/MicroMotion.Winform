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
    public partial class FormVersion : Form
    {
        public FormVersion()
        {
            InitializeComponent();
            labelVersion.Text = AppHelper.Version;
        }

        #region DragMove

        Point mPoint = new Point();

        private void FormLogin_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                var nowPosition = MousePosition;
                nowPosition.Offset(-mPoint.X, -mPoint.Y);
                Location = nowPosition;
            }
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        #endregion

        private void btnok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
