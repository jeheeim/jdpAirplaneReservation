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
		public Server()
		{
			week = new Day[7];
			for (int i = 0; i < week.Length; i++)
			{
				week[i] = new Day();
			}
            userInfo = new Dictionary<String,Account>();
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
