namespace schedule_Project
{
    partial class Calendar
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
            this.components = new System.ComponentModel.Container();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.labeDate = new System.Windows.Forms.Label();
            this.txtTimeSet = new System.Windows.Forms.TextBox();
            this.labelTimeSet = new System.Windows.Forms.Label();
            this.checkBoxAlram = new System.Windows.Forms.CheckBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.labelSchedule = new System.Windows.Forms.Label();
            this.checkBoxTimeSet = new System.Windows.Forms.CheckBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtHiddenId = new System.Windows.Forms.TextBox();
            this.txtHiddenName = new System.Windows.Forms.TextBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNowTime = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelLeftTime = new System.Windows.Forms.Label();
            this.BtnGoSearchSchedule = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.White;
            this.txtDate.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDate.Location = new System.Drawing.Point(162, 124);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(296, 30);
            this.txtDate.TabIndex = 1;
            // 
            // labeDate
            // 
            this.labeDate.AutoSize = true;
            this.labeDate.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labeDate.Location = new System.Drawing.Point(27, 129);
            this.labeDate.Name = "labeDate";
            this.labeDate.Size = new System.Drawing.Size(67, 20);
            this.labeDate.TabIndex = 2;
            this.labeDate.Text = "날짜 :";
            // 
            // txtTimeSet
            // 
            this.txtTimeSet.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimeSet.Enabled = false;
            this.txtTimeSet.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTimeSet.Location = new System.Drawing.Point(162, 181);
            this.txtTimeSet.Name = "txtTimeSet";
            this.txtTimeSet.ReadOnly = true;
            this.txtTimeSet.Size = new System.Drawing.Size(296, 30);
            this.txtTimeSet.TabIndex = 1;
            this.txtTimeSet.Text = "체크 한 뒤 시간을 선택하세요.";
            // 
            // labelTimeSet
            // 
            this.labelTimeSet.AutoSize = true;
            this.labelTimeSet.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTimeSet.Location = new System.Drawing.Point(27, 186);
            this.labelTimeSet.Name = "labelTimeSet";
            this.labelTimeSet.Size = new System.Drawing.Size(109, 20);
            this.labelTimeSet.TabIndex = 2;
            this.labelTimeSet.Text = "시간설정 :";
            // 
            // checkBoxAlram
            // 
            this.checkBoxAlram.AutoSize = true;
            this.checkBoxAlram.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxAlram.Location = new System.Drawing.Point(464, 133);
            this.checkBoxAlram.Name = "checkBoxAlram";
            this.checkBoxAlram.Size = new System.Drawing.Size(98, 21);
            this.checkBoxAlram.TabIndex = 3;
            this.checkBoxAlram.Text = "알림추가";
            this.checkBoxAlram.UseVisualStyleBackColor = true;
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtContent.Location = new System.Drawing.Point(162, 234);
            this.txtContent.MaxLength = 100;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(434, 139);
            this.txtContent.TabIndex = 1;
            // 
            // labelSchedule
            // 
            this.labelSchedule.AutoSize = true;
            this.labelSchedule.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelSchedule.Location = new System.Drawing.Point(27, 234);
            this.labelSchedule.Name = "labelSchedule";
            this.labelSchedule.Size = new System.Drawing.Size(67, 20);
            this.labelSchedule.TabIndex = 2;
            this.labelSchedule.Text = "일정 :";
            // 
            // checkBoxTimeSet
            // 
            this.checkBoxTimeSet.AutoSize = true;
            this.checkBoxTimeSet.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxTimeSet.Location = new System.Drawing.Point(464, 187);
            this.checkBoxTimeSet.Name = "checkBoxTimeSet";
            this.checkBoxTimeSet.Size = new System.Drawing.Size(137, 21);
            this.checkBoxTimeSet.TabIndex = 3;
            this.checkBoxTimeSet.Text = "시간설정 사용";
            this.checkBoxTimeSet.UseVisualStyleBackColor = true;
            this.checkBoxTimeSet.CheckedChanged += new System.EventHandler(this.checkBoxTimeSet_CheckedChanged);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(651, 166);
            this.monthCalendar.MaxSelectionCount = 31;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 4;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "tt hh:mm";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(651, 129);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(248, 25);
            this.dateTimePicker.TabIndex = 5;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(348, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "새로운 일정";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(32, 343);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHiddenId
            // 
            this.txtHiddenId.Location = new System.Drawing.Point(21, 28);
            this.txtHiddenId.Name = "txtHiddenId";
            this.txtHiddenId.Size = new System.Drawing.Size(100, 25);
            this.txtHiddenId.TabIndex = 8;
            this.txtHiddenId.Visible = false;
            // 
            // txtHiddenName
            // 
            this.txtHiddenName.Location = new System.Drawing.Point(21, 59);
            this.txtHiddenName.Name = "txtHiddenName";
            this.txtHiddenName.Size = new System.Drawing.Size(100, 25);
            this.txtHiddenName.TabIndex = 8;
            this.txtHiddenName.Visible = false;
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 5000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNowTime);
            this.groupBox1.Location = new System.Drawing.Point(651, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 65);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "현재 시간";
            // 
            // labelNowTime
            // 
            this.labelNowTime.AutoSize = true;
            this.labelNowTime.Location = new System.Drawing.Point(6, 33);
            this.labelNowTime.Name = "labelNowTime";
            this.labelNowTime.Size = new System.Drawing.Size(87, 15);
            this.labelNowTime.TabIndex = 0;
            this.labelNowTime.Text = "현재 시간 : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelLeftTime);
            this.groupBox2.Location = new System.Drawing.Point(162, 390);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 65);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "다음 알람까지";
            // 
            // labelLeftTime
            // 
            this.labelLeftTime.AutoSize = true;
            this.labelLeftTime.Location = new System.Drawing.Point(7, 33);
            this.labelLeftTime.Name = "labelLeftTime";
            this.labelLeftTime.Size = new System.Drawing.Size(62, 15);
            this.labelLeftTime.TabIndex = 0;
            this.labelLeftTime.Text = "로드중..";
            // 
            // BtnGoSearchSchedule
            // 
            this.BtnGoSearchSchedule.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold);
            this.BtnGoSearchSchedule.Location = new System.Drawing.Point(32, 425);
            this.BtnGoSearchSchedule.Name = "BtnGoSearchSchedule";
            this.BtnGoSearchSchedule.Size = new System.Drawing.Size(115, 30);
            this.BtnGoSearchSchedule.TabIndex = 10;
            this.BtnGoSearchSchedule.Text = "일정 조회";
            this.BtnGoSearchSchedule.UseVisualStyleBackColor = true;
            this.BtnGoSearchSchedule.Click += new System.EventHandler(this.BtnGoSearchSchedule_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 11;
            this.textBox1.Visible = false;
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 480);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnGoSearchSchedule);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtHiddenName);
            this.Controls.Add(this.txtHiddenId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.checkBoxTimeSet);
            this.Controls.Add(this.checkBoxAlram);
            this.Controls.Add(this.labelSchedule);
            this.Controls.Add(this.labelTimeSet);
            this.Controls.Add(this.labeDate);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtTimeSet);
            this.Controls.Add(this.txtDate);
            this.Name = "Calendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CalendarForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label labeDate;
        private System.Windows.Forms.TextBox txtTimeSet;
        private System.Windows.Forms.Label labelTimeSet;
        private System.Windows.Forms.CheckBox checkBoxAlram;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label labelSchedule;
        private System.Windows.Forms.CheckBox checkBoxTimeSet;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtHiddenId;
        private System.Windows.Forms.TextBox txtHiddenName;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelNowTime;
        private System.Windows.Forms.Label labelLeftTime;
        private System.Windows.Forms.Button BtnGoSearchSchedule;
        private System.Windows.Forms.TextBox textBox1;
    }
}