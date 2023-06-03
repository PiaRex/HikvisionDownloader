using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DATAREG = NVRCsharpDemo.ConfigurationData.DataReg;
using DATASHEDULE = NVRCsharpDemo.ConfigurationData.DataShedule;
using CHANNEL = NVRCsharpDemo.ConfigurationData.Channel;

namespace NVRCsharpDemo
{
    internal class Helpers
    {
        public static int GetHourCountDownload(DATASHEDULE shedule)
        {
            int startTimeHour = int.Parse(shedule.downloadStartInterval.Split(':')[0]);
            int endTimeHour = int.Parse(shedule.downloadEndInterval.Split(':')[0]);
            DateTime startTimeDate = DateTime.Today.AddHours(startTimeHour); ; // время старта
            DateTime EndTimeDate = DateTime.Today.AddHours(endTimeHour); // время финиша

            if (EndTimeDate < startTimeDate) // если второе время меньше первого
            {
                EndTimeDate = EndTimeDate.AddDays(1); // прибавляем день ко второму времени
            }

            TimeSpan timeDifference = EndTimeDate - startTimeDate; // вычисление разницы времени

            int hoursDifference = (int)Math.Round(timeDifference.TotalHours); // перевод разницы времени в количество часов

            return hoursDifference; // вывод результата
        }
    }
}
