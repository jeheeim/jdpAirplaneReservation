using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HashTagUI
{
	public partial class BookingSearchForm1 : Form
	{
		public Account currentUser;
		
		string dest;
		string departDay;
		string departTime;
        string country;

		public BookingSearchForm1(Account currentUser)
		{
			InitializeComponent();
			this.currentUser = currentUser;
            InitializeComboBoxes();
		}
        private void clearCBTexts()
        {
            cbRegion.Text = "";
            cbDepartDay.Text = "";
            cbDepartTime.Text = "";
            cbCountry.Text = "";
            cbDest.Text = "";
        }
        private void InitializeComboBoxes()
        {
            clearCBTexts();
            departDay = "";
            departTime = "";
            dest = "";
            country = "";
            cbRegion.Items.Clear();
            cbDepartDay.Items.Clear();
            cbDepartTime.Items.Clear();
            cbCountry.Items.Clear();
            cbDest.Items.Clear();
            this.lvSearchResult.Items.Clear();
            foreach (KeyValuePair<string, List<string>> targetPair in MainForm.server.Destinations)
            {
                this.cbRegion.Items.Add(targetPair.Key);/*
                for (int i = 0; i < targetPair.Value.Count; i++)
                {
                    this.cbCountry.Items.Add(targetPair.Value[i]);
                }*/
            }
            foreach (KeyValuePair<string, Dictionary<string, List<string>>> targetPair in MainForm.server.airplaneSchedules)
            {
                this.cbDepartDay.Items.Add(targetPair.Key);
            }
        }

		private void btnSearch_Click(object sender, EventArgs e)
		{
            this.lvSearchResult.Items.Clear();
            this.lblSearchText.Text = dest + "로 가는 비행기 리스트 입니다.";
            if(dest != "" && country != "" && departDay != "" && departTime != "")
            {
                List<string> targetID = MainForm.server.airplaneSchedules[departDay][departTime];
                for (int i = 0; i < targetID.Count; i++)
                {
                    Airplane targetApt = MainForm.server.airplaneList[targetID[i]];
                    if (targetApt.DestApt == dest && targetApt.Country == country)
                    {
                        ListViewItem lvItem = new ListViewItem(new string[6] { targetApt.ID, targetApt.DepartApt, targetApt.DestApt, targetApt.Date, targetApt.Time, targetApt.LeftSeats.ToString() });
                        this.lvSearchResult.Items.Add(lvItem);
                    }
                }
                return;
            }
            if (dest != "" && country != "" && departDay != "" && departTime == "")
            {
                List<string> targetID = MainForm.server.airplaneDest[country][dest];
                for (int i = 0; i < targetID.Count; i++)
                {
                    Airplane targetApt = MainForm.server.airplaneList[targetID[i]];
                    if (targetApt.Date == departDay)
                    {
                        ListViewItem lvItem = new ListViewItem(new string[6] { targetApt.ID, targetApt.DepartApt, targetApt.DestApt, targetApt.Date, targetApt.Time, targetApt.LeftSeats.ToString() });
                        this.lvSearchResult.Items.Add(lvItem);
                    }
                }
                return;
            }
            if (dest != "" && country != "" && departDay == "")
            {
                List<string> targetID = MainForm.server.airplaneDest[country][dest];
                for (int i = 0; i < targetID.Count; i++)
                {
                    Airplane targetApt = MainForm.server.airplaneList[targetID[i]];
                    ListViewItem lvItem = new ListViewItem(new string[6] { targetApt.ID, targetApt.DepartApt, targetApt.DestApt, targetApt.Date, targetApt.Time, targetApt.LeftSeats.ToString() });
                    this.lvSearchResult.Items.Add(lvItem);
                }
                return;
            }
            if (departDay != "" && departTime != "" && country == "")
            {
                List<string> targetID = MainForm.server.airplaneSchedules[departDay][departTime];
                for (int i = 0; i < targetID.Count; i++)
                {
                    Airplane targetApt = MainForm.server.airplaneList[targetID[i]];
                    ListViewItem lvItem = new ListViewItem(new string[6] { targetApt.ID, targetApt.DepartApt, targetApt.DestApt, targetApt.Date, targetApt.Time, targetApt.LeftSeats.ToString() });
                    this.lvSearchResult.Items.Add(lvItem);
                }
                return;
            }
            
		}

		// 취소 버튼
		private void btnCancel_Click(object sender, EventArgs e)
		{
            InitializeComboBoxes();
		}


		/*
		 지역, 국가, 목적지, 출발일, 출발시간 콤보박스 선택시
			 */

		private void cboxRegion_SelectedIndexChanged(object sender, EventArgs e)
		{
            //@"C:\Users\jay\Documents\GitHub\jdpAirplaneReservation
            this.cbCountry.Items.Clear();
            string seletedRegion = this.cbRegion.SelectedItem.ToString();
            if(MainForm.server.Destinations.ContainsKey(seletedRegion))
            {
                for(int i = 0; i < MainForm.server.Destinations[seletedRegion].Count; i++)
                {
                    cbCountry.Items.Add(MainForm.server.Destinations[seletedRegion][i]);
                }
            }
		}

		private void cboxCountry_SelectedIndexChanged(object sender, EventArgs e)
		{
            cbDest.Items.Clear();
            cbDest.Text = "";
            dest = "";
            country = this.cbCountry.SelectedItem.ToString();
            if (MainForm.server.airplaneDest.ContainsKey(country))
            {
                for (int i = 0; i < MainForm.server.airplaneDest[country].Count; i++)
                {
                    foreach (KeyValuePair<string, List<string>> target in MainForm.server.airplaneDest[country])
                        cbDest.Items.Add(target.Key);
                }
            }
		}

		private void cbDest_SelectedIndexChanged(object sender, EventArgs e)
		{
            cbDepartDay.Items.Clear();
            cbDepartDay.Text = "";
            departDay = "";
            cbDepartTime.Items.Clear();
            cbDepartTime.Text = "";
            departTime = "";
            dest = cbDest.SelectedItem.ToString();
            if (country != "" && dest != "")
            {
                string nowDate="", preDate="";
                List<string> targetID = MainForm.server.airplaneDest[country][dest];
                for (int i = 0; i < targetID.Count; i++)
                {
                    nowDate = MainForm.server.airplaneList[targetID[i]].Date;
                    if(nowDate != preDate)
                        cbDepartDay.Items.Add(nowDate);
                    preDate = nowDate;
                }
                return;
            }

		}

		private void cbDepartDay_SelectedIndexChanged(object sender, EventArgs e)
		{
            cbDepartTime.Items.Clear();
            departTime = "";
            cbDepartTime.Text = "";
            departDay = cbDepartDay.SelectedItem.ToString();
            if(country != "" && departDay != "" && dest != "")
            {
                List<string> targetID = MainForm.server.airplaneDest[country][dest];
                for (int i = 0; i < targetID.Count; i++)
                {
                    if (MainForm.server.airplaneList[targetID[i]].Date == departDay)
                        cbDepartTime.Items.Add(MainForm.server.airplaneList[targetID[i]].Time);
                }
                return;
            }
            if (MainForm.server.airplaneSchedules.ContainsKey(departDay))
            {
                foreach (KeyValuePair<string, List<string>> target in MainForm.server.airplaneSchedules[departDay])
                    cbDepartTime.Items.Add(target.Key);
            }
		}

		private void cbDepartTime_SelectedIndexChanged(object sender, EventArgs e)
		{
            departTime = cbDepartTime.SelectedItem.ToString();
		}

        private void bntReserve_Click(object sender, EventArgs e)
        {
            if (this.lvSearchResult.SelectedItems.Count != 1)
            {
                MessageBox.Show("비행기를 선택해 주세요!");
                return;
            }
            string name = this.lvSearchResult.SelectedItems[0].SubItems[0].Text;
            Form searchResult = new BookingAirplaneSeatForm(currentUser, name);
            this.Hide();
            searchResult.ShowDialog();
        }

	}
}
