using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationManager
{
	public class Account
	{
        string str_id;
        string str_pw;
        string str_name;
        string str_email;
        
        public string id { get { return str_id; } }
        public string pw { get { return str_pw; } }
        public string name { get { return str_name; } }
        public string email { get { return str_email; } }

		// 원하는 여행지
		public string placeToGo;

        //bookedAirplane -> 구분자 ',' // bookedSeats -> 구분자 ',' : Seats단위 '|' : Airplane단위
        public Account(string id, string pw, string name, string email)
		{
			this.str_id = id;
			this.str_pw = pw;
			this.str_name = name;
            this.str_email = email;
		}
	}
}
