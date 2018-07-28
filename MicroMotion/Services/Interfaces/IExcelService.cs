using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MicroMotion.Services
{
    interface IExcelService
    {
        void Export(SaveFileDialog saveFileDialog);
        void Export(string path);
    }
}
