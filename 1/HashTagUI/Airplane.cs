using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTagUI
{
	public class Airplane
	{
		public int[] seatSize;
		public Seat[,] seats;
		public String destination;
		public String airplaneName;
		public int startTime;
		public int row;
		public int col;

		public Airplane(int first, int business, int economy, String destination, String airplaneName, int startTime, int row, int column)
		{
			seatSize = new int[3] { first, business, economy };
			seats = new Seat[row, column];

			this.destination = destination;
			this.airplaneName = airplaneName;
			this.startTime = startTime;
			this.row = row;
			this.col = col;

			int cnt = 0;
			int classFactor = 0;

			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < column; j++)
				{
					if (cnt == seatSize[0])
					{
						classFactor++;
					}
					else if (cnt == seatSize[0] + seatSize[1])
					{
						classFactor++;
					}
					seats[i, j] = new Seat(classFactor, (char)('A' + i), j);
					cnt++;
				}
			}

		}

	}
}
