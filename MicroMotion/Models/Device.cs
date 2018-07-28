using System;
using System.Collections.Generic;
using System.Text;

namespace MicroMotion.Models
{
    public class Device
    {
        public static List<Device> All = new List<Device>
        {
            new Device()
            {
                TypeName = "F-1409",
                BatchControllerAddress = 1,
                Transducer2700Address = 2,
            },
            new Device()
            {
                TypeName = "OFFLINE",
                BatchControllerAddress = 3,
                Transducer2700Address = 4,
            },
            new Device()
            {
                TypeName = "F-1404",
                BatchControllerAddress = 5,
                Transducer2700Address = 6,
            },
            new Device()
            {
                TypeName = "F-1405",
                BatchControllerAddress = 7,
                Transducer2700Address = 8,
            },
            new Device()
            {
                TypeName = "F-1605",
                BatchControllerAddress = 9,
                Transducer2700Address = 10,
            },
            new Device()
            {
                TypeName = "F-6#",
                BatchControllerAddress = 11,
                Transducer2700Address = 12,
            },
        };

        public static int Count
        {
            get { return Device.All.Count; }
        }

        public string TypeName { get; set; }

        public string MaterialName { get; set; }
        public float Goal { get; set; }
        public float Real { get; set; }
        public float Residue
        {
            get 
            {
                var data = Goal - Real;
                if (data < 0 && data > -5)
                    data = 0;
                return data;
            }
        }
        public float QualityFlow { get;set;}
        public float Density { get; set; }
        public float Temperature { get; set; }
        public float TotalAmount { get; set; }

        public bool FlowMeterStatus{ get; set; }
        public bool BatchControllerStatus { get; set; }

        public int DO1Code { get; set; }

        public byte BatchControllerAddress { get; set; }
        public byte Transducer2700Address { get; set; }

        public bool IsStart { get; set; }
        public bool IsPause { get; set; }
        public bool IsEnd { get; set; }
        public bool IsAddingMaterial
        {
            get 
            {
                if (IsStart == false && IsPause == true)
                    return false;
                return (QualityFlow > 0) && (DO1Code == 1);
            }
        }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 自检结果，是否连接
        /// 若未自检时未连接，循环读取时跳过该设备。
        /// </summary>
        public bool IsConnect = false;

        public List<string> MaterialNameList { get; set; }
        public string MaterialNameListSave
        {
            get 
            {
                string str = "";
                foreach (var s in MaterialNameList)
                {
                    str += (s + "|");
                }
                return str;
            }
            set
            {
                var str = value;
                var strs = str.Split('|');
                MaterialNameList.Clear();
                var count = strs.Length - 1;
                for (int i = 0; i < count; ++i)
                    MaterialNameList.Add(strs[i]);
            }
        }

        public int GeneratePdfCount { get; set; }

        public bool IsShowControlForm { get; set; }

        public Device()
        {
            MaterialNameList = new List<string>();
            StartTime = System.DateTime.Now;
            EndTime = System.DateTime.Now;
            GeneratePdfCount = 0;
            IsStart = false;
            TypeName = "AI";
            MaterialName = "";
        }

    }
}
