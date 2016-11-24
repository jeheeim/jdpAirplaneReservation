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
            this.btnFindAcc = new System.Windows.Forms.Button();
            this.btnAdminSchedule = new System.Windows.Forms.Button();
            this.btnAdmAirManager = new System.Windows.Forms.Button();
            this.btnCheckTicket = new System.Windows.Forms.Button();
            this.btnBooking = new System.Windows.Forms.Button();
            this.btnLoginout = new System.Windows.Forms.Button();
            this.lblLoginText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(205, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "지금 가입하세요";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "회원가입을 아직안하셨나요?";
            // 
            // btnFindAcc
            // 
            this.btnFindAcc.Location = new System.Drawing.Point(252, 5);
            this.btnFindAcc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFindAcc.Name = "btnFindAcc";
            this.btnFindAcc.Size = new System.Drawing.Size(86, 24);
            this.btnFindAcc.TabIndex = 17;
            this.btnFindAcc.Text = "ID/PW찾기";
            this.btnFindAcc.UseVisualStyleBackColor = true;
            // 
            // btnAdminSchedule
            // 
            this.btnAdminSchedule.Location = new System.Drawing.Point(185, 138);
            this.btnAdminSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdminSchedule.Name = "btnAdminSchedule";
            this.btnAdminSchedule.Size = new System.Drawing.Size(152, 42);
            this.btnAdminSchedule.TabIndex = 16;
            this.btnAdminSchedule.Text = "일정관리";
            this.btnAdminSchedule.UseVisualStyleBackColor = true;
            // 
            // btnAdmAirManager
            // 
            this.btnAdmAirManager.Location = new System.Drawing.Point(8, 134);
            this.btnAdmAirManager.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdmAirManager.Name = "btnAdmAirManager";
            this.btnAdmAirManager.Size = new System.Drawing.Size(152, 46);
            this.btnAdmAirManager.TabIndex = 15;
            this.btnAdmAirManager.Text = "비행기관리";
            this.btnAdmAirManager.UseVisualStyleBackColor = true;
            // 
            // btnCheckTicket
            // 
            this.btnCheckTicket.Location = new System.Drawing.Point(185, 85);
            this.btnCheckTicket.Name = "btnCheckTicket";
            this.btnCheckTicket.Size = new System.Drawing.Size(152, 95);
            this.btnCheckTicket.TabIndex = 14;
            this.btnCheckTicket.Text = "조회";
            this.btnCheckTicket.UseVisualStyleBackColor = true;
            this.btnCheckTicket.Click += new System.EventHandler(this.btnCheckTicket_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.Location = new System.Drawing.Point(8, 85);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(152, 95);
            this.btnBooking.TabIndex = 13;
            this.btnBooking.Text = "예약";
            this.btnBooking.UseVisualStyleBackColor = true;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // btnLoginout
            // 
            this.btnLoginout.Location = new System.Drawing.Point(148, 5);
            this.btnLoginout.Name = "btnLoginout";
            this.btnLoginout.Size = new System.Drawing.Size(86, 23);
            this.btnLoginout.TabIndex = 12;
            this.btnLoginout.Text = "로그인";
            this.btnLoginout.UseVisualStyleBackColor = true;
            this.btnLoginout.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLoginText
            // 
            this.lblLoginText.AutoSize = true;
            this.lblLoginText.Location = new System.Drawing.Point(10, 11);
            this.lblLoginText.Name = "lblLoginText";
            this.lblLoginText.Size = new System.Drawing.Size(121, 12);
            this.lblLoginText.TabIndex = 11;
            this.lblLoginText.Text = "로그아웃 상태입니다.";
            this.lblLoginText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 236);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFindAcc);
            this.Controls.Add(this.btnAdminSchedule);
            this.Controls.Add(this.btnAdmAirManager);
            this.Controls.Add(this.btnCheckTicket);
            this.Controls.Add(this.btnBooking);
            this.Controls.Add(this.btnLoginout);
            this.Controls.Add(this.lblLoginText);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Text = "비행기예약";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFindAcc;
        public System.Windows.Forms.Button btnAdminSchedule;
        public System.Windows.Forms.Button btnAdmAirManager;
        public System.Windows.Forms.Button btnCheckTicket;
        public System.Windows.Forms.Button btnBooking;
        public System.Windows.Forms.Button btnLoginout;
        public System.Windows.Forms.Label lblLoginText;
        private System.Windows.Forms.Label label1;

    }
}

