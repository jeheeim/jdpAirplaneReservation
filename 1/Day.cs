using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTag
{
    class Day
    {
        public Hour[] hours;
        public Day()
        {
            hours = new Hour[24];
            int i = 0;
            for (i = 1; i <= 24; i++)
            {
                hours[i-1].thisHour = i;
            }
        }
    }
}
