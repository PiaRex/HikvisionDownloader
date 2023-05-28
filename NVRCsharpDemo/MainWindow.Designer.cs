﻿namespace NVRCsharpDemo
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
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.VideoPlayWnd = new System.Windows.Forms.PictureBox();
            this.listViewIPChannel = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSound = new System.Windows.Forms.Label();
            this.btnSound = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.labelReverse = new System.Windows.Forms.Label();
            this.btnReverse = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelPause = new System.Windows.Forms.Label();
            this.btnFrame = new System.Windows.Forms.Button();
            this.btnFast = new System.Windows.Forms.Button();
            this.btnSlow = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBMP = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnStopDownload = new System.Windows.Forms.Button();
            this.btnDownloadName = new System.Windows.Forms.Button();
            this.btnDownloadTime = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnPlaybackTime = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnStopPlayback = new System.Windows.Forms.Button();
            this.btnPlaybackName = new System.Windows.Forms.Button();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.timerDownload = new System.Windows.Forms.Timer(this.components);
            this.PlaybackprogressBar = new System.Windows.Forms.ProgressBar();
            this.timerPlayback = new System.Windows.Forms.Timer(this.components);
            this.btn_Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayWnd)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPassword.Location = new System.Drawing.Point(330, 70);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(112, 20);
            this.textBoxPassword.TabIndex = 23;
            this.textBoxPassword.Text = "12345";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(87, 70);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(114, 20);
            this.textBoxUserName.TabIndex = 22;
            this.textBoxUserName.Text = "admin";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(330, 21);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(112, 20);
            this.textBoxPort.TabIndex = 21;
            this.textBoxPort.Text = "8000";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(87, 21);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(114, 20);
            this.textBoxIP.TabIndex = 20;
            this.textBoxIP.Text = "172.6.22.19";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(478, 27);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(78, 54);
            this.btnLogin.TabIndex = 19;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Device IP";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "User Name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(256, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(256, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Device Port";
            // 
            // VideoPlayWnd
            // 
            this.VideoPlayWnd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.VideoPlayWnd.Location = new System.Drawing.Point(184, 112);
            this.VideoPlayWnd.Name = "VideoPlayWnd";
            this.VideoPlayWnd.Size = new System.Drawing.Size(440, 396);
            this.VideoPlayWnd.TabIndex = 30;
            this.VideoPlayWnd.TabStop = false;
            // 
            // listViewIPChannel
            // 
            this.listViewIPChannel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.listViewIPChannel.FullRowSelect = true;
            this.listViewIPChannel.GridLines = true;
            this.listViewIPChannel.HideSelection = false;
            this.listViewIPChannel.Location = new System.Drawing.Point(4, 112);
            this.listViewIPChannel.MultiSelect = false;
            this.listViewIPChannel.Name = "listViewIPChannel";
            this.listViewIPChannel.Size = new System.Drawing.Size(174, 407);
            this.listViewIPChannel.TabIndex = 32;
            this.listViewIPChannel.UseCompatibleStateImageBehavior = false;
            this.listViewIPChannel.View = System.Windows.Forms.View.Details;
            this.listViewIPChannel.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewIPChannel_ItemSelectionChanged);
            this.listViewIPChannel.SelectedIndexChanged += new System.EventHandler(this.listViewIPChannel_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Channel";
            this.ColumnHeader1.Width = 90;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Status";
            this.ColumnHeader2.Width = 90;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 532);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "* DEMO just for reference！";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(5, 518);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 130);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.labelSound);
            this.groupBox2.Controls.Add(this.btnSound);
            this.groupBox2.Controls.Add(this.btnResume);
            this.groupBox2.Controls.Add(this.labelReverse);
            this.groupBox2.Controls.Add(this.btnReverse);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.labelPause);
            this.groupBox2.Controls.Add(this.btnFrame);
            this.groupBox2.Controls.Add(this.btnFast);
            this.groupBox2.Controls.Add(this.btnSlow);
            this.groupBox2.Controls.Add(this.btnPause);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.btnBMP);
            this.groupBox2.Location = new System.Drawing.Point(184, 518);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 130);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Normal Speed";
            // 
            // labelSound
            // 
            this.labelSound.AutoSize = true;
            this.labelSound.Location = new System.Drawing.Point(13, 107);
            this.labelSound.Name = "labelSound";
            this.labelSound.Size = new System.Drawing.Size(63, 13);
            this.labelSound.TabIndex = 52;
            this.labelSound.Text = "Open Audio";
            // 
            // btnSound
            // 
            this.btnSound.Location = new System.Drawing.Point(7, 77);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(75, 25);
            this.btnSound.TabIndex = 51;
            this.btnSound.Text = "Sound";
            this.btnSound.UseVisualStyleBackColor = true;
            this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(140, 20);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(85, 25);
            this.btnResume.TabIndex = 49;
            this.btnResume.Text = "Normal Speed";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // labelReverse
            // 
            this.labelReverse.AutoSize = true;
            this.labelReverse.Location = new System.Drawing.Point(304, 53);
            this.labelReverse.Name = "labelReverse";
            this.labelReverse.Size = new System.Drawing.Size(47, 13);
            this.labelReverse.TabIndex = 48;
            this.labelReverse.Text = "Reserve";
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(287, 20);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(75, 25);
            this.btnReverse.TabIndex = 47;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.button1_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(227, 53);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 13);
            this.label23.TabIndex = 46;
            this.label23.Text = "Sigle Frame";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(98, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Fast";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(54, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Slow";
            // 
            // labelPause
            // 
            this.labelPause.AutoSize = true;
            this.labelPause.Location = new System.Drawing.Point(11, 53);
            this.labelPause.Name = "labelPause";
            this.labelPause.Size = new System.Drawing.Size(37, 13);
            this.labelPause.TabIndex = 43;
            this.labelPause.Text = "Pause";
            // 
            // btnFrame
            // 
            this.btnFrame.Location = new System.Drawing.Point(231, 20);
            this.btnFrame.Name = "btnFrame";
            this.btnFrame.Size = new System.Drawing.Size(50, 25);
            this.btnFrame.TabIndex = 42;
            this.btnFrame.Text = "|>";
            this.btnFrame.UseVisualStyleBackColor = true;
            this.btnFrame.Click += new System.EventHandler(this.btnFrame_Click);
            // 
            // btnFast
            // 
            this.btnFast.Location = new System.Drawing.Point(93, 20);
            this.btnFast.Name = "btnFast";
            this.btnFast.Size = new System.Drawing.Size(41, 25);
            this.btnFast.TabIndex = 41;
            this.btnFast.Text = ">>";
            this.btnFast.UseVisualStyleBackColor = true;
            this.btnFast.Click += new System.EventHandler(this.btnFast_Click);
            // 
            // btnSlow
            // 
            this.btnSlow.Location = new System.Drawing.Point(48, 20);
            this.btnSlow.Name = "btnSlow";
            this.btnSlow.Size = new System.Drawing.Size(41, 25);
            this.btnSlow.TabIndex = 40;
            this.btnSlow.Text = "<<";
            this.btnSlow.UseVisualStyleBackColor = true;
            this.btnSlow.Click += new System.EventHandler(this.btnSlow_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(7, 20);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(37, 25);
            this.btnPause.TabIndex = 39;
            this.btnPause.Text = "||";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(98, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "BMP SnapShot";
            // 
            // btnBMP
            // 
            this.btnBMP.Location = new System.Drawing.Point(100, 77);
            this.btnBMP.Name = "btnBMP";
            this.btnBMP.Size = new System.Drawing.Size(56, 25);
            this.btnBMP.TabIndex = 36;
            this.btnBMP.Text = "BMP";
            this.btnBMP.UseVisualStyleBackColor = true;
            this.btnBMP.Click += new System.EventHandler(this.btnBMP_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(4, -1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(620, 105);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart.Location = new System.Drawing.Point(101, 28);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(158, 20);
            this.dateTimeStart.TabIndex = 42;
            this.dateTimeStart.UseWaitCursor = true;
            this.dateTimeStart.Value = new System.DateTime(2014, 2, 28, 14, 43, 28, 0);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DownloadProgressBar);
            this.groupBox4.Controls.Add(this.btnStopDownload);
            this.groupBox4.Controls.Add(this.btnDownloadName);
            this.groupBox4.Controls.Add(this.btnDownloadTime);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.btnPlaybackTime);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.btnStopPlayback);
            this.groupBox4.Controls.Add(this.btnPlaybackName);
            this.groupBox4.Controls.Add(this.listViewFile);
            this.groupBox4.Controls.Add(this.btnSearch);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.dateTimeEnd);
            this.groupBox4.Controls.Add(this.dateTimeStart);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Location = new System.Drawing.Point(630, -1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(296, 649);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Location = new System.Drawing.Point(4, 572);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(283, 11);
            this.DownloadProgressBar.TabIndex = 61;
            // 
            // btnStopDownload
            // 
            this.btnStopDownload.Enabled = false;
            this.btnStopDownload.Location = new System.Drawing.Point(161, 522);
            this.btnStopDownload.Name = "btnStopDownload";
            this.btnStopDownload.Size = new System.Drawing.Size(126, 35);
            this.btnStopDownload.TabIndex = 60;
            this.btnStopDownload.Text = "Stop Download";
            this.btnStopDownload.UseVisualStyleBackColor = true;
            this.btnStopDownload.Click += new System.EventHandler(this.btnStopDownload_Click);
            // 
            // btnDownloadName
            // 
            this.btnDownloadName.Location = new System.Drawing.Point(161, 445);
            this.btnDownloadName.Name = "btnDownloadName";
            this.btnDownloadName.Size = new System.Drawing.Size(126, 35);
            this.btnDownloadName.TabIndex = 59;
            this.btnDownloadName.Text = "Download By Name";
            this.btnDownloadName.UseVisualStyleBackColor = true;
            this.btnDownloadName.Click += new System.EventHandler(this.btnDownloadName_Click);
            // 
            // btnDownloadTime
            // 
            this.btnDownloadTime.Location = new System.Drawing.Point(161, 135);
            this.btnDownloadTime.Name = "btnDownloadTime";
            this.btnDownloadTime.Size = new System.Drawing.Size(126, 31);
            this.btnDownloadTime.TabIndex = 58;
            this.btnDownloadTime.Text = "Download By Time";
            this.btnDownloadTime.UseVisualStyleBackColor = true;
            this.btnDownloadTime.Click += new System.EventHandler(this.btnDownloadTime_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(99, 417);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(163, 13);
            this.label22.TabIndex = 57;
            this.label22.Text = "Playback/Download by file name";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(108, 176);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 13);
            this.label19.TabIndex = 50;
            this.label19.Text = "Search for recording";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(99, 109);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(140, 13);
            this.label20.TabIndex = 56;
            this.label20.Text = "Playback/Download by time";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(108, 501);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(129, 13);
            this.label21.TabIndex = 54;
            this.label21.Text = "Stop Playback/Download";
            // 
            // btnPlaybackTime
            // 
            this.btnPlaybackTime.Location = new System.Drawing.Point(10, 135);
            this.btnPlaybackTime.Name = "btnPlaybackTime";
            this.btnPlaybackTime.Size = new System.Drawing.Size(124, 31);
            this.btnPlaybackTime.TabIndex = 55;
            this.btnPlaybackTime.Text = "PlayBack By Time";
            this.btnPlaybackTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlaybackTime.UseVisualStyleBackColor = true;
            this.btnPlaybackTime.Click += new System.EventHandler(this.btnPlaybackTime_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(4, 173);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(289, 11);
            this.groupBox6.TabIndex = 45;
            this.groupBox6.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(3, 498);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(289, 11);
            this.groupBox5.TabIndex = 44;
            this.groupBox5.TabStop = false;
            // 
            // btnStopPlayback
            // 
            this.btnStopPlayback.Enabled = false;
            this.btnStopPlayback.Location = new System.Drawing.Point(9, 522);
            this.btnStopPlayback.Name = "btnStopPlayback";
            this.btnStopPlayback.Size = new System.Drawing.Size(125, 37);
            this.btnStopPlayback.TabIndex = 53;
            this.btnStopPlayback.Text = "Stop PlayBack";
            this.btnStopPlayback.UseVisualStyleBackColor = true;
            this.btnStopPlayback.Click += new System.EventHandler(this.btnStopPlayback_Click);
            // 
            // btnPlaybackName
            // 
            this.btnPlaybackName.Location = new System.Drawing.Point(9, 445);
            this.btnPlaybackName.Name = "btnPlaybackName";
            this.btnPlaybackName.Size = new System.Drawing.Size(125, 35);
            this.btnPlaybackName.TabIndex = 51;
            this.btnPlaybackName.Text = "PlayBack By Name";
            this.btnPlaybackName.UseVisualStyleBackColor = true;
            this.btnPlaybackName.Click += new System.EventHandler(this.btnPlaybackName_Click);
            // 
            // listViewFile
            // 
            this.listViewFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewFile.FullRowSelect = true;
            this.listViewFile.GridLines = true;
            this.listViewFile.HideSelection = false;
            this.listViewFile.Location = new System.Drawing.Point(4, 200);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(290, 163);
            this.listViewFile.TabIndex = 49;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            this.listViewFile.SelectedIndexChanged += new System.EventHandler(this.listViewFile_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "File Name";
            this.columnHeader3.Width = 93;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Starting Time";
            this.columnHeader4.Width = 109;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ending Time";
            this.columnHeader5.Width = 113;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(9, 373);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(125, 35);
            this.btnSearch.TabIndex = 48;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 47;
            this.label17.Text = "Ending time";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 45;
            this.label16.Text = "Beginning time";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(101, 74);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(156, 20);
            this.dateTimeEnd.TabIndex = 43;
            this.dateTimeEnd.Value = new System.DateTime(2014, 2, 28, 14, 40, 31, 0);
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(4, 107);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(289, 11);
            this.groupBox7.TabIndex = 46;
            this.groupBox7.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(4, 414);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(289, 11);
            this.groupBox8.TabIndex = 46;
            this.groupBox8.TabStop = false;
            // 
            // timerDownload
            // 
            this.timerDownload.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // PlaybackprogressBar
            // 
            this.PlaybackprogressBar.Location = new System.Drawing.Point(184, 510);
            this.PlaybackprogressBar.Name = "PlaybackprogressBar";
            this.PlaybackprogressBar.Size = new System.Drawing.Size(440, 11);
            this.PlaybackprogressBar.TabIndex = 43;
            // 
            // timerPlayback
            // 
            this.timerPlayback.Tick += new System.EventHandler(this.timerPlayback_Tick);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(790, 655);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(127, 32);
            this.btn_Exit.TabIndex = 44;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 697);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.PlaybackprogressBar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listViewIPChannel);
            this.Controls.Add(this.VideoPlayWnd);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Window";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayWnd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox VideoPlayWnd;
        private System.Windows.Forms.ListView listViewIPChannel;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnPlaybackName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnStopPlayback;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnPlaybackTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnBMP;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.Button btnSlow;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnFrame;
        private System.Windows.Forms.Label labelPause;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnDownloadName;
        private System.Windows.Forms.Button btnDownloadTime;
        private System.Windows.Forms.Button btnStopDownload;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.Timer timerDownload;
        private System.Windows.Forms.ProgressBar PlaybackprogressBar;
        private System.Windows.Forms.Timer timerPlayback;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label labelSound;
        private System.Windows.Forms.Button btnSound;
        private System.Windows.Forms.Label labelReverse;
        private System.Windows.Forms.Label label5;
    }
}

