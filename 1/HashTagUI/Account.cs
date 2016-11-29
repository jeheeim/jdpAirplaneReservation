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
        private Dictionary<string, List<string>> dic_bookedSeats;
        public string id { get { return str_id; } }
        public string pw { get { return str_pw; } }
        public string name { get { return str_name; } }
        public bool isAdmin { get { return b_isAdmin; } }
        public string email { get { return str_email; } }
        public Dictionary<string, List<string>> BookedSeats { get { return dic_bookedSeats; } }

        //bookedAirplane -> 구분자 ',' // bookedSeats -> 구분자 ',' : Seats단위 '|' : Airplane단위
        public Account(string id, string pw, string name, string email, bool isAdmin, string bookedAirplane="", string bookedSeats="")
		{
			this.str_id = id;
			this.str_pw = pw;
			this.str_name = name;
            this.str_email = email;
            this.b_isAdmin = isAdmin;
            dic_bookedSeats = new Dictionary<string, List<string>>();
		}
        public void addToBook(string airplaneID, List<string> seatNum)
        {
            if(!dic_bookedSeats.ContainsKey(airplaneID))
            {
                List<string> newlist = new List<string>();
                dic_bookedSeats.Add(airplaneID, newlist);
            }
            for (int i = 0; i < seatNum.Count; i++)
            {
                dic_bookedSeats[airplaneID].Add(seatNum[i]);
                MainForm.server.airplaneList[airplaneID].Seats[seatNum[i]] = true;
            }
        }
	}
}
