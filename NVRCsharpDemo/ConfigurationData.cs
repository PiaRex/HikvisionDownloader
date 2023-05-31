using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVRCsharpDemo
{
    public static class ConfigurationData
    {
        public class DataReg // данные регистратора
        {
            public string DeviceName { get; set; }
            public string DeviceIP { get; set; }
            public string DevicePort { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class DataShedule // расписание на скачку
        {
            public int ID { get; set; }
            public string DeviceIP { get; set; }
            public string startDownloadTime { get; set; }
            public int channelNum { get; set; }
            public string downloadStartInterval { get; set; }
            public string downloadEndInterval { get; set; }

        }
        public class Channel // каналы регистратора
        {
            public int ChannelNum { get; set; }
            public byte IPID { get; set; }
        }
    }
}
