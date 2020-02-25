using CinamaLib1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaWebApp.Models
{
    public class Demo2
    {

        /// <summary>
        /// define Demo Data
        /// </summary>
        public static Movie Movie1 = new Movie()
        {
            Name = "The Danish Girl",
            MovieType = "Drama",
            Actor = "Eddie Redmayne, Alicia Vikander",
            Director = "Tom Hooper",
            Poster = "~/Images/The Danish Girl.jpeg",
            FullPrice = 10
        };

        public static Movie Movie2 = new Movie()
        {
            Name = "Her",
            MovieType = "Romance",
            Actor = "Joaquin Phoenix",
            Director = "Spike Jonze",
            Poster = "~/Images/Her.jpg",
            FullPrice = 10
        };

        public static Movie Movie3 = new Movie()
        {
            Name = "Harry Potter VII",
            MovieType = "Fantasy",
            Actor = "Daniel Radcliffe, Emma Waston",
            Director = "David Yates",
            Poster = "~/Images/Harry Potter VII.jpg",
            FullPrice = 8
        };

        public static Movie Movie4 = new Movie()
        {
            Name = "Bohnemian Rhapsody",
            MovieType = "Musical",
            Actor = "Rami Malek, Lucy Boynton",
            Director = "Bryan Singer",
            Poster = "~/Images/Bohnemian Rhapsody.jpg",
            FullPrice = 9
        };
        
        public static Movie Movie5 = new Movie()
        {
            Name = "Frozen",
            MovieType = "Animation",
            Actor = "Kristen Bell, Idina Menzel",
            Director = "Chris Buck, Jennifer Lee",
            Poster = "~/Images/Frozen.jpg",
            FullPrice = 6
        };


        public static ScheduleItem ScheduleItem1 = new ScheduleItem()
        {
            Time = new DateTime(2020, 02, 14, 09, 00, 00),
            MovieItem = Movie1
        };

        public static ScheduleItem ScheduleItem2 = new ScheduleItem()
        {
            Time = new DateTime(2020, 02, 14, 13, 30, 00),
            MovieItem = Movie2
        };

        public static ScheduleItem ScheduleItem3 = new ScheduleItem()
        {
            Time = new DateTime(2020, 02, 14, 16, 30, 00),
            MovieItem = Movie3
        };

        public static ScheduleItem ScheduleItem4 = new ScheduleItem()
        {
            Time = new DateTime(2020, 02, 15, 09, 45, 00),
            MovieItem = Movie4
        };

        public static ScheduleItem ScheduleItem5 = new ScheduleItem()
        {
            Time = new DateTime(2020, 02, 15, 13, 00, 00),
            MovieItem = Movie5
        };

        public static ScheduleItem ScheduleItem6 = new ScheduleItem()
        {
            Time = new DateTime(2020, 02, 15, 17, 00, 00),
            MovieItem = Movie1
        };

        public static ScheduleItem ScheduleItem7 = new ScheduleItem()
        {
            Time = new DateTime(2020, 02, 15, 20, 15, 00),
            MovieItem = Movie3
        };
/*
        public static ScheduleItem ScheduleItem8 = new ScheduleItem()
        {
            Time = new DateTime(2020, 02, 15, 14,30, 00),
            MovieItem = Movie4
        };

        public static ScheduleItem ScheduleItem9 = new ScheduleItem()
        {
            Time = new DateTime(2020, 02, 15, 17, 30, 00),
            MovieItem = Movie5
        };

        public static ScheduleItem ScheduleItem10 = new ScheduleItem()
        {
            Time = new DateTime(2020, 02, 15, 20, 30, 00),
            MovieItem = Movie2
        };

*/

        public IEnumerable<Movie> Movies
        {
            get
            {
                yield return Movie1;
                yield return Movie2;
                yield return Movie3;
                yield return Movie4;
                yield return Movie5;
            }
        }

        public IEnumerable<ScheduleItem> ScheduleItems
        {
            get
            {
                yield return ScheduleItem1;
                yield return ScheduleItem2;
                yield return ScheduleItem3;
                yield return ScheduleItem4;
                yield return ScheduleItem5;
                yield return ScheduleItem6;
                yield return ScheduleItem7;
             /* yield return ScheduleItem8;
                yield return ScheduleItem9;
                yield return ScheduleItem10;*/
            }
        }

        /// <summary>
        /// save Demo Data to SQL Datenbank
        /// </summary>
        private CinamaLib1.CinemaModelContainer _context;

        private CinamaLib1.CinemaModelContainer context =>
            _context ?? (_context = new CinemaModelContainer());

        public void saveDemoData()
        {
            try
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {

                    context.Tickets.RemoveRange(context.Tickets.ToArray());
                    context.SaveChanges();

                    context.ScheduleItems.RemoveRange(context.ScheduleItems.ToArray());
                    context.SaveChanges();

                    context.Movies.RemoveRange(context.Movies.ToArray());
                    context.SaveChanges();

                    dbContextTransaction.Commit();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }


            try
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    context.ScheduleItems.AddRange(ScheduleItems);
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