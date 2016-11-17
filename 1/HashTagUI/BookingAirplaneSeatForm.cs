using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTagUI
{
	public partial class BookingAirplaneSeatForm : Form
	{
		Airplane nowAirplane;
		public BookingAirplaneSeatForm()
		{
			InitializeComponent();
			nowAirplane = new Airplane(10, 10, 20, "미국", "AC130", 10, 10, 10);
		}

		private void btnReserveSeat_Click(object sender, EventArgs e)
		{
			Button btncast = sender as Button;
			MessageBox.Show(btncast.Text);
		}

		private void BookingAirplaneSeatForm_Load(object sender, EventArgs e)
		{
			int row = nowAirplane.row;
			int col = nowAirplane.col;
			int colSize = col * 29 + 150 * Convert.ToInt32((0.3 * Convert.ToDouble(col)));
			int rowSize = row * 30 + 100 * Convert.ToInt32((0.3 * Convert.ToDouble(row)));
			this.Size = new Size((col + 1) * 30 + 100, (row + 1) * 35 + 100);
			//row * 30 + 125 * (0.1 * row)
			//this.btnReserveSeat.Location = new Point(row * 67 - 100, col * 35 - 70);
			Seat[,] nowSeats = nowAirplane.seats;
			for (int i = 0; i < row; i++)
			{
				TableLayoutPanel thisTable = new TableLayoutPanel();
				Point loc = new Point(12, 25 + i * 32);
				if (i >= row / 2)
					loc.Y += 30;
				for (int j = 0; j < col; j++)
				{
					thisTable.Location = loc;
					thisTable.Size = new Size(30, col * 29); //new Size(493, 272);
					thisTable.ColumnCount = col;
					thisTable.RowCount = row;
					thisTable.AutoSize = true;
					thisTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
					Seat nowSeat = nowSeats[i, j];
					string name = nowSeat.row.ToString() + nowSeat.column.ToString();
					Button seatButton = new Button()
					{
						Text = name,
						Size = new Size(30, 29),
						FlatStyle = System.Windows.Forms.FlatStyle.Flat,
						Font = new System.Drawing.Font("굴림", 8F)
					};
					if (!nowSeat.isReserved)
					{
						seatButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
						seatButton.Click += new System.EventHandler(this.btnReserveSeat_Click);
					}
					else
						seatButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
					thisTable.Controls.Add(seatButton);
				}
				this.Controls.Add(thisTable);
			}

		}

		private void button3_Click(object sender, EventArgs e)
		{
			MessageBox.Show("확인");
			this.Close();

		}
	}
}
