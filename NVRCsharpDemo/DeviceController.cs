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
        private Int32 m_lFindHandle = -1;
        private Int32 m_lUserID = -1;
        private string str1;
        private uint iLastErr = 0;
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
                   // MessageBox.Show("Login Success!");

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
            struDownPara.struStartTime.dwMinute = startTimeMinute;
            struDownPara.struStartTime.dwSecond = 0;

            //Set the stopping time
            struDownPara.struStopTime.dwYear = (uint)now.Year;
            struDownPara.struStopTime.dwMonth = (uint)now.Month;
            struDownPara.struStopTime.dwDay = (uint)now.Day;
            struDownPara.struStopTime.dwHour = startTimeHour;
            struDownPara.struStopTime.dwMinute = startTimeMinute + 1;
            struDownPara.struStopTime.dwSecond = 0;

            string sVideoFileName;  //the path and file name to save
            FileOperations.CreateDeviceFolder(loginData.DeviceName);
            FileOperations.CreateChannelFolder("Channel " + sheduleData.channelNum, loginData.DeviceName);
            sVideoFileName = $"C:\\{loginData.DeviceName}\\Channel {sheduleData.channelNum}\\{startTimeHour}-{startTimeMinute}_{startTimeHour + 1}-{startTimeMinute}.mp4";
            //Download by time
            CheckFiles(sheduleData);
            m_lDownHandle = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, sVideoFileName, ref struDownPara);
            if (m_lDownHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GetFileByTime_V40 failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //Download controlling failed,print error code
                MessageBox.Show(str);
                return;
            }

            // timerDownload.Interval = 1000;
            // timerDownload.Enabled = true;
            //todo добавить в статус проценты загрузки или загрузка..

             FileOperations.SetSheduleStatus(sheduleData.ID,"Загрузка...");

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

        private void CheckFiles(DATASHEDULE currentDataShedue)
        {
            CHCNetSDK.NET_DVR_FILECOND_V40 struDownPara = new CHCNetSDK.NET_DVR_FILECOND_V40();

            struDownPara.lChannel = 33; //Channel number
            struDownPara.dwFileType = 0xff; //0xff-All，0-Timing record，1-Motion detection，2-Alarm trigger，...
            struDownPara.dwIsLocked = 0xff; //0-unfixed file，1-fixed file，0xff means all files（including fixed and unfixed files）

            //Set the starting time to search video files
            DateTime now = DateTime.Now;
            uint startTimeHour = uint.Parse(sheduleData.downloadStartInterval.Split(':')[0]);
            uint startTimeMinute = uint.Parse(sheduleData.downloadStartInterval.Split(':')[1]);

            struDownPara.lChannel = (int)totalNumChannels + sheduleData.channelNum;

            //Set the starting time
            struDownPara.struStartTime.dwYear = (uint)now.Year;
            struDownPara.struStartTime.dwMonth = (uint)now.Month;
            struDownPara.struStartTime.dwDay = (uint)now.Day;
            struDownPara.struStartTime.dwHour = startTimeHour;
            struDownPara.struStartTime.dwMinute = startTimeMinute;
            struDownPara.struStartTime.dwSecond = 0;

            //Set the stopping time
            struDownPara.struStopTime.dwYear = (uint)now.Year;
            struDownPara.struStopTime.dwMonth = (uint)now.Month;
            struDownPara.struStopTime.dwDay = (uint)now.Day;
            struDownPara.struStopTime.dwHour = startTimeHour;
            struDownPara.struStopTime.dwMinute = startTimeMinute + 1;
            struDownPara.struStopTime.dwSecond = 0;

            //Start to search video files 
            m_lFindHandle = CHCNetSDK.NET_DVR_FindFile_V40(m_lUserID, ref struDownPara);

            if (m_lFindHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_FindFile_V40 failed, error code= " + iLastErr; //find files failed，print error code
                MessageBox.Show(str);
                return;
            }
            else
            {
                CHCNetSDK.NET_DVR_FINDDATA_V30 struFileData = new CHCNetSDK.NET_DVR_FINDDATA_V30(); ;
                while (true)
                {
                    //Get file information one by one.
                    int result = CHCNetSDK.NET_DVR_FindNextFile_V30(m_lFindHandle, ref struFileData);

                    if (result == CHCNetSDK.NET_DVR_ISFINDING)  //Searching, please wait
                    {
                        continue;
                    }
                    else if (result == CHCNetSDK.NET_DVR_FILE_SUCCESS) //Get the file information successfully
                    {
                        string str1 = struFileData.sFileName;

                        string str2 = Convert.ToString(struFileData.struStartTime.dwYear) + "-" +
                            Convert.ToString(struFileData.struStartTime.dwMonth) + "-" +
                            Convert.ToString(struFileData.struStartTime.dwDay) + " " +
                            Convert.ToString(struFileData.struStartTime.dwHour) + ":" +
                            Convert.ToString(struFileData.struStartTime.dwMinute) + ":" +
                            Convert.ToString(struFileData.struStartTime.dwSecond);

                        string str3 = Convert.ToString(struFileData.struStopTime.dwYear) + "-" +
                            Convert.ToString(struFileData.struStopTime.dwMonth) + "-" +
                            Convert.ToString(struFileData.struStopTime.dwDay) + " " +
                            Convert.ToString(struFileData.struStopTime.dwHour) + ":" +
                            Convert.ToString(struFileData.struStopTime.dwMinute) + ":" +
                            Convert.ToString(struFileData.struStopTime.dwSecond);

                        MessageBox.Show( str1 + " " + str2 + " " + str3 );//Add the founed files to the list

                    }
                    else if (result == CHCNetSDK.NET_DVR_FILE_NOFIND || result == CHCNetSDK.NET_DVR_NOMOREFILE)
                    {
                        MessageBox.Show(result.ToString());
                        break; //No file found or no more file found, searching is finished 
                    }
                    else
                    {
                        break;
                    }
                }

            }
        }
    }
}


