using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HashTagUI
{
    
	public class ClientSocket
	{
        private Dictionary<string, Dictionary<string, List<string>>> dic_airplaneSchedules;
        private Dictionary<string, Account> dic_userInfo;
        private Dictionary<string, Dictionary<string, List<string>>> dic_airplaneDest;

        private Dictionary<string,Airplane> dic_airplaneList;
        private Dictionary<string, List<string>> dic_Destinations;

        //Date, Time
        public Dictionary<string, Dictionary<string, List<string>>> airplaneSchedules { get { return dic_airplaneSchedules; } }
        // id
        public Dictionary<string, Account> userInfo { get { return dic_userInfo; } }
        //All Lists/ id
        public Dictionary<string, Airplane> airplaneList { get { return dic_airplaneList; } }
        // 대륙, 국가
        public Dictionary<string, List<string>> Destinations { get { return dic_Destinations; } }
        // 국가, 목적지 공항
        public Dictionary<string, Dictionary<string, List<string>>> airplaneDest { get { return dic_airplaneDest; } }
        public static readonly string exePath = Application.StartupPath;
        public static readonly string prePath = System.IO.Directory.GetParent(Application.StartupPath).ToString();

		public ClientSocket()
		{
            /*week = new Day[7];
			for (int i = 0; i < week.Length; i++)
			{
				week[i] = new Day();
			}*/
            dic_userInfo = new Dictionary<String,Account>();
            dic_airplaneList = new Dictionary<string,Airplane>();
            dic_Destinations = new Dictionary<string, List<string>>();
            dic_airplaneDest = new Dictionary<string, Dictionary<string, List<string>>>();
            dic_airplaneSchedules = new Dictionary<string, Dictionary<string, List<string>>>();

            addAirplaneList();
            makeServerAccount();
        }

		public Account login(String insertID, String insertPW)
        {
            if (userInfo.ContainsKey(insertID))
            {
                if (userInfo[insertID].pw == insertPW)
                    return userInfo[insertID];
            }
            return null;
        }
        /*
        public string getAriplaneInfo(string dest, string departTime)
        {
            foreach (Airplane target in airplaneList)
            {

            }
        }*/
        public int getLeftSeats(Airplane target)
        {
            int cnt = 0;
            return cnt;
        }
		public void addAirplaneList()
		{
			string line;
			string[] splitResult;
            //@"C:\Users\jay\Documents\test.txt"
			System.IO.StreamReader file = new System.IO.StreamReader(prePath + "\\Data\\Airplane.txt",Encoding.UTF8);
            //string id, region, country, depApt, destApt, date, time, cost, seats;

			while ((line = file.ReadLine()) != null)
			{
				splitResult = line.Split(' ');
                //airplane_id,region,country,d_airport,a_airport,date,time,cost,seat_info
                Airplane newAp = new Airplane(splitResult[0], splitResult[2], splitResult[3], splitResult[4], splitResult[5], splitResult[6], Convert.ToInt32(splitResult[7]), splitResult[8]);

				
				airplaneList.Add(splitResult[0],newAp);
                //date , time
                addToAirplaneSearchDic(splitResult[5], splitResult[6], splitResult[0], dic_airplaneSchedules);
                //country, a_airport
                addToAirplaneSearchDic(splitResult[2], splitResult[4], splitResult[0], dic_airplaneDest);
                //region, country
                addToDestionationDic(splitResult[1], splitResult[2]);
            }
			file.Close();
		}
        public void addToAirplaneSearchDic(string key, string valuekey, string newApId, Dictionary<string,Dictionary<string,List<string>>> targetDic)
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
            if(dic_Destinations.ContainsKey(region))
            {
                if (!dic_Destinations[region].Contains(country))
                    dic_Destinations[region].Add(country);
                return;
            }
            List<string> newList = new List<string>();
            newList.Add(country);
            dic_Destinations.Add(region, newList);
        }
        private void makeServerAccount()
        {
            string line, id, pw, name,email,admin;

            // Read the file and display it line by line.
            //@"C:\Users\jay\Documents\account.txt"
            StreamReader file = new StreamReader(ClientSocket.prePath + "\\Data\\account.txt");
            while ((line = file.ReadLine()) != null)
            {

                string[] accountArr = line.Split(',');
                id = accountArr[0];
                pw = accountArr[1];
                name = accountArr[2];
                email = accountArr[3];
                admin = accountArr[4];
                Account temp = new Account(id, pw, name, email);
                dic_userInfo.Add(id, temp);
            }

            file.Close();
        }
        public void ApplyAirplaneInfoToDB()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(prePath + "\\Data\\Airplane.txt");
            foreach (KeyValuePair<string, Airplane> targetPair in dic_airplaneList)
            {
                string region = getRegionFromCountry(targetPair.Value.Country);
                string seatsInDBform = ConvertSeatInDBForm(targetPair.Value.Seats);
                String a = targetPair.Value.ID + " " + region + " " + targetPair.Value.Country + " " + targetPair.Value.DepartApt + " " + targetPair.Value.DestApt + " " + targetPair.Value.Date + " " + targetPair.Value.Time + " " + seatsInDBform;
                file.WriteLine(a);
                
            }
            file.Close();
        }
        private string ConvertSeatInDBForm(Dictionary<string,bool> targetDic)
        {
            string str = "";
            foreach(KeyValuePair<string,bool> target in targetDic)
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
            foreach(KeyValuePair<string,List<string>> target in dic_Destinations)
            {
                if (target.Value.Contains(country))
                    return target.Key;
            }
            return "";
        }

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

		public bool RegiserUser(Account newUser)
		{
			try
			{
				userInfo.Add(newUser.id, newUser);
				StreamWriter file = File.AppendText(prePath + "\\Data\\account.txt");
				file.WriteLine(newUser.ToString());
				file.Flush();
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());

				return false;
			}

			return true;
		}
    }
}
