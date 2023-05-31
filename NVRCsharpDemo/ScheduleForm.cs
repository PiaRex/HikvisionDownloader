using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NVRCsharpDemo.MainWindow;
using DATAREG = NVRCsharpDemo.ConfigurationData.DataReg;
using DATASHEDULE = NVRCsharpDemo.ConfigurationData.DataShedule;
using CHANNEL = NVRCsharpDemo.ConfigurationData.Channel;

namespace NVRCsharpDemo
{
    public partial class ScheduleForm : Form
    {
        Form mainWindow;

        public string selectedDeviceIP;
        public ScheduleForm(string deviceIP)
        {
            InitializeComponent();
            selectedDeviceIP = deviceIP;
            List<DATAREG> dataRegList = FileOperations.LoadDataReg();
            DATAREG selectedDevice = dataRegList.FirstOrDefault(x => x.DeviceIP == deviceIP);
            DeviceNameLavel.Text = selectedDevice.DeviceName;

            //запоняем список расписания на указанный девайс
            List<DATASHEDULE> dataShedules = FileOperations.LoadDataShedule();
            List<DATASHEDULE> deviceShedule = dataShedules.FindAll(x => x.DeviceIP == deviceIP);
            foreach (DATASHEDULE Item in deviceShedule)
            {
                SheduleDeviceTable.Items.Add(new ListViewItem(new string[]
                {
                Item.channelNum.ToString(),
                Item.startDownloadTime,
                Item.downloadStartInterval.ToString(),
                Item.downloadEndInterval.ToString()
                }
                ));
            }
        }
        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            mainWindow = Application.OpenForms.OfType<MainWindow>().FirstOrDefault();
            this.Left = mainWindow.Left + 560;
            this.Top = mainWindow.Top + 240;
        }

        private void ScheduleForm_Activated(object sender, EventArgs e)
        {
            RefreshSheduleTable();
        }

        private void DelIntervalButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            if (mainWindow != null) mainWindow.Activate();
        }

        private void AddIntervalButton_Click(object sender, EventArgs e)
        {
            Form IntervalForm = new IntervalForm(selectedDeviceIP); // TODO: пробросить параметры
            IntervalForm.Left = this.Left + 560;
            IntervalForm.Top = this.Top + 240;
            this.TopMost = false;
            IntervalForm.Show();
        }

        public void RefreshSheduleTable()
        {
            SheduleDeviceTable.Items.Clear();
            List<DATASHEDULE> dataShedules = FileOperations.LoadDataShedule();
            foreach (DATASHEDULE Item in dataShedules)
            { SheduleDeviceTable.Items.Add(new ListViewItem(new string[] { Item.channelNum.ToString(), Item.startDownloadTime, Item.downloadStartInterval, Item.downloadEndInterval })); }
        }
    }
}
