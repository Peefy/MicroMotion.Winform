using System;
using System.Collections.Generic;
using System.Text;

namespace MicroMotion.Services
{
    interface IPdfService
    {
        bool ExportDeviceRepport(int index, string savePath);
    }
}
