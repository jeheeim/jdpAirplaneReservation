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
			this.label1 = new System.Windows.Forms.Label();
			this.lblLoginText = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnBooking = new System.Windows.Forms.Button();
			this.btnCheckTicket = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 15);
			this.label1.TabIndex = 0;
			// 
			// lblLoginText
			// 
			this.lblLoginText.AutoSize = true;
			this.lblLoginText.Location = new System.Drawing.Point(14, 20);
			this.lblLoginText.Name = "lblLoginText";
			this.lblLoginText.Size = new System.Drawing.Size(152, 15);
			this.lblLoginText.TabIndex = 1;
			this.lblLoginText.Text = "로그아웃 상태입니다.";
			this.lblLoginText.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(184, 13);
			this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(86, 29);
			this.btnLogin.TabIndex = 2;
			this.btnLogin.Text = "Log In";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// btnBooking
			// 
			this.btnBooking.Location = new System.Drawing.Point(12, 112);
			this.btnBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnBooking.Name = "btnBooking";
			this.btnBooking.Size = new System.Drawing.Size(120, 119);
			this.btnBooking.TabIndex = 3;
			this.btnBooking.Text = "예약";
			this.btnBooking.UseVisualStyleBackColor = true;
			this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
			// 
			// btnCheckTicket
			// 
			this.btnCheckTicket.Location = new System.Drawing.Point(150, 112);
			this.btnCheckTicket.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnCheckTicket.Name = "btnCheckTicket";
			this.btnCheckTicket.Size = new System.Drawing.Size(120, 119);
			this.btnCheckTicket.TabIndex = 4;
			this.btnCheckTicket.Text = "조회";
			this.btnCheckTicket.UseVisualStyleBackColor = true;
			this.btnCheckTicket.Click += new System.EventHandler(this.btnCheckTicket_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(282, 253);
			this.Controls.Add(this.btnCheckTicket);
			this.Controls.Add(this.btnBooking);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.lblLoginText);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "Airplane Reservation Manager";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBooking;
		private System.Windows.Forms.Button btnCheckTicket;
		public System.Windows.Forms.Label lblLoginText;
		public System.Windows.Forms.Button btnLogin;

	}
}

