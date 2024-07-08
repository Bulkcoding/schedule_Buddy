namespace schedule_Project
{
    partial class AddUser
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
            this.textID = new System.Windows.Forms.TextBox();
            this.labelAddUser = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.textPwd = new System.Windows.Forms.TextBox();
            this.labelPWD = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.BtnIdCheck = new System.Windows.Forms.Button();
            this.labelGender = new System.Windows.Forms.Label();
            this.textBirthday = new System.Windows.Forms.TextBox();
            this.labelBirthday = new System.Windows.Forms.Label();
            this.textMobile = new System.Windows.Forms.TextBox();
            this.labelMobile = new System.Windows.Forms.Label();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioWoman = new System.Windows.Forms.RadioButton();
            this.radioMan = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textID
            // 
            this.textID.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textID.Location = new System.Drawing.Point(201, 160);
            this.textID.MaxLength = 40;
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(326, 34);
            this.textID.TabIndex = 11;
            this.textID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textID_KeyDown);
            // 
            // labelAddUser
            // 
            this.labelAddUser.AutoSize = true;
            this.labelAddUser.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelAddUser.Location = new System.Drawing.Point(250, 66);
            this.labelAddUser.Name = "labelAddUser";
            this.labelAddUser.Size = new System.Drawing.Size(93, 20);
            this.labelAddUser.TabIndex = 12;
            this.labelAddUser.Text = "회원가입";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelID.Location = new System.Drawing.Point(67, 166);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(69, 20);
            this.labelID.TabIndex = 13;
            this.labelID.Text = "아이디";
            // 
            // textPwd
            // 
            this.textPwd.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textPwd.Location = new System.Drawing.Point(201, 250);
            this.textPwd.MaxLength = 25;
            this.textPwd.Name = "textPwd";
            this.textPwd.PasswordChar = '*';
            this.textPwd.Size = new System.Drawing.Size(326, 34);
            this.textPwd.TabIndex = 11;
            // 
            // labelPWD
            // 
            this.labelPWD.AutoSize = true;
            this.labelPWD.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPWD.Location = new System.Drawing.Point(67, 259);
            this.labelPWD.Name = "labelPWD";
            this.labelPWD.Size = new System.Drawing.Size(89, 20);
            this.labelPWD.TabIndex = 13;
            this.labelPWD.Text = "비밀번호";
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textName.Location = new System.Drawing.Point(201, 310);
            this.textName.MaxLength = 7;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(326, 34);
            this.textName.TabIndex = 11;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelName.Location = new System.Drawing.Point(67, 319);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(49, 20);
            this.labelName.TabIndex = 13;
            this.labelName.Text = "성함";
            // 
            // BtnIdCheck
            // 
            this.BtnIdCheck.Location = new System.Drawing.Point(385, 200);
            this.BtnIdCheck.Name = "BtnIdCheck";
            this.BtnIdCheck.Size = new System.Drawing.Size(142, 27);
            this.BtnIdCheck.TabIndex = 14;
            this.BtnIdCheck.Text = "아이디 중복체크";
            this.BtnIdCheck.UseVisualStyleBackColor = true;
            this.BtnIdCheck.Click += new System.EventHandler(this.BtnIdCheck_Click_1);
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelGender.Location = new System.Drawing.Point(67, 359);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(49, 20);
            this.labelGender.TabIndex = 13;
            this.labelGender.Text = "성별";
            // 
            // textBirthday
            // 
            this.textBirthday.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBirthday.Location = new System.Drawing.Point(201, 432);
            this.textBirthday.MaxLength = 8;
            this.textBirthday.Name = "textBirthday";
            this.textBirthday.Size = new System.Drawing.Size(326, 34);
            this.textBirthday.TabIndex = 11;
            this.textBirthday.Leave += new System.EventHandler(this.CheckBirthDate);
            // 
            // labelBirthday
            // 
            this.labelBirthday.AutoSize = true;
            this.labelBirthday.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelBirthday.Location = new System.Drawing.Point(67, 441);
            this.labelBirthday.Name = "labelBirthday";
            this.labelBirthday.Size = new System.Drawing.Size(89, 20);
            this.labelBirthday.TabIndex = 13;
            this.labelBirthday.Text = "생년월일";
            // 
            // textMobile
            // 
            this.textMobile.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textMobile.Location = new System.Drawing.Point(201, 472);
            this.textMobile.MaxLength = 11;
            this.textMobile.Name = "textMobile";
            this.textMobile.Size = new System.Drawing.Size(326, 34);
            this.textMobile.TabIndex = 11;
            this.textMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumber_KeyPress);
            // 
            // labelMobile
            // 
            this.labelMobile.AutoSize = true;
            this.labelMobile.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMobile.Location = new System.Drawing.Point(67, 481);
            this.labelMobile.Name = "labelMobile";
            this.labelMobile.Size = new System.Drawing.Size(129, 20);
            this.labelMobile.TabIndex = 13;
            this.labelMobile.Text = "휴대전화번호";
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Location = new System.Drawing.Point(71, 566);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(456, 41);
            this.BtnSubmit.TabIndex = 16;
            this.BtnSubmit.Text = "인증요청";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioMan);
            this.groupBox1.Controls.Add(this.radioWoman);
            this.groupBox1.Location = new System.Drawing.Point(201, 359);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 60);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "성별";
            // 
            // radioWoman
            // 
            this.radioWoman.AutoSize = true;
            this.radioWoman.Location = new System.Drawing.Point(53, 28);
            this.radioWoman.Name = "radioWoman";
            this.radioWoman.Size = new System.Drawing.Size(43, 19);
            this.radioWoman.TabIndex = 0;
            this.radioWoman.TabStop = true;
            this.radioWoman.Text = "여";
            this.radioWoman.UseVisualStyleBackColor = true;
            // 
            // radioMan
            // 
            this.radioMan.AutoSize = true;
            this.radioMan.Location = new System.Drawing.Point(221, 28);
            this.radioMan.Name = "radioMan";
            this.radioMan.Size = new System.Drawing.Size(43, 19);
            this.radioMan.TabIndex = 1;
            this.radioMan.TabStop = true;
            this.radioMan.Text = "남";
            this.radioMan.UseVisualStyleBackColor = true;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 655);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnSubmit);
            this.Controls.Add(this.BtnIdCheck);
            this.Controls.Add(this.labelMobile);
            this.Controls.Add(this.labelBirthday);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelPWD);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.textMobile);
            this.Controls.Add(this.textBirthday);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelAddUser);
            this.Controls.Add(this.textPwd);
            this.Controls.Add(this.textID);
            this.Name = "AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddUser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Label labelAddUser;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textPwd;
        private System.Windows.Forms.Label labelPWD;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button BtnIdCheck;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.TextBox textBirthday;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.TextBox textMobile;
        private System.Windows.Forms.Label labelMobile;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioMan;
        private System.Windows.Forms.RadioButton radioWoman;
    }
}