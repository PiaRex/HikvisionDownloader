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
        public Timer minuteTimer = new Timer();

        public void TimeMonitor(MainWindow mainWindow)
        {
            mainWindowForm = mainWindow;
            minuteTimer.Start();
            minuteTimer.Interval = 60000;
            minuteTimer.AutoReset = true;
            minuteTimer.Elapsed += ScanTime;

        }

        private void ScanTime(object sender, ElapsedEventArgs e)
        {      
            DataRegList = FileOperations.LoadDataReg(); // чтение данных о регике
            DataSheduleList = FileOperations.LoadDataShedule(); // чтение данных расписание  
            int i = 0;
                //проверить не остановлена ли служба
            if (!MainWindow.getStatusService()) return;
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
        }

    }
}

