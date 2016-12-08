using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
		public static ClientSocket clientSocket;
		
		public MainForm()
		{
			InitializeComponent();

			for(int i=0;i<lvSearchResult1.Columns.Count;i++)
			{
				lvSearchResult1.Columns[i].Width = lvSearchResult1.Width / lvSearchResult1.Columns.Count;
			}
		}
        /* 11.29 수정*/
		// 로그인 함수
		private void btnLogin_Click(object sender, EventArgs e)
		{
            if (currentUser == null)
            {
				// clientSocket 클래스의 login실행
                currentUser = clientSocket.login(textBox1.Text, textBox2.Text);

                if (currentUser != null)
                {
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    btnFindId.Visible = false;
                    btnFindPw.Visible = false;
                    lblLoginText.Location = new Point(539, 27);
                    lblLoginText.Text = currentUser.name + "님 환영합니다.";
                    lblLoginText.Visible = true;
                    label2.Visible = false;
                    label3.Visible = false;
                    btnLoginout.Text = "로그아웃";
                    gbRecommend.Text = currentUser.id + "님을 위한 추천 항공편";
                    gbRecommend.Visible = true;
					btnModifyInfo.Visible = true;
					btnModifyInfo.Enabled = true;
					InputRecommendToUsers();

					MessageBox.Show("로그인 성공");
                }
                else
                {
                    MessageBox.Show("로그인 실패");
                }
            }
            else
            {
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
                gbRecommend.Text = "추천 항공편";
                gbRecommend.Visible = false;
				btnModifyInfo.Visible = false;
				btnModifyInfo.Enabled = false;

				MessageBox.Show("로그아웃 성공");
			}
		}

		// 메소드 추가
		private void InputRecommendToUsers()
		{
			Dictionary<int, Airplane> dicMinCosts = new Dictionary<int, Airplane>();
			string userInterest = "NULL";
			this.lvSearchResult1.Items.Clear();
			if (currentUser != null)
				userInterest = currentUser.Interest;
			if (userInterest == "")
			{
				foreach (KeyValuePair<string, Airplane> temp in MainForm.clientSocket.airplaneList)
				{
					putValueInMinCost(temp.Value, dicMinCosts);
				}
			}
			else
			{
				foreach (KeyValuePair<string, List<string>> targetValue in clientSocket.airplaneDest[userInterest])
				{
					foreach (string targetKey in targetValue.Value)
					{
						putValueInMinCost(clientSocket.airplaneList[targetKey], dicMinCosts);
					}
				}
			}
			for (int i = 0; i < 3; i++)
			{
				ListViewItem lvItem = new ListViewItem(new string[6] { dicMinCosts[i].ID, dicMinCosts[i].DepartApt, dicMinCosts[i].DestApt, dicMinCosts[i].Date, dicMinCosts[i].Time, dicMinCosts[i].Cost.ToString() });
				this.lvSearchResult1.Items.Add(lvItem);
			}
		}

		// 폼 로드 이벤트
		private void MainForm_Load(object sender, EventArgs e)
		{
			clientSocket = new ClientSocket();

			foreach (KeyValuePair<string, Airplane> temp in clientSocket.airplaneList)
			{
				cbStart.Items.Add(temp.Value.DepartApt);
			}

			cbArrive.Enabled = false;
			cbDest.Enabled = false;
			cbDepart.Enabled = false;
			gbRecommend.Text = "추천 항공편";
			gbRecommend.Visible = false;
			
			// timer관련 함수
			TimerMQ.Start();
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
		}

        private void putValueInMinCost(Airplane target, Dictionary<int, Airplane> targetDic)
		{
			if (targetDic.Count < 3)
			{
				for (int i = 0; i < 3; i++)
				{
					if (!targetDic.ContainsKey(i))
					{
						targetDic.Add(i, target);
						return;
					}
				}
			}
			for (int i = 0; i < 3; i++)
			{
				if (targetDic[i].Cost > target.Cost)
				{
					for (int j = i + 1; j < 3; j++)
					{
						targetDic[j] = targetDic[j - 1];
					}
					targetDic[i] = target;
					break;
				}
			}
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
            if (cbArrive.SelectedIndex != -1 && comboBox1.SelectedIndex!=-1 && currentUser!=null)
            {
                Form f = new FastBookingSearchForm(this);
                f.ShowDialog();
            }
            else if (currentUser == null)
            {
                MessageBox.Show("로그인을 하세요");
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
                cbDest.Items.Clear();
                foreach (KeyValuePair<string, Airplane> temp in clientSocket.airplaneList)
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
                cbDepart.Items.Clear();
                foreach (KeyValuePair<string, Airplane> temp in clientSocket.airplaneList)
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
            int maxSeat = 0;
            if (cbDepart.SelectedIndex == -1)
            {
                cbArrive.SelectedIndex = -1;
                cbArrive.Enabled = false;
            }
            else
            {
                cbArrive.Enabled = true;
                cbArrive.Items.Clear();
                foreach (KeyValuePair<string, Airplane> temp in clientSocket.airplaneList)
                {
                    if (temp.Value.DestApt.Equals(cbStart.SelectedItem.ToString()) && temp.Value.DepartApt.Equals(cbDest.SelectedItem.ToString()) && !temp.Value.Date.Equals(cbDepart.SelectedItem.ToString()))
                    {
                        cbArrive.Items.Add(temp.Value.Date);
                        if (maxSeat > temp.Value.LeftSeats)
                        {
                            maxSeat = temp.Value.LeftSeats;
                        }
                        else if (maxSeat == 0)
                        {
                            maxSeat = temp.Value.LeftSeats;
                        }
                    }
                }
                for (int i = 1; i <= maxSeat; i++)
                {
                    comboBox1.Items.Add(i);
                }
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar) && e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void TimerMQ_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            lblMarqRec.Left += 5;
            if(lblMarqRec.Left >= this.Width)
            {
                lblMarqRec.Left = lblMarqRec.Width * -1;
            }
            Graphics gra = this.CreateGraphics();
            gra.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        }

        private void lblMarqRec_MouseHover(object sender, EventArgs e)
        {
            TimerMQ.Stop();
        }

        private void lblMarqRec_MouseLeave(object sender, EventArgs e)
        {
            TimerMQ.Start();
        }

        private void cbStart_MouseClick(object sender, MouseEventArgs e)
        {
            FastBookingInputForm fbi = new FastBookingInputForm(this, 0);
            fbi.ShowDialog();
        }

        private void lvSearchResult1_DoubleClick(object sender, EventArgs e)
        {
            string name = this.lvSearchResult1.SelectedItems[0].SubItems[0].Text;
            Form searchResult = new BookingAirplaneSeatForm(currentUser, name);
            searchResult.ShowDialog();
        }

		bool isPasswordCorrect = false;
		public void ShowModifyInfoForm() { isPasswordCorrect = true; }

		// 임제희 12/8 추가
		// 개인정보 수정하기 버튼을 클릭할 경우 실행되는 이벤트
		// 비밀번호 확인 창을 띄워 확인한 뒤, 맞으면 개인정보 수정하기 창을 띄운다.
		private void btnModifyInfo_Click(object sender, EventArgs e)
		{
			CheckPassword checkPassword = new CheckPassword(this);
			checkPassword.ShowDialog();

			if(isPasswordCorrect)
			{
				ModifyInfoForm modifyInfoForm = new ModifyInfoForm(this);
				modifyInfoForm.ShowDialog();
			}
		}
	}
}
