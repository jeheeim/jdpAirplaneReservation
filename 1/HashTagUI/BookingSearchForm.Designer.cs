namespace HashTagUI
{
	partial class BookingSearchForm
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
            this.cbDest = new System.Windows.Forms.ComboBox();
            this.cbDepartTime = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDepartDay = new System.Windows.Forms.ComboBox();
            this.bntReserve = new System.Windows.Forms.Button();
            this.lvSearchResult = new System.Windows.Forms.ListView();
            this.chAirplane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSeatInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.chDepartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "목적지";
            // 
            // cbDest
            // 
            this.cbDest.FormattingEnabled = true;
            this.cbDest.Location = new System.Drawing.Point(393, 25);
            this.cbDest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbDest.Name = "cbDest";
            this.cbDest.Size = new System.Drawing.Size(132, 21);
            this.cbDest.TabIndex = 3;
            this.cbDest.SelectedIndexChanged += new System.EventHandler(this.cbDest_SelectedIndexChanged);
            // 
            // cbDepartTime
            // 
            this.cbDepartTime.FormattingEnabled = true;
            this.cbDepartTime.Location = new System.Drawing.Point(252, 52);
            this.cbDepartTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbDepartTime.Name = "cbDepartTime";
            this.cbDepartTime.Size = new System.Drawing.Size(123, 21);
            this.cbDepartTime.TabIndex = 5;
            this.cbDepartTime.SelectedIndexChanged += new System.EventHandler(this.cbDepartTime_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "날짜";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(393, 55);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 25);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "지역";
            // 
            // cbRegion
            // 
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Location = new System.Drawing.Point(46, 25);
            this.cbRegion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(123, 21);
            this.cbRegion.TabIndex = 1;
            this.cbRegion.SelectedIndexChanged += new System.EventHandler(this.cboxRegion_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "국가";
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(219, 25);
            this.cbCountry.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(123, 21);
            this.cbCountry.TabIndex = 2;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cboxCountry_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(461, 55);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "출발시간";
            // 
            // cbDepartDay
            // 
            this.cbDepartDay.FormattingEnabled = true;
            this.cbDepartDay.Location = new System.Drawing.Point(46, 52);
            this.cbDepartDay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbDepartDay.Name = "cbDepartDay";
            this.cbDepartDay.Size = new System.Drawing.Size(123, 21);
            this.cbDepartDay.TabIndex = 4;
            this.cbDepartDay.SelectedIndexChanged += new System.EventHandler(this.cbDepartDay_SelectedIndexChanged);
            // 
            // bntReserve
            // 
            this.bntReserve.Location = new System.Drawing.Point(441, 244);
            this.bntReserve.Name = "bntReserve";
            this.bntReserve.Size = new System.Drawing.Size(64, 25);
            this.bntReserve.TabIndex = 12;
            this.bntReserve.Text = "예매";
            this.bntReserve.UseVisualStyleBackColor = true;
            // 
            // lvSearchResult
            // 
            this.lvSearchResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAirplane,
            this.chDepartDate,
            this.chDepartTime,
            this.chSeatInfo});
            this.lvSearchResult.FullRowSelect = true;
            this.lvSearchResult.GridLines = true;
            this.lvSearchResult.Location = new System.Drawing.Point(15, 115);
            this.lvSearchResult.Name = "lvSearchResult";
            this.lvSearchResult.Size = new System.Drawing.Size(510, 123);
            this.lvSearchResult.TabIndex = 11;
            this.lvSearchResult.UseCompatibleStateImageBehavior = false;
            this.lvSearchResult.View = System.Windows.Forms.View.Details;
            // 
            // chAirplane
            // 
            this.chAirplane.Text = "비행기";
            this.chAirplane.Width = 103;
            // 
            // chDepartTime
            // 
            this.chDepartTime.Text = "출발시각";
            this.chDepartTime.Width = 110;
            // 
            // chSeatInfo
            // 
            this.chSeatInfo.Text = "남은좌석";
            this.chSeatInfo.Width = 98;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "%s(으)로 가는 비행기 리스트입니다.";
            // 
            // chDepartDate
            // 
            this.chDepartDate.Text = "출발 날짜";
            this.chDepartDate.Width = 115;
            // 
            // BookingSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 287);
            this.Controls.Add(this.bntReserve);
            this.Controls.Add(this.lvSearchResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbDepartDay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbRegion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDepartTime);
            this.Controls.Add(this.cbDest);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "BookingSearchForm";
            this.Text = "BookingSearchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbDest;
		private System.Windows.Forms.ComboBox cbDepartTime;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbRegion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbCountry;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbDepartDay;
        private System.Windows.Forms.Button bntReserve;
        private System.Windows.Forms.ListView lvSearchResult;
        private System.Windows.Forms.ColumnHeader chAirplane;
        private System.Windows.Forms.ColumnHeader chDepartDate;
        private System.Windows.Forms.ColumnHeader chDepartTime;
        private System.Windows.Forms.ColumnHeader chSeatInfo;
        private System.Windows.Forms.Label label6;
    }
}