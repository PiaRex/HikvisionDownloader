using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NVRCsharpDemo
{
    public partial class IntervalForm : Form
    {
        Form scheduleForm;
        DeviceController deviceController = new DeviceController();

        public string selectedDeviceIP;
        public IntervalForm(string deviceIP)
        {
            InitializeComponent();
            selectedDeviceIP = deviceIP;
        }

        private void IntervalForm_Load(object sender, EventArgs e)
        {
            scheduleForm = Application.OpenForms.OfType<ScheduleForm>().FirstOrDefault();
            this.Left = scheduleForm.Left + 320;
            this.Top = scheduleForm.Top;

            deviceController.getDeviceChannel(selectedDeviceIP);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (scheduleForm != null) scheduleForm.Activate();
            else MessageBox.Show("mainWindow");
        }

        private void OKButton_Click(object sender, EventArgs e)
        {

        }
    }
}
