using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using DATAREG = NVRCsharpDemo.ConfigurationData.DataReg;
using DATASHEDULE = NVRCsharpDemo.ConfigurationData.DataShedule;

namespace NVRCsharpDemo
{

    public partial class MainWindow : Form

    {
        public static bool service = false;

        private bool m_bInitSDK = false;
        private uint iLastErr = 0;
        private Int32 m_lUserID = -1;
        private Int32 m_lFindHandle = -1;
        private Int32 m_lPlayHandle = -1;
        private Int32 m_lDownHandle = -1;
        private string str;
        private string str1;
        private string str2;
        private string str3;
        private string sPlayBackFileName = null;
        private Int32 i = 0;
        private Int32 m_lTree = 0;
        private Timer currentTimeTimer = new Timer();
        private int DeviceIndex = 0;
        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;
        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        public CHCNetSDK.NET_DVR_GET_STREAM_UNION m_unionGetStream;
        public CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;
        public string StatusText { get { return StatusServiceLabel.Text; } set { StatusServiceLabel.Text = value; } }




        // создание колекции обьектов
        public List<DATAREG> DataRegList = new List<DATAREG>();
        public List<DATASHEDULE> DataSheduleList = new List<DATASHEDULE>();


        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 96, ArraySubType = UnmanagedType.U4)]
        private int[] iChannelNum;

        public MainWindow()
        {
            InitializeComponent();
            currentTimeTimer.Interval = 1000;
            currentTimeTimer.Tick += Timer_Tick;
            currentTimeTimer.Start();

            RefreshDeviceTable();
            RefreshSheduleTable();

            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            else
            {
                //Save log of SDK
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
                iChannelNum = new int[96];
            }
        }

        public void InfoIPChannel()
        {
            uint dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);

            IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
            Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);

            uint dwReturn = 0;
            int iGroupNo = 0; //The demo just acquire 64 channels of first group.If ip channels of device is more than 64,you should call NET_DVR_GET_IPPARACFG_V40 times to acquire more according to group 0~i
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

                for (i = 0; i < dwAChanTotalNum; i++)
                {
                    ListAnalogChannel(i + 1, m_struIpParaCfgV40.byAnalogChanEnable[i]);
                    iChannelNum[i] = i + (int)DeviceInfo.byStartChan;
                }

                byte byStreamType;
                uint iDChanNum = 64;

                if (dwDChanTotalNum < 64)
                {
                    iDChanNum = dwDChanTotalNum; //If the ip channels of device is less than 64,will get the real channel of device
                }

                for (i = 0; i < iDChanNum; i++)
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
                            ListIPChannel(i + 1, m_struChanInfo.byEnable, m_struChanInfo.byIPID);
                            Marshal.FreeHGlobal(ptrChanInfo);
                            break;

                        default:
                            break;
                    }
                }
            }
            Marshal.FreeHGlobal(ptrIpParaCfgV40);
        }
        public void ListIPChannel(Int32 iChanNo, byte byOnline, byte byIPID)
        {
            str1 = String.Format("IPCamera {0}", iChanNo);
            m_lTree++;

            if (byIPID == 0)
            {
                str2 = "X"; //The ip channel is empty,no front-end(such as camera)is added               
            }
            else
            {
                if (byOnline == 0)
                {
                    str2 = "offline"; //The channel is offline
                }
                else
                    str2 = "online"; //The channel is online
            }

            DevicesList.Items.Add(new ListViewItem(new string[] { str1, str2 }));//Add channels to list
        }
        public void ListAnalogChannel(Int32 iChanNo, byte byEnable)
        {
            str1 = String.Format("Camera {0}", iChanNo);
            m_lTree++;

            if (byEnable == 0)
            {
                str2 = "Disabled"; //This channel has been disabled               
            }
            else
            {
                str2 = "Enabled"; //This channel has been enabled  
            }

            DevicesList.Items.Add(new ListViewItem(new string[] { str1, str2 }));//Add channels to list
        }

        private void listViewFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SheduleTable.SelectedItems.Count > 0)
            {
                sPlayBackFileName = SheduleTable.FocusedItem.SubItems[0].Text;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Show current time
            DateTimeLabel.Text = DateTime.Now.ToLongTimeString();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Initialize current time
            DateTimeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //Stop playback
            if (m_lPlayHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopPlayBack(m_lPlayHandle);
                m_lPlayHandle = -1;
            }

            //Stop download
            if (m_lDownHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle);
                m_lDownHandle = -1;
            }

            //Logout the device
            if (m_lUserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
                m_lUserID = -1;
            }
            Application.Exit();
        }

        private void DelDeviceButton_Click(object sender, EventArgs e)
        {
            string selectedDeviceIP = GetSelectedDeviceIP();
            FileOperations.DeleteDevice(selectedDeviceIP);
            RefreshDeviceTable();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (textBoxIP.Text == "" || textBoxPort.Text == "" ||
                textBoxUserName.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Please input IP, Port, User name and Password!");
                return;
            }
            if (m_lUserID < 0)
            {
                string DVRIPAddress = textBoxIP.Text; //IP or domain of device
                Int16 DVRPortNumber = Int16.Parse(textBoxPort.Text);//Service port of device
                string DVRUserName = textBoxUserName.Text;//Login name of deivce
                string DVRPassword = textBoxPassword.Text;//Login password of device

                //    DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //Login the device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (m_lUserID < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str1 = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //Login failed,print error code
                    MessageBox.Show(str1);
                    return;
                }
                else
                {
                    //Login successsfully
                    MessageBox.Show("Login Success!");

                    dwAChanTotalNum = (uint)DeviceInfo.byChanNum;
                    dwDChanTotalNum = (uint)DeviceInfo.byIPChanNum + 256 * (uint)DeviceInfo.byHighDChanNum;

                    if (dwDChanTotalNum > 0)
                    {
                        InfoIPChannel();
                    }
                    else
                    {
                        for (i = 0; i < dwAChanTotalNum; i++)
                        {
                            ListAnalogChannel(i + 1, 1);
                            iChannelNum[i] = i + (int)DeviceInfo.byStartChan;
                        }
                        // MessageBox.Show("This device has no IP channel!");
                    }

                    List<DATAREG> DataRegList = FileOperations.LoadDataReg();

                    DataRegList.Add(new DATAREG
                    {
                        DeviceName = textBoxDeviceName.Text,
                        DeviceIP = textBoxIP.Text,
                        DevicePort = textBoxPort.Text,
                        UserName = textBoxUserName.Text,
                        Password = textBoxPassword.Text
                    });

                    FileOperations.SaveDataReg(DataRegList);

                    RefreshDeviceTable();
                    m_lUserID = -1;
                }

            }
            else
            {
                if (m_lPlayHandle >= 0)
                {
                    MessageBox.Show("Please stop playback firstly"); //Please stop playback before logout
                    return;
                }

                //Logout the device
                if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str1 = "NET_DVR_Logout failed, error code= " + iLastErr;
                    MessageBox.Show(str1);
                    return;
                }
                DevicesList.Items.Clear();//Clear channel list
                m_lUserID = -1;
            }
            return;
        }

        private void AddIntervalButton_Click(object sender, EventArgs e)
        {

            Form scheduleForm = new ScheduleForm(GetSelectedDeviceIP());
            scheduleForm.Left = this.Left + 560;
            scheduleForm.Top = this.Top + 240;
            scheduleForm.Show();
        }

        private void buttonStartService_Click(object sender, EventArgs e)
        {

            if (!service)
            {
                //Start the service
                service = true;
                //todo когда сервис запущен заблочит возможность добавления новых региков и расписания, что-бы каждый раз не читать из файла
                Monitor.TimeMonitor(StatusServiceLabel);
                buttonStartService.Text = "СТОП";
                StatusServiceLabel.ForeColor = Color.Green;
            }
            else
            {
                service = false;
                //todo восстановить возможность редактировать регики и расписание
                buttonStartService.Text = "СТАРТ";
                StatusServiceLabel.ForeColor = Color.Black;
                StatusServiceLabel.Text = "Статус сервиса: Остановлен";

            }
        }

        public static bool getStatusService() { return service; }
        public void UpdateStatusServiceLabel(string newText)
        { StatusServiceLabel.Text = newText; }

        public string GetSelectedDeviceIP()
        {
            if (DevicesList.SelectedItems.Count > 0)
            {
                string deviceIP = DevicesList.SelectedItems[0].SubItems[1].Text;  //Select the current items
                return deviceIP;
            }
            return null;
        }

        private void DevicesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshDeviceTable()
        {
            DevicesList.Items.Clear();
            DataRegList = FileOperations.LoadDataReg();
            foreach (DATAREG Item in DataRegList)
            { DevicesList.Items.Add(new ListViewItem(new string[] { Item.DeviceName, Item.DeviceIP, Item.DevicePort, Item.UserName })); }
        }

        private void RefreshSheduleTable()
        {
            SheduleTable.Items.Clear();
            DataRegList = FileOperations.LoadDataReg();
            DataSheduleList = FileOperations.LoadDataShedule();
            foreach (DATASHEDULE Item in DataSheduleList)
            {
                SheduleTable.Items.Add(new ListViewItem(new string[]
                {
                    Item.ID.ToString(),
                    DataRegList.Find(x => x.DeviceIP == Item.DeviceIP).DeviceName,
                    Item.DeviceIP,
                    Item.channelNum.ToString(),
                    Item.startDownloadTime,
                    Item.downloadStartInterval,
                    Item.downloadEndInterval
                }));
            }
        }

        private void DelScheduleButton_Click(object sender, EventArgs e)
        {
            string selectedSheduleID = GetSelectedSheduleID();
            FileOperations.DeleteShedule(selectedSheduleID);
            RefreshSheduleTable();
        }

        private string GetSelectedSheduleID()
        {
            if (SheduleTable.SelectedItems.Count > 0)
            {
                string sheduleID = SheduleTable.SelectedItems[0].SubItems[0].Text;  //Select the current items
                return sheduleID;
            }
            return null;
        }
    }
}
