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
        List<string> alarmSeats = new List<string>();

		public BookingAirplaneSeatForm(Account currentUser, string nowAirplane)
		{
			InitializeComponent();
			this.nowAirplane = MainForm.clientSocket.airplaneList[nowAirplane];
			this.currentUser = currentUser;
		}
		private void btnSeat_Click(object sender, EventArgs e)
		{
			Button btncast = sender as Button;
			string seatNum = btncast.Text;
			if (clickedSeats.Contains(seatNum))
			{
				clickedSeats.Remove(seatNum);
				btncast.BackColor = SystemColors.ActiveCaption;
				totCost -= nowAirplane.Cost;
				this.lblTotCost.Text = "선택하신 좌석의 가격은 : " + totCost + "원 입니다.";
				bookingSeatCnt--;
				return;
			}
			btncast.BackColor = SystemColors.Highlight;
			totCost += nowAirplane.Cost;
			this.lblTotCost.Text = "선택하신 좌석의 가격은 : " + totCost + "원 입니다.";
			clickedSeats.Add(seatNum);
			bookingSeatCnt++;
		}
        private void btnAlarmSeat_Click(object sender, EventArgs e)
        {
            Button btncast = sender as Button;
            string seatNum = btncast.Text;
            if (alarmSeats.Contains(seatNum))
            {
                alarmSeats.Remove(seatNum);
                btncast.BackColor = SystemColors.ControlDark;
                return;
            }
            btncast.BackColor = SystemColors.ControlDarkDark;
            alarmSeats.Add(seatNum);
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
            if(alarmSeats.Count > 0)
            {
                DialogResult result1 = MessageBox.Show("선택하신 좌석중에 이미 예약된 좌석이 있습니다.\n알람 서비스를 신청하시겠습니까?", "예약하기", MessageBoxButtons.OKCancel);
                if (result1 == DialogResult.OK)
                {
                    if (MainForm.clientSocket.AlarmSeats(currentUser.id, nowAirplane.ID, ChangeInDBForm(alarmSeats)))
                    {
                        MessageBox.Show("알람 신청에 성공했습니다!");
                    }
                    else
                    {
                        MessageBox.Show("알람 신청에 실패했습니다!");
                    }

                    this.Close();
                }
            }
            if (clickedSeats.Count < 0)
                return;
			DialogResult result = MessageBox.Show("정말로 예매하시겠습니까?", "예약하기", MessageBoxButtons.OKCancel);

			if (result == DialogResult.OK)
			{
                string value = MainForm.clientSocket.Reservation(currentUser.id, nowAirplane.ID, ChangeInDBForm(clickedSeats));
                if (value == "T")
				{
                    MessageBox.Show("예약에 성공했습니다!");
                    currentUser.addToBook(nowAirplane.ID, clickedSeats);
				}
				else
				{
                    changeToFalseInSheet(value);
					MessageBox.Show("예약에 실패했습니다! 다시 시도하세요!");
				}

				this.Close();
			}
		}
        private void changeToFalseInSheet(string seats)
        {
            string[] seatsCom = seats.Split(',');
            for(int i = 0; i < seatsCom.Length; i++)
            {
                nowAirplane.Seats[seatsCom[i]] = false;
            }
        }
        private string ChangeInDBForm(List<string> targetList)
        {
            string tot = "";
            for(int i = 0; i < targetList.Count; i++)
            {
                tot += targetList[i];
                if (targetList.Count-1 != i)
                    tot += ",";
            }
            return tot;
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
					thisTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
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
                {
                    seatButton.BackColor = System.Drawing.SystemColors.ControlDark;
                    seatButton.Click += new System.EventHandler(this.btnAlarmSeat_Click);
                }
                preSeat = nowSeat;
				loc.X += 30;
				thisTable.Controls.Add(seatButton);
			}

			this.Controls.Add(thisTable);
		}

	}
}
