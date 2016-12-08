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
    delegate void DelegateLayout();
    public partial class FastBookingInputForm : Form
    {
        MainForm mf;
        FlowLayoutPanel flp = new FlowLayoutPanel();
        DelegateLayout LayoutFill;
        int startIndex = 0;
        ComboBox[] comboBoxSelector;
        Dictionary<string, List<string>> dic_CountryWithDestination = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> dic_SelectedDestinationInfo = new Dictionary<string, List<string>>();
        public FastBookingInputForm(MainForm main, int startIndex)
        {
            flp.BorderStyle = BorderStyle.FixedSingle;
            flp.Location = new Point(1, 1);
            flp.Visible = true;
            mf = main;
            InitializeComponent();
            this.startIndex = startIndex;
        }
        private void layoutFillDelegateSelector()
        {
            switch (startIndex)
            {
                case 0:
                    LayoutFill = new DelegateLayout(cbStartLayoutFill);
                    break;
                case 1:
                    LayoutFill = new DelegateLayout(cbDestLayoutFill);
                    break;
                default:
                    this.Close();
                    break;
            }
        }
        private void FastBookingInputForm_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, Airplane> temp in MainForm.clientSocket.airplaneList)
            {
                string departName = temp.Value.DepartApt;
                string country = findCountryByAirport(departName);
                if (country == "-1")
                    continue;
                addToDepartDicitonary(departName, country);
            }

            layoutFillDelegateSelector();
            LayoutFill();
            comboBoxSelector = new ComboBox[5] { mf.cbStart, mf.cbDest, mf.cbDepart, mf.cbArrive, mf.comboBox1 };
        }
        private string findCountryByAirport(string aptName)
        {
            foreach(KeyValuePair<string,List<string>> targetPair in dic_CountryWithDestination)
            {
                foreach(string name in targetPair.Value)
                {
                    if (name == aptName)
                        return targetPair.Key;
                }
            }
            foreach (KeyValuePair<string, Dictionary<string, List<string>>> targetPair in MainForm.clientSocket.airplaneDest)
            {
                foreach (KeyValuePair<string, List<string>> valuePair in targetPair.Value)
                {
                    if (aptName == valuePair.Key)
                    {
                        return targetPair.Key;
                    }
                }
            }
            return "-1";
        }
        private void addToDepartDicitonary(string departName, string keyCountry)
        {
            if(!dic_CountryWithDestination.ContainsKey(keyCountry))
            {
                List<string> newList = new List<string>();
                dic_CountryWithDestination.Add(keyCountry, newList);
            }
            if(!dic_CountryWithDestination[keyCountry].Contains(departName))
                dic_CountryWithDestination[keyCountry].Add(departName);

        }
        private void ButtonComboboxFill_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            comboBoxSelector[startIndex++].Text = btnSender.Text;
            layoutFillDelegateSelector();
            LayoutFill();
        }
        private void cbStartLayoutFill()
        {
            this.Text = "출발지 선택";
            int cnt = 0;
            
            foreach (KeyValuePair<string,List<string>> targetPair in dic_CountryWithDestination)
            {
                Label lblCountry = new Label();
                lblCountry.Size = new Size(350, 20);
                lblCountry.BorderStyle = BorderStyle.FixedSingle;
                lblCountry.Text = targetPair.Key;
                flp.Controls.Add(lblCountry);
                foreach (string aptName in targetPair.Value)
                {
                    Button btnAirport = new Button();
                    btnAirport.Name = "cbStart";
                    btnAirport.Text = aptName;
                    btnAirport.Size = new Size(50, 50);
                    btnAirport.Click += new EventHandler(ButtonComboboxFill_Click);
                    flp.Controls.Add(btnAirport);
                }
                cnt++;
            }
            flp.Size = new Size(350, 50 + cnt * 70);
            this.Size = new Size(370, 70 + cnt * 70);
            this.Controls.Add(flp);
        }
        private void addToSelectedDictinary(string country, string airport)
        {
            if (!dic_SelectedDestinationInfo.ContainsKey(country))
            {
                List<string> newList = new List<string>();
                dic_SelectedDestinationInfo.Add(country, newList);
            }
            if (!dic_SelectedDestinationInfo[country].Contains(airport))
                dic_SelectedDestinationInfo[country].Add(airport);
        }
        private void cbDestLayoutFill()
        {
            flp.Controls.Clear();
            dic_SelectedDestinationInfo.Clear();
            this.Text = "목적지 선택";
            string startApt = mf.cbStart.Text;
            int cnt = 0;
            string country = findCountryByAirport(startApt);
            
            foreach (KeyValuePair<string, Airplane> temp in MainForm.clientSocket.airplaneList)
            {
                if (temp.Value.DepartApt.Equals(startApt))
                {
                    addToSelectedDictinary(temp.Value.Country, temp.Value.DestApt);
                }
            }
            foreach (KeyValuePair<string, List<string>> targetPair in dic_SelectedDestinationInfo)
            {
                Label lblCountry = new Label();
                lblCountry.Size = new Size(350, 20);
                lblCountry.BorderStyle = BorderStyle.FixedSingle;
                lblCountry.Text = targetPair.Key;
                flp.Controls.Add(lblCountry);
                foreach (string aptName in targetPair.Value)
                {
                    Button btnAirport = new Button();
                    btnAirport.Name = "cbStart";
                    btnAirport.Text = aptName;
                    btnAirport.Size = new Size(50, 50);
                    btnAirport.Click += new EventHandler(ButtonComboboxFill_Click);
                    flp.Controls.Add(btnAirport);
                }
                cnt++;
            }
            flp.Size = new Size(350, 50+ cnt * 70);
            this.Size = new Size(370, 70 + cnt * 70);
            this.Controls.Add(flp);
        }
        private void cbStartDateLayoutFill()
        {
            flp.Controls.Clear();
            dic_SelectedDestinationInfo.Clear();
            this.Text = "목적지 선택";
            string startApt = mf.cbStart.Text;
            int cnt = 0;
            string country = findCountryByAirport(startApt);

            foreach (KeyValuePair<string, Airplane> temp in MainForm.clientSocket.airplaneList)
            {
                if (temp.Value.DepartApt.Equals(startApt))
                {
                    addToSelectedDictinary(temp.Value.Country, temp.Value.DestApt);
                }
            }
            foreach (KeyValuePair<string, List<string>> targetPair in dic_SelectedDestinationInfo)
            {
                Label lblCountry = new Label();
                lblCountry.Size = new Size(350, 20);
                lblCountry.BorderStyle = BorderStyle.FixedSingle;
                lblCountry.Text = targetPair.Key;
                flp.Controls.Add(lblCountry);
                foreach (string aptName in targetPair.Value)
                {
                    Button btnAirport = new Button();
                    btnAirport.Name = "cbStart";
                    btnAirport.Text = aptName;
                    btnAirport.Size = new Size(50, 50);
                    btnAirport.Click += new EventHandler(ButtonComboboxFill_Click);
                    flp.Controls.Add(btnAirport);
                }
                cnt++;
            }
            flp.Size = new Size(350, 50 + cnt * 70);
            this.Size = new Size(370, 70 + cnt * 70);
            this.Controls.Add(flp);
        }
    }
}
