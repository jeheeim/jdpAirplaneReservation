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
            // FastBookingSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 339);
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
    }
}