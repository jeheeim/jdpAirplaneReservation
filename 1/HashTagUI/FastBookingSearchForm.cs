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
    public partial class FastBookingSearchForm : Form
    {
        MainForm mainForm;
        public FastBookingSearchForm(MainForm f)
        {
            mainForm = f;
            InitializeComponent();
        }

        private void FastBookingSearchForm_Load(object sender, EventArgs e)
        {
            lblSearchText.Text = mainForm.cbArrive.SelectedItem.ToString() + "로 가는 비행기 리스트 입니다.";
        }
    }
}
