using System;
using System.Windows.Forms;

namespace HashTagUI
{
	public partial class CheckPassword : Form
	{
		MainForm mainForm;

		public CheckPassword(MainForm mainForm)
		{
			InitializeComponent();

			this.mainForm = mainForm;
		}


		#region 버튼 이벤트 확인, 취소

		// 확인 버튼
		private void btnOK_Click(object sender, EventArgs e)
		{
			if(mainForm.currentUser.pw == tboxPassword.Text)
			{
				mainForm.ShowModifyInfoForm();

				Close();
			}
			else
			{
				MessageBox.Show("비밀번호를 틀리셨습니다!");
			}
		}

		// 취소 버튼
		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		#endregion
	}
}
