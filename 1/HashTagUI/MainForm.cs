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
                currentUser = server.login(textBox1.Text, textBox2.Text);
                if (currentUser != null)
                {
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    btnFindId.Visible = false;
                    btnFindPw.Visible = false;
                    lblLoginText.Text = currentUser.name + "님 환영합니다.";
                    btnLoginout.Text = "로그아웃";
                    MessageBox.Show("로그인 성공");
                }
                else
                {
                    MessageBox.Show("로그인 실패");
                }
            }
            else
            {
                MessageBox.Show("로그아웃 성공");
                currentUser = null;
                btnLoginout.Text = "로그인";
                lblLoginText.Visible = false;

                label2.Visible = true;
                label3.Visible = true;
                btnAdmAirManager.Visible = false;
                btnAdminSchedule.Visible = false;
                btnCheckTicket.Visible = true;
                btnBooking.Visible = true;
				btnFindId.Visible = true;
                btnFindPw.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
            }
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
            server = new Server();
            foreach (KeyValuePair<string, Airplane> temp in server.airplaneList)
            {
                cbStart.Items.Add(temp.Value.DepartApt);
            }
        }

		private void btnBooking_Click(object sender, EventArgs e)
		{
            if (currentUser == null)
            {
                MessageBox.Show("로그인부터 하십시오!");
                return;
            }
			Form searchForm = new BookingSearchForm1(currentUser);
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
                btnFindId.Visible = false;
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

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = new RegisterForm();
            f.ShowDialog();
        }

        private void btnFindAcc_Click(object sender, EventArgs e)
        {
            Form f = new FindIdForm(this);
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new FindPwForm(this);
            f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form f = new FastBookingSearchForm(this);
            f.ShowDialog();
        }

        private void cbDest_Click(object sender, EventArgs e)
        {
            if (cbStart.SelectedIndex == -1)
            {
                cbDest.Enabled = false;
                MessageBox.Show("출발지를 선택해주세요");
                
            }
        }

        
	}
}
