using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DATAREG = NVRCsharpDemo.ConfigurationData.DataReg;
using DATASHEDULE = NVRCsharpDemo.ConfigurationData.DataShedule;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace NVRCsharpDemo
{
    internal class Monitor
    {
        DeviceController deviceController;
        MainWindow mainWindowForm;

        List<DATAREG> DataRegList;
        List<DATASHEDULE> DataSheduleList;

        public void TimeMonitor(MainWindow mainWindow)
        {
            mainWindowForm = mainWindow;

            // Запустите таймер в отдельном потоке     
           // var timerThread = new Thread(() => ScanTime());
           // timerThread.Start();
            Timer minuteTimer = new Timer();
            minuteTimer.Start();
            minuteTimer.Interval = 60000;
            minuteTimer.AutoReset = true;
            minuteTimer.Elapsed += ScanTime;
        }

        private void ScanTime(object sender, ElapsedEventArgs e)
        {
            // Читаем данные из файла
            DataRegList = FileOperations.LoadDataReg(); // чтение данных о регике
            DataSheduleList = FileOperations.LoadDataShedule(); // чтение данных расписание  
            //setStatusLabel("Статус сервиса: запущен");

            int i = 0;
            while (true)
            {
                //проверить не остановлена ли служба
                if (!MainWindow.getStatusService()) return;

                // Проверьте текущее время каждую минуту 

                foreach (var item in DataSheduleList)
                {


                    DateTime now = DateTime.Now;

                    if (now.Hour == uint.Parse(item.startDownloadTime.Split(':')[0]) &&
                         now.Minute == uint.Parse(item.startDownloadTime.Split(':')[1]))
                    {
                        // запустить в отдельном потоке закачку каждого канала
                        DATAREG currentDataReg = DataRegList.FirstOrDefault(x => x.DeviceIP == item.DeviceIP);
                        DATASHEDULE currentDataShedule = item;
                        deviceController = new DeviceController();
                        var downloadThread = new Thread(() => deviceController.DownloadIntervalDeviceVideo(currentDataReg, currentDataShedule, mainWindowForm));
                        downloadThread.Start();
                    }
                }

                // Приостановите поток на одну минуту 
                System.Threading.Thread.Sleep(61000);
            }
        }
    }
}

