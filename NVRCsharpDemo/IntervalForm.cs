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
        public IntervalForm()
        {
            InitializeComponent();
        }

        private void IntervalForm_Load(object sender, EventArgs e)
        {
            scheduleForm = Application.OpenForms.OfType<ScheduleForm>().FirstOrDefault();
            this.Left = scheduleForm.Left + 320;
            this.Top = scheduleForm.Top;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.Hide();
            if (scheduleForm != null)
            {

                scheduleForm.Activate();
                scheduleForm.Enabled = true;
                scheduleForm.TopMost = true;
            }
            else MessageBox.Show("mainWindow");
        }
    
    }
}
