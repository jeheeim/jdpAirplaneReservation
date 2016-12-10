using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HashTagUI
{
	public class Account
	{
		/* 클래스 멤버
		 * str_id : 사용자 아이디
		 * str_pw : 사용자 패스워드
		 * str_name : 사용자 이름
		 * str_email : 사용자 이메일
		 * interest : 가고싶어하는 여행지
		 */
        string str_id;
        string str_pw;
        string str_name;
        string str_email;
		string str_interest;

		// 프로퍼티
		public string id { get { return str_id; } }
        public string pw { get { return str_pw; } set { str_pw = value; } }
        public string name { get { return str_name; } set { str_name = value; } }
        public string email { get { return str_email; } set { str_email = value; } }
        public string Interest { get { return str_interest; } set { str_interest = value; } }

		// 예약된 좌석
		private Dictionary<string, List<string>> dic_bookedSeats;
		public Dictionary<string, List<string>> BookedSeats { get { return dic_bookedSeats; } }

        //bookedAirplane -> 구분자 ',' // bookedSeats -> 구분자 ',' : Seats단위 '|' : Airplane단위
		// isadmin 생성자 패러미터에서 삭제. 예약된 좌석 비행기 관련 내용 패러미터에서 삭제
        public Account(string id, string pw, string name, string email, string interest = "NULL", string airplane = "NULL", string seats = "NULL")
		{
			str_id = id;
			str_pw = pw;
			str_name = name;
            str_email = email;
            this.str_interest = interest;

            dic_bookedSeats = new Dictionary<string, List<string>>();
            if (airplane != "NULL")
                addToBook(airplane, seats);
		}

        // 파일에서 한줄로 쭉 읽어들일때 쓸 생성자. 한줄단위로 읽어들이기 때문에 스트링 하나로 하는게 편해서. 
        public Account(string accountInfo)
        {
            string[] info = accountInfo.Split(' ');
            dic_bookedSeats = new Dictionary<string, List<string>>();

            str_id = info[0];
            str_pw = info[1];
            str_name = info[2];
            str_email = info[3];
            str_interest = info[4];
            if (info.Length > 5)
                addToBook(info[5], info[6]);
        }

        public void addToBook(string airplaneID, string seatNum)
        {
            string[] airplanes = airplaneID.Split(',');
            string[] seats = seatNum.Split('|');
            for (int i = 0; i < airplanes.Length; i++)
            {
                List<string> newSeats = new List<string>();
                dic_bookedSeats.Add(airplaneID, newSeats);
                for (int j = 0; j < seats[i].Split(',').Length; j++)
                {
                    dic_bookedSeats[airplaneID].Add(seats[i].Split(',')[j]);
                    MainForm.clientSocket.airplaneList[airplanes[i]].Seats[seats[i].Split(',')[j]] = true;
                }
            }
        }
		// 좌석을 직접 지정하는 방식으로 예약한 경우
		// dic_bookedSeats에 항공편ID와 좌석번호 리스트를 저장한다.
		// 항공편명이 없다면 미리 항공편ID와 리스트 객체를 더해주도
		// 개별 좌석들을 더해준다.
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
                MainForm.clientSocket.airplaneList[airplaneID].Seats[seatNum[i]] = true;
            }
        }

		// 좌석을 지정하지않고 예약한 경우
		// dic_bookedSeats 객체에 항공편ID과 아무런 값이 없는 문자열 리스트 객체를 더한다.
		public void addToBook(string airplaneID, int seatSize)
        {
            List<string> toTrueSeats = new List<string>();
			if (!dic_bookedSeats.ContainsKey(airplaneID))
			{
				List<string> newlist = new List<string>();
				dic_bookedSeats.Add(airplaneID, newlist);
			}
			foreach (KeyValuePair<string, bool> targetSeat in MainForm.clientSocket.airplaneList[airplaneID].Seats)
			{
				if (!targetSeat.Value)
				{
					seatSize--;
                    toTrueSeats.Add(targetSeat.Key);
				}
				if (seatSize == 0)
					break;
            } 
            string value = MainForm.clientSocket.Reservation(id, airplaneID, ChangeInDBForm(toTrueSeats));
            if (value == "T")
            {
                MessageBox.Show("예약에 성공했습니다!");
            }
            else
            {
                changeToFalseInSheet(value, airplaneID);
                MessageBox.Show("예약에 실패했습니다! 다시 시도하세요!");
            }
            foreach(string key in toTrueSeats)
            {
                dic_bookedSeats[airplaneID].Add(key);
                 MainForm.clientSocket.airplaneList[airplaneID].Seats[key] = true;
            }
            
		}
        private void changeToFalseInSheet(string seats,string airplaneID)
        {
            string[] seatsCom = seats.Split(',');
            for (int i = 0; i < seatsCom.Length; i++)
            {
                MainForm.clientSocket.airplaneList[airplaneID].Seats[seatsCom[i]] = false;
            }
        }
        private string ChangeInDBForm(List<string> targetList)
        {
            string tot = "";
            for (int i = 0; i < targetList.Count; i++)
            {
                tot += targetList[i];
                if (targetList.Count - 1 != i)
                    tot += ",";
            }
            return tot;
        }
		// 고객등록할때 저장하는 방식
		public override string ToString()
		{
            string result = str_id + '$' + str_pw + '$' + str_name + '$' + str_email + '$' + str_interest;

			return result;
		}
	}
}
