using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTag
{
    public class Day
    {
        public Hour[] hours;
        public Day()
        {
            hours = new Hour[24];
            int i = 0;
            for (i = 0; i <= 23; i++)
            {
                hours[i] = new Hour(i);
            }
        }
    }
}
