using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTag
{
    class Hour
    {
        List<Airplane> airplaneList;

        public int thisHour;
        
		public Hour(int thisHour=0)
        {
            this.thisHour = thisHour;
            airplaneList = new List<Airplane>();
        }
    }
}
