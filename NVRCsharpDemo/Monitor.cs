using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DATAREG = NVRCsharpDemo.ConfigurationData.DataReg;
using DATASHEDULE = NVRCsharpDemo.ConfigurationData.DataShedule;
using CHANNEL = NVRCsharpDemo.ConfigurationData.Channel;
using System.Threading;

namespace NVRCsharpDemo
{
    internal class Monitor
    {
        Form mainWindowForm = Application.OpenForms.OfType<MainWindow>().FirstOrDefault();
        DeviceController deviceController;
        MainWindow mainWindowFormDesign;

        List<DATAREG> DataRegList;
        List<DATASHEDULE> DataSheduleList;

        public void TimeMonitor(MainWindow mainWindow)
        {
            mainWindowFormDesign = mainWindow;

            // Запустите таймер в отдельном потоке     
            var timerThread = new Thread(() => ScanTime());
            timerThread.Start();
        }

        private void ScanTime()
        {
            // Читаем данные из файла
            DataRegList = FileOperations.LoadDataReg(); // чтение данных о регике
            DataSheduleList = FileOperations.LoadDataShedule(); // чтение данных расписание  
            setStatusLabel("Статус сервиса: запущен");

            int i = 0;
            while (true)
            {
                //проверить не остановлена ли служба
                if (!MainWindow.getStatusService()) return;

                // Проверьте текущее время каждую минуту 

                foreach (var item in DataSheduleList)
                {

                    DATAREG currentDataReg = DataRegList.FirstOrDefault(x => x.DeviceIP == item.DeviceIP);
                    DATASHEDULE currentDataShedule = item;
                    DateTime now = DateTime.Now;

                    if (now.Hour == uint.Parse(item.startDownloadTime.Split(':')[0]) &&
                         now.Minute == uint.Parse(item.startDownloadTime.Split(':')[1]))
                    {
                        // запустить в отдельном потоке закачку каждого канала
                        deviceController = new DeviceController();
                        deviceController.DownloadIntervalDeviceVideo(currentDataReg, currentDataShedule);

                        // проверить статус закачки
                       // bool status;
                       // do
                       // {
                        //    System.Threading.Thread.Sleep(1000);
                       //     status = deviceController.GetDownloadStatus(); 
                       // } while (!status);
                    }
                }

                // Приостановите поток на одну минуту 
                System.Threading.Thread.Sleep(60000);
            }
        }

        private void setStatusLabel(string text)
        {
            mainWindowForm.Invoke(new Action(() =>
            {
                mainWindowFormDesign.StatusServiceLabel.Text = text;
            }));
        }
        private void Downloader()
        {
            //
        }
    }
}

