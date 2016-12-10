using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ApplicationManager
{
	public partial class ManagerForm : Form
	{
		ClientSocket clientSocket;
		LoginForm loginForm;
		
		public ManagerForm(LoginForm loginForm)
		{
			InitializeComponent();

			this.loginForm = loginForm;
			clientSocket = loginForm.clientSocket;

			InitiateListbox();
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
			string item = listBox1.SelectedItem.ToString();
			Airplane airplane = clientSocket.airplaneList[item];

			tboxAirplaneID.Text = airplane.ID;
			tboxDepartApt.Text = airplane.DepartApt;

			string[] monthAndDate = airplane.Date.Split('.');
			string[] hour = airplane.Time.Split(':');

			DateTime departDateTime = new DateTime(2016, int.Parse(monthAndDate[0]), int.Parse(monthAndDate[1]));
			departDateTime = departDateTime.AddHours(int.Parse(hour[0]));
			departDateTime = departDateTime.AddMinutes(int.Parse(hour[1]));

			dtpDepartDate.Value = departDateTime;
			dtpDepartTime.Value = departDateTime;

			tboxDestCountry.Text = airplane.Country;
			tboxDestApt.Text = airplane.DestApt;
			tboxNumOfSeat.Text = airplane.LeftSeats.ToString();
			tboxCost.Text = airplane.Cost.ToString();
		}

		#region 버튼 이벤트

		// 리스트박스 초기화 메소드로 바꿀것
		// 추가 버튼
		private void btnAdd_Click(object sender, EventArgs e)
		{
			Airplane newAirplane = ConversionIntoAirplane();

			if(clientSocket.AddAirplane(newAirplane)) { listBox1.Items.Add(newAirplane); }
			else { MessageBox.Show("추가 실패!"); }
		}

		private void btnModify_Click(object sender, EventArgs e)
		{
			Airplane newAirplane = ConversionIntoAirplane();

			if (clientSocket.ModifyAirplaneInfo(newAirplane)) { listBox1.Items.Add(newAirplane); }
			else { MessageBox.Show("수정 실패!"); }
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

			if (dr == DialogResult.OK)
			{
				Airplane newAirplane = ConversionIntoAirplane();

				if (clientSocket.DeleteAirplane(newAirplane)) { listBox1.Items.Add(newAirplane); }
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
			string departDate = dtpDepartDate.Value.Month.ToString() + '.' + dtpDepartDate.Value.Day.ToString();
			string departTime = dtpDepartTime.Value.Hour.ToString();
			string destCountry = tboxDestCountry.Text;
			string destApt = tboxDestApt.Text;
			string numOfSeats = tboxNumOfSeat.Text;
			int cost = int.Parse(tboxCost.Text);

			Airplane newAirplane = new Airplane(id, destCountry, departApt, destApt, departDate, departTime, cost, numOfSeats);

			return newAirplane;
		}

		private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			loginForm.Close();
		}
	}
}
