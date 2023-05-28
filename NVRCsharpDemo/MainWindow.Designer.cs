namespace NVRCsharpDemo
{
    partial class MainWindow
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
            if (m_lPlayHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopPlayBack(m_lPlayHandle);
            }
            if (m_lDownHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle);

            }
            if (m_lUserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
            }
            if (m_bInitSDK == true)
            {
                CHCNetSDK.NET_DVR_Cleanup();
            }

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
            this.components = new System.ComponentModel.Container();
            this.DevicesList = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timerDownload = new System.Windows.Forms.Timer(this.components);
            this.timerPlayback = new System.Windows.Forms.Timer(this.components);
            this.btn_Exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DelDeviceButton = new System.Windows.Forms.Button();
            this.AddIntervalButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EditScheduleButton = new System.Windows.Forms.Button();
            this.DelScheduleButton = new System.Windows.Forms.Button();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DevicesList
            // 
            this.DevicesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.DevicesList.FullRowSelect = true;
            this.DevicesList.GridLines = true;
            this.DevicesList.HideSelection = false;
            this.DevicesList.Location = new System.Drawing.Point(9, 19);
            this.DevicesList.MultiSelect = false;
            this.DevicesList.Name = "DevicesList";
            this.DevicesList.Size = new System.Drawing.Size(426, 476);
            this.DevicesList.TabIndex = 32;
            this.DevicesList.UseCompatibleStateImageBehavior = false;
            this.DevicesList.View = System.Windows.Forms.View.Details;
            this.DevicesList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewIPChannel_ItemSelectionChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Имя";
            this.ColumnHeader1.Width = 107;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "IP-адрес";
            this.ColumnHeader2.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Порт";
            this.columnHeader6.Width = 44;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Пользователь";
            this.columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Статус";
            this.columnHeader8.Width = 85;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DelScheduleButton);
            this.groupBox4.Controls.Add(this.EditScheduleButton);
            this.groupBox4.Controls.Add(this.listViewFile);
            this.groupBox4.Location = new System.Drawing.Point(562, 35);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(744, 626);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Расписание";
            // 
            // listViewFile
            // 
            this.listViewFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listViewFile.FullRowSelect = true;
            this.listViewFile.GridLines = true;
            this.listViewFile.HideSelection = false;
            this.listViewFile.Location = new System.Drawing.Point(17, 63);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(703, 551);
            this.listViewFile.TabIndex = 49;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            this.listViewFile.SelectedIndexChanged += new System.EventHandler(this.listViewFile_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Имя устройства";
            this.columnHeader3.Width = 133;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "IP-адрес";
            this.columnHeader4.Width = 96;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Канал";
            this.columnHeader5.Width = 55;
            // 
            // timerDownload
            // 
            this.timerDownload.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // timerPlayback
            // 
            this.timerPlayback.Tick += new System.EventHandler(this.timerPlayback_Tick);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(1179, 676);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(127, 32);
            this.btn_Exit.TabIndex = 44;
            this.btn_Exit.Text = "Выход";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DelDeviceButton);
            this.groupBox1.Controls.Add(this.AddIntervalButton);
            this.groupBox1.Controls.Add(this.DevicesList);
            this.groupBox1.Location = new System.Drawing.Point(12, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 515);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Устройства";
            // 
            // DelDeviceButton
            // 
            this.DelDeviceButton.Location = new System.Drawing.Point(441, 60);
            this.DelDeviceButton.Name = "DelDeviceButton";
            this.DelDeviceButton.Size = new System.Drawing.Size(87, 35);
            this.DelDeviceButton.TabIndex = 34;
            this.DelDeviceButton.Text = "Удалить устройство";
            this.DelDeviceButton.UseVisualStyleBackColor = true;
            this.DelDeviceButton.Click += new System.EventHandler(this.DelDeviceButton_Click);
            // 
            // AddIntervalButton
            // 
            this.AddIntervalButton.Location = new System.Drawing.Point(441, 19);
            this.AddIntervalButton.Name = "AddIntervalButton";
            this.AddIntervalButton.Size = new System.Drawing.Size(87, 35);
            this.AddIntervalButton.TabIndex = 33;
            this.AddIntervalButton.Text = "Добавить в расписание";
            this.AddIntervalButton.UseVisualStyleBackColor = true;
            this.AddIntervalButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxPassword);
            this.groupBox3.Controls.Add(this.textBoxUserName);
            this.groupBox3.Controls.Add(this.textBoxPort);
            this.groupBox3.Controls.Add(this.textBoxIP);
            this.groupBox3.Controls.Add(this.btnLogin);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(544, 105);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPassword.Location = new System.Drawing.Point(304, 67);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(112, 20);
            this.textBoxPassword.TabIndex = 32;
            this.textBoxPassword.Text = "12345";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(98, 67);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(114, 20);
            this.textBoxUserName.TabIndex = 31;
            this.textBoxUserName.Text = "admin";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(304, 19);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(112, 20);
            this.textBoxPort.TabIndex = 30;
            this.textBoxPort.Text = "8000";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(98, 19);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(114, 20);
            this.textBoxIP.TabIndex = 29;
            this.textBoxIP.Text = "172.6.22.19";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(441, 26);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(87, 54);
            this.btnLogin.TabIndex = 28;
            this.btnLogin.Text = "Добавить устройство";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "IP-адрес";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "Пользователь";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(241, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(241, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Порт";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Начальное время";
            this.columnHeader9.Width = 112;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Конечное время";
            this.columnHeader10.Width = 105;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Статус загрузки";
            this.columnHeader11.Width = 197;
            // 
            // EditScheduleButton
            // 
            this.EditScheduleButton.Location = new System.Drawing.Point(17, 26);
            this.EditScheduleButton.Name = "EditScheduleButton";
            this.EditScheduleButton.Size = new System.Drawing.Size(100, 31);
            this.EditScheduleButton.TabIndex = 50;
            this.EditScheduleButton.Text = "Редактировать";
            this.EditScheduleButton.UseVisualStyleBackColor = true;
            // 
            // DelScheduleButton
            // 
            this.DelScheduleButton.Location = new System.Drawing.Point(123, 27);
            this.DelScheduleButton.Name = "DelScheduleButton";
            this.DelScheduleButton.Size = new System.Drawing.Size(75, 30);
            this.DelScheduleButton.TabIndex = 51;
            this.DelScheduleButton.Text = "Удалить";
            this.DelScheduleButton.UseVisualStyleBackColor = true;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(9, 9);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(90, 13);
            this.TimeLabel.TabIndex = 47;
            this.TimeLabel.Text = "Текущее время:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 723);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.groupBox4);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HikVision Downloader v0.1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView DevicesList;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Timer timerDownload;
        private System.Windows.Forms.Timer timerPlayback;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddIntervalButton;
        private System.Windows.Forms.Button DelDeviceButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button EditScheduleButton;
        private System.Windows.Forms.Button DelScheduleButton;
        private System.Windows.Forms.Label TimeLabel;
    }
}

