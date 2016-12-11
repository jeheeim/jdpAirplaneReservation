using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ApplicationManager
{
	public partial class ManagerForm : Form
	{
		ClientSocket clientSocket;
		LoginForm loginForm;

		string seat30 = "";
		string seat50 = "";

		public ManagerForm(LoginForm loginForm)
		{
			InitializeComponent();

			this.loginForm = loginForm;
			clientSocket = loginForm.clientSocket;

			InitiateListbox();

			seat30 = InitiateSeats(3);
			seat50 = InitiateSeats(5);
		}

		string InitiateSeats(int num)
		{
			string result = "";
			for (int i = 0; i < num; i++)
			{
				for (int j = 1; j <= 10; j++)
				{
					result += (char)('A' + i) + j.ToString() + ',';
				}
			}
			result = result.Substring(0, result.LastIndexOf(','));
			
			return result;
		}

		void InitiateListbox()
		{
			listBox1.Items.Clear();

			clientSocket.addAirplaneList();

			//서버에 있는 리스트를 전부 받아옴
			foreach (KeyValuePair<string, Airplane> kv in clientSocket.airplaneList)
			{
				listBox1.Items.Add(kv.Value);
			}
		}

		// 리스트박스 클릭시
		private void listBox1_ItemClicked(object sender, EventArgs e)
		{
			string item = ((Airplane)listBox1.SelectedItem).ID;
			Airplane airplane = clientSocket.airplaneList[item];

			tboxAirplaneID.Text = airplane.ID;
			tboxRegion.Text = airplane.Continent;
			tboxDepartApt.Text = airplane.DepartApt;

			string[] monthAndDate = airplane.Date.Split('/');
			string[] hour = airplane.Time.Split(':');

			DateTime departDateTime = new DateTime(2016, int.Parse(monthAndDate[0]), int.Parse(monthAndDate[1]));
			departDateTime = departDateTime.AddHours(int.Parse(hour[0]));
			departDateTime = departDateTime.AddMinutes(int.Parse(hour[1]));

			dtpDepartDate.Value = departDateTime;
			dtpDepartTime.Value = departDateTime;

			tboxDestCountry.Text = airplane.Country;
			tboxDestApt.Text = airplane.DestApt;

			if(airplane.LeftSeats == 30)
			{
				rbtn30.PerformClick();
			}
			else
			{
				rbtn50.PerformClick();
			}

			tboxCost.Text = airplane.Cost.ToString();
		}

		#region 버튼 이벤트

		// 리스트박스 초기화 메소드로 바꿀것
		// 추가 버튼
		private void btnAdd_Click(object sender, EventArgs e)
		{
			Airplane newAirplane = ConversionIntoAirplane();

			if (clientSocket.AddAirplane(newAirplane)) { listBox1.Items.Add(newAirplane); }
			else { MessageBox.Show("추가 실패!"); }
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			Airplane newAirplane = ConversionIntoAirplane();

			if (clientSocket.ModifyAirplaneInfo(newAirplane))
			{
				// 기존의 것을 삭제하고 새로운 것으로 더함
				listBox1.Items.Remove(listBox1.SelectedItem);
				listBox1.Items.Add(newAirplane);
			}
			else { MessageBox.Show("수정 실패!"); }
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

			if (dr == DialogResult.OK)
			{
				Airplane newAirplane = ConversionIntoAirplane();

				if (clientSocket.DeleteAirplane(newAirplane))
				{
					listBox1.Items.Remove(listBox1.SelectedItem);
				}
				else { MessageBox.Show("삭제 실패!"); }
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		#endregion

		// Airplane 객체 만들기
		private Airplane ConversionIntoAirplane()
		{
			string id = tboxAirplaneID.Text;
			string departApt = tboxDepartApt.Text;
			string departDate = dtpDepartDate.Value.Month.ToString() + '/' + dtpDepartDate.Value.Day.ToString();
			string departTime = dtpDepartTime.Value.Hour.ToString() + ":" + dtpDepartTime.Value.Minute.ToString();
			string region = tboxRegion.Text;
			string destCountry = tboxDestCountry.Text;
			string destApt = tboxDestApt.Text;
			string seats;

			if(rbtn30.Checked == true)
			{
				seats = seat30;
			}
			else if(rbtn50.Checked == true)
			{
				seats = seat50;
			}
			else
			{
				seats = seat50;
			}

			int cost = int.Parse(tboxCost.Text);

			Airplane newAirplane = new Airplane(id, region, destCountry, departApt, destApt, departDate, departTime, cost, seats);

			return newAirplane;
		}

		private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			loginForm.Close();
		}
	}
}
