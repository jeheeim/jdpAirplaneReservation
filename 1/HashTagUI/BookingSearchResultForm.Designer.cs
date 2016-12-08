namespace HashTagUI
{
	partial class BookingSearchResultForm
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
            this.lvSearchResult = new System.Windows.Forms.ListView();
            this.chAirplane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSeatInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bntReserve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "%s(으)로 가는 비행기 리스트입니다.";
            // 
            // lvSearchResult
            // 
            this.lvSearchResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAirplane,
            this.chDepartTime,
            this.chSeatInfo});
            this.lvSearchResult.FullRowSelect = true;
            this.lvSearchResult.GridLines = true;
            this.lvSearchResult.Location = new System.Drawing.Point(10, 44);
            this.lvSearchResult.Name = "lvSearchResult";
            this.lvSearchResult.Size = new System.Drawing.Size(316, 114);
            this.lvSearchResult.TabIndex = 4;
            this.lvSearchResult.UseCompatibleStateImageBehavior = false;
            this.lvSearchResult.View = System.Windows.Forms.View.Details;
            // 
            // chAirplane
            // 
            this.chAirplane.Text = "비행기";
            this.chAirplane.Width = 78;
            // 
            // chDepartTime
            // 
            this.chDepartTime.Text = "출발시각";
            this.chDepartTime.Width = 69;
            // 
            // chSeatInfo
            // 
            this.chSeatInfo.Text = "남은좌석";
            this.chSeatInfo.Width = 71;
            // 
            // bntReserve
            // 
            this.bntReserve.Location = new System.Drawing.Point(251, 164);
            this.bntReserve.Name = "bntReserve";
            this.bntReserve.Size = new System.Drawing.Size(75, 23);
            this.bntReserve.TabIndex = 5;
            this.bntReserve.Text = "예매";
            this.bntReserve.UseVisualStyleBackColor = true;
            this.bntReserve.Click += new System.EventHandler(this.button1_Click);
            // 
            // BookingSearchResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 202);
            this.Controls.Add(this.bntReserve);
            this.Controls.Add(this.lvSearchResult);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BookingSearchResultForm";
            this.Text = "BookingSearchResultForm";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView lvSearchResult;
		private System.Windows.Forms.ColumnHeader chAirplane;
		private System.Windows.Forms.ColumnHeader chDepartTime;
		private System.Windows.Forms.ColumnHeader chSeatInfo;
		private System.Windows.Forms.Button bntReserve;
	}
}