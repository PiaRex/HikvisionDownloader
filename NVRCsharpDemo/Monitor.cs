using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NVRCsharpDemo.MainWindow;

namespace NVRCsharpDemo
{
    internal class Monitor
    {

        public static void TimeMonitor(Label StatusServiceLabel)
        {
            // Запустите таймер в отдельном потоке 
            var timerThread = new System.Threading.Thread(() => ScanTime(StatusServiceLabel));
            timerThread.Start();
            StatusServiceLabel.Text = "Таймер запущен";
        }

        private static void ScanTime(Label StatusServiceLabel)
        {
            // Читаем данные из файла
            List<DataReg> DataRegList = FileOperations.LoadDataReg(); // чтение данных о регике
            List<DataShedule> DataSheduleList = FileOperations.LoadDataShedule(); // чтение данных расписание  

            int i = 0;
            while (true)
            {
                //проверить не остановлена ли служба
                if (!MainWindow.getStatusService()) return;

                // Проверьте текущее время каждую минуту 

                foreach (var item in DataSheduleList)
                {

                    DataReg currentDataReg = DataRegList.FirstOrDefault(x => x.DeviceIP == item.DeviceIP);
                    DateTime downloadStartTime = item.downloadStartInterval;
                    DateTime now = DateTime.Now;

                    if (now.Hour == downloadStartTime.Hour && now.Minute == downloadStartTime.Minute)
                    {
                        // запустить в отдельном потоке закачку каждого канала
                    }
                }

                // todo Изменить StatusServiceLabel на MainWindow
                StatusServiceLabel.Invoke((MethodInvoker)(() => StatusServiceLabel.Text = "сервер запущен: " + " итерация: " + i++));
                // Приостановите поток на одну минуту 
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void Downloader()
        {
            //
        }
    }
}

