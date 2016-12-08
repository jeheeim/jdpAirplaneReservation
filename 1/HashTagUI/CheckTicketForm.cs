using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HashTagUI
{
	public partial class CheckTicketForm : Form
	{
        Account currentUser;
		public CheckTicketForm(Account currentUser)
		{
			InitializeComponent();
            this.currentUser = currentUser;
		}

		private void btnBackToMain_Click(object sender, EventArgs e)
		{
			MessageBox.Show("확인");
			this.Close();
		}

		private void btnCancelTicket_Click(object sender, EventArgs e)
		{
            if (this.lvTicketInfo.SelectedItems.Count != 1)
            {
                MessageBox.Show("취소할 좌석을 선택해 주세요!");
                return;
            }
			MessageBox.Show("취소 되었습니다!");
            string seatNum = this.lvTicketInfo.SelectedItems[0].SubItems[3].Text;
            string apName = this.lvTicketInfo.SelectedItems[0].SubItems[0].Text;
            MainForm.clientSocket.airplaneList[apName].Seats[seatNum] = false;
            currentUser.BookedSeats[apName].Remove(seatNum);
            this.lvTicketInfo.Items.Remove(this.lvTicketInfo.SelectedItems[0]);
		}

        private void CheckTicketForm_Load(object sender, EventArgs e)
        {
            this.label1.Text = currentUser.name + "님의 티켓 예매 정보입니다.";
            foreach(KeyValuePair<string,List<string>> targetList in currentUser.BookedSeats)
            {
                string apname = targetList.Key;
                Airplane nowAp = MainForm.clientSocket.airplaneList[apname];
                string dest = nowAp.DestApt;
                string departAP = nowAp.DepartApt;
                string seatClass;
                string startDate = nowAp.Date + "월/일" + nowAp.Time + "시";
                int price;
                for(int i = 0; i < targetList.Value.Count; i++)
                {
                    if (targetList.Value[i][0] == 'A')
                    {
                        seatClass = "First Class";
                        price = nowAp.Cost * 3;
                    }
                    else if (targetList.Value[i][0] == 'b')
                    {
                        seatClass = "Business";
                        price = nowAp.Cost * 2;
                    }
                    else
                    {
                        seatClass = "Economy";
                        price = nowAp.Cost;
                    }
                    ListViewItem lvItem = new ListViewItem(new string[7] { apname, departAP, dest, targetList.Value[i], seatClass, startDate, price.ToString() });
                    this.lvTicketInfo.Items.Add(lvItem);
                }
                /*ListViewItem lvItem = new ListViewItem(new string[3] { target.airplaneName, target.startTime.ToString(), leftSeats.ToString() });
                this.lvSearchResult.Items.Add(lvItem);*/
            }

        }
	}
}
