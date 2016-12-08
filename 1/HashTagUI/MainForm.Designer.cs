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
			this.components = new System.ComponentModel.Container();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnFindId = new System.Windows.Forms.Button();
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
			this.cbStart = new System.Windows.Forms.ComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.cbDest = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cbArrive = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbDepart = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.gbRecommend = new System.Windows.Forms.GroupBox();
			this.lvSearchResult1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lblMarqRec = new System.Windows.Forms.Label();
			this.TimerMQ = new System.Windows.Forms.Timer(this.components);
			this.btnModifyInfo = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.gbRecommend.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label3.Location = new System.Drawing.Point(231, 62);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 15);
			this.label3.TabIndex = 19;
			this.label3.Text = "지금 가입하세요";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 62);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 15);
			this.label2.TabIndex = 18;
			this.label2.Text = "회원가입을 아직안하셨나요?";
			// 
			// btnFindId
			// 
			this.btnFindId.Location = new System.Drawing.Point(628, 85);
			this.btnFindId.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnFindId.Name = "btnFindId";
			this.btnFindId.Size = new System.Drawing.Size(99, 29);
			this.btnFindId.TabIndex = 17;
			this.btnFindId.Text = "ID찾기";
			this.btnFindId.UseVisualStyleBackColor = true;
			this.btnFindId.Click += new System.EventHandler(this.btnFindAcc_Click);
			// 
			// btnCheckTicket
			// 
			this.btnCheckTicket.Location = new System.Drawing.Point(173, 503);
			this.btnCheckTicket.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnCheckTicket.Name = "btnCheckTicket";
			this.btnCheckTicket.Size = new System.Drawing.Size(173, 119);
			this.btnCheckTicket.TabIndex = 14;
			this.btnCheckTicket.Text = "조회";
			this.btnCheckTicket.UseVisualStyleBackColor = true;
			this.btnCheckTicket.Click += new System.EventHandler(this.btnCheckTicket_Click);
			// 
			// btnBooking
			// 
			this.btnBooking.Location = new System.Drawing.Point(569, 503);
			this.btnBooking.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnBooking.Name = "btnBooking";
			this.btnBooking.Size = new System.Drawing.Size(173, 119);
			this.btnBooking.TabIndex = 13;
			this.btnBooking.Text = "예약";
			this.btnBooking.UseVisualStyleBackColor = true;
			this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
			// 
			// btnLoginout
			// 
			this.btnLoginout.Location = new System.Drawing.Point(768, 13);
			this.btnLoginout.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnLoginout.Name = "btnLoginout";
			this.btnLoginout.Size = new System.Drawing.Size(99, 66);
			this.btnLoginout.TabIndex = 12;
			this.btnLoginout.Text = "로그인";
			this.btnLoginout.UseVisualStyleBackColor = true;
			this.btnLoginout.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// lblLoginText
			// 
			this.lblLoginText.AutoSize = true;
			this.lblLoginText.Location = new System.Drawing.Point(592, 68);
			this.lblLoginText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblLoginText.Name = "lblLoginText";
			this.lblLoginText.Size = new System.Drawing.Size(0, 15);
			this.lblLoginText.TabIndex = 11;
			this.lblLoginText.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 27);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 15);
			this.label1.TabIndex = 10;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(617, 13);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(129, 25);
			this.textBox1.TabIndex = 20;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(617, 53);
			this.textBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(129, 25);
			this.textBox2.TabIndex = 21;
			// 
			// btnFindPw
			// 
			this.btnFindPw.Location = new System.Drawing.Point(768, 84);
			this.btnFindPw.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnFindPw.Name = "btnFindPw";
			this.btnFindPw.Size = new System.Drawing.Size(99, 30);
			this.btnFindPw.TabIndex = 22;
			this.btnFindPw.Text = "PW찾기";
			this.btnFindPw.UseVisualStyleBackColor = true;
			this.btnFindPw.Click += new System.EventHandler(this.btnFindPw_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("굴림", 20F);
			this.label4.Location = new System.Drawing.Point(396, 9);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(151, 34);
			this.label4.TabIndex = 23;
			this.label4.Text = "해시태그";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbStart);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.cbDest);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.cbArrive);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.cbDepart);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(32, 357);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.groupBox1.Size = new System.Drawing.Size(835, 113);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "빠른 예약";
			// 
			// cbStart
			// 
			this.cbStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStart.FormattingEnabled = true;
			this.cbStart.Location = new System.Drawing.Point(137, 30);
			this.cbStart.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.cbStart.Name = "cbStart";
			this.cbStart.Size = new System.Drawing.Size(123, 23);
			this.cbStart.TabIndex = 25;
			this.cbStart.SelectedIndexChanged += new System.EventHandler(this.cbStart_SelectedIndexChanged);
			this.cbStart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbStart_MouseClick);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(655, 30);
			this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(59, 23);
			this.comboBox1.TabIndex = 32;
			this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(655, 59);
			this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(109, 40);
			this.button1.TabIndex = 31;
			this.button1.Text = "예약";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(720, 32);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(22, 15);
			this.label10.TabIndex = 30;
			this.label10.Text = "명";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(581, 32);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(67, 15);
			this.label9.TabIndex = 28;
			this.label9.Text = "인원수 : ";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(319, 32);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
			this.cbDest.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.cbDest.Name = "cbDest";
			this.cbDest.Size = new System.Drawing.Size(120, 23);
			this.cbDest.TabIndex = 26;
			this.cbDest.SelectedIndexChanged += new System.EventHandler(this.cbDest_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(52, 32);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(62, 15);
			this.label7.TabIndex = 5;
			this.label7.Text = "출발지: ";
			// 
			// cbArrive
			// 
			this.cbArrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbArrive.FormattingEnabled = true;
			this.cbArrive.Location = new System.Drawing.Point(392, 70);
			this.cbArrive.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.cbArrive.Name = "cbArrive";
			this.cbArrive.Size = new System.Drawing.Size(120, 23);
			this.cbArrive.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(319, 73);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 15);
			this.label6.TabIndex = 3;
			this.label6.Text = "오는날 : ";
			// 
			// cbDepart
			// 
			this.cbDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDepart.FormattingEnabled = true;
			this.cbDepart.Location = new System.Drawing.Point(137, 70);
			this.cbDepart.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.cbDepart.Name = "cbDepart";
			this.cbDepart.Size = new System.Drawing.Size(123, 23);
			this.cbDepart.TabIndex = 2;
			this.cbDepart.SelectedIndexChanged += new System.EventHandler(this.cbDepart_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(52, 73);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(67, 15);
			this.label5.TabIndex = 0;
			this.label5.Text = "가는날 : ";
			// 
			// gbRecommend
			// 
			this.gbRecommend.Controls.Add(this.lvSearchResult1);
			this.gbRecommend.Location = new System.Drawing.Point(32, 149);
			this.gbRecommend.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.gbRecommend.Name = "gbRecommend";
			this.gbRecommend.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.gbRecommend.Size = new System.Drawing.Size(835, 160);
			this.gbRecommend.TabIndex = 27;
			this.gbRecommend.TabStop = false;
			this.gbRecommend.Text = "groupBox2";
			// 
			// lvSearchResult1
			// 
			this.lvSearchResult1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.lvSearchResult1.FullRowSelect = true;
			this.lvSearchResult1.GridLines = true;
			this.lvSearchResult1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvSearchResult1.Location = new System.Drawing.Point(12, 17);
			this.lvSearchResult1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.lvSearchResult1.Name = "lvSearchResult1";
			this.lvSearchResult1.Size = new System.Drawing.Size(815, 136);
			this.lvSearchResult1.TabIndex = 28;
			this.lvSearchResult1.UseCompatibleStateImageBehavior = false;
			this.lvSearchResult1.View = System.Windows.Forms.View.Details;
			this.lvSearchResult1.DoubleClick += new System.EventHandler(this.lvSearchResult1_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "비행기";
			this.columnHeader1.Width = 103;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "출발 공항";
			this.columnHeader2.Width = 69;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "도착 공항";
			this.columnHeader3.Width = 88;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "출발 날짜";
			this.columnHeader4.Width = 75;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "출발시각";
			this.columnHeader5.Width = 87;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "가격";
			this.columnHeader6.Width = 98;
			// 
			// lblMarqRec
			// 
			this.lblMarqRec.AutoSize = true;
			this.lblMarqRec.Location = new System.Drawing.Point(39, 130);
			this.lblMarqRec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblMarqRec.Name = "lblMarqRec";
			this.lblMarqRec.Size = new System.Drawing.Size(139, 15);
			this.lblMarqRec.TabIndex = 28;
			this.lblMarqRec.Text = "추천해드립니다.~~";
			this.lblMarqRec.MouseLeave += new System.EventHandler(this.lblMarqRec_MouseLeave);
			this.lblMarqRec.MouseHover += new System.EventHandler(this.lblMarqRec_MouseHover);
			// 
			// TimerMQ
			// 
			this.TimerMQ.Interval = 50;
			this.TimerMQ.Tick += new System.EventHandler(this.TimerMQ_Tick);
			// 
			// btnModifyInfo
			// 
			this.btnModifyInfo.Enabled = false;
			this.btnModifyInfo.Font = new System.Drawing.Font("굴림", 7F);
			this.btnModifyInfo.Location = new System.Drawing.Point(768, 85);
			this.btnModifyInfo.Name = "btnModifyInfo";
			this.btnModifyInfo.Size = new System.Drawing.Size(99, 29);
			this.btnModifyInfo.TabIndex = 29;
			this.btnModifyInfo.Text = "개인정보 수정";
			this.btnModifyInfo.UseVisualStyleBackColor = true;
			this.btnModifyInfo.Visible = false;
			this.btnModifyInfo.Click += new System.EventHandler(this.btnModifyInfo_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(892, 653);
			this.Controls.Add(this.btnModifyInfo);
			this.Controls.Add(this.lblMarqRec);
			this.Controls.Add(this.gbRecommend);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnFindPw);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnFindId);
			this.Controls.Add(this.btnCheckTicket);
			this.Controls.Add(this.btnBooking);
			this.Controls.Add(this.btnLoginout);
			this.Controls.Add(this.lblLoginText);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "비행기예약";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gbRecommend.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFindId;
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
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox gbRecommend;
        private System.Windows.Forms.ListView lvSearchResult1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label lblMarqRec;
        private System.Windows.Forms.Timer TimerMQ;
		private System.Windows.Forms.Button btnModifyInfo;
	}
}

