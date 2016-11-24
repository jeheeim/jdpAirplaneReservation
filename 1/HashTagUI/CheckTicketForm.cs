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
            int row, col;
            int index = Convert.ToInt32(this.lvTicketInfo.SelectedItems[0].SubItems[0].Text);
            row = currentUser.accAirplaneInfo[index-1].seatNum[0] - 'A';
            col = Convert.ToInt32(currentUser.accAirplaneInfo[index - 1].seatNum.Substring(1));
            currentUser.accAirplaneInfo[index - 1].bookedAirplane.seats[row, col].isReserved = false;
            currentUser.accAirplaneInfo.RemoveAt(index - 1);
            if (currentUser.accAirplaneInfo.Count == 0)
                currentUser.existAirplane = false;
            for(int i = index; i < this.lvTicketInfo.Items.Count;i++)
            {
                this.lvTicketInfo.Items[i].SubItems[0].Text = i.ToString();
            }
            this.lvTicketInfo.Items[index - 1].Remove();
		}

        private void CheckTicketForm_Load(object sender, EventArgs e)
        {
            this.label1.Text = currentUser.name + "님의 티켓 예매 정보입니다.";
            if(!currentUser.existAirplane)
            {
                MessageBox.Show("예매된 비행기가 없습니다!");
                return;
            }
            for (int i = 0; i < currentUser.accAirplaneInfo.Count; i++)
            {
                Airplane targetAirplane = currentUser.accAirplaneInfo[i].bookedAirplane;
                string[] arrInfo = new string[6] { (i + 1).ToString(), targetAirplane.airplaneName, targetAirplane.destination, currentUser.accAirplaneInfo[i].seatNum, currentUser.accAirplaneInfo[i].seatClass, targetAirplane.startTime.ToString() };
                ListViewItem lvItem = new ListViewItem(arrInfo);
                this.lvTicketInfo.Items.Add(lvItem);
            }

        }
	}
}
