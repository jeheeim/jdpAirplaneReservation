using System;
using System.Collections.Generic;

namespace HashTagUI
{
	public class Account
	{
		// 클래스 멤버
        string str_id;
        string str_pw;
        string str_name;
        string str_email;
        
		// 프로퍼티
        public string id { get { return str_id; } }
        public string pw { get { return str_pw; } }
        public string name { get { return str_name; } }
        public string email { get { return str_email; } }

		// 예약된 좌석
		private Dictionary<string, List<string>> dic_bookedSeats;
		public Dictionary<string, List<string>> BookedSeats { get { return dic_bookedSeats; } }

		// 원하는 여행지
		public string placeToGo;

        //bookedAirplane -> 구분자 ',' // bookedSeats -> 구분자 ',' : Seats단위 '|' : Airplane단위
		// isadmin 생성자 패러미터에서 삭제. 예약된 좌석 비행기 관련 내용 패러미터에서 삭제
        public Account(string id, string pw, string name, string email)
		{
			str_id = id;
			str_pw = pw;
			str_name = name;
            str_email = email;

            dic_bookedSeats = new Dictionary<string, List<string>>();
		}

		// 파일에서 한줄로 쭉 읽어들일때 쓸 생성자. 한줄단위로 읽어들이기 때문에 스트링 하나로 하는게 편해서.
		public Account(string accountInfo)
		{
			string[] info = accountInfo.Split(',');

			str_id = info[0];
			str_pw = info[1];
			str_name = info[2];
			str_email = info[3];

			dic_bookedSeats = new Dictionary<string, List<string>>();
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
                MainForm.server.airplaneList[airplaneID].Seats[seatNum[i]] = true;
            }
        }

		// 좌석을 지정하지않고 예약한 경우
		// dic_bookedSeats 객체에 항공편ID과 아무런 값이 없는 문자열 리스트 객체를 더한다.
        public void addToBook(string airplaneID, int seatSize)
        {
            if (!dic_bookedSeats.ContainsKey(airplaneID))
            {
                List<string> newlist = new List<string>();
                dic_bookedSeats.Add(airplaneID, newlist);
            }
            dic_bookedSeats[airplaneID].Add(seatSize.ToString());
        }

		// 고객등록할때 저장하는 방식
		public override string ToString()
		{
			string result = str_id + ',' + str_pw + ',' + str_name + ',' + str_email;

			return result;
		}
	}
}
