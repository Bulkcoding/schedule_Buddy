namespace schedule_Project
{
    partial class SearchSchedule
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
            this.txtHiddenId = new System.Windows.Forms.TextBox();
            this.txtHiddenName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtAlramTime = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtHiddenSeq = new System.Windows.Forms.TextBox();
            this.checkAlram = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHiddenId
            // 
            this.txtHiddenId.Location = new System.Drawing.Point(12, 12);
            this.txtHiddenId.Name = "txtHiddenId";
            this.txtHiddenId.Size = new System.Drawing.Size(100, 25);
            this.txtHiddenId.TabIndex = 0;
            this.txtHiddenId.Visible = false;
            // 
            // txtHiddenName
            // 
            this.txtHiddenName.Location = new System.Drawing.Point(12, 43);
            this.txtHiddenName.Name = "txtHiddenName";
            this.txtHiddenName.Size = new System.Drawing.Size(100, 25);
            this.txtHiddenName.TabIndex = 0;
            this.txtHiddenName.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Location = new System.Drawing.Point(30, 515);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 31);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "일정 수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(140, 515);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 31);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "일정삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(732, 278);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "시작 날짜";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "마지막 날짜";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 387);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "알람 시간";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "일정 내용";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(34, 426);
            this.txtStartDate.MaxLength = 10;
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(100, 25);
            this.txtStartDate.TabIndex = 5;
            this.txtStartDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Date_KeyPress);
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(140, 426);
            this.txtEndDate.MaxLength = 10;
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(100, 25);
            this.txtEndDate.TabIndex = 5;
            this.txtEndDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Date_KeyPress);
            // 
            // txtAlramTime
            // 
            this.txtAlramTime.Location = new System.Drawing.Point(246, 426);
            this.txtAlramTime.MaxLength = 5;
            this.txtAlramTime.Name = "txtAlramTime";
            this.txtAlramTime.Size = new System.Drawing.Size(100, 25);
            this.txtAlramTime.TabIndex = 5;
            this.txtAlramTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlramTime_KeyPress);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(352, 426);
            this.txtContent.MaxLength = 500;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(385, 129);
            this.txtContent.TabIndex = 5;
            // 
            // txtHiddenSeq
            // 
            this.txtHiddenSeq.Location = new System.Drawing.Point(688, 382);
            this.txtHiddenSeq.Name = "txtHiddenSeq";
            this.txtHiddenSeq.Size = new System.Drawing.Size(100, 25);
            this.txtHiddenSeq.TabIndex = 6;
            this.txtHiddenSeq.Visible = false;
            // 
            // checkAlram
            // 
            this.checkAlram.AutoSize = true;
            this.checkAlram.Location = new System.Drawing.Point(460, 383);
            this.checkAlram.Name = "checkAlram";
            this.checkAlram.Size = new System.Drawing.Size(94, 19);
            this.checkAlram.TabIndex = 7;
            this.checkAlram.Text = "알람 여부";
            this.checkAlram.UseVisualStyleBackColor = true;
            // 
            // SearchSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 595);
            this.Controls.Add(this.checkAlram);
            this.Controls.Add(this.txtHiddenSeq);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtAlramTime);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtHiddenName);
            this.Controls.Add(this.txtHiddenId);
            this.Name = "SearchSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchSchedule";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHiddenId;
        private System.Windows.Forms.TextBox txtHiddenName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtAlramTime;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtHiddenSeq;
        private System.Windows.Forms.CheckBox checkAlram;
    }
}