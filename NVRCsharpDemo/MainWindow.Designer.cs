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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DelScheduleButton = new System.Windows.Forms.Button();
            this.EditScheduleButton = new System.Windows.Forms.Button();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timerDownload = new System.Windows.Forms.Timer(this.components);
            this.timerPlayback = new System.Windows.Forms.Timer(this.components);
            this.btn_Exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DelDeviceButton = new System.Windows.Forms.Button();
            this.AddIntervalButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxDeviceName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.buttonStartService = new System.Windows.Forms.Button();
            this.StatusServiceLabel = new System.Windows.Forms.Label();
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
            this.columnHeader7});
            this.DevicesList.FullRowSelect = true;
            this.DevicesList.GridLines = true;
            this.DevicesList.HideSelection = false;
            this.DevicesList.Location = new System.Drawing.Point(9, 19);
            this.DevicesList.MultiSelect = false;
            this.DevicesList.Name = "DevicesList";
            this.DevicesList.Size = new System.Drawing.Size(370, 476);
            this.DevicesList.TabIndex = 32;
            this.DevicesList.UseCompatibleStateImageBehavior = false;
            this.DevicesList.View = System.Windows.Forms.View.Details;
            this.DevicesList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewIPChannel_ItemSelectionChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Имя";
            this.ColumnHeader1.Width = 140;
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DelScheduleButton);
            this.groupBox4.Controls.Add(this.EditScheduleButton);
            this.groupBox4.Controls.Add(this.listViewFile);
            this.groupBox4.Location = new System.Drawing.Point(558, 35);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(748, 667);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Расписание";
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
            // EditScheduleButton
            // 
            this.EditScheduleButton.Location = new System.Drawing.Point(17, 26);
            this.EditScheduleButton.Name = "EditScheduleButton";
            this.EditScheduleButton.Size = new System.Drawing.Size(100, 31);
            this.EditScheduleButton.TabIndex = 50;
            this.EditScheduleButton.Text = "Редактировать";
            this.EditScheduleButton.UseVisualStyleBackColor = true;
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
            this.listViewFile.Size = new System.Drawing.Size(703, 590);
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
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(1179, 708);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 509);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Устройства";
            // 
            // DelDeviceButton
            // 
            this.DelDeviceButton.Location = new System.Drawing.Point(385, 60);
            this.DelDeviceButton.Name = "DelDeviceButton";
            this.DelDeviceButton.Size = new System.Drawing.Size(149, 35);
            this.DelDeviceButton.TabIndex = 34;
            this.DelDeviceButton.Text = "Удалить устройство";
            this.DelDeviceButton.UseVisualStyleBackColor = true;
            this.DelDeviceButton.Click += new System.EventHandler(this.DelDeviceButton_Click);
            // 
            // AddIntervalButton
            // 
            this.AddIntervalButton.Location = new System.Drawing.Point(385, 19);
            this.AddIntervalButton.Name = "AddIntervalButton";
            this.AddIntervalButton.Size = new System.Drawing.Size(149, 35);
            this.AddIntervalButton.TabIndex = 33;
            this.AddIntervalButton.Text = "Добавить в расписание";
            this.AddIntervalButton.UseVisualStyleBackColor = true;
            this.AddIntervalButton.Click += new System.EventHandler(this.AddIntervalButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxDeviceName);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxPassword);
            this.groupBox3.Controls.Add(this.textBoxUserName);
            this.groupBox3.Controls.Add(this.textBoxPort);
            this.groupBox3.Controls.Add(this.textBoxIP);
            this.groupBox3.Controls.Add(this.LoginButton);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(540, 159);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            // 
            // textBoxDeviceName
            // 
            this.textBoxDeviceName.Location = new System.Drawing.Point(113, 23);
            this.textBoxDeviceName.Name = "textBoxDeviceName";
            this.textBoxDeviceName.Size = new System.Drawing.Size(147, 20);
            this.textBoxDeviceName.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Имя устройства";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPassword.Location = new System.Drawing.Point(279, 98);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(112, 20);
            this.textBoxPassword.TabIndex = 32;
            this.textBoxPassword.Text = "qwer1234";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(102, 99);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(94, 20);
            this.textBoxUserName.TabIndex = 31;
            this.textBoxUserName.Text = "Test";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(279, 58);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(112, 20);
            this.textBoxPort.TabIndex = 30;
            this.textBoxPort.Text = "8000";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(102, 59);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(94, 20);
            this.textBoxIP.TabIndex = 29;
            this.textBoxIP.Text = "178.64.253.11";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(435, 62);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(90, 54);
            this.LoginButton.TabIndex = 28;
            this.LoginButton.Text = "Добавить устройство";
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "IP-адрес";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "Пользователь";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(219, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(219, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Порт";
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
            // DateTimeLabel
            // 
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.Location = new System.Drawing.Point(96, 9);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(56, 13);
            this.DateTimeLabel.TabIndex = 48;
            this.DateTimeLabel.Text = "TimeLabel";
            // 
            // buttonStartService
            // 
            this.buttonStartService.Location = new System.Drawing.Point(282, 3);
            this.buttonStartService.Name = "buttonStartService";
            this.buttonStartService.Size = new System.Drawing.Size(116, 33);
            this.buttonStartService.TabIndex = 35;
            this.buttonStartService.Text = "СТАРТ";
            this.buttonStartService.UseVisualStyleBackColor = true;
            this.buttonStartService.Click += new System.EventHandler(this.buttonStartService_Click);
            // 
            // StatusServiceLabel
            // 
            this.StatusServiceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusServiceLabel.AutoSize = true;
            this.StatusServiceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusServiceLabel.Location = new System.Drawing.Point(571, 5);
            this.StatusServiceLabel.Name = "StatusServiceLabel";
            this.StatusServiceLabel.Size = new System.Drawing.Size(297, 24);
            this.StatusServiceLabel.TabIndex = 49;
            this.StatusServiceLabel.Text = "Статус сервиса: Остановлен";
            this.StatusServiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 752);
            this.Controls.Add(this.StatusServiceLabel);
            this.Controls.Add(this.buttonStartService);
            this.Controls.Add(this.DateTimeLabel);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddIntervalButton;
        private System.Windows.Forms.Button DelDeviceButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button LoginButton;
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
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDeviceName;
        private System.Windows.Forms.Button buttonStartService;
        public System.Windows.Forms.Label StatusServiceLabel;
    }
}

