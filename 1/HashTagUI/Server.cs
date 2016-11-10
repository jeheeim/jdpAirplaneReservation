using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTagUI
{
	public class Server
	{
		public Day[] week;
		public Dictionary<String, Account> userInfo;
		public List<Airplane> airplaneList;

		public Server()
		{
			week = new Day[7];
			for (int i = 0; i < week.Length; i++)
			{
				week[i] = new Day();
			}
            userInfo = new Dictionary<String,Account>();
			
			airplaneList = new List<Airplane>();

			addAirplaneList();
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

		public void addAirplaneList()
		{
			string line;
			string[] splitResult;
			System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\jay\Documents\test.txt");
			int firstclassSize, businessclasSize, economyclassSize;
			string dest, apName;
			int startTime, row, col;

			while ((line = file.ReadLine()) != null)
			{
				splitResult = line.Split(' ');

				firstclassSize = int.Parse(splitResult[0]);
				businessclasSize = int.Parse(splitResult[1]);
				economyclassSize = int.Parse(splitResult[2]);
				dest = splitResult[3];
				apName = splitResult[4];
				startTime = int.Parse(splitResult[5]);
				row = int.Parse(splitResult[6]);
				col = int.Parse(splitResult[7]);

				Airplane newAp = new Airplane(firstclassSize, businessclasSize, economyclassSize, dest, apName, startTime, row, col);
				airplaneList.Add(newAp);
			}

			file.Close();
		}
		/*public List<String> getDestList()
		{

		}
		public List<String> getDayList(String Dest)
		{

		}
		public List<Airplane> getAirplaneList(String Dest, String Date)
		{

		}
		public Seat[,] getSeats(Airplane target)
		{
		return target.seats;
		}*/
	}
}
