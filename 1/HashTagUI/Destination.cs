using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HashTagUI
{
    public class Destination
    {
        public static readonly Dictionary<string, int> CATEGORY_KEYS = new Dictionary<string, int>();
        private string str_cityName;
        private int int_category;
        public string CityName { get { return str_cityName; } set { str_cityName = value; } }
        public int Category { get { return int_category; } set { int_category = value; } }
        static Destination()
        {
            string readRegions;
            //@"C:\Users\jay\Documents\GitHub\jdpAirplaneReservation\Data\Region.txt"
            StreamReader reader = new StreamReader(Server.prePath + "\\Data\\Region.txt");
            int index = 0;
            while ((readRegions = reader.ReadLine()) != null)
            {
                CATEGORY_KEYS.Add(readRegions, index++);
            }
        }
        public Destination(string cityName, int category)
        {
            str_cityName = cityName;
            int_category = category;
        }
    }
}
