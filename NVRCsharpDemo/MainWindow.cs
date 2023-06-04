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
using System.Threading;

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
        private System.Windows.Forms.Timer currentTimeTimer = new System.Windows.Forms.Timer();
        private int DeviceIndex = 0;
        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;

        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;

        public string StatusText { get { return StatusServiceLabel.Text; } set { StatusServiceLabel.Text = value; } }


        // создание колекции обьектов
        public List<DATAREG> DataRegList = new List<DATAREG>();
        public List<DATASHEDULE> DataSheduleList = new List<DATASHEDULE>();

        public MainWindow()
        {
            InitializeComponent();
            
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
            }

            currentTimeTimer.Interval = 1000;
            currentTimeTimer.Tick += Timer_Tick;
            currentTimeTimer.Start();
            CurrentFolderLabel.Text = FileOperations.CurrentFolder;
            RefreshDeviceTable();
            RefreshSheduleTable();
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
            service = false;
            Application.Exit();
        }

        private void DelDeviceButton_Click(object sender, EventArgs e)
        {
            string selectedDeviceIP = GetSelectedDeviceIP();
            FileOperations.DeleteDevice(selectedDeviceIP);
            RefreshDeviceTable();
        }

        private void AddDeviceButton_Click(object sender, EventArgs e)
        { 
            if (textBoxDeviceName.Text == "" || textBoxIP.Text == "" || textBoxPort.Text == "" ||
                textBoxUserName.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Для добавления нового устройства введите его имя, IP-адрес, порт, логин и пароль");
                return;
            }
            DATAREG datareg = DataRegList.FirstOrDefault(x => x.DeviceIP == textBoxIP.Text);
            if ((datareg !=null))
            {
                MessageBox.Show("Устройство с этим IP-адресом уже добавлено!");
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
                    uint iDChanNum = 64;

                    if (dwDChanTotalNum < 64 & dwDChanTotalNum > 0)
                    {
                        iDChanNum = dwDChanTotalNum; //If the ip channels of device is less than 64,will get the real channel of device
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
                }

            }
            return;
        }

        private void AddIntervalButton_Click(object sender, EventArgs e)
        {
            string selectedDeviceIP = GetSelectedDeviceIP();
            if (selectedDeviceIP != null)
            {
                Form scheduleForm = new ScheduleForm(GetSelectedDeviceIP(),this);
                scheduleForm.Show();
            }

        }

        private void buttonStartService_Click(object sender, EventArgs e)
        {

            if (!service)
            {
                //Start the service
                service = true;
                //todo когда сервис запущен заблочит возможность добавления новых региков и расписания, что-бы каждый раз не читать из файла
                Monitor monitor = new Monitor();
                monitor.TimeMonitor(this);
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
            else
            {
                MessageBox.Show("Выберите устройство из списка");
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

        public void RefreshSheduleTable()
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
                    Item.downloadEndInterval,
                    Item.status
                }));
            }
        }

        private void DelScheduleButton_Click(object sender, EventArgs e)
        {
            if (GetSelectedSheduleID() != null)
            {
                string selectedSheduleID = GetSelectedSheduleID();
                FileOperations.DeleteShedule(selectedSheduleID);
                RefreshSheduleTable();
            }
        }

        private string GetSelectedSheduleID()
        {
            if (SheduleTable.SelectedItems.Count > 0)
            {
                string sheduleID = SheduleTable.SelectedItems[0].SubItems[0].Text;  //Select the current items
                return sheduleID;
            }
            MessageBox.Show("Выберите задачу из списка");
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (GetSelectedSheduleID() != null)
            {
                DeviceController deviceController = new DeviceController();
                string selectedSheduleID = GetSelectedSheduleID();
                DATASHEDULE selectedShedule = DataSheduleList.FirstOrDefault(x => x.ID.ToString() == selectedSheduleID);
                DATAREG selectedDevice = DataRegList.FirstOrDefault(x => x.DeviceIP == selectedShedule.DeviceIP);
                var downloadThread = new Thread(() => deviceController.DownloadIntervalDeviceVideo(selectedDevice, selectedShedule, this));
                downloadThread.Start();
            }
            
        }

        private void EditScheduleButton_Click(object sender, EventArgs e)
        {
            if (GetSelectedSheduleID() != null)
            {
                Form EditForm = new EditForm(GetSelectedSheduleID(),this);
                EditForm.Show();
            }

        }

        private void ChooseFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            FileOperations.CurrentFolder = folderBrowserDialog.SelectedPath;
            CurrentFolderLabel.Text = FileOperations.CurrentFolder;
        }
    }
}
