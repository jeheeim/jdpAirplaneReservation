using System;
using System.Windows.Forms;

namespace ApplicationManager
{
	public partial class LoginForm : Form
	{
		internal ClientSocket clientSocket;

		ManagerForm managerForm;

		public LoginForm()
		{
			InitializeComponent();

			clientSocket = new ClientSocket();

		}

		#region 버튼 이벤트
		private void btnLogin_Click(object sender, EventArgs e)
		{
			if (clientSocket.Login(tboxID.Text, tboxPassword.Text))
			{
				MessageBox.Show("로그인에 성공했습니다");

				managerForm = new ManagerForm(this);

				managerForm.Show();
				Hide();
			}
			else
			{
				MessageBox.Show("아이디 혹은 패스워드를 잘못 입력하셨습니다.");
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
	}
}
