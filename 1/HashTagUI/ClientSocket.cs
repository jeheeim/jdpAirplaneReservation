using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace HashTagUI
{

	public class ClientSocket
	{
		private Dictionary<string, Dictionary<string, List<string>>> dic_airplaneSchedules;
		private Dictionary<string, Dictionary<string, List<string>>> dic_airplaneDest;

		private Dictionary<string, Airplane> dic_airplaneList;
		private Dictionary<string, List<string>> dic_Destinations;
        public static TcpClient clientTcpSocket = new TcpClient();

        //Date, Time
        public Dictionary<string, Dictionary<string, List<string>>> airplaneSchedules { get { return dic_airplaneSchedules; } }
		//All Lists/ id
		public Dictionary<string, Airplane> airplaneList { get { return dic_airplaneList; } }
		// 대륙, 국가
		public Dictionary<string, List<string>> Destinations { get { return dic_Destinations; } }
		// 국가, 목적지 공항
		public Dictionary<string, Dictionary<string, List<string>>> airplaneDest { get { return dic_airplaneDest; } }

		public ClientSocket()
		{
			//dic_userInfo = new Dictionary<String, Account>();
			dic_airplaneList = new Dictionary<string, Airplane>();
			dic_Destinations = new Dictionary<string, List<string>>();
			dic_airplaneDest = new Dictionary<string, Dictionary<string, List<string>>>();
			dic_airplaneSchedules = new Dictionary<string, Dictionary<string, List<string>>>();

            InitSocket();

			addAirplaneList();
			//makeclientSocketAccount();

        }
        private void InitSocket()
        {
            try
            {
                clientTcpSocket.Connect("210.94.181.218", 9999);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

		// 완성전에 외부 클래스에서 접근하는지 확인할것
		public string sendAndReceive(string message)
        {
			NetworkStream stream = clientTcpSocket.GetStream();

			byte[] sbuffer = Encoding.Unicode.GetBytes(message);
			stream.Write(sbuffer, 0, sbuffer.Length);
			stream.Flush();
			byte[] rbuffer = new byte[65023];
			stream.Read(rbuffer, 0, rbuffer.Length);
			string msg = Encoding.Unicode.GetString(rbuffer).Split('\0')[0];

			return msg.Split('!')[0];
		}

		public int getLeftSeats(Airplane target)
		{
			int cnt = target.LeftSeats;

			return cnt;
		}

        #region 생성자 관련

        // 생성자 load로 불러오기
		public void addAirplaneList()
		{
            string wholeText = sendAndReceive("LOAD!");
            string[] lines = wholeText.Split('$');

            foreach (string line in lines)
            {
                string[] splitResult = line.Split(' ');
                if (splitResult.Length < 9)
                    continue;
                //airplane_id,region,country,d_airport,a_airport,date,time,cost,seat_info
                Airplane newAp = new Airplane(splitResult[0], splitResult[2], splitResult[3], splitResult[4], splitResult[5], splitResult[6], Convert.ToInt32(splitResult[7]), splitResult[8]);


                airplaneList.Add(splitResult[0], newAp);
                //date , time
                addToAirplaneSearchDic(splitResult[5], splitResult[6], splitResult[0], dic_airplaneSchedules);
                //country, a_airport
                addToAirplaneSearchDic(splitResult[2], splitResult[4], splitResult[0], dic_airplaneDest);
                //region, country
                addToDestionationDic(splitResult[1], splitResult[2]);
            }
		}

		public void addToAirplaneSearchDic(string key, string valuekey, string newApId, Dictionary<string, Dictionary<string, List<string>>> targetDic)
		{
			if (targetDic.ContainsKey(key))
			{
				if (targetDic[key].ContainsKey(valuekey))
					targetDic[key][valuekey].Add(newApId);
				else
				{
					List<string> newList = new List<string>();
					newList.Add(newApId);
					targetDic[key].Add(valuekey, newList);
				}
			}
			else
			{
				Dictionary<string, List<string>> newDic = new Dictionary<string, List<string>>();
				targetDic.Add(key, newDic);
				List<string> newList = new List<string>();
				newList.Add(newApId);
				targetDic[key].Add(valuekey, newList);
			}
		}
		public void addToDestionationDic(string region, string country)
		{
			if (dic_Destinations.ContainsKey(region))
			{
				if (!dic_Destinations[region].Contains(country))
					dic_Destinations[region].Add(country);
				return;
			}
			List<string> newList = new List<string>();
			newList.Add(country);
			dic_Destinations.Add(region, newList);
        }
        // 새로운 비행기 객체를 추가하는 함수
        public void addToAirplaneList(string continent, Airplane newAp)
        {
            if (airplaneList.ContainsKey(newAp.ID))
            {
                MessageBox.Show("이미 있는 비행기 이름입니다.");
                return;

            }
            airplaneList.Add(newAp.ID, newAp);
            //date , time
            addToAirplaneSearchDic(newAp.Date, newAp.Time, newAp.ID, dic_airplaneSchedules);
            //country, a_airport
            addToAirplaneSearchDic(newAp.Country, newAp.DestApt, newAp.ID, dic_airplaneDest);
            //region, country
            addToDestionationDic(continent, newAp.Country);
        }
        #endregion

        public void ApplyAirplaneInfoToDB()
		{
            string allText = "";
			foreach (KeyValuePair<string, Airplane> targetPair in dic_airplaneList)
			{
				string region = getRegionFromCountry(targetPair.Value.Country);
				string seatsInDBform = ConvertSeatInDBForm(targetPair.Value.Seats);
                allText += targetPair.Value.ID + " " + region + " " + targetPair.Value.Country + " " + targetPair.Value.DepartApt + " " + targetPair.Value.DestApt + " " + targetPair.Value.Date + " " + targetPair.Value.Time + " " + seatsInDBform;

			}
            if (sendAndReceive(allText) == "F")
                MessageBox.Show("데이터를 업데이트 하는데 실패했습니다!");
		}
		private string ConvertSeatInDBForm(Dictionary<string, bool> targetDic)
		{
			string str = "";
			foreach (KeyValuePair<string, bool> target in targetDic)
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
		private string getRegionFromCountry(string country)
		{
			foreach (KeyValuePair<string, List<string>> target in dic_Destinations)
			{
				if (target.Value.Contains(country))
					return target.Key;
			}
			return "";
		}

		

		#region 밖에서 사용할 함수

		/* 서버로 보내는 명령어 양식
		 * 각 요소들은 $로 구분하고 마지막은 !로 끝낸다.
		 * 예약 : RES$(account id)$(airplane id, airplane id)$seats......!
		 * 가입 : NACC$(account.ToString())!
		 * 취소 : CANS$(account id)$(airplane id)$(좌석번호)!
		 * 변경 : MODA$(account.ToString())!
		 * AirplaneList 받아오기 : LOAD!
		 * AirplaneUpdate : UPD$(airplane id)$기타!
		 * 로그인 : LOGIN$(account id)$(account pw)!
		 * ID 찾기 : FINDID$(name)$(email)!
		 * PW 찾기 : FINDPW$(id)$(이름)$(email)!
		 */

		#region true or false

		// 예약
		public bool Reservation(Account account, List<string> seatToReserve)
		{
			string message = "RES$" + account.ToString() + "!";

			string returnMessage = sendAndReceive(message);

			if (returnMessage == "T") { return true;}
			else { return false; }
		}

		// 가입
		public bool RegisterUser(Account newUser)
		{
			string message = "NACC$" + newUser.ToString() + "!";

			string returnMessage = sendAndReceive(message);

			if (returnMessage == "T") { return true; }
			else { return false; }
		}

		// 예약 취소
		public bool CancelTicket(Account account, string apName, string seatNum)
		{
			string message = "CANS$" + account.id + "$" + apName + "$" + seatNum + "!";

			string returnMessage = sendAndReceive(message);

			if (returnMessage == "T") { return true; }
			else { return false; }
		}

		// 입력된 account 객체의 개인정보를 수정하는 메소드
		public bool ModifyInfo(Account account)
		{
			//try
			//{
			//	/*
			//	dic_userInfo[account
			//             .id].name = account.name;
			//	dic_userInfo[account.id].pw = account.pw;
			//	dic_userInfo[account.id].email = account.email;
			//	dic_userInfo[account.id].Interest = account.Interest;
			//             */
			//}
			//catch { return false; }

			string message = "MODA$" + account.ToString() + "!";

			string returnMessage = sendAndReceive(message);

			if(returnMessage == "T") { return true; }
			else { return false;}
		}
		#endregion

		#region 특정한 리턴값이 있는 메소드

		

		public Account login(string insertID, string insertPW)
		{
			/*
			if (userInfo.ContainsKey(insertID))
			{
				if (userInfo[insertID].pw == insertPW)
					return userInfo[insertID];
			}
            */

			string message = "LOGIN$" + insertID + "$" + insertPW + "!";

			string returnMessage = sendAndReceive(message);

			if(returnMessage == "F")
			{
				return null;
			}
			else
			{
				Account newAccount = new Account(returnMessage);

				return newAccount;
			}
		}

		// 아이디 찾기
		public string GetInfo(string name, string email)
		{
			string message = "FINDID$" + name + "$" + email + "!";

			string returnMessage = sendAndReceive(message);

			if(returnMessage == "F")
			{
				return null;
			}
			else
			{
				return returnMessage;
			}
		}

		// 패스워드 찾기
		public string GetInfo(string id, string name, string email)
		{
			string message = "FINDID$" + id + "$" + name + "$" + email + "!";

			string returnMessage = sendAndReceive(message);

			if (returnMessage == "F")
			{
				return null;
			}
			else
			{
				return returnMessage;
			}
		}

		#endregion
		#endregion
	}
}