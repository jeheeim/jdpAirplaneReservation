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
	public partial class BookingSearchForm : Form
	{
		public Account currentUser;
		
		string dest;
		string departDay;
		string departTime;
        string strcountry;

		public BookingSearchForm(Account currentUser)
		{
			InitializeComponent();
            departDay = "";
            departTime = "";
            dest = "";
            strcountry = "";
			this.currentUser = currentUser;
            /*
			for(int i=0;i<24;i++)
			{
				cbDepartTime.Items.Add(i);
			}*/
			DateTime[] day = new DateTime[7];
            /*
			for (double i=0;i<7;i++)
			{
				day[(int)i] = DateTime.Today.AddDays(i);
				cbDepartDay.Items.Add(day[(int)i].ToShortDateString());
			}*/
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
            /*Form searchResult = new BookingSearchResultForm(currentUser, strcountry, dest, departDay, departTime);
			this.Hide();
			searchResult.ShowDialog();
            */
		}

		// 취소 버튼
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		/*
		 지역, 국가, 목적지, 출발일, 출발시간 콤보박스 선택시
			 */

		private void cboxRegion_SelectedIndexChanged(object sender, EventArgs e)
		{
			string readResult;
            //@"C:\Users\jay\Documents\GitHub\jdpAirplaneReservation
			string regionSelected = Server.prePath + "\\Data\\" + cbRegion.SelectedItem + ".txt" ;
			StreamReader country = new StreamReader(regionSelected);
            cbCountry.Items.Clear();
			while((readResult = country.ReadLine()) != null)
			{
				cbCountry.Items.Add(readResult);
			}
		}

		private void cboxCountry_SelectedIndexChanged(object sender, EventArgs e)
		{
			string readResult;
			string countrySelected = Server.prePath + "\\Data\\" + cbCountry.SelectedItem + ".txt";
            strcountry = cbCountry.SelectedItem.ToString(); 
            if(!System.IO.File.Exists(countrySelected))
            {
                MessageBox.Show("해당 목적지로 가는 비행기가 아직 준비되지 않았습니다! 조금만 더 기다려 주세요!");
                return;
            }
   			StreamReader country = new StreamReader(countrySelected);
            cbDest.Items.Clear();
			while ((readResult = country.ReadLine()) != null)
			{
				cbDest.Items.Add(readResult);
			}
		}

		private void cbDest_SelectedIndexChanged(object sender, EventArgs e)
		{
			dest = cbDest.SelectedItem.ToString();
		}

		private void cbDepartDay_SelectedIndexChanged(object sender, EventArgs e)
		{
			departDay = cbDepartDay.SelectedItem.ToString();
		}

		private void cbDepartTime_SelectedIndexChanged(object sender, EventArgs e)
		{
			departTime = cbDepartTime.SelectedItem.ToString();
		}
	}
}
