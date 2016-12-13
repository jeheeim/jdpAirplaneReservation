using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpServerExample
{
    class AlarmSeat
    {
        public string id;
        public Dictionary<string,Dictionary<string,string>> alarmSeats;
        
        public AlarmSeat(string id, string airplane_id, string seat, string check = "")
        {
            this.id = id;
            alarmSeats = new Dictionary<string, Dictionary<string, string>>();
            string[] temp = seat.Split(',');
            addToAlarmSeats(airplane_id, seat, check);
        }
        public void addToAlarmSeats(string airplane_id, string seat, string check = "")
        {
            if (!alarmSeats.ContainsKey(airplane_id))
            {
                Dictionary<string, string> newDic = new Dictionary<string, string>();
                alarmSeats.Add(airplane_id, newDic);
            }
            string[] seats = seat.Split(',');
            string[] checks = {"NULL"};
            if (check != "")
                checks = check.Split(',');
            for(int i = 0; i < seats.Length; i++)
            {

                if (!alarmSeats[airplane_id].ContainsKey(seats[i]))
                {
                    alarmSeats[airplane_id].Add(seats[i],(check=="")?"0":checks[i]);
                }
            }
        }
        public bool containsSeat(string seatNum)
        {
            foreach (KeyValuePair<string, Dictionary<string,string>> target in alarmSeats)
            {
                if (target.Value.ContainsKey(seatNum))
                    return true;
            }
            return false;
        }
        public void cancelSeat(string airId, string seat)
        {
            if(alarmSeats.ContainsKey(airId))
                if(alarmSeats[airId].ContainsKey(seat))
                   alarmSeats[airId].Remove(seat);
        }
        public string alarmServiceOkSeat()
        {
            string returnSeats = "";
            foreach (KeyValuePair<string, Dictionary<string, string>> airpDic in alarmSeats)
            {
                bool check = false;
                foreach (KeyValuePair<string, string> seatDic in airpDic.Value)
                {
                    if (seatDic.Value == "1")
                    {
                        if (!check)
                            returnSeats += airpDic.Key + ";";
                        check = true;
                        returnSeats += seatDic.Key + ";";

                    }
                }
                if (check)
                    returnSeats = returnSeats.Substring(0, returnSeats.Length - 1) + "%";
            }
            return returnSeats;
        }
        public override string ToString()
        {
            return id + " " + DBForm();
        }
        private string DBForm()
        {
            string totair = "";
            string totseat = "";
            string totcheck = "";
            foreach (KeyValuePair<string, Dictionary<string, string>> airpDic in alarmSeats)
            {
                totair += airpDic.Key + ",";
                foreach (KeyValuePair<string, string> seatDic in airpDic.Value)
                {
                    totseat += seatDic.Key + ",";
                    totcheck += seatDic.Value + ",";
                }
            }
            totair = totair.Substring(0, totair.Length - 1);
            totseat = totseat.Substring(0, totseat.Length - 1);
            totcheck = totcheck.Substring(0, totcheck.Length - 1);
            return totair + " " + totseat + " " + totcheck;
        }
    }
}
