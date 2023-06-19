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

namespace NVRCsharpDemo
{

    public partial class RenameDeviceForm : Form
    {
        MainWindow mainWindow;

        public string selectedDeviceIP;
        DATAREG selectedDevice;
        List<DATAREG> dataRegList;
        public RenameDeviceForm(string deviceIP, MainWindow form)
        {
            InitializeComponent();
            mainWindow = form;
            selectedDeviceIP = deviceIP;
            dataRegList = FileOperations.LoadDataReg();
            selectedDevice = dataRegList.FirstOrDefault(x => x.DeviceIP == deviceIP);
            DeviceNameTextbox.Text = selectedDevice.DeviceName;
        }

        private void RenameDeviceForm_Load(object sender, EventArgs e)
        {
            mainWindow = Application.OpenForms.OfType<MainWindow>().FirstOrDefault();
            this.Left = mainWindow.Left + 170;
            this.Top = mainWindow.Top + 270;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            dataRegList.FirstOrDefault(x => x.DeviceIP.ToString() == selectedDevice.DeviceIP).DeviceName = DeviceNameTextbox.Text;
            FileOperations.SaveDataReg(dataRegList);
            mainWindow.RefreshDeviceTable();
            mainWindow.RefreshSheduleTable();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
