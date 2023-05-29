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
        public static List<SaveData> LoadData()
        {
            string json;
            // проверка, есть ли файл
            if (File.Exists("data.json"))
            {
                // загрузка массива объектов из файла
                json = File.ReadAllText("data.json");
                List<SaveData> saveDataList =
                    JsonConvert.DeserializeObject<List<SaveData>>(json);
                return saveDataList;
            }
            return new List<SaveData>();
        }

        public static void SaveData(List<SaveData> saveDataList)
        {
            string json = JsonConvert.SerializeObject(saveDataList, Formatting.Indented);
            File.WriteAllText("data.json", json);
        }
    }
}
