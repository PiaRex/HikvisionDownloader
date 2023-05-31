using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;  // требуется NuGet-пакет Newtonsoft.Json
using System.IO;
using static NVRCsharpDemo.MainWindow;

namespace NVRCsharpDemo
{
    public static class FileOperations
    {
        public static List<DataReg> LoadDataReg() // чтение данных о регике
        {
            string json;
            // проверка, есть ли файл
            if (File.Exists("DataReg.json"))
            {
                // загрузка массива объектов из файла
                json = File.ReadAllText("DataReg.json");
                List<DataReg> readDataRegList =
                    JsonConvert.DeserializeObject<List<DataReg>>(json);
                return readDataRegList;
            }
            return new List<DataReg>();
        }

        public static void SaveDataReg(List<DataReg> saveDataList) // запись данных о регике
        {
            string json = JsonConvert.SerializeObject(saveDataList, Formatting.Indented);
            File.WriteAllText("DataReg.json", json);
        }

        public static List<DataShedule> LoadDataShedule() // чтение данных расписание
        {
            string json;
            if (File.Exists("DataShedule.json"))
            {
                json = File.ReadAllText("DataShedule.json");
                List<DataShedule> readDataSheduleList =
                    JsonConvert.DeserializeObject<List<DataShedule>>(json);
                return readDataSheduleList;
            }
            return new List<DataShedule>();
        }

        public static void SaveDataSchedule(List<DataShedule> saveDataSheduleList) // сохранение данных расписание
        {
            string json = JsonConvert.SerializeObject(saveDataSheduleList);
            File.WriteAllText("DataShedule", json);
        }

        public static void DeleteDevice(string deviceIP)
        {
            string json = File.ReadAllText("DataReg.json");
            List<DataReg> DataRegList =
                JsonConvert.DeserializeObject<List<DataReg>>(json);
            DataRegList.Remove(DataRegList.FirstOrDefault(x => x.DeviceIP == deviceIP));
            json = JsonConvert.SerializeObject(DataRegList, Formatting.Indented);
            File.WriteAllText("DataReg.json", json);
        }

        public static DataReg GetDeviceReg(string deviceIP) 
        { 
            string json = File.ReadAllText("DataReg.json");
            List<DataReg> DataRegList =
                JsonConvert.DeserializeObject<List<DataReg>>(json);
            return DataRegList.FirstOrDefault(x => x.DeviceIP == deviceIP);
        }
    }
}
