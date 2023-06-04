namespace NVRCsharpDemo
{
    partial class ScheduleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DeviceNameLavel = new System.Windows.Forms.Label();
            this.AddIntervalButton = new System.Windows.Forms.Button();
            this.DelIntervalButton = new System.Windows.Forms.Button();
            this.SheduleDeviceTable = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Устройство:";
            // 
            // DeviceNameLavel
            // 
            this.DeviceNameLavel.AutoSize = true;
            this.DeviceNameLavel.Location = new System.Drawing.Point(88, 9);
            this.DeviceNameLavel.Name = "DeviceNameLavel";
            this.DeviceNameLavel.Size = new System.Drawing.Size(95, 13);
            this.DeviceNameLavel.TabIndex = 1;
            this.DeviceNameLavel.Text = "DeviceNameLavel";
            // 
            // AddIntervalButton
            // 
            this.AddIntervalButton.Location = new System.Drawing.Point(12, 44);
            this.AddIntervalButton.Name = "AddIntervalButton";
            this.AddIntervalButton.Size = new System.Drawing.Size(119, 23);
            this.AddIntervalButton.TabIndex = 2;
            this.AddIntervalButton.Text = "Добавить интервал";
            this.AddIntervalButton.UseVisualStyleBackColor = true;
            this.AddIntervalButton.Click += new System.EventHandler(this.AddIntervalButton_Click);
            // 
            // DelIntervalButton
            // 
            this.DelIntervalButton.Location = new System.Drawing.Point(137, 44);
            this.DelIntervalButton.Name = "DelIntervalButton";
            this.DelIntervalButton.Size = new System.Drawing.Size(114, 23);
            this.DelIntervalButton.TabIndex = 3;
            this.DelIntervalButton.Text = "Удалить интервал";
            this.DelIntervalButton.UseVisualStyleBackColor = true;
            this.DelIntervalButton.Click += new System.EventHandler(this.DelIntervalButton_Click);
            // 
            // SheduleDeviceTable
            // 
            this.SheduleDeviceTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3});
            this.SheduleDeviceTable.FullRowSelect = true;
            this.SheduleDeviceTable.GridLines = true;
            this.SheduleDeviceTable.HideSelection = false;
            this.SheduleDeviceTable.Location = new System.Drawing.Point(15, 73);
            this.SheduleDeviceTable.Name = "SheduleDeviceTable";
            this.SheduleDeviceTable.Size = new System.Drawing.Size(422, 329);
            this.SheduleDeviceTable.TabIndex = 4;
            this.SheduleDeviceTable.UseCompatibleStateImageBehavior = false;
            this.SheduleDeviceTable.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 26;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Канал";
            this.columnHeader1.Width = 47;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Начало загрузки";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Начальный интервал";
            this.columnHeader2.Width = 123;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Конечный интервал";
            this.columnHeader3.Width = 118;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(372, 408);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(65, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "ОК";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 439);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SheduleDeviceTable);
            this.Controls.Add(this.DelIntervalButton);
            this.Controls.Add(this.AddIntervalButton);
            this.Controls.Add(this.DeviceNameLavel);
            this.Controls.Add(this.label1);
            this.Name = "ScheduleForm";
            this.Text = "Расписание устройства";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.ScheduleForm_Activated);
            this.Load += new System.EventHandler(this.ScheduleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DeviceNameLavel;
        private System.Windows.Forms.Button AddIntervalButton;
        private System.Windows.Forms.Button DelIntervalButton;
        private System.Windows.Forms.ListView SheduleDeviceTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}