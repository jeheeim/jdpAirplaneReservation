using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTagUI
{
	public class Seat
	{
        private int n_seatClass;
        private bool b_isReserved;
        private char c_row;
        private int n_col;
        public bool isReserved { get { return b_isReserved; } set { b_isReserved = value; } }
        public int seatClass { get { return n_seatClass; } }
        public char row { get { return c_row; } }
		public int column { get { return n_col; } }
		public Seat()
		{
		}
		public Seat(int seatClass, char row, int column)
		{
			this.n_col = column;
			this.c_row = row;
			this.n_seatClass = seatClass;
			isReserved = false;
		}
	}
}
