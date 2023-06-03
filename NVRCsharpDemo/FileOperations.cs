using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;  // требуется NuGet-пакет Newtonsoft.Json
using System.IO;
using static NVRCsharpDemo.MainWindow;
using DATAREG = NVRCsharpDemo.ConfigurationData.DataReg;
using DATASHEDULE = NVRCsharpDemo.ConfigurationData.DataShedule;
using DATALOG = NVRCsharpDemo.ConfigurationData.LogData;
using System.Dynamic;

namespace NVRCsharpDemo
{
    public static class FileOperations
    {
        public static List<DATAREG> LoadDataReg() // чтение данных о регике
        {
            string json;
            // проверка, есть ли файл
            if (File.Exists("DataReg.json"))
            {
                // загрузка массива объектов из файла
                json = File.ReadAllText("DataReg.json");
                List<DATAREG> readDataRegList =
                    JsonConvert.DeserializeObject<List<DATAREG>>(json);
                return readDataRegList;
            }
            return new List<DATAREG>();
        }

        public static void SaveDataReg(List<DATAREG> saveDataList) // запись данных о регике
        {
            string json = JsonConvert.SerializeObject(saveDataList, Formatting.Indented);
            File.WriteAllText("DataReg.json", json);
        }

        public static List<DATASHEDULE> LoadDataShedule() // чтение данных расписание
        {
            string json;
            if (File.Exists("DataShedule.json"))
            {
                json = File.ReadAllText("DataShedule.json");
                List<DATASHEDULE> readDataSheduleList =
                    JsonConvert.DeserializeObject<List<DATASHEDULE>>(json);
                return readDataSheduleList;
            }
            return new List<DATASHEDULE>();
        }

        public static void SaveDataSchedule(List<DATASHEDULE> saveDataSheduleList) // сохранение данных расписание
        {
            int i = 0;
            saveDataSheduleList.ForEach(s => { s.ID = i++; });
            string json = JsonConvert.SerializeObject(saveDataSheduleList, Formatting.Indented);
            File.WriteAllText("DataShedule.json", json);
        }

        public static void DeleteDevice(string deviceIP)
        {
            string json = File.ReadAllText("DataReg.json");
            List<DATAREG> DataRegList =
                JsonConvert.DeserializeObject<List<DATAREG>>(json);
            DataRegList.Remove(DataRegList.FirstOrDefault(x => x.DeviceIP == deviceIP));
            json = JsonConvert.SerializeObject(DataRegList, Formatting.Indented);
            File.WriteAllText("DataReg.json", json);
        }

        public static void DeleteShedule(string sheduleID)
        {
            string json = File.ReadAllText("DataShedule.json");
            List<DATASHEDULE> DataSheduleList =
                JsonConvert.DeserializeObject<List<DATASHEDULE>>(json);
            DataSheduleList.Remove(DataSheduleList.FirstOrDefault(x => x.ID.ToString() == sheduleID));
            int i = 0;
            DataSheduleList.ForEach(s => { s.ID = i++; });
            json = JsonConvert.SerializeObject(DataSheduleList, Formatting.Indented);
            File.WriteAllText("DataShedule.json", json);
        }

        public static DATAREG GetDeviceReg(string deviceIP)
        {
            string json = File.ReadAllText("DataReg.json");
            List<DATAREG> DataRegList =
                JsonConvert.DeserializeObject<List<DATAREG>>(json);
            return DataRegList.FirstOrDefault(x => x.DeviceIP == deviceIP);
        }

        public static void CreateDeviceFolder(string DeviceName)
        {
            if (!Directory.Exists(DeviceName))
            {
                string folderPath = "C:\\";
                Directory.CreateDirectory(folderPath + DeviceName);
            }
        }
        public static void CreateChannelFolder(string Channel, string DeviceName)
        {
            string folderPath = "C:\\" + DeviceName + "\\";
            if (!Directory.Exists(Channel))
            {
                Directory.CreateDirectory(folderPath + Channel);
            }
        }

        public static void SetSheduleStatus(int ID, string status)
        {
            string json = File.ReadAllText("DataShedule.json");
            List<DATASHEDULE> DataSheduleList =
                JsonConvert.DeserializeObject<List<DATASHEDULE>>(json);

            DataSheduleList.FirstOrDefault(x => x.ID == ID).status = status;

            json = JsonConvert.SerializeObject(DataSheduleList, Formatting.Indented);
            File.WriteAllText("DataShedule.json", json);
        }


        public static void AddLog(string location, string message)
        {
            DateTime now = DateTime.Now;

            string filePath = @"Log.txt";

            string logEntry = $"[{now.ToString()}] {location}: {message}{Environment.NewLine}";

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.Write(logEntry);
            }

        }




    }
}
