namespace HashTagUI
{
	partial class BookingAirplaneSeatForm
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
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.btnReserveSeat = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(0, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 358);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// btnReserveSeat
			// 
			this.btnReserveSeat.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnReserveSeat.Location = new System.Drawing.Point(3, 335);
			this.btnReserveSeat.Name = "btnReserveSeat";
			this.btnReserveSeat.Size = new System.Drawing.Size(514, 23);
			this.btnReserveSeat.TabIndex = 2;
			this.btnReserveSeat.Text = "예약";
			this.btnReserveSeat.UseVisualStyleBackColor = true;
			this.btnReserveSeat.Click += new System.EventHandler(this.btnReserveSeat_Click);
			// 
			// BookingAirplaneSeatForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(517, 358);
			this.Controls.Add(this.btnReserveSeat);
			this.Controls.Add(this.splitter1);
			this.Name = "BookingAirplaneSeatForm";
			this.Text = "BookingAirplaneSeatForm";
			this.Load += new System.EventHandler(this.BookingAirplaneSeatForm_Load);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Button btnReserveSeat;
	}
}
