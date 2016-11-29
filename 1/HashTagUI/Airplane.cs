using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTagUI
{
	public class Airplane
	{
		//public int[] seatSize;
		//public Seat[,] seats;
        private string str_id;
        private string str_destCountry;
        private string str_destApt;
        private string str_departApt;
        private string str_departDate;
        private string str_departTime;
        private int n_leftSeats = 0;
        private int n_cost;
        //private int n_SeatsCount = 0;
        Dictionary<string, bool> dic_seats = new Dictionary<string, bool>();

        public string ID { get { return str_id; } }
        public string Country { get { return str_destCountry; } }
        public string DestApt { get { return str_destApt; } }
        public string DepartApt { get { return str_departApt; } }
        public string Date { get { return str_departDate; } }
        public string Time { get { return str_departTime; } }
        public int LeftSeats { get { return n_leftSeats; } set { n_leftSeats = value; } }
        public int Cost { get { return n_cost; } }
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
	}
}
