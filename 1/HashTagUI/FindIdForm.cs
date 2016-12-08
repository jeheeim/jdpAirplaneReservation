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
    public partial class FindIdForm : Form
    {
        MainForm mainForm;
        public FindIdForm(MainForm f)
        {
            mainForm = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isexist = false;
            if(textBox1.Text.Equals(""))
            {
                MessageBox.Show("이름을 입력해주세요");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Email을 입력해주세요");
            }
            else
            {
                foreach (KeyValuePair<String, Account> temp in MainForm.clientSocket.userInfo)
                {
                    if (temp.Value.name.Equals(textBox1.Text) && temp.Value.email.Equals(textBox2.Text))
                    {
                        MessageBox.Show("id는 "+temp.Value.id+"입니다");
                        isexist = true;
                        break;
                    }
                }
            }
            if (!isexist)
            {
                MessageBox.Show("id가 존재하지 않습니다");
            }
        }
    }
}
