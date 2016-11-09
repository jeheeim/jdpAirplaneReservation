using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HashTag;

namespace HashTagUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            Form loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Form loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            Form searchForm = new BookingSearchForm();
            searchForm.ShowDialog();

        }

        private void btnCheckTicket_Click(object sender, EventArgs e)
        {
            Form CheckTicket= new CheckTicketForm();
            CheckTicket.ShowDialog();
        }
    }
}
