namespace HashTagUI
{
	partial class CheckTicketForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lvTicketInfo = new System.Windows.Forms.ListView();
            this.chAirplane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancelTicket = new System.Windows.Forms.Button();
            this.btnBackToMain = new System.Windows.Forms.Button();
            this.chNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "%s님의 티켓 예매 정보입니다.";
            // 
            // lvTicketInfo
            // 
            this.lvTicketInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNo,
            this.chAirplane,
            this.chDest,
            this.chSeat,
            this.chClass,
            this.chDepartTime});
            this.lvTicketInfo.FullRowSelect = true;
            this.lvTicketInfo.GridLines = true;
            this.lvTicketInfo.Location = new System.Drawing.Point(10, 53);
            this.lvTicketInfo.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lvTicketInfo.Name = "lvTicketInfo";
            this.lvTicketInfo.Size = new System.Drawing.Size(364, 98);
            this.lvTicketInfo.TabIndex = 2;
            this.lvTicketInfo.UseCompatibleStateImageBehavior = false;
            this.lvTicketInfo.View = System.Windows.Forms.View.Details;
            // 
            // chAirplane
            // 
            this.chAirplane.Text = "비행기";
            // 
            // chDest
            // 
            this.chDest.Text = "목적지";
            // 
            // chSeat
            // 
            this.chSeat.Text = "좌석";
            this.chSeat.Width = 43;
            // 
            // chClass
            // 
            this.chClass.Text = "클래스";
            this.chClass.Width = 83;
            // 
            // chDepartTime
            // 
            this.chDepartTime.Text = "출발시각";
            // 
            // btnCancelTicket
            // 
            this.btnCancelTicket.Location = new System.Drawing.Point(122, 162);
            this.btnCancelTicket.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCancelTicket.Name = "btnCancelTicket";
            this.btnCancelTicket.Size = new System.Drawing.Size(74, 23);
            this.btnCancelTicket.TabIndex = 3;
            this.btnCancelTicket.Text = "예매취소";
            this.btnCancelTicket.UseVisualStyleBackColor = true;
            this.btnCancelTicket.Click += new System.EventHandler(this.btnCancelTicket_Click);
            // 
            // btnBackToMain
            // 
            this.btnBackToMain.Location = new System.Drawing.Point(203, 162);
            this.btnBackToMain.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(74, 23);
            this.btnBackToMain.TabIndex = 4;
            this.btnBackToMain.Text = "돌아가기";
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            // 
            // chNo
            // 
            this.chNo.Text = "No.";
            this.chNo.Width = 36;
            // 
            // CheckTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 202);
            this.Controls.Add(this.btnBackToMain);
            this.Controls.Add(this.btnCancelTicket);
            this.Controls.Add(this.lvTicketInfo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CheckTicketForm";
            this.Text = "CheckTicketForm";
            this.Load += new System.EventHandler(this.CheckTicketForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView lvTicketInfo;
		private System.Windows.Forms.ColumnHeader chAirplane;
		private System.Windows.Forms.ColumnHeader chDest;
		private System.Windows.Forms.ColumnHeader chSeat;
		private System.Windows.Forms.ColumnHeader chClass;
		private System.Windows.Forms.ColumnHeader chDepartTime;
		private System.Windows.Forms.Button btnCancelTicket;
		private System.Windows.Forms.Button btnBackToMain;
        private System.Windows.Forms.ColumnHeader chNo;
	}
}