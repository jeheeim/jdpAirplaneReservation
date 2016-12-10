namespace HashTagUI
{
    partial class FastBookingSearchForm
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
            this.lblSearchText = new System.Windows.Forms.Label();
            this.lvSearchResult = new System.Windows.Forms.ListView();
            this.chAirplane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepartApt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDestApt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSeatInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bntReserve = new System.Windows.Forms.Button();
            this.lvSearchResult1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSearchText
            // 
            this.lblSearchText.AutoSize = true;
            this.lblSearchText.Location = new System.Drawing.Point(15, 13);
            this.lblSearchText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchText.Name = "lblSearchText";
            this.lblSearchText.Size = new System.Drawing.Size(253, 15);
            this.lblSearchText.TabIndex = 11;
            this.lblSearchText.Text = "%s(으)로 가는 비행기 리스트입니다.";
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
            this.lvSearchResult.Location = new System.Drawing.Point(18, 43);
            this.lvSearchResult.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvSearchResult.Name = "lvSearchResult";
            this.lvSearchResult.Size = new System.Drawing.Size(699, 141);
            this.lvSearchResult.TabIndex = 12;
            this.lvSearchResult.UseCompatibleStateImageBehavior = false;
            this.lvSearchResult.View = System.Windows.Forms.View.Details;
            this.lvSearchResult.SelectedIndexChanged += new System.EventHandler(this.lvSearchResult_SelectedIndexChanged);
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
            // bntReserve
            // 
            this.bntReserve.Location = new System.Drawing.Point(632, 298);
            this.bntReserve.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bntReserve.Name = "bntReserve";
            this.bntReserve.Size = new System.Drawing.Size(85, 29);
            this.bntReserve.TabIndex = 13;
            this.bntReserve.Text = "예매";
            this.bntReserve.UseVisualStyleBackColor = true;
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
            this.lvSearchResult1.Location = new System.Drawing.Point(18, 225);
            this.lvSearchResult1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvSearchResult1.Name = "lvSearchResult1";
            this.lvSearchResult1.Size = new System.Drawing.Size(699, 141);
            this.lvSearchResult1.TabIndex = 14;
            this.lvSearchResult1.UseCompatibleStateImageBehavior = false;
            this.lvSearchResult1.View = System.Windows.Forms.View.Details;
            this.lvSearchResult1.SelectedIndexChanged += new System.EventHandler(this.lvSearchResult1_SelectedIndexChanged);
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
            this.columnHeader6.Text = "남은좌석";
            this.columnHeader6.Width = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 196);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "%s(으)로 가는 비행기 리스트입니다.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 33);
            this.button1.TabIndex = 17;
            this.button1.Text = "결제하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FastBookingSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 447);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvSearchResult1);
            this.Controls.Add(this.bntReserve);
            this.Controls.Add(this.lvSearchResult);
            this.Controls.Add(this.lblSearchText);
            this.Name = "FastBookingSearchForm";
            this.Text = "FastBookingSearchForm";
            this.Load += new System.EventHandler(this.FastBookingSearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchText;
        private System.Windows.Forms.ListView lvSearchResult;
        private System.Windows.Forms.ColumnHeader chAirplane;
        private System.Windows.Forms.ColumnHeader chDepartApt;
        private System.Windows.Forms.ColumnHeader chDestApt;
        private System.Windows.Forms.ColumnHeader chDepartDate;
        private System.Windows.Forms.ColumnHeader chDepartTime;
        private System.Windows.Forms.ColumnHeader chSeatInfo;
        private System.Windows.Forms.Button bntReserve;
        private System.Windows.Forms.ListView lvSearchResult1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}