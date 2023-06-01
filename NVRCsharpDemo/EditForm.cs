using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NVRCsharpDemo.ConfigurationData;
using DATAREG = NVRCsharpDemo.ConfigurationData.DataReg;
using DATASHEDULE = NVRCsharpDemo.ConfigurationData.DataShedule;
using CHANNEL = NVRCsharpDemo.ConfigurationData.Channel;

namespace NVRCsharpDemo
{
    public partial class EditForm : Form
    {
        string selectedSheduleID;
        Form mainWindow;
        List<DATAREG> dataRegList;
        List<DATASHEDULE> dataSheduleList;
        DATASHEDULE selectedShedule;
        DATAREG selectedDevice;
        public EditForm(string SheduleID)
        {
            InitializeComponent();
            selectedSheduleID = SheduleID;
            dataRegList = FileOperations.LoadDataReg();
            dataSheduleList = FileOperations.LoadDataShedule();
            selectedShedule = dataSheduleList.FirstOrDefault(x => x.ID.ToString() == selectedSheduleID);
            selectedDevice = dataRegList.FirstOrDefault(x => x.DeviceIP == selectedShedule.DeviceIP);
            DeviceNameLabel.Text = selectedDevice.DeviceName;
            StartDownloadText.Text = selectedShedule.startDownloadTime;
            StartTimeText.Text = selectedShedule.downloadStartInterval;
            EndTimeText.Text = selectedShedule.downloadEndInterval;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            dataSheduleList.FirstOrDefault(x => x.ID.ToString() == selectedSheduleID).startDownloadTime = StartDownloadText.Text;
            dataSheduleList.FirstOrDefault(x => x.ID.ToString() == selectedSheduleID).downloadStartInterval = StartTimeText.Text;
            dataSheduleList.FirstOrDefault(x => x.ID.ToString() == selectedSheduleID).downloadEndInterval = EndTimeText.Text;
            FileOperations.SaveDataSchedule(dataSheduleList);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            mainWindow = Application.OpenForms.OfType<MainWindow>().FirstOrDefault();
            this.Left = mainWindow.Width/2+80;
            this.Top = mainWindow.Top + 140;
        }
    }
}
