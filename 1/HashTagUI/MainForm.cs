using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HashTagUI;

namespace HashTagUI
{
	public partial class MainForm : Form
	{
        public Account currentUser;
		public static Server server;
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
            if (currentUser == null)
            {
                Form loginForm = new LoginForm(this);
                loginForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("로그아웃 성공");
                currentUser = null;
                btnLogin.Text = "log in";
                lblLoginText.Text = "로그아웃상태입니다";
            }
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			server = new Server();
            makeServerAccount();
			Form loginForm = new LoginForm(this);
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
			string line,id,pw,name;

			// Read the file and display it line by line.
			System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\jay\Documents\account.txt");
			while ((line = file.ReadLine()) != null)
			{
                id = line.Substring(0, line.IndexOf(','));
                line = line.Substring(line.IndexOf(',') + 1);
                pw = line.Substring(0, line.IndexOf(','));
                line = line.Substring(line.IndexOf(',') + 1);
                name = line;
                Account temp=new Account(id,pw,name);
                server.userInfo.Add(id,temp);
			}

			file.Close();
		}
	}
}
