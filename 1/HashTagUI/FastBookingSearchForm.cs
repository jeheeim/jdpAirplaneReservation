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
            label1.Text = mainForm.cbStart.SelectedItem.ToString() + "로 돌아오는 비행기 리스트 입니다.";
            //label2.Visible = false;
            label2.Text = "이용하실 비행기를 선택해주세요";

            foreach (KeyValuePair<string, Airplane> temp in MainForm.server.airplaneList)
            {
                if (temp.Value.DepartApt.Equals(mainForm.cbStart.SelectedItem.ToString()) && temp.Value.DestApt.Equals(mainForm.cbDest.SelectedItem.ToString()) && temp.Value.Date.Equals(mainForm.cbDepart.SelectedItem.ToString()))
                {
                   ListViewItem lvItem = new ListViewItem(new string[6] { temp.Value.ID, temp.Value.DepartApt, temp.Value.DestApt, temp.Value.Date, temp.Value.Time, temp.Value.LeftSeats.ToString() });
                   this.lvSearchResult.Items.Add(lvItem);
                }
            }
            
            foreach (KeyValuePair<string, Airplane> temp in MainForm.server.airplaneList)
            {
                if (temp.Value.DestApt.Equals(mainForm.cbStart.SelectedItem.ToString()) && temp.Value.DepartApt.Equals(mainForm.cbDest.SelectedItem.ToString()) && temp.Value.Date.Equals(mainForm.cbArrive.SelectedItem.ToString()))
                {
                    ListViewItem lvItem = new ListViewItem(new string[6] { temp.Value.ID, temp.Value.DepartApt, temp.Value.DestApt, temp.Value.Date, temp.Value.Time, temp.Value.LeftSeats.ToString() });
                    this.lvSearchResult1.Items.Add(lvItem);
                }
            }
            lvSearchResult.HideSelection = false;
            lvSearchResult1.HideSelection = false;
            
        }

        private void lvSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSearchResult.SelectedItems.Count != 1)
            {
                label2.Text="출발 비행기를 선택해주세요";
                label2.Visible=true;
            }
            else if (lvSearchResult1.SelectedItems.Count != 1)
            {
                label2.Text="도착 비행기를 선택해주세요";
            }
            else
            {
                label2.Text = "총 비용은 " + (int)(MainForm.server.airplaneList[lvSearchResult.SelectedItems[0].SubItems[0].Text].Cost + MainForm.server.airplaneList[lvSearchResult1.SelectedItems[0].SubItems[0].Text].Cost) + "입니다";
            }
        }

        private void lvSearchResult1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSearchResult.SelectedItems.Count != 1)
            {
                label2.Text = "출발 비행기를 선택해주세요";
                label2.Visible = true;
            }
            else if (lvSearchResult1.SelectedItems.Count != 1)
            {
                label2.Text = "도착 비행기를 선택해주세요";
            }
            else
            {
                label2.Text = "총 비용은 " + (int)(MainForm.server.airplaneList[lvSearchResult.SelectedItems[0].SubItems[0].Text].Cost + MainForm.server.airplaneList[lvSearchResult1.SelectedItems[0].SubItems[0].Text].Cost) + "입니다";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons button = MessageBoxButtons.OKCancel;
            String text = "결제하시겠습니까?";
            String caption = "결제확인";
            DialogResult result = MessageBox.Show(text, caption, button);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (MainForm.server.airplaneList[lvSearchResult.SelectedItems[0].SubItems[0].Text].LeftSeats >= int.Parse(mainForm.comboBox1.SelectedItem.ToString()) && MainForm.server.airplaneList[lvSearchResult1.SelectedItems[0].SubItems[0].Text].LeftSeats >= int.Parse(mainForm.comboBox1.SelectedItem.ToString()))
                {
                    MessageBox.Show("예약완료");
                    mainForm.currentUser.addToBook(lvSearchResult.SelectedItems[0].SubItems[0].Text, int.Parse(mainForm.comboBox1.SelectedItem.ToString()));
                    mainForm.currentUser.addToBook(lvSearchResult1.SelectedItems[0].SubItems[0].Text, int.Parse(mainForm.comboBox1.SelectedItem.ToString()));
                    MainForm.server.airplaneList[lvSearchResult.SelectedItems[0].SubItems[0].Text].LeftSeats -= int.Parse(mainForm.comboBox1.SelectedItem.ToString());
                    MainForm.server.airplaneList[lvSearchResult1.SelectedItems[0].SubItems[0].Text].LeftSeats -= int.Parse(mainForm.comboBox1.SelectedItem.ToString());
        
                }
                else if (MainForm.server.airplaneList[lvSearchResult.SelectedItems[0].SubItems[0].Text].LeftSeats < int.Parse(mainForm.comboBox1.SelectedItem.ToString()))
                {
                    MessageBoxButtons button1 = MessageBoxButtons.OKCancel;
                    String text1 = "출발 비행기의 좌석이 부족합니다, 알림서비스를 요청하시겠습니까?";
                    String caption1 = "알림서비스 요청여부";
                    DialogResult result1 = MessageBox.Show(text1, caption1, button1);
                }
                else if (MainForm.server.airplaneList[lvSearchResult1.SelectedItems[0].SubItems[0].Text].LeftSeats < int.Parse(mainForm.comboBox1.SelectedItem.ToString()))
                {
                    MessageBoxButtons button1 = MessageBoxButtons.OKCancel;
                    String text1 = "도착 비행기의 좌석이 부족합니다, 알림서비스를 요청하시겠습니까?";
                    String caption1 = "알림서비스 요청여부";
                    DialogResult result1 = MessageBox.Show(text1, caption1, button1);
                }
                //mainForm.currentUser.addToBook(nowAirplane.ID, clickedSeats);
            }
            else
            {
                MessageBox.Show("취소");
            }
            
        }

        
    }
}
