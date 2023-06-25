using System.ComponentModel;

namespace NVRCsharpDemo
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartDownloadText = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeviceNameLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EndTimeText = new System.Windows.Forms.MaskedTextBox();
            this.StartTimeText = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.TriesCountTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StartDownloadText);
            this.groupBox1.Location = new System.Drawing.Point(11, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Время начала загрузки";
            // 
            // StartDownloadText
            // 
            this.StartDownloadText.Location = new System.Drawing.Point(18, 28);
            this.StartDownloadText.Mask = "00:00";
            this.StartDownloadText.Name = "StartDownloadText";
            this.StartDownloadText.Size = new System.Drawing.Size(42, 20);
            this.StartDownloadText.TabIndex = 0;
            this.StartDownloadText.Tag = this.StartDownloadText.Text;
            this.StartDownloadText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StartDownloadText.ValidatingType = typeof(System.DateTime);
            this.StartDownloadText.Validating += new System.ComponentModel.CancelEventHandler(this.StartDownloadText_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Устройство:";
            // 
            // DeviceNameLabel
            // 
            this.DeviceNameLabel.AutoSize = true;
            this.DeviceNameLabel.Location = new System.Drawing.Point(88, 9);
            this.DeviceNameLabel.Name = "DeviceNameLabel";
            this.DeviceNameLabel.Size = new System.Drawing.Size(95, 13);
            this.DeviceNameLabel.TabIndex = 2;
            this.DeviceNameLabel.Text = "DeviceNameLabel";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EndTimeText);
            this.groupBox2.Controls.Add(this.StartTimeText);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(11, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 147);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Интервал";
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
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 13);
            this.label16.TabIndex = 64;
            this.label16.Text = "Начальное время:";
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
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(91, 302);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(53, 23);
            this.OKButton.TabIndex = 70;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(150, 302);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(65, 23);
            this.CancelButton.TabIndex = 71;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // TriesCountTextBox
            // 
            this.TriesCountTextBox.Location = new System.Drawing.Point(193, 39);
            this.TriesCountTextBox.Mask = "0";
            this.TriesCountTextBox.Name = "TriesCountTextBox";
            this.TriesCountTextBox.Size = new System.Drawing.Size(22, 20);
            this.TriesCountTextBox.TabIndex = 75;
            this.TriesCountTextBox.Text = "1";
            this.TriesCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Попыток:";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 334);
            this.Controls.Add(this.TriesCountTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DeviceNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditForm";
            this.Text = "Изменить интервал";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DeviceNameLabel;
        private System.Windows.Forms.MaskedTextBox StartDownloadText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox EndTimeText;
        private System.Windows.Forms.MaskedTextBox StartTimeText;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.MaskedTextBox TriesCountTextBox;
        private System.Windows.Forms.Label label2;
    }
}