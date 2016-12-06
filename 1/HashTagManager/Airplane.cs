using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTagManager
{
	public class Airplane
	{
        string str_id;
        string str_destCountry;
        string str_destApt;
        string str_departApt;
        string str_departDate;
        string str_departTime;
        int n_leftSeats = 0;
        int n_cost;
        Dictionary<string, bool> dic_seats = new Dictionary<string, bool>();

		// id를 제외한 프로퍼티에 set 값 추가
		public string ID { get { return str_id; } set { str_id = value; } }
		public string Country { get { return str_destCountry; } set { str_destCountry = value; } }
		public string DestApt { get { return str_destApt; } set { str_destApt = value; } }
		public string DepartApt { get { return str_departApt; } set { str_departApt = value; } }
		public string Date { get { return str_departDate; } set { str_departDate = value; } }
		public string Time { get { return str_departTime; } set { str_departTime = value; } }
        public int LeftSeats { get { return n_leftSeats; } set { n_leftSeats = value; } }
		public int Cost { get { return n_cost; } set { n_cost = value; } }
        //private int SeatsCount { get { return n_SeatsCount; } }
        public Dictionary<string, bool> Seats { get { return dic_seats; } }

        //A좌석 -> FirstClass B좌석 -> Business 그 외 Economy
        public Airplane(string id, string destCountry, string departApt, string destApt, string date, string time, int cost, string seats)
		{
            this.str_id = id;
            this.str_destCountry = destCountry;
            this.str_destApt = destApt;
            this.str_departApt = departApt;
            this.str_departDate = date;
            this.str_departTime = time;
            this.n_cost = cost;

            string[] splitSeats = seats.Split(',');
 
            for(int i = 0; i < splitSeats.Length; i++)
            {
                string nowSeat = splitSeats[i];
                if (nowSeat[0] == 'R')
                    dic_seats.Add(splitSeats[i].Substring(1), true);
                else
                {
                    dic_seats.Add(splitSeats[i], false);
                    n_leftSeats++;
                }
            }
		}

		public override string ToString()
		{
			return str_id;
		}
	}
}
