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
    public partial class CheckTicketForm : Form
    {
        public CheckTicketForm()
        {
            InitializeComponent();
        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            MessageBox.Show("확인");
            this.Close();
        }

        private void btnCancelTicket_Click(object sender, EventArgs e)
        {
            MessageBox.Show("확인");
            this.Close();
        }
    }
}
