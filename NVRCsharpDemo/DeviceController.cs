using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVRCsharpDemo
{
    public class DeviceController
    {
        private string str;
        private Int32 m_lDownHandle = -1;
        private Int32 m_lUserID = -1;
        private string str1;
        private uint iLastErr = 0;
        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        public void DownloadDeviceVideo(string IP, string Port, string UserName, string Password, int Channel, DateTime StartTime, DateTime EndTime)
        {
            if (m_lUserID < 0)
            {
                //Login the device
                Int16 PortNumber = Int16.Parse(Port);//Service port of device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V30(IP, PortNumber, UserName, Password, ref DeviceInfo);
                if (m_lUserID < 0)
                {

                    // todo вывести ошибку в статус расписания
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str1 = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //Login failed,print error code
                    // MessageBox.Show(str1);
                    return;
                }
                else
                {
                    //статус расписания загружен успешно залогинились
                    //MessageBox.Show("Login Success!");
                }
            }

            // начать закачку с указанным интевалом
            CHCNetSDK.NET_DVR_PLAYCOND struDownPara = new CHCNetSDK.NET_DVR_PLAYCOND();
            struDownPara.dwChannel = (uint)Channel; //Channel number  

            //Set the starting time
            struDownPara.struStartTime.dwYear = (uint)StartTime.Year;
            struDownPara.struStartTime.dwMonth = (uint)StartTime.Month;
            struDownPara.struStartTime.dwDay = (uint)StartTime.Day;
            struDownPara.struStartTime.dwHour = (uint)StartTime.Hour-4;
            struDownPara.struStartTime.dwMinute = (uint)StartTime.Minute;
            struDownPara.struStartTime.dwSecond = (uint)StartTime.Second;

            //Set the stopping time
            struDownPara.struStopTime.dwYear = (uint)StartTime.Year;
            struDownPara.struStopTime.dwMonth = (uint)StartTime.Month;
            struDownPara.struStopTime.dwDay = (uint)StartTime.Day;
            struDownPara.struStopTime.dwHour = (uint)StartTime.Hour -4;
            struDownPara.struStopTime.dwMinute = (uint)StartTime.Minute+5;
            struDownPara.struStopTime.dwSecond = (uint)StartTime.Second;

            string sVideoFileName;  //the path and file name to save      
            sVideoFileName = "C:\\Downtest_Channel" + struDownPara.dwChannel + ".mp4";

            //Download by time
            m_lDownHandle = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, sVideoFileName, ref struDownPara);
            if (m_lDownHandle < 0)
            {

                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GetFileByTime_V40 failed, error code= " + iLastErr;
                // MessageBox.Show(str);
                //todo вывести ошибуку в статус расписания загрузки
                return;
            }

            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //Download controlling failed,print error code
                // MessageBox.Show(str);
                //todo вывести ошибку в статус расписания загрузки
                return;
            }

            // timerDownload.Interval = 1000;
            // timerDownload.Enabled = true;
            //todo добавить в статус проценты загрузки или загрузка...
        }
        // return;
    }
}


