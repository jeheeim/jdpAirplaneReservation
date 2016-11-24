using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTagUI
{
	public class Account
	{
        private string str_id;
        private string str_pw;
        private string str_name;
        private string str_email;
        private bool b_isAdmin;
        private bool b_existAirplane;
        private List<AccountAirplaneInfo> list_accAirplaneInfo;
        public string id { get { return str_id; } }
        public string pw { get { return str_pw; } }
        public string name { get { return str_name; } }
        public bool isAdmin { get { return b_isAdmin; } }
        public string email { get { return str_email; } }
        public bool existAirplane { get { return b_existAirplane; } set { b_existAirplane = value; } }
        public List<AccountAirplaneInfo> accAirplaneInfo { get { return list_accAirplaneInfo; } }
		public Account(String id, String pw, String name, string email, bool isAdmin)
		{
			this.str_id = id;
			this.str_pw = pw;
			this.str_name = name;
            this.b_existAirplane = false;
            this.str_email = email;
            this.b_isAdmin = isAdmin;

            list_accAirplaneInfo = new List<AccountAirplaneInfo>();
		}
	}
    public class AccountAirplaneInfo
    {
        private Airplane ap_booked;
        public Airplane bookedAirplane { get { return ap_booked; } }
        private string str_seatNum;
        public string seatNum { get { return str_seatNum; } set { str_seatNum = value; } }
        private string str_seatClass;
        public string seatClass { get { return str_seatClass; } set { str_seatClass = value; } }
        public AccountAirplaneInfo(Airplane bookedAirplane, string seatNum="", string seatClass ="")
        {
            this.ap_booked = bookedAirplane;
            this.str_seatNum = seatNum;
            this.str_seatClass = seatClass;
        }
    }
}
