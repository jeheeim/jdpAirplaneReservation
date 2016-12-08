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
    /* 11.29 수정*/
    public partial class FindPwForm : Form
    {
        MainForm mainForm;
        public FindPwForm(MainForm f)
        {
            mainForm = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("id를 입력해주세요");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("이름을 입력해주세요");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Email을 입력해주세요");
            }
            else
            {
				// textBox정보 서버에 넘겨서 패스워드 알아내야함
				/*
                if (MainForm.clientSocket.userInfo.ContainsKey(textBox1.Text))
                {
                    if (MainForm.clientSocket.userInfo[textBox1.Text].name.Equals(textBox2.Text))
                    {
                        if (MainForm.clientSocket.userInfo[textBox1.Text].email.Equals(textBox3.Text))
                        {
                            MessageBox.Show("PW는 " + MainForm.clientSocket.userInfo[textBox1.Text].pw + "입니다");
                        }
                        else
                        {
                            MessageBox.Show("입력된 email이 틀렸습니다");
                        }
                    }
                    else
                    {
                        MessageBox.Show("입력된 이름이 틀렸습니다");
                    }
                }
                else
                {
                    MessageBox.Show("해당 id가 존재하지 않습니다");
                }*/

				string password = MainForm.clientSocket.GetInfo(textBox1.Text, textBox2.Text, textBox3.Text);

				if(password == null)
				{
					MessageBox.Show("실패!");
				}
				else
				{
					MessageBox.Show("패스워드는 " + password + "입니다.");
				}
            }
        }
    }
}
