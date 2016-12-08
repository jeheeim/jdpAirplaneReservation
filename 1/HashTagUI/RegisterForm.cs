using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HashTagUI
{
    public partial class RegisterForm : Form
    {
		Server server;
        bool idCheck = false;
        bool pwCheck = false;
        public static string prePath = Directory.GetParent(Application.StartupPath).ToString();

        public RegisterForm(Server server)
        {
            InitializeComponent();

			this.server = server;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tbID.Text.Length <8)
            {
                label6.Text = "8~15자를 입력해주세요";
                button1.Enabled = false;
            }
            else if (tbID.Text.Length >= 8 && tbID.Text.Length <= 15)
            {
                label6.Text = "중복확인을 해주세요";
                button1.Enabled = true;
            }
            else
            {
                label6.Text = "길이를 초과했습니다";
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.server.userInfo.ContainsKey(tbID.Text))
            {
                MessageBox.Show("중복됩니다");
            }
            else
            {
                MessageBox.Show("사용가능합니다");
                idCheck = true;
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbID.Text.Length<8)
            {
                MessageBox.Show("ID를 입력해주세요");
            }
            else if (idCheck == false)
            {
                MessageBox.Show("중복확인을 해주세요");
            }
            else if (tbPW.Text == "")
            {
                MessageBox.Show("PW를 입력해주세요");
            }
            else if (tbPWagain.Text == "")
            {
                MessageBox.Show("PW재입력을 해주세요");
            }
            else if (pwCheck == false)
            {
                MessageBox.Show("입력하신 PW와 재입력한 PW가 동일하지 않습니다");
            }
            else if(tbUserName.Text=="")
            {
                MessageBox.Show("이름을 입력해주세요");
            }
            else if(tbEmail.Text=="")
            {
                MessageBox.Show("Email을 입력해주세요");
            }
            else
            {
                Account temp = new Account(tbID.Text,tbPW.Text,tbUserName.Text,tbEmail.Text);

				if (server.RegiserUser(temp))
				{
					MessageBox.Show("등록 성공했습니다!");
				}
                else
				{
					MessageBox.Show("등록 실패!");
				}
			}
		}

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((!Char.IsLetter(e.KeyChar)&& !Char.IsDigit(e.KeyChar)&& e.KeyChar!=8) || tbID.Text.Length>=15)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==' ' || tbPW.Text.Length>=20)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (tbPWagain.Text.Length == 0)
            {
                label8.Text = "PW를 다시한번 입력해주세요";
                pwCheck = false;
            }
            else if (!tbPWagain.Text.Equals(tbPW.Text))
            {
                label8.Text = "비밀번호가 동일하지 않습니다";
                pwCheck = false;
            }
            else
            {
                label8.Text = "PW가 일치합니다";
                pwCheck = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Char.IsPunctuation(e.KeyChar) || Char.IsDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        
    }
}
