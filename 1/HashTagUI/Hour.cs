using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTagUI
{
	public class Hour
	{
		List<Airplane> airplaneList;

		public int thisHour;

		public Hour(int thisHour)
		{
			this.thisHour = thisHour;

			airplaneList = new List<Airplane>();


			// hour 클래스에 airplane list를 db에서 가져와야함
		}

		// 검색 조건을 더 집어넣어야함
		public List<Airplane> searchAirplane()
		{
			List<Airplane> result = airplaneList.FindAll(
				delegate (Airplane a)
				{
					return a.startTime == thisHour;
				}
				);

			return result;
		}
	}
}
