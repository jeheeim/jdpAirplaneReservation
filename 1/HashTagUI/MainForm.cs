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
        /* 11.29 수정*/
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
                    label2.Visible = false;
                    label3.Visible = false;
                    btnLoginout.Text = "로그아웃";
                    label11.Visible = true;
                    label11.Text = currentUser.id + "님을 위한 추천 항공편";
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
				btnFindId.Visible = true;
                btnFindPw.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label11.Visible = false;
            }
		}
        /* 11.29 수정*/
		private void MainForm_Load(object sender, EventArgs e)
		{
            server = new Server();
            foreach (KeyValuePair<string, Airplane> temp in server.airplaneList)
            {
                cbStart.Items.Add(temp.Value.DepartApt);
            }
            cbArrive.Enabled = false;
            cbDest.Enabled = false;
            cbDepart.Enabled = false;
            label11.Visible = false;
            
        }
        /* 11.29 수정*/
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
        /* 11.29 수정*/
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
        /* 11.29 수정*/
        private void label3_Click(object sender, EventArgs e)
        {
            Form f = new RegisterForm();
            f.ShowDialog();
        }
        /* 11.29 J 수정*/
        private void btnFindAcc_Click(object sender, EventArgs e)
        {
            Form f = new FindIdForm(this);
            f.ShowDialog();
        }
        /* 11.29 수정*/
        private void btnFindPw_Click(object sender, EventArgs e)
        {
            Form f = new FindPwForm(this);
            f.ShowDialog();
        }
        /* 11.29 수정*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbArrive.SelectedIndex != -1 && textPerson.Text != "")
            {
                Form f = new FastBookingSearchForm(this);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("정보를 다 입력하세요");
            }
        }
        /* 11.29 수정*/
        private void cbStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStart.SelectedIndex == -1)
            {
                cbArrive.SelectedIndex = cbDepart.SelectedIndex = cbDest.SelectedIndex = -1;
                cbArrive.Enabled = cbDepart.Enabled = cbDest.Enabled = false;
            }
            else
            {
                cbDest.Enabled = true;
                foreach (KeyValuePair<string, Airplane> temp in server.airplaneList)
                {
                    if(temp.Value.DepartApt.Equals(cbStart.SelectedItem.ToString()))
                    {
                        cbDest.Items.Add(temp.Value.DestApt);
                    }
                }
            }
        }
        /* 11.29 수정*/
        private void cbDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDest.SelectedIndex == -1)
            {
                cbArrive.SelectedIndex = cbDepart.SelectedIndex =  -1;
                cbArrive.Enabled = cbDepart.Enabled = false;
            }
            else
            {
                cbDepart.Enabled = true;
                foreach (KeyValuePair<string, Airplane> temp in server.airplaneList)
                {
                    if (temp.Value.DepartApt.Equals(cbStart.SelectedItem.ToString()) && temp.Value.DestApt.Equals(cbDest.SelectedItem.ToString()))
                    {
                        cbDepart.Items.Add(temp.Value.Date);
                    }
                }
            }
        }
        /* 11.29 수정*/
        private void cbDepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDepart.SelectedIndex == -1)
            {
                cbArrive.SelectedIndex = -1;
                cbArrive.Enabled = false;
            }
            else
            {
                cbArrive.Enabled = true;
                foreach (KeyValuePair<string, Airplane> temp in server.airplaneList)
                {
                    if (temp.Value.DestApt.Equals(cbStart.SelectedItem.ToString()) && temp.Value.DepartApt.Equals(cbDest.SelectedItem.ToString()) && !temp.Value.Date.Equals(cbDepart.SelectedItem.ToString()))
                    {
                        cbArrive.Items.Add(temp.Value.Date);
                    }
                }
            }
        }
	}
}
