using System.ComponentModel;
using System.Windows.Forms;

namespace NVRCsharpDemo
{
    partial class IntervalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntervalForm));
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ChannelsGroupBox = new System.Windows.Forms.GroupBox();
            this.Ch4CheckBox = new System.Windows.Forms.CheckBox();
            this.Ch3CheckBox = new System.Windows.Forms.CheckBox();
            this.Ch2CheckBox = new System.Windows.Forms.CheckBox();
            this.Ch1CheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EndTimeText = new System.Windows.Forms.MaskedTextBox();
            this.StartTimeText = new System.Windows.Forms.MaskedTextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StartDownloadTextbox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TriesCountTextBox = new System.Windows.Forms.MaskedTextBox();
            this.ChannelsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 83);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 13);
            this.label17.TabIndex = 65;
            this.label17.Text = "Конечное время:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 13);
            this.label16.TabIndex = 64;
            this.label16.Text = "Начальное время:";
            // 
            // ChannelsGroupBox
            // 
            this.ChannelsGroupBox.Controls.Add(this.Ch4CheckBox);
            this.ChannelsGroupBox.Controls.Add(this.Ch3CheckBox);
            this.ChannelsGroupBox.Controls.Add(this.Ch2CheckBox);
            this.ChannelsGroupBox.Controls.Add(this.Ch1CheckBox);
            this.ChannelsGroupBox.Location = new System.Drawing.Point(15, 35);
            this.ChannelsGroupBox.Name = "ChannelsGroupBox";
            this.ChannelsGroupBox.Size = new System.Drawing.Size(196, 75);
            this.ChannelsGroupBox.TabIndex = 67;
            this.ChannelsGroupBox.TabStop = false;
            this.ChannelsGroupBox.Text = "Каналы";
            // 
            // Ch4CheckBox
            // 
            this.Ch4CheckBox.AutoSize = true;
            this.Ch4CheckBox.Location = new System.Drawing.Point(132, 32);
            this.Ch4CheckBox.Name = "Ch4CheckBox";
            this.Ch4CheckBox.Size = new System.Drawing.Size(32, 17);
            this.Ch4CheckBox.TabIndex = 4;
            this.Ch4CheckBox.Text = "4";
            this.Ch4CheckBox.UseVisualStyleBackColor = true;
            // 
            // Ch3CheckBox
            // 
            this.Ch3CheckBox.AutoSize = true;
            this.Ch3CheckBox.Location = new System.Drawing.Point(94, 32);
            this.Ch3CheckBox.Name = "Ch3CheckBox";
            this.Ch3CheckBox.Size = new System.Drawing.Size(32, 17);
            this.Ch3CheckBox.TabIndex = 3;
            this.Ch3CheckBox.Text = "3";
            this.Ch3CheckBox.UseVisualStyleBackColor = true;
            // 
            // Ch2CheckBox
            // 
            this.Ch2CheckBox.AutoSize = true;
            this.Ch2CheckBox.Location = new System.Drawing.Point(56, 32);
            this.Ch2CheckBox.Name = "Ch2CheckBox";
            this.Ch2CheckBox.Size = new System.Drawing.Size(32, 17);
            this.Ch2CheckBox.TabIndex = 2;
            this.Ch2CheckBox.Text = "2";
            this.Ch2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Ch1CheckBox
            // 
            this.Ch1CheckBox.AutoSize = true;
            this.Ch1CheckBox.Location = new System.Drawing.Point(18, 32);
            this.Ch1CheckBox.Name = "Ch1CheckBox";
            this.Ch1CheckBox.Size = new System.Drawing.Size(32, 17);
            this.Ch1CheckBox.TabIndex = 1;
            this.Ch1CheckBox.Text = "1";
            this.Ch1CheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EndTimeText);
            this.groupBox1.Controls.Add(this.StartTimeText);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Location = new System.Drawing.Point(15, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 147);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Интервал";
            // 
            // EndTimeText
            // 
            this.EndTimeText.Location = new System.Drawing.Point(18, 99);
            this.EndTimeText.Mask = "00:00";
            this.EndTimeText.Name = "EndTimeText";
            this.EndTimeText.Size = new System.Drawing.Size(42, 20);
            this.EndTimeText.TabIndex = 67;
            this.EndTimeText.Tag = this.EndTimeText.Text;
            this.EndTimeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EndTimeText.ValidatingType = typeof(System.DateTime);
            this.EndTimeText.Validating += new System.ComponentModel.CancelEventHandler(this.EndTimeText_Validating);
            // 
            // StartTimeText
            // 
            this.StartTimeText.Location = new System.Drawing.Point(18, 43);
            this.StartTimeText.Mask = "00:00";
            this.StartTimeText.Name = "StartTimeText";
            this.StartTimeText.Size = new System.Drawing.Size(42, 20);
            this.StartTimeText.TabIndex = 66;
            this.StartTimeText.Tag = this.StartTimeText.Text;
            this.StartTimeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StartTimeText.ValidatingType = typeof(System.DateTime);
            this.StartTimeText.Validating += new System.ComponentModel.CancelEventHandler(this.StartTimeText_Validating);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(71, 339);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(59, 23);
            this.OKButton.TabIndex = 69;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(136, 339);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 70;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StartDownloadTextbox);
            this.groupBox2.Location = new System.Drawing.Point(15, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 64);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Время начала загрузки";
            // 
            // StartDownloadTextbox
            // 
            this.StartDownloadTextbox.Location = new System.Drawing.Point(18, 29);
            this.StartDownloadTextbox.Mask = "00:00";
            this.StartDownloadTextbox.Name = "StartDownloadTextbox";
            this.StartDownloadTextbox.Size = new System.Drawing.Size(42, 20);
            this.StartDownloadTextbox.TabIndex = 0;
            this.StartDownloadTextbox.Tag = this.StartDownloadTextbox.Text;
            this.StartDownloadTextbox.ValidatingType = typeof(System.DateTime);
            this.StartDownloadTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.StartDownloadTextbox_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Попыток:";
            // 
            // TriesCountTextBox
            // 
            this.TriesCountTextBox.Location = new System.Drawing.Point(187, 9);
            this.TriesCountTextBox.Mask = "0";
            this.TriesCountTextBox.Name = "TriesCountTextBox";
            this.TriesCountTextBox.Size = new System.Drawing.Size(24, 20);
            this.TriesCountTextBox.TabIndex = 73;
            this.TriesCountTextBox.Tag = "";
            this.TriesCountTextBox.Text = "1";
            this.TriesCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IntervalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 367);
            this.Controls.Add(this.TriesCountTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChannelsGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IntervalForm";
            this.Text = "Новый интервал";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.IntervalForm_Load);
            this.ChannelsGroupBox.ResumeLayout(false);
            this.ChannelsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox ChannelsGroupBox;
        private System.Windows.Forms.CheckBox Ch4CheckBox;
        private System.Windows.Forms.CheckBox Ch3CheckBox;
        private System.Windows.Forms.CheckBox Ch2CheckBox;
        private System.Windows.Forms.CheckBox Ch1CheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.MaskedTextBox StartTimeText;
        private System.Windows.Forms.MaskedTextBox EndTimeText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox StartDownloadTextbox;
        private Label label1;
        private MaskedTextBox TriesCountTextBox;
    }
}