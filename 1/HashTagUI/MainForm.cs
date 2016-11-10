using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HashTag;

namespace HashTagUI
{
	public partial class MainForm : Form
	{
		public Server server;
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{

			Form loginForm = new LoginForm();
			loginForm.ShowDialog();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			server = new Server();

			Form loginForm = new LoginForm();
			MessageBox.Show(server.week[0].hours[0].thisHour + " ");
			loginForm.ShowDialog();
		}

		private void btnBooking_Click(object sender, EventArgs e)
		{
			Form searchForm = new BookingSearchForm();
			searchForm.ShowDialog();

		}

		private void btnCheckTicket_Click(object sender, EventArgs e)
		{
			Form CheckTicket = new CheckTicketForm();
			CheckTicket.ShowDialog();
		}
		public void makeServerAccount()
		{
			int counter = 0;
			string line;

			// Read the file and display it line by line.
			System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\jay\Documents\test.txt");
			while ((line = file.ReadLine()) != null)
			{
				System.Console.WriteLine(line);
				counter++;
			}

			file.Close();
		}
	}
}
