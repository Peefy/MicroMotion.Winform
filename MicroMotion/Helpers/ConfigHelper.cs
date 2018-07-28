using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace MicroMotion.Helpers
{
    public static class ConfigHelper
    {
        public static string UserConfigFileName = "\\user.uni";

        public static string RepportFileSavePath = Path.Combine(Application.StartupPath,"Export");

    }
}
