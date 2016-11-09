using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTag
{
    class Server
    {
        Day[] week;
        Dictionary<String, Account> userInfo;
        public Server()
        {
            week = new Day[7];
        }
        public bool login(String insertID, String insertPW)
        {
            if (userInfo.ContainsKey(insertID))
            {
                if (userInfo[insertID].pw == insertPW)
                    return true;
            }
            return false;
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
