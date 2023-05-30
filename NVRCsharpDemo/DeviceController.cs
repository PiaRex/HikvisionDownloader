using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NVRCsharpDemo
{
    public class DeviceController
    {
        private string str;
        private Int32 m_lDownHandle = -1;
        private Int32 m_lUserID = -1;
        private string str1;
        private uint iLastErr = 0;
        private long iSelIndex = 0;
        private int[] iChannelNum;
        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;
        private uint totalNumChannels;
        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        public CHCNetSDK.NET_DVR_GET_STREAM_UNION m_unionGetStream;
        public CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;

        public void InfoIPChannel()
        {
            MessageBox.Show("InfoIP");
            uint dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);

            IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
            Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);

            uint dwReturn = 0;
            int iGroupNo = 0;
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSize, ref dwReturn))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str1 = "NET_DVR_GET_IPPARACFG_V40 failed, error code= " + iLastErr; //Get IP parameter of configuration failed,print error code.
                MessageBox.Show(str1);
            }
            else
            {
                // succ
                m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));

                byte byStreamType;
                uint iDChanNum = 64;
                totalNumChannels = m_struIpParaCfgV40.dwStartDChan-1;
                if (dwDChanTotalNum < 64)
                {
                    iDChanNum = dwDChanTotalNum; //If the ip channels of device is less than 64,will get the real channel of device
                }

                for (int i = 0; i < iDChanNum; i++)
                {
                    iChannelNum[i + dwAChanTotalNum] = i + (int)m_struIpParaCfgV40.dwStartDChan;

                    byStreamType = m_struIpParaCfgV40.struStreamMode[i].byGetStreamType;
                    m_unionGetStream = m_struIpParaCfgV40.struStreamMode[i].uGetStream;

                    switch (byStreamType)
                    {
                        //At present NVR just support case 0-one way to get stream from device
                        case 0:
                            dwSize = (uint)Marshal.SizeOf(m_unionGetStream);
                            IntPtr ptrChanInfo = Marshal.AllocHGlobal((Int32)dwSize);
                            Marshal.StructureToPtr(m_unionGetStream, ptrChanInfo, false);
                            m_struChanInfo = (CHCNetSDK.NET_DVR_IPCHANINFO)Marshal.PtrToStructure(ptrChanInfo, typeof(CHCNetSDK.NET_DVR_IPCHANINFO));

                            //List ip channels
                            Marshal.FreeHGlobal(ptrChanInfo);

                            break;

                        default:
                            break;
                    }
                }
            }
            Marshal.FreeHGlobal(ptrIpParaCfgV40);
        }
        public void DownloadDeviceVideo(string IP, string Port, string UserName, string Password, uint Channel, DateTime StartTime, DateTime EndTime)
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
                    MessageBox.Show(str1);
                    return;
                }
                else
                {
                    //статус расписания загружен успешно залогинились
                    MessageBox.Show("Login Success!");
                    DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
                    iChannelNum = new int[96];
                    dwDChanTotalNum = (uint)DeviceInfo.byIPChanNum + 256 * (uint)DeviceInfo.byHighDChanNum;
                    InfoIPChannel();
                }
            }

            // начать закачку с указанным интевалом
            CHCNetSDK.NET_DVR_PLAYCOND struDownPara = new CHCNetSDK.NET_DVR_PLAYCOND();

            struDownPara.dwChannel = totalNumChannels+Channel;  

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
                MessageBox.Show(str);
                //todo вывести ошибуку в статус расписания загрузки
                return;
            }

            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //Download controlling failed,print error code
                MessageBox.Show(str);
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


