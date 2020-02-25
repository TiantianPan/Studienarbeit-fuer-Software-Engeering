using CinamaLib1;
using System;
using System.Collections.Generic;

namespace CinemaAppplication
{
    class DemoData
    {
        /*public static Movie TestMovie1 = new MovieBuilder()
            .setActor("actor1")
            .setDirector("director1")
            .setName("name1")
            .setMovieType("movieType1")
            .setPoster("poster1")
            .setFullPrice(100)
            .create();

        public static Movie TestMovie2 = new MovieBuilder()
            .setActor("actor2")
            .setDirector("director2")
            .setName("name2")
            .setMovieType("movieType2")
            .setPoster("poster2")
            .setFullPrice(200)
            .create();

        public static ScheduleItem TestScheduleItem1 = new ScheduleItemBuilder()
            .setTime("time1")
            .setMovieItem(TestMovie1)
            .create();

        public static ScheduleItem TestScheduleItem2 = new ScheduleItemBuilder()
             .setTime("time2")
             .setMovieItem(TestMovie1)
             .create();

        public static ScheduleItem TestScheduleItem3 = new ScheduleItemBuilder()
            .setTime("time3")
            .setMovieItem(TestMovie1)
            .create();

        public static ScheduleItem TestScheduleItem4 = new ScheduleItemBuilder()
            .setTime("time4")
            .setMovieItem(TestMovie2)
            .create();

        public static ScheduleItem TestScheduleItem5 = new ScheduleItemBuilder()
            .setTime("time5")
            .setMovieItem(TestMovie2)
            .create();
        */
        public static Movie Movie1 = new Movie()
        {
            Name = "The Danish Girl",
            MovieType = "test movietype1",
            Actor = "Eddie Redmayne, Alicia Vikander, Amber Heard",
            Director = "Tom Hooper",
            Poster = "test poster1",
            FullPrice = 100
        };

        public static Movie Movie2 = new Movie()
        {
            Name = "Her",
            MovieType = "test movietype2",
            Actor = "test actor2",
            Director = "Spike Jonze",
            Poster = "test poster2",
            FullPrice = 90
        };

        public static Movie Movie3 = new Movie()
        {
            Name = "Harry Potter",
            MovieType = "test movietype3",
            Actor = "test actor3",
            Director = "David Yates",
            Poster = "test poster3",
            FullPrice = 80
        };

        public static Movie Movie4 = new Movie()
        {
            Name = "Bohnemian Rhapsody",
            MovieType = "test movietype4",
            Actor = "test actor4",
            Director = "Bryan Singer",
            Poster = "test poster4",
            FullPrice = 110
        };

        public static ScheduleItem ScheduleItem1 = new ScheduleItem()
        {
            Time = new DateTime(2020, 01, 10, 16, 00, 00),
            MovieItem = Movie1
        };

        public static ScheduleItem ScheduleItem2 = new ScheduleItem()
        {
            Time = new DateTime(2020, 01, 10, 08, 00, 00),
            MovieItem = Movie2
        };

        public static ScheduleItem ScheduleItem3 = new ScheduleItem()
        {
            Time = new DateTime(2020, 01, 10, 10, 30, 00),
            MovieItem = Movie1
        };

        public static ScheduleItem ScheduleItem4 = new ScheduleItem()
        {
            Time = new DateTime(2020, 01, 10, 14, 45, 00),
            MovieItem = Movie4
        };

        public static ScheduleItem ScheduleItem5 = new ScheduleItem()
        {
            Time = new DateTime(2020, 01, 10, 17, 50, 00),
            MovieItem = Movie3
        };

        public static ScheduleItem ScheduleItem6 = new ScheduleItem()
        {
            Time = new DateTime(2020, 01, 11, 20, 00, 00),
            MovieItem = Movie4
        };

        public static ScheduleItem ScheduleItem7 = new ScheduleItem()
        {
            Time = new DateTime(2020, 01, 11, 08, 00, 00),
            MovieItem = Movie4
        };



        public IEnumerable<Movie> Movies
        {
            get
            {
                yield return Movie1;
                yield return Movie2;
                yield return Movie3;
                yield return Movie4;
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
            }
        }
    }
}
