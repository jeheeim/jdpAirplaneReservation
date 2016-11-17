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
	public partial class LoginForm : Form
	{
		MainForm mainForm;
		public LoginForm(MainForm mainForm)
		{
			this.mainForm = mainForm;
			InitializeComponent();
		}


		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void LoginForm_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			mainForm.currentUser = MainForm.server.login(textBox1.Text, textBox2.Text);
			mainForm.lblLoginText.Text = "로그인 되었습니다.";
			mainForm.btnLogin.Text = "log out";
			if (mainForm.currentUser != null)
			{
				MessageBox.Show("로그인 성공");
				this.Close();
			}
			else
			{
				MessageBox.Show("로그인 실패");
			}
		}

	}
}
