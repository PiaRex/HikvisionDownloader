using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DATAREG = NVRCsharpDemo.ConfigurationData.DataReg;
using DATASHEDULE = NVRCsharpDemo.ConfigurationData.DataShedule;
using CHANNEL = NVRCsharpDemo.ConfigurationData.Channel;

namespace NVRCsharpDemo
{

    public class DeviceController
    {
        Form mainWindowForm = Application.OpenForms.OfType<MainWindow>().FirstOrDefault();
        MainWindow mainWindowFormDesign;

        DATASHEDULE sheduleData;

        private string str;
        private Int32 m_lDownHandle = -1;
        private Int32 m_lUserID = -1;
        private string str1;
        private uint iLastErr = 0;
        private int[] iChannelNum;
        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;
        private uint totalNumChannels;
        private uint iDChanNum;
        private byte byStreamType;
        private uint dwSize;

        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        public CHCNetSDK.NET_DVR_GET_STREAM_UNION m_unionGetStream;
        public CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;

        List<CHANNEL> listChannel = new List<CHANNEL>();

        public List<CHANNEL> getDeviceChannel(string deviceIP)
        {
            LoginDevice(FileOperations.GetDeviceReg(deviceIP));
            return listChannel;
        }

        public void LoginDevice(DATAREG loginData)
        {

            if (m_lUserID < 0)
            {
                //Login the device
                Int16 PortNumber = Int16.Parse(loginData.DevicePort);//Service port of device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V30
                    (
                    loginData.DeviceIP,
                    PortNumber,
                    loginData.UserName,
                    loginData.Password,
                    ref DeviceInfo
                    );
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
                    dwDChanTotalNum = (uint)DeviceInfo.byIPChanNum + 256 * (uint)DeviceInfo.byHighDChanNum;
                    GetIPChannels();
                }
            }
        }

        public void GetIPChannels()
        {
            dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);
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
                m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));
                iDChanNum = 64;
                totalNumChannels = m_struIpParaCfgV40.dwStartDChan - 1;
                if (dwDChanTotalNum < 64)
                {
                    iDChanNum = dwDChanTotalNum; //If the ip channels of device is less than 64,will get the real channel of device
                }
                listChannel.Clear();
                for (int i = 0; i < iDChanNum; i++)
                {
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

                            //добавить в массив найденный ип                      
                            listChannel.Add(new CHANNEL
                            {
                                ChannelNum = i + 1,
                                IPID = m_struChanInfo.byIPID
                            });
                            Marshal.FreeHGlobal(ptrChanInfo);

                            break;

                        default:
                            break;
                    }
                }
            }
            Marshal.FreeHGlobal(ptrIpParaCfgV40);
        }
        public void DownloadDeviceVideo(DATAREG loginData, DATASHEDULE shedule)
        {
            sheduleData = shedule;
            LoginDevice(loginData);

            // начать закачку с указанным интевалом
            CHCNetSDK.NET_DVR_PLAYCOND struDownPara = new CHCNetSDK.NET_DVR_PLAYCOND();
            DateTime now = DateTime.Now;
            uint startTimeHour = uint.Parse(sheduleData.downloadStartInterval.Split(':')[0]);
            uint startTimeMinute = uint.Parse(sheduleData.downloadStartInterval.Split(':')[1]);

            struDownPara.dwChannel = totalNumChannels + (uint)sheduleData.channelNum;

            //Set the starting time
            struDownPara.struStartTime.dwYear = (uint)now.Year;
            struDownPara.struStartTime.dwMonth = (uint)now.Month;
            struDownPara.struStartTime.dwDay = (uint)now.Day;
            struDownPara.struStartTime.dwHour = startTimeHour;
            struDownPara.struStartTime.dwMinute = (uint)startTimeMinute;
            struDownPara.struStartTime.dwSecond = 0;

            //Set the stopping time
            struDownPara.struStopTime.dwYear = (uint)now.Year;
            struDownPara.struStopTime.dwMonth = (uint)now.Month;
            struDownPara.struStopTime.dwDay = (uint)now.Day;
            struDownPara.struStopTime.dwHour = (uint)startTimeHour;
            struDownPara.struStopTime.dwMinute = (uint)startTimeMinute + 1;
            struDownPara.struStopTime.dwSecond = 0;

            MessageBox.Show(m_lUserID.ToString() + " "+ struDownPara.dwChannel.ToString() + " " + struDownPara.struStartTime.dwDay.ToString() + " " + struDownPara.struStartTime.dwMonth.ToString() + " " + struDownPara.struStartTime.dwYear.ToString() + " " +struDownPara.struStartTime.dwHour.ToString() + " " + struDownPara.struStartTime.dwMinute.ToString() + " " + struDownPara.struStopTime.dwHour.ToString() + " " + struDownPara.struStopTime.dwMinute.ToString());
            string sVideoFileName;  //the path and file name to save
            FileOperations.CreateDeviceFolder(loginData.DeviceName);
            FileOperations.CreateChannelFolder("Channel " + sheduleData.channelNum, loginData.DeviceName);
            sVideoFileName = $"C:\\{loginData.DeviceName}\\Channel {sheduleData.channelNum}\\{startTimeHour}-{startTimeMinute}_{startTimeHour + 1}-{startTimeMinute}.mp4";
            //Download by time
            m_lDownHandle = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, sVideoFileName, ref struDownPara);


            // Ошиюка при загрузке
            if (m_lDownHandle < 0)
            {

                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GetFileByTime_V40 failed, error code= " + iLastErr;
                MessageBox.Show(str);
                //todo вывести ошибуку в статус расписания загрузки
                return;
            }

            // timerDownload.Interval = 1000;
            // timerDownload.Enabled = true;
            //todo добавить в статус проценты загрузки или загрузка..
            
           // FileOperations.SetSheduleStatus(sheduleData.ID,"Загрузка...");
            
        }

        public bool GetDownloadStatus()
        {

            int iPos = 0;

            //Get downloading process
            iPos = CHCNetSDK.NET_DVR_GetDownloadPos(m_lDownHandle);

            if ((iPos >= 0) && (iPos < 100))
            {
                // вернуть статус проценты
                FileOperations.SetSheduleStatus(sheduleData.ID, "Загрузка: " + iPos + "%");
                return false;
            }

            if (iPos == 100)  //Finish downloading
            {
                // вернуть статус финиш
              
                if (!CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "err:= " + iLastErr; //Download controlling failed,print error code
                    // вернуть статус ошибка
                    FileOperations.SetSheduleStatus(sheduleData.ID, str);
                    return true;
                }
                m_lDownHandle = -1;
                FileOperations.SetSheduleStatus(sheduleData.ID, "Финиш: " + iPos + "%");
                return true;
            }

            if (iPos == 200) //Network abnormal,download failed
            {
                // вернуть статус abnormal
                m_lDownHandle = -1;
                FileOperations.SetSheduleStatus(sheduleData.ID, "Abnormal: " + iPos + "%");
                return true;
            }
            m_lDownHandle = -1;
            FileOperations.SetSheduleStatus(sheduleData.ID, "!!!!!!!!!!!!: " + iPos + "%");
            return true;
        }
    }
}


