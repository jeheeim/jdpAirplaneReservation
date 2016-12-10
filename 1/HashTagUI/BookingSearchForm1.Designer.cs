namespace HashTagUI
{
	partial class BookingSearchForm1
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
            this.chDepartApt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDestApt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSeatInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSearchText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "목적지";
            // 
            // cbDest
            // 
            this.cbDest.FormattingEnabled = true;
            this.cbDest.Location = new System.Drawing.Point(524, 29);
            this.cbDest.Name = "cbDest";
            this.cbDest.Size = new System.Drawing.Size(175, 23);
            this.cbDest.TabIndex = 3;
            this.cbDest.SelectedIndexChanged += new System.EventHandler(this.cbDest_SelectedIndexChanged);
            // 
            // cbDepartTime
            // 
            this.cbDepartTime.FormattingEnabled = true;
            this.cbDepartTime.Location = new System.Drawing.Point(328, 60);
            this.cbDepartTime.Name = "cbDepartTime";
            this.cbDepartTime.Size = new System.Drawing.Size(163, 23);
            this.cbDepartTime.TabIndex = 5;
            this.cbDepartTime.SelectedIndexChanged += new System.EventHandler(this.cbDepartTime_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "날짜";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(524, 63);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 29);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "지역";
            // 
            // cbRegion
            // 
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Location = new System.Drawing.Point(61, 29);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(163, 23);
            this.cbRegion.TabIndex = 1;
            this.cbRegion.SelectedIndexChanged += new System.EventHandler(this.cboxRegion_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "국가";
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(293, 29);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(163, 23);
            this.cbCountry.TabIndex = 2;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cboxCountry_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(615, 63);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "출발시간";
            // 
            // cbDepartDay
            // 
            this.cbDepartDay.FormattingEnabled = true;
            this.cbDepartDay.Location = new System.Drawing.Point(61, 60);
            this.cbDepartDay.Name = "cbDepartDay";
            this.cbDepartDay.Size = new System.Drawing.Size(163, 23);
            this.cbDepartDay.TabIndex = 4;
            this.cbDepartDay.SelectedIndexChanged += new System.EventHandler(this.cbDepartDay_SelectedIndexChanged);
            // 
            // bntReserve
            // 
            this.bntReserve.Location = new System.Drawing.Point(588, 282);
            this.bntReserve.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bntReserve.Name = "bntReserve";
            this.bntReserve.Size = new System.Drawing.Size(85, 29);
            this.bntReserve.TabIndex = 12;
            this.bntReserve.Text = "예매";
            this.bntReserve.UseVisualStyleBackColor = true;
            this.bntReserve.Click += new System.EventHandler(this.bntReserve_Click);
            // 
            // lvSearchResult
            // 
            this.lvSearchResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAirplane,
            this.chDepartApt,
            this.chDestApt,
            this.chDepartDate,
            this.chDepartTime,
            this.chSeatInfo});
            this.lvSearchResult.FullRowSelect = true;
            this.lvSearchResult.GridLines = true;
            this.lvSearchResult.Location = new System.Drawing.Point(20, 133);
            this.lvSearchResult.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvSearchResult.Name = "lvSearchResult";
            this.lvSearchResult.Size = new System.Drawing.Size(699, 141);
            this.lvSearchResult.TabIndex = 11;
            this.lvSearchResult.UseCompatibleStateImageBehavior = false;
            this.lvSearchResult.View = System.Windows.Forms.View.Details;
            // 
            // chAirplane
            // 
            this.chAirplane.Text = "비행기";
            this.chAirplane.Width = 103;
            // 
            // chDepartApt
            // 
            this.chDepartApt.Text = "출발 공항";
            this.chDepartApt.Width = 69;
            // 
            // chDestApt
            // 
            this.chDestApt.Text = "도착 공항";
            this.chDestApt.Width = 88;
            // 
            // chDepartDate
            // 
            this.chDepartDate.Text = "출발 날짜";
            this.chDepartDate.Width = 75;
            // 
            // chDepartTime
            // 
            this.chDepartTime.Text = "출발시각";
            this.chDepartTime.Width = 87;
            // 
            // chSeatInfo
            // 
            this.chSeatInfo.Text = "남은좌석";
            this.chSeatInfo.Width = 98;
            // 
            // lblSearchText
            // 
            this.lblSearchText.AutoSize = true;
            this.lblSearchText.Location = new System.Drawing.Point(16, 114);
            this.lblSearchText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchText.Name = "lblSearchText";
            this.lblSearchText.Size = new System.Drawing.Size(253, 15);
            this.lblSearchText.TabIndex = 10;
            this.lblSearchText.Text = "%s(으)로 가는 비행기 리스트입니다.";
            // 
            // BookingSearchForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 331);
            this.Controls.Add(this.bntReserve);
            this.Controls.Add(this.lvSearchResult);
            this.Controls.Add(this.lblSearchText);
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
            this.Name = "BookingSearchForm1";
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
        private System.Windows.Forms.Label lblSearchText;
        private System.Windows.Forms.ColumnHeader chDepartApt;
        private System.Windows.Forms.ColumnHeader chDestApt;
    }
}