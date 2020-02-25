using CinamaLib1;
using System.Collections.Generic;


namespace CinemaAppplication
{
    class SeatBuilder
    {
        public List<Seat> Seats = new List<Seat>();
        public SeatBuilder setSeat()
        {
            int row = 5;
            int col = 6;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Seat seatVar = new Seat();
                    seatVar.SeatNum = (i + 1) + "-" + (j + 1);
                    Seats.Add(seatVar);
                }
            }

            return this;
        }


    }

}


