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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
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
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(15, 73);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(276, 329);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Канал";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Начальное время";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Конечное время";
            this.columnHeader3.Width = 102;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(216, 408);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(135, 408);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 450);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.DelIntervalButton);
            this.Controls.Add(this.AddIntervalButton);
            this.Controls.Add(this.DeviceNameLavel);
            this.Controls.Add(this.label1);
            this.Name = "ScheduleForm";
            this.Text = "Расписание устройства";
            this.Load += new System.EventHandler(this.ScheduleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DeviceNameLavel;
        private System.Windows.Forms.Button AddIntervalButton;
        private System.Windows.Forms.Button DelIntervalButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}