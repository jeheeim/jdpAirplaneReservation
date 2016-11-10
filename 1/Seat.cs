﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTag
{
    class Seat
    {
        public int seatClass;
        public bool isReserved;
        public char row;
        public int column;
        public Seat()
        {
        }
        public Seat(int seatClass, char row, int column)
        {
            this.column = column;
            this.row = row;
            this.seatClass = seatClass;
            isReserved = false;
        }
    }
}
