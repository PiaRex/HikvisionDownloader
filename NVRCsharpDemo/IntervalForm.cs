using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DATAREG = NVRCsharpDemo.ConfigurationData.DataReg;
using DATASHEDULE = NVRCsharpDemo.ConfigurationData.DataShedule;
using CHANNEL = NVRCsharpDemo.ConfigurationData.Channel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;

namespace NVRCsharpDemo
{
    public partial class IntervalForm : Form
    {
        MainWindow mainWindow;

        public Form scheduleForm;
        DeviceController deviceController = new DeviceController();

        public string selectedDeviceIP;
        public IntervalForm(string deviceIP, MainWindow window)
        {
            InitializeComponent();

            mainWindow = window;
            selectedDeviceIP = deviceIP;
            List<CHANNEL> channelList = deviceController.getDeviceChannel(selectedDeviceIP);
            foreach (CHANNEL Item in channelList)
            {
                if (Ch1CheckBox.Text == Item.ChannelNum.ToString() & Item.IPID == 0) Ch1CheckBox.Enabled = false; 
                else if (Ch1CheckBox.Text == Item.ChannelNum.ToString() & Item.IPID != 0) Ch1CheckBox.Enabled = true;
                if (Ch2CheckBox.Text == Item.ChannelNum.ToString() & Item.IPID == 0) Ch2CheckBox.Enabled = false;
                else if (Ch2CheckBox.Text == Item.ChannelNum.ToString() & Item.IPID != 0) Ch2CheckBox.Enabled = true;
                if (Ch3CheckBox.Text == Item.ChannelNum.ToString() & Item.IPID == 0) Ch1CheckBox.Enabled = false;
                else if (Ch3CheckBox.Text == Item.ChannelNum.ToString() & Item.IPID != 0) Ch3CheckBox.Enabled = true;
                if (Ch4CheckBox.Text == Item.ChannelNum.ToString() & Item.IPID == 0) Ch4CheckBox.Enabled = false;
                else if (Ch4CheckBox.Text == Item.ChannelNum.ToString() & Item.IPID != 0) Ch4CheckBox.Enabled = true;
            }
        }

        private void IntervalForm_Load(object sender, EventArgs e)
        {
            scheduleForm = Application.OpenForms.OfType<ScheduleForm>().FirstOrDefault();
            this.Left = scheduleForm.Left + 320;
            this.Top = scheduleForm.Top;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            scheduleForm.Activate();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (Ch1CheckBox.Checked)
            {
                addNewShedule(1);
            }
            if (Ch2CheckBox.Checked)
            {
                addNewShedule(2);
            }
            if (Ch3CheckBox.Checked)
            {
                addNewShedule(3);
            }
            if (Ch4CheckBox.Checked)
            {
                addNewShedule(4);
            }
            this.Close();
            scheduleForm.Refresh();
            mainWindow.RefreshSheduleTable();
        }

        private void addNewShedule(int channel)
        {
            List<DATASHEDULE> dataSheduleList = FileOperations.LoadDataShedule();
            dataSheduleList.Add(new DATASHEDULE
            {
                DeviceIP = selectedDeviceIP,
                channelNum = channel,
                startDownloadTime = StartDownloadTextbox.Text,
                downloadStartInterval = StartTimeText.Text,
                downloadEndInterval = EndTimeText.Text
            });
            FileOperations.SaveDataSchedule(dataSheduleList);
        }

        private void StartDownloadTextbox_Validating(object sender, CancelEventArgs e) { ValidateTextBox(StartDownloadTextbox); }

        private void StartTimeText_Validating(object sender, CancelEventArgs e) {  ValidateTextBox(StartTimeText); }

        private void EndTimeText_Validating(object sender, CancelEventArgs e) {  ValidateTextBox(EndTimeText);}

        private void ValidateTextBox(MaskedTextBox textBox)
        {
            // Проверяем, что значение в maskedTextBox соответствует формату времени HH:mm
            DateTime dt;
            if (!DateTime.TryParseExact(textBox.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                // Если значение не соответствует формату, то сбросить на предыдущее корректное
                MessageBox.Show("Введите время в формате HH:mm");
               // e.Cancel = true;
                textBox.Text = textBox.Tag.ToString();
            }
            else
            {
                // Запоминаем текущее корректное значение в Tag для использования в следующий раз
                textBox.Tag = textBox.Text;
            }
        }

    }
}
