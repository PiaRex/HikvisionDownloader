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
using System.Threading;

namespace NVRCsharpDemo
{

    public class DeviceController
    {
        Form mainWindowForm = Application.OpenForms.OfType<MainWindow>().FirstOrDefault();
        MainWindow mainWindowFormDesign;

        DATASHEDULE shedule;
        private Int32 m_lDownHandle = -1;
        private Int32 m_lUserID = -1;
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
            LoginDevice(FileOperations.GetDeviceReg(deviceIP), " ");
            return listChannel;
        }

        public void LoginDevice(DATAREG loginData, string DeviceFolder)
        {
            string deviceFolder = DeviceFolder;
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
                    FileOperations.AddLog("DeviceController.LoginDevice", "Неудачный логин, код  ошибки: " + iLastErr, deviceFolder, "Login.log");
                    return;
                }
                else
                {
                    //статус расписания загружен успешно залогинились
                    FileOperations.AddLog("DeviceController.LoginDevice", "Успешный логин. IP: " + loginData.DeviceIP, deviceFolder, "Login.log");
                    dwDChanTotalNum = (uint)DeviceInfo.byIPChanNum + 256 * (uint)DeviceInfo.byHighDChanNum;
                    GetIPChannels(deviceFolder);
                }
            }
        }

        public void GetIPChannels(string DeviceFolder)

        {
            string deviceFolder = DeviceFolder;
            dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);
            IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
            Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);
            uint dwReturn = 0;
            int iGroupNo = 0;
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSize, ref dwReturn))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                FileOperations.AddLog("DeviceController.GetIPChannels", "Ошибка получения списка каналов, код ошибки: " + iLastErr, deviceFolder, "Login.log");
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

        public delegate void DownloadCompletedCallback(string currentFolder, bool success);
        public void DownloadIntervalDeviceVideo(DATAREG loginData, DATASHEDULE shedule, MainWindow mainWindow)
        {
            mainWindowFormDesign = mainWindow;
            string deviceFolder = FileOperations.SetDeviceDestinationFolder(loginData.DeviceName,shedule.channelNum.ToString());
            string logFileName = "Download.log";

            // цикл по количеству часов
            int countHour = Helpers.GetHourCountDownload(shedule);
            int successDownload = 0;
            int failDownload = 0;
            string currentFolder = "";

            DownloadCompletedCallback callback = (currentDownloadFolder, success) =>
            {
                if (!success) Interlocked.Increment(ref failDownload);
                else Interlocked.Increment(ref successDownload);

            };

            LoginDevice(loginData, deviceFolder);
            refreshSheduleTableStatus(shedule.ID, "Загрузка начата...");
            for (int i = 0; i < countHour; i++)
            {  
                int j = i + 1;
                currentFolder = DownloadDeviceVideo(loginData, shedule, i, callback); // запускаем закачку с параметрами час = i}
                FileOperations.AddLog("DeviceController", "Старт загрузки: " + j + " из " + countHour, currentFolder, logFileName);
                // бесконечный цикл который ждёт когда видос скачается или закрашится
                bool status;
                do
                {
                    status = GetDownloadStatus(currentFolder , callback);
                    Thread.Sleep(1000);
                } while (!status);
                refreshSheduleTableStatus(shedule.ID, "Загрузка... файлов загружено: " + successDownload + " из " + countHour + ", ошибок: " + failDownload);
            }

            // вывести таблицу закачано из общкол (3/10)
            FileOperations.AddLog("DeviceController", "Загрузка завершена. Файлов загружено: " + successDownload + " из " + countHour, currentFolder, logFileName);
            FileOperations.SetSheduleStatus(shedule.ID, DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ". Загрузка завершена. Файлов загружено: " + successDownload + " из " + countHour + ", ошибок: " + failDownload);
            refreshSheduleTableStatus(shedule.ID, DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ". Загрузка завершена. Файлов загружено: " + successDownload + " из " + countHour + ", ошибок: " + failDownload);
        }


        public string DownloadDeviceVideo(DATAREG loginData, DATASHEDULE shedule1, int currentHour, DownloadCompletedCallback callback)
        {
            Thread.Sleep(1000);
            shedule = shedule1;
            // начать закачку с указанным интевалом
            CHCNetSDK.NET_DVR_PLAYCOND struDownPara = new CHCNetSDK.NET_DVR_PLAYCOND();
            DateTime now = DateTime.Now;
            DateTime startDateTime = new DateTime(
                now.Year,
                now.Month,
                now.Day,
                int.Parse(shedule.downloadStartInterval.Split(':')[0]),
                int.Parse(shedule.downloadStartInterval.Split(':')[1]),
                0
            );
            int offset = Helpers.GetDayOffset(shedule);
            string logFileName = "Download.log";
            DateTime dayOffSet = startDateTime.AddDays(offset); // вставит кол дней которые отнимаем
            DateTime startDownloadDateTime = dayOffSet.AddHours(currentHour);
            DateTime endDownloadDateTime = startDownloadDateTime.AddMinutes(2);
            string currentFolder = FileOperations.SetDownloadDestinationFolder(loginData.DeviceName, shedule.channelNum.ToString(), startDownloadDateTime);
            struDownPara.dwChannel = totalNumChannels + (uint)shedule.channelNum;

            //Set the starting time
            struDownPara.struStartTime.dwYear = (uint)startDownloadDateTime.Year;
            struDownPara.struStartTime.dwMonth = (uint)startDownloadDateTime.Month;
            struDownPara.struStartTime.dwDay = (uint)startDownloadDateTime.Day;
            struDownPara.struStartTime.dwHour = (uint)startDownloadDateTime.Hour;
            struDownPara.struStartTime.dwMinute = (uint)startDownloadDateTime.Minute;
            struDownPara.struStartTime.dwSecond = 0;

            //Set the stopping time
            struDownPara.struStopTime.dwYear = (uint)endDownloadDateTime.Year;
            struDownPara.struStopTime.dwMonth = (uint)endDownloadDateTime.Month;
            struDownPara.struStopTime.dwDay = (uint)endDownloadDateTime.Day;
            struDownPara.struStopTime.dwHour = (uint)endDownloadDateTime.Hour;
            struDownPara.struStopTime.dwMinute = (uint)endDownloadDateTime.Minute;
            struDownPara.struStopTime.dwSecond = 0;

            string sVideoFileName;  //the path and file name to save

            sVideoFileName = $"{currentFolder}" +
                $"{startDownloadDateTime.Hour}-" +
                $"{startDownloadDateTime.Minute}_" +
                $"{endDownloadDateTime.Hour}-" +
                $"{endDownloadDateTime.Minute}.mp4";
            //Download by time
            m_lDownHandle = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, sVideoFileName, ref struDownPara);
            if (m_lDownHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                FileOperations.AddLog("DeviceController.DownloadDeviceVideo", "Код ошибки: " + iLastErr, currentFolder, logFileName);
                callback?.Invoke(currentFolder, false);
                return null;
            }
            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                FileOperations.AddLog("DeviceController.DownloadDeviceVideo", "Код ошибки: " + iLastErr, currentFolder, logFileName);
                callback?.Invoke(currentFolder, false);
                return null;
            }
            FileOperations.AddLog("DeviceController.DownloadDeviceVideo", "Загрузка: " + shedule.ID + ": " + sVideoFileName, currentFolder, logFileName);
            return currentFolder;
        }

        public bool GetDownloadStatus(string currentDownloadLogFolder, DownloadCompletedCallback callback)

        {
            int iPos = 0;
            string logFileName = "Download.log";
            string currentFolder = currentDownloadLogFolder;
            //Get downloading process
            iPos = CHCNetSDK.NET_DVR_GetDownloadPos(m_lDownHandle);


            if ((iPos >= 0) && (iPos < 100))
            {
                // вернуть статус проценты
                FileOperations.AddLog("DeviceController.GetDownloadStatus", "Загрузка: " + shedule.ID + ": " + m_lDownHandle + " (" + iPos + "%)", currentFolder, logFileName);
                return false;
            }

            if (iPos == 100)  //Finish downloading
            {
                // вернуть статус финиш

                if (!CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    // вернуть статус ошибка
                    FileOperations.AddLog("DeviceController.GetDownloadStatus", "Ошибка загрузки: " + shedule.ID + ": " + iLastErr.ToString(), currentFolder, logFileName);
                    if (iLastErr == 12) callback?.Invoke(currentFolder, true); else callback?.Invoke(currentFolder, false);
                    return true;
                }
                m_lDownHandle = -1;
                FileOperations.AddLog("DeviceController.GetDownloadStatus", shedule.ID + " Финиш " + iPos + "%", currentFolder, logFileName);
                callback?.Invoke(currentFolder, true);
                return true;
            }

            if (iPos == 200) //Network abnormal,download failed
            {
                // вернуть статус abnormal
                m_lDownHandle = -1;
                FileOperations.AddLog("DeviceController.GetDownloadStatus", "Ошибка загрузки: Abnormal" + shedule.ID + ": " + iPos, currentFolder,logFileName);
                callback?.Invoke(currentFolder, false);
                return true;
            }
            m_lDownHandle = -1;
            FileOperations.AddLog("DeviceController.GetDownloadStatus", shedule.ID + " непредвиденный результат: " + iPos.ToString(), currentFolder, logFileName);
            callback?.Invoke(currentFolder, true);
            return true;
        }

        private void refreshSheduleTableStatus(int ID, string status)
        {
            mainWindowForm.Invoke(new Action(() =>
            {
                mainWindowFormDesign.SheduleTable.Items[ID].SubItems[7].Text = status;
            }));
        }
    }
}


