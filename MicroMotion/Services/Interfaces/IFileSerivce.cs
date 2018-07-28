using System;
using System.Collections.Generic;
using System.Text;

namespace MicroMotion.Services
{
    interface IFileSerivce
    {
        bool ReadSerialPortConfig(out int[] parityIndex,out int[] stopBitsIndex,out int[] baudRateIndex);
        bool SaveSerialPortConfig(int[] parityIndex, int[] stopBitsIndex, int[] baudRateIndex);

        bool SaveUserConfig();
        bool ReadUserConfig();

    }
}
