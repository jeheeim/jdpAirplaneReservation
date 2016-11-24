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
	public partial class BookingSearchResultForm : Form
	{
		Account currentUser;
		string dest; string departDay; string departTime;
        List<int> indexes = new List<int>();

		public BookingSearchResultForm(Account currentUser, string country, string dest, string departDay, string departTime)
		{
			InitializeComponent();

			this.currentUser = currentUser;
			this.dest = dest;
			this.departDay = departDay;
			this.departTime = departTime;
            this.label1.Text = dest + "로 가는 비행기 리스트 입니다.";
            foreach (Airplane target in MainForm.server.airplaneList)// && target.startTime.ToString() == departTime
            {
                bool isValid = target.destination == country;
                if(departTime != "")
                {
                    isValid = (isValid && target.startTime.ToString() == departTime);
                }
                if (isValid)
                {
                    int leftSeats = MainForm.server.getLeftSeats(target);
                    ListViewItem lvItem = new ListViewItem(new string[3] { target.airplaneName, target.startTime.ToString(), leftSeats.ToString() });
                    this.lvSearchResult.Items.Add(lvItem);
                }
            }
			label1.Text = label1.Text.Replace("%s", dest);
		}

		private void button1_Click(object sender, EventArgs e)
		{
            if(this.lvSearchResult.SelectedItems.Count != 1)
            {
                MessageBox.Show("비행기를 선택해 주세요!");
                return;
            }
            string name = this.lvSearchResult.SelectedItems[0].SubItems[0].Text;
            Airplane nowAirplane = null;
            foreach(Airplane target in MainForm.server.airplaneList)
            {
                if (target.airplaneName == name)
                {
                    nowAirplane = target;
                    break;
                }
            }
            Form searchResult = new BookingAirplaneSeatForm(currentUser, nowAirplane);
			this.Hide();
			searchResult.ShowDialog();
		}
	}
}
