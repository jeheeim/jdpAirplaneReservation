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
        DateTime resetDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public FastBookingInputForm(MainForm main, int startIndex)
        {
            flp.BorderStyle = BorderStyle.FixedSingle;
            flp.Location = new Point(1, 1);
            flp.Visible = true;
            mf = main;
            InitializeComponent();
            this.startIndex = startIndex;
        }
        // 화면 전환기
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
                case 2:
                    LayoutFill = new DelegateLayout(cbDateLayoutFill);
                    break;
                case 4:
                    LayoutFill = new DelegateLayout(cbNumPplLayoutFill);
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
            comboBoxSelector = new ComboBox[5] { mf.cbStart, mf.cbDest, mf.cbDepart, mf.cbArrive, mf.cbNumPpl };
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
        // 1번째 2번째 버튼에 추가될 EventHandler
        private void ButtonComboboxFill_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            comboBoxSelector[startIndex++].Text = btnSender.Text;
            layoutFillDelegateSelector();
            LayoutFill();
        }
        //1번재 스탭
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
        

        // 2번째 스탭
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
        // 3번째 스텝
        private void cbDateLayoutFill()
        {
            flp.Controls.Clear();
            this.Text = "날짜 선택";
            Label space = new Label();
            space.Size = new Size(350, 10);

            Label departDay = new Label();
            departDay.Size = new Size(160, 13);
            departDay.Text = "가는날";
            Label returnDay = new Label();
            returnDay.Size = new Size(160, 13);
            returnDay.Text = "오는날";
            DateTimePicker departDatePicker = new DateTimePicker();
            departDatePicker.Size = new Size(160, 20);
            departDatePicker.Name = "departDatePicker";
            departDatePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            departDatePicker.ValueChanged += new EventHandler(DatePicker_ValueChanged);
            DateTimePicker returnDatePicker = new DateTimePicker();
            returnDatePicker.Size = new Size(160, 20);
            returnDatePicker.Name = "returnDatePicker";
            returnDatePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            returnDatePicker.ValueChanged += new EventHandler(DatePicker_ValueChanged);
            Label spacebtm = new Label();
            spacebtm.Size = new Size(350, 150);
            flp.Controls.Add(space);
            flp.Controls.Add(departDay);
            flp.Controls.Add(returnDay);
            flp.Controls.Add(departDatePicker);
            flp.Controls.Add(returnDatePicker);
            flp.Controls.Add(spacebtm);
            
            Button btnOkay = new Button();
            btnOkay.Text = "확인";
            btnOkay.Size = new Size(100, 30);
            btnOkay.Dock = DockStyle.Bottom;
            btnOkay.Click += new EventHandler(ButtonDatePickerFill_Click);
            flp.Controls.Add(btnOkay);
            flp.Size = new Size(350, 250);
            this.Size = new Size(370, 280);
            
        }
        private void ButtonDatePickerFill_Click(object sender, EventArgs e)
        {
            DateTimePicker tempDateTime = (DateTimePicker)flp.Controls["departDatePicker"];
            string strDateFormat = tempDateTime.Value.Month + "." + tempDateTime.Value.Day;
            comboBoxSelector[startIndex++].Text = strDateFormat;
            tempDateTime = (DateTimePicker)flp.Controls["returnDatePicker"];
            strDateFormat = tempDateTime.Value.Month + "." + tempDateTime.Value.Day;
            comboBoxSelector[startIndex++].Text = strDateFormat;
            layoutFillDelegateSelector();
            LayoutFill();
        }
        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker nowPicker = (DateTimePicker)sender;
            DateTimePicker returnDate = (DateTimePicker)flp.Controls["returnDatePicker"];
            DateTimePicker departDate = (DateTimePicker)flp.Controls["departDatePicker"];
            if(returnDate.Value < departDate.Value)
            {
                MessageBox.Show("돌아오는 날은 가는날 보다 일찍일 수 없습니다!");
                
                nowPicker.Value = resetDate;
            }
        }
        // 사람 선택 마지막 순서
        private void cbNumPplLayoutFill()
        {
            flp.Controls.Clear();
            this.Text = "예약 인수 선택";

            Label space = new Label();
            space.Size = new Size(350, 10);

            Label lblIntro = new Label();
            lblIntro.Text = "예약 인수 선택";
            lblIntro.Size = new Size(350, 20);

            Label leftSpace = new Label();
            leftSpace.Size = new Size(50, 10);

            NumericUpDown numericPeopleSelector = new NumericUpDown();
            numericPeopleSelector.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericPeopleSelector.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericPeopleSelector.Size = new System.Drawing.Size(50, 20);
            numericPeopleSelector.Value = new decimal(new int[] {1, 0, 0, 0});
            numericPeopleSelector.Name = "numericPpl";

            Label lblCount = new Label();
            lblCount.Text = "명";
            lblCount.Size = new Size(50, 20);

            Button btnOkay = new Button();
            btnOkay.Text = "예약하기";
            btnOkay.Size = new Size(100, 30);
            btnOkay.Dock = DockStyle.Bottom;
            btnOkay.Click += new EventHandler(ButtonPeoplePickerFill_Click);

            flp.Controls.Add(space);
            flp.Controls.Add(lblIntro);
            flp.Controls.Add(leftSpace);
            flp.Controls.Add(numericPeopleSelector);
            flp.Controls.Add(lblCount);
            leftSpace = new Label();
            leftSpace.Size = new Size(50, 10);
            flp.Controls.Add(leftSpace);
            flp.Controls.Add(btnOkay);

            flp.Size = new Size(220, 130);
            this.Size = new Size(230, 150);
        }
        private void ButtonPeoplePickerFill_Click(object sender, EventArgs e)
        {
            NumericUpDown numericTool = (NumericUpDown)flp.Controls["numericPpl"];
            string numOfPeople = numericTool.Value.ToString();
            comboBoxSelector[startIndex++].Text = numOfPeople;
            layoutFillDelegateSelector();
            LayoutFill();
        }
    }
}
