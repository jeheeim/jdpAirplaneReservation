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
            Account currentUser;
            int bookingSeatCnt = 0;
        int totCost = 0;
            List<string> clickedSeats = new List<string>();
        	public BookingAirplaneSeatForm(Account currentUser,string nowAirplane)
        	{
            		InitializeComponent();
                    this.nowAirplane = MainForm.clientSocket.airplaneList[nowAirplane];
                    this.currentUser = currentUser;
        	}
            private void btnSeat_Click(object sender, EventArgs e)
            {
                Button btncast = sender as Button;
                string seatNum = btncast.Text;
                if(clickedSeats.Contains(seatNum))
                {
                    clickedSeats.Remove(seatNum);
                    btncast.BackColor = System.Drawing.SystemColors.ActiveCaption;
                totCost -= nowAirplane.Cost;
                this.lblTotCost.Text = "선택하신 좌석의 가격은 : " + totCost + "원 입니다.";
                bookingSeatCnt--;
                    return;
                }
                btncast.BackColor = System.Drawing.SystemColors.Highlight;
                totCost += nowAirplane.Cost;
            this.lblTotCost.Text = "선택하신 좌석의 가격은 : " + totCost + "원 입니다.";
                clickedSeats.Add(seatNum);
                bookingSeatCnt++;
            }
        	private void btnReserveSeat_Click(object sender, EventArgs e)
        	{
                /*
                string seatClass = "";
                if (seatNum[0] == 'A')
                    seatClass = "First";
                else if (seatNum[0] == 'B')
                    seatClass = "Business";
                else
                    seatClass = "Economy";*/
                DialogResult result = MessageBox.Show("정말로 예매하시겠습니까?", "예약하기", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    currentUser.addToBook(nowAirplane.ID, clickedSeats);
                    nowAirplane.LeftSeats -= bookingSeatCnt;
                    MessageBox.Show("예매되었습니다");
                    this.Close();
                }
        	}

            private void BookingAirplaneSeatForm_Load(object sender, EventArgs e)
            {
                Dictionary<string, bool> seats = nowAirplane.Seats;
                char nowSeat;
                char preSeat = ' ';
                Point loc = new Point(12, 25);
                TableLayoutPanel thisTable = new TableLayoutPanel();
                foreach (KeyValuePair<string, bool> targetSeat in seats)
                {
                    nowSeat = (targetSeat.Key[0] == 'R') ? targetSeat.Key[1] : targetSeat.Key[0];
                    string name = (targetSeat.Key[0] == 'R') ? targetSeat.Key.Substring(1) : targetSeat.Key;
                    if (nowSeat != preSeat)
                    {
                        thisTable = new TableLayoutPanel();
                        loc.Y += 35;
                        loc.X = 12;
                        thisTable.Location = loc;
                        thisTable.Size = new Size(30, 10 * 29); //new Size(493, 272);
                        thisTable.ColumnCount = 10;
                        thisTable.RowCount = 5;
                        thisTable.AutoSize = true;
                        thisTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                        this.Controls.Add(thisTable);
                    }
                    Button seatButton = new Button()
                    {
                        Text = name,
                        Size = new Size(30, 29),
                        FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                        Font = new System.Drawing.Font("굴림", 8F)
                    };
                    if (!targetSeat.Value)
                    {
                        seatButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
                        seatButton.Click += new System.EventHandler(this.btnSeat_Click);
                    }
                    else
                        seatButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                    preSeat = nowSeat;
                    loc.X += 30;
                    thisTable.Controls.Add(seatButton);
                }

                this.Controls.Add(thisTable);
            }

	}
}
