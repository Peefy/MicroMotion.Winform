using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

using MicroMotion.Services;

namespace MicroMotion.Builders
{
    public class SerialPortBuilder : IDisposable
    {

        IFileSerivce fileSerivce;

        public const int DefaultBaudRateIndex = 3;
        public const int DefaultStopBitsIndex = 0;
        public const int DefaultDataBitsIndex = 1;
        public const int DefaultParityIndex = 0;

        public int BaudRateIndex = 3;
        public int StopBitsIndex = 0;
        public int DataBitsIndex = 1;
        public int ParityIndex = 0;

        public string PortName = "COM*";

        public int BaudRateFromIndex
        {
            get
            {
                switch (BaudRateIndex)
                {
                    case 0: return 1200;
                    case 1: return 2400;
                    case 2: return 4800;
                    case 3: return 9600;
                    case 4: return 19200;
                    case 5: return 38400;
                    default: return 9600;
                }
            }
        }

        public StopBits StopBitsFromIndex
        {
            get
            {
                switch (StopBitsIndex)
                {
                    case 0: return StopBits.One;
                    case 1: return StopBits.Two;
                    case 2: return StopBits.OnePointFive;
                    default: return StopBits.One;
                }
            }
        }

        public int DataBitsFromIndex
        {
            get
            {
                switch (DataBitsIndex)
                {
                    case 0: return 6;
                    case 1: return 7;
                    case 2: return 8;
                    case 3: return 9;
                    default: return 8;
                }
            }
        }

        public Parity ParityFromIndex
        {
            get
            {
                switch (ParityIndex)
                {
                    case 0: return Parity.None;
                    case 1: return Parity.Even;
                    case 2: return Parity.Odd;
                    default: return Parity.Even;
                }
            }
        }

        public SerialPort Default
        {
            get
            {
                return new SerialPort()
                {
                    BaudRate = 9600,
                    Parity = Parity.None,
                    DataBits = 8,
                    StopBits = StopBits.One,
                };
            }
        }

        public SerialPort FormIndex
        {
            get 
            {
                return new SerialPort()
                {
                    BaudRate = BaudRateFromIndex,
                    StopBits = StopBitsFromIndex,
                    Parity = ParityFromIndex,
                    PortName = PortName,
                };
            }
        }

        public SerialPort[] FromFiles()
        {
            fileSerivce = new FileService();
            int[] parityIndexs; int[] stopBitsIndexs; int[] baudRateIndexs;
            if (fileSerivce.ReadSerialPortConfig(out parityIndexs, out stopBitsIndexs, out baudRateIndexs) == true)
            {
                return new SerialPort[]
                {
                    Default,
                    Default,
                };
            }
            return new SerialPort[]
            {
                Default,
                Default,
            };
        }

        public void FromFiles(out int[] parityIndexs, out int[] stopBitsIndexs, out int[] baudRateIndexs)
        {
            fileSerivce = new FileService();
            fileSerivce.ReadSerialPortConfig(out parityIndexs, out stopBitsIndexs, out baudRateIndexs);
            
        }

        public bool SaveToFiles(int[] parityIndexs, int[] stopBitsIndexs, int[] baudRateIndexs)
        {
            fileSerivce = new FileService();
            return fileSerivce.SaveSerialPortConfig(parityIndexs, stopBitsIndexs, baudRateIndexs);
        }

        public SerialPortBuilder()
        {

        }

        public void Dispose()
        {
            if (fileSerivce != null)
            {
                fileSerivce = null;
            }
        }
    }
}
