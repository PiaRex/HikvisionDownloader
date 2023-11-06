using System.ComponentModel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.DevicesList = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StopDownloadButton = new System.Windows.Forms.Button();
            this.MainDownloadButton = new System.Windows.Forms.Button();
            this.CurrentFolderLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ChooseFolderButton = new System.Windows.Forms.Button();
            this.DelScheduleButton = new System.Windows.Forms.Button();
            this.EditScheduleButton = new System.Windows.Forms.Button();
            this.SheduleTable = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.channel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartDownload = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Start_Interval = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.End_Interval = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tries = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmailStatusLabel = new System.Windows.Forms.Label();
            this.SendEmailButton = new System.Windows.Forms.Button();
            this.timerDownload = new System.Windows.Forms.Timer(this.components);
            this.timerPlayback = new System.Windows.Forms.Timer(this.components);
            this.btn_Exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RenameButtton = new System.Windows.Forms.Button();
            this.DelDeviceButton = new System.Windows.Forms.Button();
            this.AddIntervalButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxDeviceName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.AddDeviceButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.buttonStartService = new System.Windows.Forms.Button();
            this.StatusServiceLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ReceiverEmailText = new System.Windows.Forms.TextBox();
            this.SenderPasswordText = new System.Windows.Forms.TextBox();
            this.SenderEmailText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SMTPPortText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SMTPServerText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DownloadOneRadio = new System.Windows.Forms.RadioButton();
            this.DownloadAllRadio = new System.Windows.Forms.RadioButton();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.DevicesList.Location = new System.Drawing.Point(15, 60);
            this.DevicesList.MultiSelect = false;
            this.DevicesList.Name = "DevicesList";
            this.DevicesList.Size = new System.Drawing.Size(512, 459);
            this.DevicesList.TabIndex = 32;
            this.DevicesList.UseCompatibleStateImageBehavior = false;
            this.DevicesList.View = System.Windows.Forms.View.Details;
            this.DevicesList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.DevicesList_ColumnClick);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Имя";
            this.ColumnHeader1.Width = 165;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "IP-адрес";
            this.ColumnHeader2.Width = 105;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Порт";
            this.columnHeader6.Width = 65;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Пользователь";
            this.columnHeader7.Width = 150;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.CurrentFolderLabel);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.ChooseFolderButton);
            this.groupBox4.Controls.Add(this.DelScheduleButton);
            this.groupBox4.Controls.Add(this.EditScheduleButton);
            this.groupBox4.Controls.Add(this.SheduleTable);
            this.groupBox4.Location = new System.Drawing.Point(561, 35);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1044, 728);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Расписание";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.DownloadOneRadio);
            this.groupBox2.Controls.Add(this.DownloadAllRadio);
            this.groupBox2.Controls.Add(this.StopDownloadButton);
            this.groupBox2.Controls.Add(this.MainDownloadButton);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(855, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(181, 58);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ручная загрузка";
            // 
            // StopDownloadButton
            // 
            this.StopDownloadButton.Image = ((System.Drawing.Image)(resources.GetObject("StopDownloadButton.Image")));
            this.StopDownloadButton.Location = new System.Drawing.Point(138, 16);
            this.StopDownloadButton.Name = "StopDownloadButton";
            this.StopDownloadButton.Size = new System.Drawing.Size(36, 34);
            this.StopDownloadButton.TabIndex = 57;
            this.StopDownloadButton.UseVisualStyleBackColor = true;
            this.StopDownloadButton.Click += new System.EventHandler(this.StopDownloadButton_Click);
            // 
            // MainDownloadButton
            // 
            this.MainDownloadButton.Image = ((System.Drawing.Image)(resources.GetObject("MainDownloadButton.Image")));
            this.MainDownloadButton.Location = new System.Drawing.Point(96, 16);
            this.MainDownloadButton.Name = "MainDownloadButton";
            this.MainDownloadButton.Size = new System.Drawing.Size(36, 34);
            this.MainDownloadButton.TabIndex = 52;
            this.MainDownloadButton.UseVisualStyleBackColor = true;
            this.MainDownloadButton.Click += new System.EventHandler(this.MainDownloadButton_Click);
            // 
            // CurrentFolderLabel
            // 
            this.CurrentFolderLabel.AutoSize = true;
            this.CurrentFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentFolderLabel.Location = new System.Drawing.Point(367, 39);
            this.CurrentFolderLabel.Name = "CurrentFolderLabel";
            this.CurrentFolderLabel.Size = new System.Drawing.Size(114, 13);
            this.CurrentFolderLabel.TabIndex = 56;
            this.CurrentFolderLabel.Text = "CurrentFolderLabel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(229, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Текущий путь сохранения:";
            // 
            // ChooseFolderButton
            // 
            this.ChooseFolderButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChooseFolderButton.CausesValidation = false;
            this.ChooseFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("ChooseFolderButton.Image")));
            this.ChooseFolderButton.Location = new System.Drawing.Point(182, 27);
            this.ChooseFolderButton.Name = "ChooseFolderButton";
            this.ChooseFolderButton.Size = new System.Drawing.Size(41, 37);
            this.ChooseFolderButton.TabIndex = 54;
            this.ChooseFolderButton.UseVisualStyleBackColor = true;
            this.ChooseFolderButton.Click += new System.EventHandler(this.ChooseFolderButton_Click);
            // 
            // DelScheduleButton
            // 
            this.DelScheduleButton.Location = new System.Drawing.Point(116, 27);
            this.DelScheduleButton.Name = "DelScheduleButton";
            this.DelScheduleButton.Size = new System.Drawing.Size(60, 37);
            this.DelScheduleButton.TabIndex = 51;
            this.DelScheduleButton.Text = "Удалить";
            this.DelScheduleButton.UseVisualStyleBackColor = true;
            this.DelScheduleButton.Click += new System.EventHandler(this.DelScheduleButton_Click);
            // 
            // EditScheduleButton
            // 
            this.EditScheduleButton.Location = new System.Drawing.Point(17, 27);
            this.EditScheduleButton.Name = "EditScheduleButton";
            this.EditScheduleButton.Size = new System.Drawing.Size(93, 37);
            this.EditScheduleButton.TabIndex = 50;
            this.EditScheduleButton.Text = "Редактировать";
            this.EditScheduleButton.UseVisualStyleBackColor = true;
            this.EditScheduleButton.Click += new System.EventHandler(this.EditScheduleButton_Click);
            // 
            // SheduleTable
            // 
            this.SheduleTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.DeviceName,
            this.IP,
            this.channel,
            this.StartDownload,
            this.Start_Interval,
            this.End_Interval,
            this.Tries,
            this.status});
            this.SheduleTable.FullRowSelect = true;
            this.SheduleTable.GridLines = true;
            this.SheduleTable.HideSelection = false;
            this.SheduleTable.Location = new System.Drawing.Point(17, 75);
            this.SheduleTable.Name = "SheduleTable";
            this.SheduleTable.Size = new System.Drawing.Size(1019, 641);
            this.SheduleTable.TabIndex = 49;
            this.SheduleTable.UseCompatibleStateImageBehavior = false;
            this.SheduleTable.View = System.Windows.Forms.View.Details;
            this.SheduleTable.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SheduleTable_ColumnClick);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 26;
            // 
            // DeviceName
            // 
            this.DeviceName.Text = "Имя устройства";
            this.DeviceName.Width = 133;
            // 
            // IP
            // 
            this.IP.Text = "IP-адрес";
            this.IP.Width = 85;
            // 
            // channel
            // 
            this.channel.Text = "Канал";
            this.channel.Width = 46;
            // 
            // StartDownload
            // 
            this.StartDownload.Text = "Начало загрузки";
            this.StartDownload.Width = 102;
            // 
            // Start_Interval
            // 
            this.Start_Interval.Text = "Нач.\n время";
            this.Start_Interval.Width = 71;
            // 
            // End_Interval
            // 
            this.End_Interval.Text = "Кон. время";
            this.End_Interval.Width = 70;
            // 
            // Tries
            // 
            this.Tries.Text = "Попыток";
            this.Tries.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Tries.Width = 57;
            // 
            // status
            // 
            this.status.Text = "Статус последней загрузки";
            this.status.Width = 424;
            // 
            // EmailStatusLabel
            // 
            this.EmailStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EmailStatusLabel.Location = new System.Drawing.Point(267, 12);
            this.EmailStatusLabel.Name = "EmailStatusLabel";
            this.EmailStatusLabel.Size = new System.Drawing.Size(1211, 28);
            this.EmailStatusLabel.TabIndex = 60;
            this.EmailStatusLabel.Text = "label7";
            this.EmailStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SendEmailButton
            // 
            this.SendEmailButton.Location = new System.Drawing.Point(154, 153);
            this.SendEmailButton.Name = "SendEmailButton";
            this.SendEmailButton.Size = new System.Drawing.Size(135, 28);
            this.SendEmailButton.TabIndex = 59;
            this.SendEmailButton.Text = "Отправить письмо";
            this.SendEmailButton.UseVisualStyleBackColor = true;
            this.SendEmailButton.Click += new System.EventHandler(this.SendMailButton_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Exit.Font = new System.Drawing.Font("Bahnschrift Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Exit.Location = new System.Drawing.Point(1502, 766);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(103, 40);
            this.btn_Exit.TabIndex = 44;
            this.btn_Exit.Text = "ВЫХОД";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RenameButtton);
            this.groupBox1.Controls.Add(this.DelDeviceButton);
            this.groupBox1.Controls.Add(this.AddIntervalButton);
            this.groupBox1.Controls.Add(this.DevicesList);
            this.groupBox1.Location = new System.Drawing.Point(12, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 531);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Устройства";
            // 
            // RenameButtton
            // 
            this.RenameButtton.Location = new System.Drawing.Point(160, 19);
            this.RenameButtton.Name = "RenameButtton";
            this.RenameButtton.Size = new System.Drawing.Size(101, 35);
            this.RenameButtton.TabIndex = 57;
            this.RenameButtton.Text = "Переименовать";
            this.RenameButtton.UseVisualStyleBackColor = true;
            this.RenameButtton.Click += new System.EventHandler(this.RenameButtton_Click);
            // 
            // DelDeviceButton
            // 
            this.DelDeviceButton.Location = new System.Drawing.Point(267, 19);
            this.DelDeviceButton.Name = "DelDeviceButton";
            this.DelDeviceButton.Size = new System.Drawing.Size(118, 35);
            this.DelDeviceButton.TabIndex = 34;
            this.DelDeviceButton.Text = "Удалить устройство";
            this.DelDeviceButton.UseVisualStyleBackColor = true;
            this.DelDeviceButton.Click += new System.EventHandler(this.DelDeviceButton_Click);
            // 
            // AddIntervalButton
            // 
            this.AddIntervalButton.Location = new System.Drawing.Point(15, 19);
            this.AddIntervalButton.Name = "AddIntervalButton";
            this.AddIntervalButton.Size = new System.Drawing.Size(139, 35);
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
            this.groupBox3.Controls.Add(this.AddDeviceButton);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 191);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            // 
            // textBoxDeviceName
            // 
            this.textBoxDeviceName.Location = new System.Drawing.Point(113, 23);
            this.textBoxDeviceName.Name = "textBoxDeviceName";
            this.textBoxDeviceName.Size = new System.Drawing.Size(117, 20);
            this.textBoxDeviceName.TabIndex = 34;
            this.textBoxDeviceName.Text = "Тест";
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
            this.textBoxPassword.Location = new System.Drawing.Point(113, 127);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(117, 20);
            this.textBoxPassword.TabIndex = 32;
            this.textBoxPassword.Text = "qwer1234";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(113, 101);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(117, 20);
            this.textBoxUserName.TabIndex = 31;
            this.textBoxUserName.Text = "Test";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(113, 75);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(117, 20);
            this.textBoxPort.TabIndex = 30;
            this.textBoxPort.Text = "8000";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(113, 49);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(117, 20);
            this.textBoxIP.TabIndex = 29;
            this.textBoxIP.Text = "178.64.253.11";
            // 
            // AddDeviceButton
            // 
            this.AddDeviceButton.Location = new System.Drawing.Point(94, 153);
            this.AddDeviceButton.Name = "AddDeviceButton";
            this.AddDeviceButton.Size = new System.Drawing.Size(136, 28);
            this.AddDeviceButton.TabIndex = 28;
            this.AddDeviceButton.Text = "Добавить устройство";
            this.AddDeviceButton.Click += new System.EventHandler(this.AddDeviceButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "IP-адрес";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "Пользователь";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Порт";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(1468, 16);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(90, 13);
            this.TimeLabel.TabIndex = 47;
            this.TimeLabel.Text = "Текущее время:";
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.Location = new System.Drawing.Point(1554, 16);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(56, 13);
            this.DateTimeLabel.TabIndex = 48;
            this.DateTimeLabel.Text = "TimeLabel";
            // 
            // buttonStartService
            // 
            this.buttonStartService.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStartService.Location = new System.Drawing.Point(12, 4);
            this.buttonStartService.Name = "buttonStartService";
            this.buttonStartService.Size = new System.Drawing.Size(100, 34);
            this.buttonStartService.TabIndex = 35;
            this.buttonStartService.Text = "СТАРТ";
            this.buttonStartService.UseVisualStyleBackColor = true;
            this.buttonStartService.Click += new System.EventHandler(this.buttonStartService_Click);
            // 
            // StatusServiceLabel
            // 
            this.StatusServiceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusServiceLabel.AutoSize = true;
            this.StatusServiceLabel.Font = new System.Drawing.Font("Haettenschweiler", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusServiceLabel.Location = new System.Drawing.Point(118, 4);
            this.StatusServiceLabel.Name = "StatusServiceLabel";
            this.StatusServiceLabel.Size = new System.Drawing.Size(182, 21);
            this.StatusServiceLabel.TabIndex = 49;
            this.StatusServiceLabel.Text = "Статус сервиса: Остановлен";
            this.StatusServiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ReceiverEmailText);
            this.groupBox5.Controls.Add(this.SenderPasswordText);
            this.groupBox5.Controls.Add(this.SendEmailButton);
            this.groupBox5.Controls.Add(this.SenderEmailText);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.SMTPPortText);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.SMTPServerText);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(256, 35);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(299, 191);
            this.groupBox5.TabIndex = 50;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Почта";
            // 
            // ReceiverEmailText
            // 
            this.ReceiverEmailText.Location = new System.Drawing.Point(125, 127);
            this.ReceiverEmailText.Name = "ReceiverEmailText";
            this.ReceiverEmailText.Size = new System.Drawing.Size(164, 20);
            this.ReceiverEmailText.TabIndex = 9;
            // 
            // SenderPasswordText
            // 
            this.SenderPasswordText.Location = new System.Drawing.Point(125, 101);
            this.SenderPasswordText.Name = "SenderPasswordText";
            this.SenderPasswordText.PasswordChar = '*';
            this.SenderPasswordText.Size = new System.Drawing.Size(164, 20);
            this.SenderPasswordText.TabIndex = 8;
            // 
            // SenderEmailText
            // 
            this.SenderEmailText.Location = new System.Drawing.Point(125, 75);
            this.SenderEmailText.Name = "SenderEmailText";
            this.SenderEmailText.Size = new System.Drawing.Size(164, 20);
            this.SenderEmailText.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Почта получателя";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Пароль";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Почта отправителя";
            // 
            // SMTPPortText
            // 
            this.SMTPPortText.Location = new System.Drawing.Point(125, 49);
            this.SMTPPortText.Name = "SMTPPortText";
            this.SMTPPortText.Size = new System.Drawing.Size(164, 20);
            this.SMTPPortText.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Порт";
            // 
            // SMTPServerText
            // 
            this.SMTPServerText.Location = new System.Drawing.Point(125, 23);
            this.SMTPServerText.Name = "SMTPServerText";
            this.SMTPServerText.Size = new System.Drawing.Size(164, 20);
            this.SMTPServerText.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "SMTP-сервер";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.EmailStatusLabel);
            this.groupBox6.Location = new System.Drawing.Point(12, 762);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1484, 44);
            this.groupBox6.TabIndex = 61;
            this.groupBox6.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(6, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(260, 13);
            this.label12.TabIndex = 61;
            this.label12.Text = "Статус последнего отправленного отчёта:";
            // 
            // DownloadOneRadio
            // 
            this.DownloadOneRadio.AutoSize = true;
            this.DownloadOneRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DownloadOneRadio.Location = new System.Drawing.Point(10, 32);
            this.DownloadOneRadio.Name = "DownloadOneRadio";
            this.DownloadOneRadio.Size = new System.Drawing.Size(80, 17);
            this.DownloadOneRadio.TabIndex = 59;
            this.DownloadOneRadio.TabStop = true;
            this.DownloadOneRadio.Text = "Выборочно";
            this.DownloadOneRadio.UseVisualStyleBackColor = true;
            // 
            // DownloadAllRadio
            // 
            this.DownloadAllRadio.AutoSize = true;
            this.DownloadAllRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DownloadAllRadio.Location = new System.Drawing.Point(6, 16);
            this.DownloadAllRadio.Name = "DownloadAllRadio";
            this.DownloadAllRadio.Size = new System.Drawing.Size(84, 17);
            this.DownloadAllRadio.TabIndex = 60;
            this.DownloadAllRadio.TabStop = true;
            this.DownloadAllRadio.Text = "Весь список";
            this.DownloadAllRadio.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1617, 811);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.StatusServiceLabel);
            this.Controls.Add(this.buttonStartService);
            this.Controls.Add(this.DateTimeLabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HikVision Downloader v1.1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView DevicesList;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.ListView SheduleTable;
        private System.Windows.Forms.ColumnHeader DeviceName;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader channel;
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
        private System.Windows.Forms.Button AddDeviceButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader Start_Interval;
        private System.Windows.Forms.ColumnHeader End_Interval;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.Button EditScheduleButton;
        private System.Windows.Forms.Button DelScheduleButton;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDeviceName;
        private System.Windows.Forms.Button buttonStartService;
        public System.Windows.Forms.Label StatusServiceLabel;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader StartDownload;
        private System.Windows.Forms.Button MainDownloadButton;
        private System.Windows.Forms.Button ChooseFolderButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label CurrentFolderLabel;
        private System.Windows.Forms.Button RenameButtton;
        private System.Windows.Forms.Button StopDownloadButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader Tries;
        private System.Windows.Forms.Button SendEmailButton;
        public System.Windows.Forms.Label EmailStatusLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox SMTPServerText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SMTPPortText;
        private System.Windows.Forms.TextBox ReceiverEmailText;
        private System.Windows.Forms.TextBox SenderPasswordText;
        private System.Windows.Forms.TextBox SenderEmailText;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton DownloadAllRadio;
        private System.Windows.Forms.RadioButton DownloadOneRadio;
    }
}

