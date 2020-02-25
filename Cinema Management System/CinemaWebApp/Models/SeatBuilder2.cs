using CinamaLib1;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CinemaWebApp.Models
{

    class SeatBuilder2
    {

        private CinamaLib1.CinemaModelContainer _context;

        private CinamaLib1.CinemaModelContainer context =>
            _context ?? (_context = new CinemaModelContainer());


        private List<Seat> seats = new List<Seat>();
        public void SetSeats()
        {
            int row = 5;
            int col = 6;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Seat seatVar = new Seat();
                    seatVar.SeatNum = (i + 1) + "-" + (j + 1);
                    seats.Add(seatVar);
                }
            }

            if (context.Seats.Count() == 0)
            {
                try
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        context.Seats.AddRange(seats);
                        context.SaveChanges();

                        dbContextTransaction.Commit();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                }

            }

        }

    }
}





