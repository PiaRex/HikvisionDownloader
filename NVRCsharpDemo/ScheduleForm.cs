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
    public partial class ScheduleForm : Form
    {
        Form mainWindow;
        Form IntervalForm = new IntervalForm();
        public ScheduleForm()
        {
            InitializeComponent();
        }
        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            mainWindow = Application.OpenForms.OfType<MainWindow>().FirstOrDefault();
            
            this.Left = mainWindow.Left + 560;
            this.Top = mainWindow.Top + 240;
        }
        private void DelIntervalButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (mainWindow != null) mainWindow.Activate();
        }

        private void AddIntervalButton_Click(object sender, EventArgs e)
        {
            IntervalForm.Left = this.Left + 560;
            IntervalForm.Top = this.Top + 240;
            this.TopMost = false;
            IntervalForm.Show();
        }
    }
}
