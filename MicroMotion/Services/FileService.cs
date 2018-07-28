using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using MicroMotion.Services;
using MicroMotion.Helpers;
using MicroMotion.Models;
using MicroMotion.Builders;

namespace MicroMotion.Services
{
    public class FileService : IFileSerivce
    {
        static string savePath = Application.StartupPath;
        static string serialPortConfigFileName = "\\serport.uni";

        public bool ReadSerialPortConfig(out int[] parityIndex, out int[] stopBitsIndex, out int[] baudRateIndex)
        {
            try
            {
                var _par = new int[2];
                var _sto = new int[2];
                var _bau = new int[2];
                if (Directory.Exists(savePath) == false) Directory.CreateDirectory(savePath);
                FileStream fs = new FileStream(savePath + serialPortConfigFileName, FileMode.Open);
                using (BinaryReader r = new BinaryReader(fs))
                {
                    for (int i = 0; i < 2; ++i)
                    {
                        _par[i] = r.ReadInt32();
                        _sto[i] = r.ReadInt32();
                        _bau[i] = r.ReadInt32();
                    }

                }
                parityIndex = _par;
                stopBitsIndex = _sto;
                baudRateIndex = _bau;
                return true;
            }
            catch
            {
                parityIndex = new int[] { SerialPortBuilder.DefaultParityIndex, SerialPortBuilder.DefaultParityIndex };
                stopBitsIndex = new int[] { SerialPortBuilder.DefaultStopBitsIndex, SerialPortBuilder.DefaultStopBitsIndex };
                baudRateIndex = new int[] { SerialPortBuilder.DefaultBaudRateIndex, SerialPortBuilder.DefaultBaudRateIndex };
                return false;
            }
        }

        public bool SaveSerialPortConfig(int[] parityIndex, int[] stopBitsIndex, int[] baudRateIndex)
        {
            try
            {
                if (Directory.Exists(savePath) == false) Directory.CreateDirectory(savePath);
                FileStream fsn = new FileStream(savePath + serialPortConfigFileName, FileMode.Create);
                BinaryWriter w = new BinaryWriter(fsn);
                for (int i = 0; i < parityIndex.Length; ++i)
                {
                    w.Write(parityIndex[i]);
                    w.Write(stopBitsIndex[i]);
                    w.Write(baudRateIndex[i]);
                }
                w.Flush();
                w.Close();
                fsn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ReadUserConfig()
        {
            try
            {
                if (Directory.Exists(savePath) == false) Directory.CreateDirectory(savePath);
                FileStream fs = new FileStream(savePath + ConfigHelper.UserConfigFileName, FileMode.Open);
                using (BinaryReader r = new BinaryReader(fs))
                {
                    for (int i = 0; i < Device.All.Count; ++i)
                    {
                        Device.All[i].BatchControllerAddress = r.ReadByte();
                        Device.All[i].Transducer2700Address = r.ReadByte();
                        Device.All[i].Goal = r.ReadSingle();
                        Device.All[i].MaterialName = r.ReadString();
                        Device.All[i].MaterialNameListSave = r.ReadString();
                        Device.All[i].GeneratePdfCount = r.ReadInt32();
                    }

                    ConfigHelper.RepportFileSavePath = r.ReadString();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveUserConfig()
        {
            try
            {
                if (Directory.Exists(savePath) == false) Directory.CreateDirectory(savePath);
                FileStream fsn = new FileStream(savePath + ConfigHelper.UserConfigFileName, FileMode.Create);
                BinaryWriter w = new BinaryWriter(fsn);
                for (int i = 0; i < Device.All.Count; ++i)
                {
                    w.Write(Device.All[i].BatchControllerAddress);
                    w.Write(Device.All[i].Transducer2700Address);
                    w.Write(Device.All[i].Goal);
                    w.Write(Device.All[i].MaterialName);
                    w.Write(Device.All[i].MaterialNameListSave);
                    w.Write(Device.All[i].GeneratePdfCount);
                }

                w.Write(ConfigHelper.RepportFileSavePath);

                w.Flush();
                w.Close();
                fsn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
