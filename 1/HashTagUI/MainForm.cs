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
        //6, 1
        public static readonly Size MainFormSize = new Size(265, 265);
        public static readonly Point GroupBoxLoc = new Point(6, 1);
        public static readonly Point GroupBoxOutOfRange = new Point(200, 300);
        private Account acc_currnetUser;
        public Account currentUser { get { return acc_currnetUser; } set { acc_currnetUser = value; } }
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
                this.Hide();
                loginForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("로그아웃 성공");
                currentUser = null;
                btnLoginout.Text = "log in";
                lblLoginText.Text = "로그아웃상태입니다";
                label2.Visible = true;
                label3.Visible = true;
                btnAdmAirManager.Visible = false;
                btnAdminSchedule.Visible = false;
                btnCheckTicket.Visible = true;
				btnBooking.Visible = true;
				btnFindAcc.Visible = true;
            }
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
            server = new Server();
            Form loginForm = new LoginForm(this);
            loginForm.ShowDialog();

        }

		private void btnBooking_Click(object sender, EventArgs e)
		{
            if (currentUser == null)
            {
                MessageBox.Show("로그인부터 하십시오!");
                return;
            }
			Form searchForm = new BookingSearchForm(currentUser);
			searchForm.ShowDialog();
		}

		private void btnCheckTicket_Click(object sender, EventArgs e)
		{
            if (currentUser == null)
            {
                MessageBox.Show("로그인부터 하십시오!");
                return;
            }
            Form CheckTicket = new CheckTicketForm(currentUser);
			CheckTicket.ShowDialog();
		}
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                label2.Visible = true;
                label3.Visible = true;
                btnAdmAirManager.Visible = false;
                btnAdminSchedule.Visible = false;
                btnBooking.Visible = true;
                btnCheckTicket.Visible = true;
            }
            else
            {
                label2.Visible = false;
				label3.Visible = false;
				btnFindAcc.Visible = false;
                if (currentUser.isAdmin)
                {
                    btnAdmAirManager.Visible = true;
                    btnAdminSchedule.Visible = true;
                    btnBooking.Visible = false;
                    btnCheckTicket.Visible = false;
                }
                else
                {
                    btnAdmAirManager.Visible = false;
                    btnAdminSchedule.Visible = false;
                    btnBooking.Visible = true;
                    btnCheckTicket.Visible = true;
                }
            }
        }
	}
}
