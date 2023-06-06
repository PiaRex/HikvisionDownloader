using System;
using DATASHEDULE = NVRCsharpDemo.ConfigurationData.DataShedule;

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

        public static int GetDayOffset(DATASHEDULE shedule)
        {
            int startTimeHour = int.Parse(shedule.downloadStartInterval.Split(':')[0]);
            int endTimeHour = int.Parse(shedule.downloadEndInterval.Split(':')[0]);
            int endTimeMinute = int.Parse(shedule.downloadStartInterval.Split(':')[1]);
            int downloadTimeHour = int.Parse(shedule.startDownloadTime.Split(':')[0]);
            int downloadTimeMinute = int.Parse(shedule.startDownloadTime.Split(':')[1]);

            if (downloadTimeHour>endTimeHour || (downloadTimeHour == endTimeHour & downloadTimeMinute > endTimeMinute)) return 0; 
            if (endTimeHour>startTimeHour) return -1;
            else return -2;

        }
    }
}
