using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HashTagManagerUI
{
    public partial class MainForm : Form
    {
        bool islogin = false;
        public MainForm()
        {
            
            InitializeComponent();
        }

        private void btnLoginout_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("a"))
            {
                this.Size=new Size(1000,1000)
                ;
            }
        }
        
    }
}
