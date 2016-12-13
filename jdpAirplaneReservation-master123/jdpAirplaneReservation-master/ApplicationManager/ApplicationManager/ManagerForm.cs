using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ApplicationManager
{
	public partial class ManagerForm : Form
	{
		Server server;

		public ManagerForm()
		{
			InitializeComponent();

			server = new Server();

			// 서버에 있는 리스트를 전부 받아옴
			foreach (KeyValuePair<string, Airplane> kv in server.airplaneList)
			{
				listBox1.Items.Add(kv.Value);
			}
		}

		private void listBox1_ItemClicked(object sender, EventArgs e)
		{
			tboxAirplaneID.Text = server.airplaneList[listBox1.SelectedItem.ToString()].ID;
			tboxDepartApt.Text = server.airplaneList[listBox1.SelectedItem.ToString()].DepartApt;

			string[] split = server.airplaneList[listBox1.SelectedItem.ToString()].Date.Split('.');
			int hour = int.Parse(server.airplaneList[listBox1.SelectedItem.ToString()].Time);

			DateTime departDateTime = new DateTime(2016, int.Parse(split[0]), int.Parse(split[1]));
			departDateTime = departDateTime.AddHours(hour);


			dtpDepartDate.Value = departDateTime;
			dtpDepartTime.Value = departDateTime;

			tboxDestCountry.Text = server.airplaneList[listBox1.SelectedItem.ToString()].Country;
			tboxDestApt.Text = server.airplaneList[listBox1.SelectedItem.ToString()].DestApt;
			tboxNumOfSeat.Text = server.airplaneList[listBox1.SelectedItem.ToString()].LeftSeats.ToString();
			tboxCost.Text = server.airplaneList[listBox1.SelectedItem.ToString()].Cost.ToString();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Airplane newAirplane = ConversionIntoAirplane();

			server.addToAirplaneList(tboxContinent.Text, newAirplane);
			listBox1.Items.Add(newAirplane);

		}

		private Airplane ConversionIntoAirplane()
		{
			string id = tboxAirplaneID.Text;
			string departApt = tboxDepartApt.Text;
			string departDate = dtpDepartDate.Value.Month.ToString() + '.' + dtpDepartDate.Value.Day.ToString();
			string departTime = dtpDepartTime.Value.Hour.ToString();
			string destCountry = tboxDestCountry.Text;
			string destApt = tboxDestApt.Text;
			string numOfSeats = tboxNumOfSeat.Text;
			int cost = int.Parse(tboxCost.Text);

			Airplane newAirplane = new Airplane(id, destCountry, departApt, destApt, departDate, departTime, cost, numOfSeats);

			return newAirplane;
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			Airplane newAp = ConversionIntoAirplane();

			server.airplaneList[newAp.ID].Cost = newAp.Cost;
			server.airplaneList[newAp.ID].Country = newAp.Country;
			server.airplaneList[newAp.ID].Date = newAp.Date;
			server.airplaneList[newAp.ID].DepartApt = newAp.DepartApt;
			server.airplaneList[newAp.ID].DestApt = newAp.DestApt;
			server.airplaneList[newAp.ID].LeftSeats = newAp.LeftSeats;
			server.airplaneList[newAp.ID].Time = newAp.Time;

			listBox1.Items.Clear();

			// 서버에 있는 리스트를 전부 받아옴
			foreach (KeyValuePair<string, Airplane> kv in server.airplaneList)
			{
				listBox1.Items.Add(kv.Value);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

			if (dr == DialogResult.OK)
			{
				server.airplaneList.Remove(listBox1.SelectedItem.ToString());
				listBox1.Items.Remove(listBox1.SelectedItem);

				MessageBox.Show("정상적으로 삭제되었습니다.");
			}
		}
	}
}
