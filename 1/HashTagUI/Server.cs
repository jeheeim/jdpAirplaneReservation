using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HashTagUI
{
    
	public class Server
	{
		//public Day[] week;
        private Dictionary<string, Dictionary<string, List<Airplane>>> dic_airplaneSchedules;
        private Dictionary<String, Account> dic_userInfo;

        private List<Airplane> list_airplaneList;
        private Dictionary<string, List<Destination>> dic_Destinations;
        public Dictionary<string, Dictionary<string, List<Airplane>>> airplaneSchedules { get { return dic_airplaneSchedules; } } // Date, Hour
        public Dictionary<String, Account> userInfo { get { return dic_userInfo; } }
        public List<Airplane> airplaneList { get { return list_airplaneList; } }
        public Dictionary<string, List<Destination>> Destinations { get { return dic_Destinations; } }
        public static readonly string exePath = Application.StartupPath;
        public static readonly string prePath = System.IO.Directory.GetParent(Application.StartupPath).ToString();

		public Server()
		{
            dic_airplaneSchedules = new Dictionary<string, Dictionary<string, List<Airplane>>>();
            /*week = new Day[7];
			for (int i = 0; i < week.Length; i++)
			{
				week[i] = new Day();
			}*/
            dic_userInfo = new Dictionary<String,Account>();
            list_airplaneList = new List<Airplane>();
            dic_Destinations = new Dictionary<string, List<Destination>>();

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
            int col = target.col;
            int row = target.row;
            int cnt = 0;
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    if (target.seats[i, j].isReserved == false)
                        cnt++;
                }
            }
            return cnt;
        }
		public void addAirplaneList()
		{
			string line;
			string[] splitResult;
            //@"C:\Users\jay\Documents\test.txt"
			System.IO.StreamReader file = new System.IO.StreamReader(prePath + @"\Data\Airplane.txt",Encoding.UTF8);
			int firstclassSize, businessclasSize, economyclassSize;
			string dest, apName, departDate, departTime, country, region;
			int startTime, row, col;

			while ((line = file.ReadLine()) != null)
			{
				splitResult = line.Split(' ');

				firstclassSize = int.Parse(splitResult[0]);
				businessclasSize = int.Parse(splitResult[1]);
				economyclassSize = int.Parse(splitResult[2]);

                region = splitResult[3];
                country = splitResult[4];
				dest = splitResult[5];
				apName = splitResult[6];
                departDate = splitResult[7];
                departTime = splitResult[8];
				row = int.Parse(splitResult[9]);
				col = int.Parse(splitResult[10]);

				Airplane newAp = new Airplane(firstclassSize, businessclasSize, economyclassSize, dest, apName, int.Parse(departTime), row, col);
				airplaneList.Add(newAp);
                addAirplaneInDictionary(departDate, departTime, newAp);
                addDestionationInDictionary(region, country);
            }
			file.Close();
		}
        public void addAirplaneInDictionary(string departDate, string departTime, Airplane newAp)
        {
            if (airplaneSchedules.ContainsKey(departDate))
            {
                if (airplaneSchedules[departDate].ContainsKey(departTime))
                    airplaneSchedules[departDate][departTime].Add(newAp);
                else
                {
                    List<Airplane> newList = new List<Airplane>();
                    newList.Add(newAp);
                    airplaneSchedules[departDate].Add(departTime, newList);
                }
            }
            else
            {
                Dictionary<string, List<Airplane>> newDic = new Dictionary<string, List<Airplane>>();
                airplaneSchedules.Add(departDate, newDic);
                List<Airplane> newList = new List<Airplane>();
                airplaneSchedules[departDate].Add(departTime, newList);
            }
        }
        public void addDestionationInDictionary(string region, string country)
        {

        }
        private void makeServerAccount()
        {
            string line, id, pw, name,email,admin;

            // Read the file and display it line by line.
            //@"C:\Users\jay\Documents\account.txt"
            System.IO.StreamReader file = new System.IO.StreamReader(Server.prePath + @"\Data\account.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] accountArr = line.Split(',');
                id = accountArr[0];
                pw = accountArr[1];
                name = accountArr[2];
                email = accountArr[3];
                admin = accountArr[4];
                Account temp = new Account(id, pw, name, email, (admin == "1")?true:false);
                dic_userInfo.Add(id, temp);
            }

            file.Close();
        }
    }
}
