namespace HashTagUI
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFindId = new System.Windows.Forms.Button();
            this.btnAdminSchedule = new System.Windows.Forms.Button();
            this.btnAdmAirManager = new System.Windows.Forms.Button();
            this.btnCheckTicket = new System.Windows.Forms.Button();
            this.btnBooking = new System.Windows.Forms.Button();
            this.btnLoginout = new System.Windows.Forms.Button();
            this.lblLoginText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnFindPw = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textPerson = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbDest = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbStart = new System.Windows.Forms.ComboBox();
            this.cbArrive = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDepart = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(231, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "지금 가입하세요";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "회원가입을 아직안하셨나요?";
            // 
            // btnFindId
            // 
            this.btnFindId.Location = new System.Drawing.Point(628, 85);
            this.btnFindId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFindId.Name = "btnFindId";
            this.btnFindId.Size = new System.Drawing.Size(98, 29);
            this.btnFindId.TabIndex = 17;
            this.btnFindId.Text = "ID찾기";
            this.btnFindId.UseVisualStyleBackColor = true;
            this.btnFindId.Click += new System.EventHandler(this.btnFindAcc_Click);
            // 
            // btnAdminSchedule
            // 
            this.btnAdminSchedule.Location = new System.Drawing.Point(234, 502);
            this.btnAdminSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdminSchedule.Name = "btnAdminSchedule";
            this.btnAdminSchedule.Size = new System.Drawing.Size(174, 119);
            this.btnAdminSchedule.TabIndex = 16;
            this.btnAdminSchedule.Text = "일정관리";
            this.btnAdminSchedule.UseVisualStyleBackColor = true;
            // 
            // btnAdmAirManager
            // 
            this.btnAdmAirManager.Location = new System.Drawing.Point(32, 502);
            this.btnAdmAirManager.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdmAirManager.Name = "btnAdmAirManager";
            this.btnAdmAirManager.Size = new System.Drawing.Size(174, 119);
            this.btnAdmAirManager.TabIndex = 15;
            this.btnAdmAirManager.Text = "비행기관리";
            this.btnAdmAirManager.UseVisualStyleBackColor = true;
            // 
            // btnCheckTicket
            // 
            this.btnCheckTicket.Location = new System.Drawing.Point(447, 502);
            this.btnCheckTicket.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCheckTicket.Name = "btnCheckTicket";
            this.btnCheckTicket.Size = new System.Drawing.Size(174, 119);
            this.btnCheckTicket.TabIndex = 14;
            this.btnCheckTicket.Text = "조회";
            this.btnCheckTicket.UseVisualStyleBackColor = true;
            this.btnCheckTicket.Click += new System.EventHandler(this.btnCheckTicket_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.Location = new System.Drawing.Point(651, 502);
            this.btnBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(174, 119);
            this.btnBooking.TabIndex = 13;
            this.btnBooking.Text = "예약";
            this.btnBooking.UseVisualStyleBackColor = true;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // btnLoginout
            // 
            this.btnLoginout.Location = new System.Drawing.Point(768, 13);
            this.btnLoginout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoginout.Name = "btnLoginout";
            this.btnLoginout.Size = new System.Drawing.Size(98, 66);
            this.btnLoginout.TabIndex = 12;
            this.btnLoginout.Text = "로그인";
            this.btnLoginout.UseVisualStyleBackColor = true;
            this.btnLoginout.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLoginText
            // 
            this.lblLoginText.AutoSize = true;
            this.lblLoginText.Location = new System.Drawing.Point(592, 68);
            this.lblLoginText.Name = "lblLoginText";
            this.lblLoginText.Size = new System.Drawing.Size(0, 15);
            this.lblLoginText.TabIndex = 11;
            this.lblLoginText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(617, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 25);
            this.textBox1.TabIndex = 20;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(617, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 25);
            this.textBox2.TabIndex = 21;
            // 
            // btnFindPw
            // 
            this.btnFindPw.Location = new System.Drawing.Point(768, 84);
            this.btnFindPw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFindPw.Name = "btnFindPw";
            this.btnFindPw.Size = new System.Drawing.Size(98, 30);
            this.btnFindPw.TabIndex = 22;
            this.btnFindPw.Text = "PW찾기";
            this.btnFindPw.UseVisualStyleBackColor = true;
            this.btnFindPw.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 20F);
            this.label4.Location = new System.Drawing.Point(397, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 34);
            this.label4.TabIndex = 23;
            this.label4.Text = "해시태그";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textPerson);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbDest);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbStart);
            this.groupBox1.Controls.Add(this.cbArrive);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbDepart);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(32, 289);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 119);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "빠른 예약";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(655, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 40);
            this.button1.TabIndex = 31;
            this.button1.Text = "예약";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(720, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "명";
            // 
            // textPerson
            // 
            this.textPerson.Location = new System.Drawing.Point(655, 30);
            this.textPerson.Name = "textPerson";
            this.textPerson.Size = new System.Drawing.Size(56, 25);
            this.textPerson.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(582, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "인원수 : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(319, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "목적지 : ";
            // 
            // cbDest
            // 
            this.cbDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDest.FormattingEnabled = true;
            this.cbDest.Location = new System.Drawing.Point(392, 30);
            this.cbDest.Name = "cbDest";
            this.cbDest.Size = new System.Drawing.Size(86, 23);
            this.cbDest.TabIndex = 26;
            this.cbDest.Click += new System.EventHandler(this.cbDest_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "출발지: ";
            // 
            // cbStart
            // 
            this.cbStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStart.FormattingEnabled = true;
            this.cbStart.Location = new System.Drawing.Point(137, 30);
            this.cbStart.Name = "cbStart";
            this.cbStart.Size = new System.Drawing.Size(87, 23);
            this.cbStart.TabIndex = 25;
            // 
            // cbArrive
            // 
            this.cbArrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArrive.FormattingEnabled = true;
            this.cbArrive.Location = new System.Drawing.Point(392, 70);
            this.cbArrive.Name = "cbArrive";
            this.cbArrive.Size = new System.Drawing.Size(121, 23);
            this.cbArrive.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "도착일 : ";
            // 
            // cbDepart
            // 
            this.cbDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepart.FormattingEnabled = true;
            this.cbDepart.Location = new System.Drawing.Point(137, 70);
            this.cbDepart.Name = "cbDepart";
            this.cbDepart.Size = new System.Drawing.Size(123, 23);
            this.cbDepart.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "출발일 : ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 653);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFindPw);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFindId);
            this.Controls.Add(this.btnAdminSchedule);
            this.Controls.Add(this.btnAdmAirManager);
            this.Controls.Add(this.btnCheckTicket);
            this.Controls.Add(this.btnBooking);
            this.Controls.Add(this.btnLoginout);
            this.Controls.Add(this.lblLoginText);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "MainForm";
            this.Text = "비행기예약";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFindId;
        public System.Windows.Forms.Button btnAdminSchedule;
        public System.Windows.Forms.Button btnAdmAirManager;
        public System.Windows.Forms.Button btnCheckTicket;
        public System.Windows.Forms.Button btnBooking;
        public System.Windows.Forms.Button btnLoginout;
        public System.Windows.Forms.Label lblLoginText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnFindPw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cbDepart;
        public System.Windows.Forms.ComboBox cbArrive;
        public System.Windows.Forms.ComboBox cbDest;
        public System.Windows.Forms.ComboBox cbStart;
        public System.Windows.Forms.TextBox textPerson;

    }
}

