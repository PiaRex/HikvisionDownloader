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
using DOWNLOADSTATUS = NVRCsharpDemo.ConfigurationData.DownloadStatus;
using System.Threading;

namespace NVRCsharpDemo
{

    public class DeviceController
    {
        Form mainWindowForm = Application.OpenForms.OfType<MainWindow>().FirstOrDefault();
        MainWindow mainWindowFormDesign;

        DATASHEDULE sheduleData;
        DATASHEDULE shedule;
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
        public string currentFolder;
        public string deviceFolder;
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


                    FileOperations.AddLog("DeviceController.LoginDevice", "Ошибка логина: " + str1, deviceFolder);
                    return;
                }
                else
                {
                    //статус расписания загружен успешно залогинились
                    FileOperations.AddLog("DeviceController.LoginDevice", "Успешно логинимся к:" + loginData.DeviceIP, deviceFolder);
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
                FileOperations.AddLog("DeviceController.GetIPChannels", "Ошибка: " + str1, deviceFolder);
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

        public void DownloadIntervalDeviceVideo(DATAREG loginData, DATASHEDULE shedule, MainWindow mainWindow)
        {
            mainWindowFormDesign = mainWindow;

            deviceFolder = FileOperations.SetDeviceDestinationFolder(loginData.DeviceName,shedule.channelNum.ToString());
            // цикл по количеству часов
            int countHour = Helpers.GetHourCountDownload(shedule);
            int successDownload = 0;
            int failDownload = 0;
           
            refreshSheduleTableStatus(shedule.ID, "загрузка...");
            for (int i = 0; i < countHour; i++)
            {  
                DownloadDeviceVideo(loginData, shedule, i); // запускаем закачку с параметрами час = i}
                FileOperations.AddLog("DeviceController", "запуск скачки: " + i + " из " + countHour, currentFolder);
                // бесконечный цикл который ждёт когда видос скачается или закрашится
                DOWNLOADSTATUS status;
                do
                {
                    status = GetDownloadStatus();
                    Thread.Sleep(1000);
                } while (!status.status);

                if (status.value.Contains("Finish")) successDownload++;
                if (status.value.Contains("Err")) failDownload++;
                refreshSheduleTableStatus(shedule.ID, "загрузка: " + successDownload + " из " + countHour + " с ошибкой: " + failDownload);
            }
            // вывести таблицу закачано из общкол (3/10)
            FileOperations.AddLog("DeviceController", "закачки закончились, успешно: " + successDownload + " из " + countHour, currentFolder);
            FileOperations.SetSheduleStatus(shedule.ID, "успешно: " + successDownload + " из " + countHour + " с ошибкой: " + failDownload);
            refreshSheduleTableStatus(shedule.ID, "успешно: " + successDownload + " из " + countHour + " с ошибкой: " + failDownload);
        }

        public void DownloadDeviceVideo(DATAREG loginData, DATASHEDULE shedule1, int currentHour)
        {
            LoginDevice(loginData);
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
            
            DateTime dayOffSet = startDateTime.AddDays(offset); // вставит кол дней которые отнимаем
            DateTime startDownloadDateTime = dayOffSet.AddHours(currentHour);
            DateTime endDownloadDateTime = startDownloadDateTime.AddMinutes(1);

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
            currentFolder = FileOperations.SetDownloadDestinationFolder(loginData.DeviceName, shedule.channelNum.ToString(),startDownloadDateTime);
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
                str = "NET_DVR_GetFileByTime_V40 failed, error code= " + iLastErr;
                FileOperations.AddLog("DeviceController.DownloadDeviceVideo", "Ошибка: " + str, currentFolder);
                return;
            }
            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //Download controlling failed,print error code
                FileOperations.AddLog("DeviceController.DownloadDeviceVideo", "Ошибка: " + str, currentFolder);
                return;
            }
            FileOperations.AddLog("DeviceController.DownloadDeviceVideo", "Загрузка: " + shedule.ID + ": " + sVideoFileName, currentFolder);
        }

        public DOWNLOADSTATUS GetDownloadStatus()
        {
            DOWNLOADSTATUS status = new DOWNLOADSTATUS();
            int iPos = 0;

            //Get downloading process
            iPos = CHCNetSDK.NET_DVR_GetDownloadPos(m_lDownHandle);


            if ((iPos >= 0) && (iPos < 100))
            {
                // вернуть статус проценты
                FileOperations.AddLog("DeviceController.GetDownloadStatus", "Загрузка: " + shedule.ID + ": " + m_lDownHandle + " (" + iPos + "%)", currentFolder);
                status.status = false;
                status.value = iPos.ToString();
                return status;
            }

            if (iPos == 100)  //Finish downloading
            {
                // вернуть статус финиш

                if (!CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "err:= " + iLastErr; // Download controlling failed,print error code
                    // вернуть статус ошибка
                    FileOperations.AddLog("DeviceController.GetDownloadStatus", "Ошибка загрузки: " + shedule.ID + ": " + str, currentFolder);
                    status.status = true;
                    status.value = str;
                    return status;
                }
                m_lDownHandle = -1;
                FileOperations.AddLog("DeviceController.GetDownloadStatus", shedule.ID + " Финиш" + iPos + "%", currentFolder );
                status.status = true;
                status.value = "Finish " + iPos + "%";
                return status;
            }

            if (iPos == 200) //Network abnormal,download failed
            {
                // вернуть статус abnormal
                m_lDownHandle = -1;
                FileOperations.AddLog("DeviceController.GetDownloadStatus", "Ошибка загрузки: Abnormal" + shedule.ID + ": " + iPos, currentFolder);
                status.status = true;
                status.value = "Abnormal: Err" + iPos.ToString();
                return status;
            }
            m_lDownHandle = -1;
            status.status = true;
            FileOperations.AddLog("DeviceController.GetDownloadStatus", shedule.ID + " непредвиденный результат: " + iPos.ToString(), currentFolder);
            status.value = "непредвиденный результат: " + iPos.ToString();
            return status;
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


