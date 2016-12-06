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
	public partial class ManagerForm : Form
	{
		Server server;
		MainForm mainForm;

		public ManagerForm(Server server, MainForm mainForm)
		{
			InitializeComponent();

			this.server = server;
			this.mainForm = mainForm;

			foreach (KeyValuePair<string, Airplane> kv in server.airplaneList)
			{
				listBox1.Items.Add(kv.Value);
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			mainForm.btnLoginout.PerformClick();
			mainForm.ShowInTaskbar = true;
			mainForm.Show();

			this.Close();
		}
	}
}
