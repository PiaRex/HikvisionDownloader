
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
            public string triesCount { get; set; }
            public string status { get; set; }

        }
        public class Channel // каналы регистратора
        {
            public int ChannelNum { get; set; }
            public byte IPID { get; set; }
        }
        public class DownloadingID 
        {
            public int DownloadHandle { get; set; }
            public int ID { get; set; }
            public bool isDownloadStopped { get; set; }
        }
        public class LogData
        {
            public string date { get; set; }
            public string location { get; set; }
            public string message { get; set; }
        }

        public class EmailData
        {
            public string smtpServer { get; set; }
            public string smtpPort { get; set; }
            public string senderEmail { get; set; }
            public string senderPassword { get; set; }
            public string receiverEmail { get; set; }
            public string lastEmailStatus { get; set; }
        }

        public delegate void StopDownloadCallback(string sheduleID);

    }
}
