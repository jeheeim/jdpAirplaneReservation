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
        /* 11.29 수정*/
        MainForm mainForm;
        public FastBookingSearchForm(MainForm f)
        {
            mainForm = f;
            InitializeComponent();
        }

        private void FastBookingSearchForm_Load(object sender, EventArgs e)
        {
            lblSearchText.Text = mainForm.cbDest.SelectedItem.ToString() + "로 가는 비행기 리스트 입니다.";
            foreach (KeyValuePair<string, Airplane> temp in MainForm.server.airplaneList)
            {
                if (temp.Value.DepartApt.Equals(mainForm.cbStart.SelectedItem.ToString()) && temp.Value.DestApt.Equals(mainForm.cbDest.SelectedItem.ToString()) && temp.Value.Date.Equals(mainForm.cbDepart.SelectedItem.ToString()))
                {
                   ListViewItem lvItem = new ListViewItem(new string[6] { temp.Value.ID, temp.Value.DepartApt, temp.Value.DestApt, temp.Value.Date, temp.Value.Time, temp.Value.LeftSeats.ToString() });
                   this.lvSearchResult.Items.Add(lvItem);
                }
            }
        }
    }
}
