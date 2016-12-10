using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace ApplicationManager
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
				Application.Exit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
				Application.Exit();
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

		#region 가져온 메소드

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
		#endregion

		#region 매니저폼 전용함수

		// 로그인
		public bool Login(string id, string password)
		{
			string message = "LOGIN$" + id + "$" + password + "!";
			string returnMessage = sendAndReceive(message);

			if (returnMessage != "F") { return true; }
			else { return false; }
		}

		// 비행기 추가
		public bool AddAirplane(Airplane newAirplane)
		{
			if (CommunicateWithServer("NEWAIR", newAirplane))
			{
				airplaneList.Add(newAirplane.ID, newAirplane);

				return true;
			}
			else { return false; }
		}

		// 항공편 삭제
		public bool DeleteAirplane(Airplane airplaneDeleted)
		{
			if (CommunicateWithServer("DELAIR", airplaneDeleted))
			{
				airplaneList.Remove(airplaneDeleted.ID);

				return true;
			}
			else { return false; }
		}

		// 비행기 정보 수정
		public bool ModifyAirplaneInfo(Airplane airplane)
		{
			if (CommunicateWithServer("MODAIR", airplane))
			{
				airplaneList[airplane.ID].ModifyInfo(airplane);

				return true;
			}
			else { return false; }
		}

		// 추가, 수정, 삭제시 주고받을 내용
		bool CommunicateWithServer(string command, Airplane airplane)
		{
			string message = command + "$" + airplane.ToString() + "!";
			string returnMessage = sendAndReceive(message);

			if (returnMessage == "T") { return true; }
			else { return false; }
		}

		#endregion
	}
}