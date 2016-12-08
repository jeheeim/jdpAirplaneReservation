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
		ClientSocket clientSocket;
		MainForm mainForm;

		public ManagerForm(ClientSocket clientSocket, MainForm mainForm)
		{
			InitializeComponent();

			this.clientSocket = clientSocket;
			this.mainForm = mainForm;

			foreach (KeyValuePair<string, Airplane> kv in clientSocket.airplaneList)
			{
				listBox1.Items.Add(kv.Value);
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			tboxAirplaneID.Text = clientSocket.airplaneList[listBox1.SelectedItem.ToString()].ID;
			tboxDepartApt.Text = clientSocket.airplaneList[listBox1.SelectedItem.ToString()].DepartApt;

			string[] split = clientSocket.airplaneList[listBox1.SelectedItem.ToString()].Date.Split('.');
			int hour = int.Parse(clientSocket.airplaneList[listBox1.SelectedItem.ToString()].Time);

			DateTime departDateTime = new DateTime(2016, int.Parse(split[0]), int.Parse(split[1]));
			departDateTime = departDateTime.AddHours(hour);


			dtpDepartDate.Value = departDateTime;
			dtpDepartTime.Value = departDateTime;

			tboxDestCountry.Text = clientSocket.airplaneList[listBox1.SelectedItem.ToString()].Country;
			tboxDestApt.Text = clientSocket.airplaneList[listBox1.SelectedItem.ToString()].DestApt;
			tboxNumOfSeat.Text = clientSocket.airplaneList[listBox1.SelectedItem.ToString()].LeftSeats.ToString();
			tboxCost.Text = clientSocket.airplaneList[listBox1.SelectedItem.ToString()].Cost.ToString();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Airplane newAirplane = ConversionIntoAirplane();

			clientSocket.addToAirplaneList(tboxContinent.Text, newAirplane);
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

			clientSocket.airplaneList[newAp.ID].Cost = newAp.Cost;
			clientSocket.airplaneList[newAp.ID].Country = newAp.Country;
			clientSocket.airplaneList[newAp.ID].Date = newAp.Date;
			clientSocket.airplaneList[newAp.ID].DepartApt = newAp.DepartApt;
			clientSocket.airplaneList[newAp.ID].DestApt = newAp.DestApt;
			clientSocket.airplaneList[newAp.ID].LeftSeats = newAp.LeftSeats;
			clientSocket.airplaneList[newAp.ID].Time = newAp.Time;
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
