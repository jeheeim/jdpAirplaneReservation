using System.Collections.Generic;

namespace ApplicationManager
{
	public class Airplane
	{
		//public int[] seatSize;
		//public Seat[,] seats;
		private string str_id;
		private string region;
		private string str_destCountry;
		private string str_destApt;
		private string str_departApt;
		private string str_departDate;
		private string str_departTime;
		private int n_leftSeats = 0;
		private int n_cost;
		//private int n_SeatsCount = 0;
		Dictionary<string, bool> dic_seats = new Dictionary<string, bool>();

		//id를 제외한 프로퍼티에 set 값 추가
		public string ID { get { return str_id; } }
		public string Continent { get { return region; } set { region = value; } }
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
		public Airplane(string id, string region, string destCountry, string departApt, string destApt, string date, string time, int cost, string seats)
		{
			this.str_id = id;
			this.region = region;
			this.str_destCountry = destCountry;
			this.str_destApt = destApt;
			this.str_departApt = departApt;
			this.str_departDate = date;
			this.str_departTime = time;
			this.n_cost = cost;

			string[] splitSeats = seats.Split(',');

			for (int i = 0; i < splitSeats.Length; i++)
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

		// id, 국가, 도착도시, 출발공항, 도착공항, 날짜, 시간, 가격, 좌석정보
		public Airplane(string info)
		{
			string[] strArr = info.Split(' ');

			str_id = strArr[0];
			str_destCountry = strArr[1];
			str_departApt = strArr[2];
			str_destApt = strArr[3];
			str_departDate = strArr[4];
			str_departTime = strArr[5];
			n_cost = int.Parse(strArr[6]);

			string[] splitSeats = strArr[7].Split(',');

			for (int i = 0; i < splitSeats.Length; i++)
			{
				string nowSeat = splitSeats[i];

				if (nowSeat[0] == 'R')
				{
					dic_seats.Add(splitSeats[i].Substring(1), true);
				}
				else
				{
					dic_seats.Add(splitSeats[i], false);
					n_leftSeats++;
				}
			}
		}

		public void ModifyInfo(Airplane airplane)
		{
			if (str_destCountry != airplane.Country) { str_destCountry = airplane.Country; }
			if (region != airplane.Continent) { region = airplane.Continent; }
			if (str_destApt != airplane.DestApt) { str_destApt = airplane.DestApt; }
			if (str_departApt != airplane.DepartApt) { str_departApt = airplane.DepartApt; }
			if (str_departDate != airplane.Date) { str_departDate = airplane.Date; }
			if (str_departTime != airplane.Time) { str_departTime = airplane.Time; }
			if (n_leftSeats != airplane.LeftSeats) { n_leftSeats = airplane.LeftSeats; }
			if (n_cost != airplane.Cost) { n_cost = airplane.Cost; }
		}

		public override string ToString()
		{
			return str_id;
		}

		public string FullData()
		{
			return str_id + "$" + region + "$" + str_destCountry + "$" + str_destApt + "$" + str_departApt + "$" + str_departDate
				+ "$" + str_departTime + "$" + n_cost + "$" + n_leftSeats + "$" + ConvertSeatInDBForm();
		}

		public string ConvertSeatInDBForm()
		{
			string str = "";
			foreach (KeyValuePair<string, bool> target in Seats)
			{
				string concatStr = target.Key;

				if (target.Value == true)
				{
					concatStr = "R" + target.Key;
				}

				str += concatStr + ",";
			}
			str = str.Substring(0, str.Length - 1);
			return str;
		}
	}
}
