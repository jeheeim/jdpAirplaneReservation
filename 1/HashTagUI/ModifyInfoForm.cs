using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HashTagUI
{
	public partial class ModifyInfoForm : Form
	{
		MainForm mainForm;

		public ModifyInfoForm(MainForm mainForm)
		{
			InitializeComponent();
			
			this.mainForm = mainForm;
		}

		private void ModifyInfo_Load(object sender, EventArgs e)
		{
			tboxName.Text = mainForm.currentUser.name;
			tboxID.Text = mainForm.currentUser.id;
			tboxPassword.Text = mainForm.currentUser.pw;
			tboxEmail.Text = mainForm.currentUser.email;

			foreach(KeyValuePair < string, List < string >> targetCountries in MainForm.clientSocket.Destinations)

			{
				foreach (string eachContury in targetCountries.Value)
				{
					cboxInterest.Items.Add(eachContury); // 이부분 수정
				}
			}
		}

		#region 버튼 메소드

		private void btnOK_Click(object sender, EventArgs e)
		{

			if (ChechFull())
			{
				if (tboxPassword.Text == tboxPasswordConfirm.Text)
				{
					Account temp = new Account(tboxID.Text, tboxPassword.Text, tboxName.Text, tboxEmail.Text,((cboxInterest.Text=="")?"NULL":cboxInterest.Text));

					if (cboxInterest.SelectedItem != null)
					{
						temp.Interest = cboxInterest.SelectedItem.ToString();
					}

					if(MainForm.clientSocket.ModifyInfo(temp))
					{
                        mainForm.currentUser.pw = temp.pw;
                        mainForm.currentUser.name = temp.name;
                        mainForm.currentUser.email = temp.email;
                        mainForm.currentUser.Interest = temp.Interest;

						MessageBox.Show("개인정보 수정을 성공했습니다!");

						this.Close();
					}
					else
					{
						MessageBox.Show("에러!");
					}
				}
				else
				{
					MessageBox.Show("비밀번호가 일치하지않습니다!");
				}
			}
			else
			{
				MessageBox.Show("빈 내용이 있습니다!");
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("탈퇴하시겠습니까?", "경고", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if (MainForm.clientSocket.DeleteAccount(mainForm.currentUser.id))
				{
					MessageBox.Show("삭제되었습니다");
                    mainForm.ToLogOut();
                    this.Close();
				}
				else
				{
					MessageBox.Show("실패했습니다. 다시 시도해주세요.");
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		#endregion

		bool ChechFull()
		{
			if(tboxName.Text == "")
			{
				return false;
			}
			if(tboxPassword.Text == "")
			{
				return false;
			}
			if(tboxPasswordConfirm.Text == "")
			{
				return false;
			}
			if(tboxEmail.Text == "")
			{
				return false;
			}

			return true;
		}
	}
}
