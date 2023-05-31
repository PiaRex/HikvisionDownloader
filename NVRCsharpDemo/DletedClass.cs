/*        private void btnDownloadTime_Click(object sender, EventArgs e)
        {
            if (m_lDownHandle >= 0)
            {
                MessageBox.Show("Downloading, please stop firstly!");//Please stop downloading
                return;
            }

            CHCNetSDK.NET_DVR_PLAYCOND struDownPara = new CHCNetSDK.NET_DVR_PLAYCOND();
            struDownPara.dwChannel = (uint)iChannelNum[(int)iSelIndex]; //Channel number  

            //Set the starting time
            struDownPara.struStartTime.dwYear = (uint)dateTimeStart.Value.Year;
            struDownPara.struStartTime.dwMonth = (uint)dateTimeStart.Value.Month;
            struDownPara.struStartTime.dwDay = (uint)dateTimeStart.Value.Day;
            struDownPara.struStartTime.dwHour = (uint)dateTimeStart.Value.Hour;
            struDownPara.struStartTime.dwMinute = (uint)dateTimeStart.Value.Minute;
            struDownPara.struStartTime.dwSecond = (uint)dateTimeStart.Value.Second;

            //Set the stopping time
            struDownPara.struStopTime.dwYear = (uint)dateTimeEnd.Value.Year;
            struDownPara.struStopTime.dwMonth = (uint)dateTimeEnd.Value.Month;
            struDownPara.struStopTime.dwDay = (uint)dateTimeEnd.Value.Day;
            struDownPara.struStopTime.dwHour = (uint)dateTimeEnd.Value.Hour;
            struDownPara.struStopTime.dwMinute = (uint)dateTimeEnd.Value.Minute;
            struDownPara.struStopTime.dwSecond = (uint)dateTimeEnd.Value.Second;

            string sVideoFileName;  //the path and file name to save      
            sVideoFileName = "D:\\Downtest_Channel"+struDownPara.dwChannel+".mp4";

            //Download by time
            m_lDownHandle = CHCNetSDK.NET_DVR_GetFileByTime_V40(m_lUserID, sVideoFileName, ref struDownPara);
            if (m_lDownHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GetFileByTime_V40 failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }

            uint iOutValue = 0;
            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //Download controlling failed,print error code
                MessageBox.Show(str);
                return;
            }

            timerDownload.Interval = 1000;
            timerDownload.Enabled = true;
            btnStopDownload.Enabled = true;
        }

        private void btnDownloadName_Click(object sender, EventArgs e)
        {
            if (m_lDownHandle >= 0)
            {
                MessageBox.Show("Downloading, please stop firstly!");//Please stop downloading
                return;
            }

            string sVideoFileName;  //the path and file name to save      
            sVideoFileName = "Downtest_"+sPlayBackFileName+".mp4";

            //Download by file name
            m_lDownHandle = CHCNetSDK.NET_DVR_GetFileByName(m_lUserID, sPlayBackFileName, sVideoFileName);
            if (m_lDownHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GetFileByName failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }

            uint iOutValue = 0;

            //Set format of transfer package.
            //UInt32 iInValue = 5;
            //IntPtr lpInValue = Marshal.AllocHGlobal(4);
            //Marshal.StructureToPtr(iInValue, lpInValue, false);

            //if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_SET_TRANS_TYPE, lpInValue, 4, IntPtr.Zero, ref iOutValue))
            //{
            //    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
            //    str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //Download controlling failed,print error code
            //    MessageBox.Show(str);
            //    return;
            //}

            if (!CHCNetSDK.NET_DVR_PlayBackControl_V40(m_lDownHandle, CHCNetSDK.NET_DVR_PLAYSTART, IntPtr.Zero, 0, IntPtr.Zero, ref iOutValue))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_PLAYSTART failed, error code= " + iLastErr; //Download controlling failed,print error code
                MessageBox.Show(str);
                return;
            }
            timerDownload.Interval = 1000;
            timerDownload.Enabled = true;
            btnStopDownload.Enabled = true;
        }

        private void btnStopDownload_Click(object sender, EventArgs e)
        {
            if(m_lDownHandle<0)
            {
                return;            
            }

            if (!CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_StopGetFile failed, error code= " + iLastErr; //Download controlling failed,print error code
                MessageBox.Show(str);
                return;
            }

            timerDownload.Stop(); 

            MessageBox.Show("The downloading has been stopped succesfully!");
            m_lDownHandle = -1;
            DownloadProgressBar.Value = 0;
            btnStopDownload.Enabled = true;
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            DownloadProgressBar.Maximum = 100;
            DownloadProgressBar.Minimum = 0;

            int iPos = 0;

            //Get downloading process
            iPos = CHCNetSDK.NET_DVR_GetDownloadPos(m_lDownHandle);

            if ((iPos > DownloadProgressBar.Minimum) && (iPos < DownloadProgressBar.Maximum))
            {
                DownloadProgressBar.Value = iPos;            
            }

            if (iPos == 100)  //Finish downloading
            {
                DownloadProgressBar.Value = iPos;
                if (!CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopGetFile failed, error code= " + iLastErr; //Download controlling failed,print error code
                    MessageBox.Show(str);
                    return;
                }
                m_lDownHandle = -1;
                timerDownload.Stop(); 
            }

            if (iPos == 200) //Network abnormal,download failed
            {
                MessageBox.Show("The downloading is abnormal for the abnormal network!");
                timerDownload.Stop();
            }
        }*/