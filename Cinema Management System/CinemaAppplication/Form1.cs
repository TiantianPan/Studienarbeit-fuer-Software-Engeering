using CinamaLib1;
using de.i2cm.helper.HelperLib.Configuration;
using de.i2cm.helper.HelperLib.Forms;
using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace CinemaAppplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DemoData DemoData = new DemoData();
        CinemaModelContainer context = new CinemaModelContainer();
        public TicketForm ticketForm;

        private void Form1_Load(object sender, EventArgs e)
        {
            ticketForm = new TicketForm();
        }

        // movie creat
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Movie newMovie = new Movie()
                {
                    Name = "muster",
                    MovieType = "muster",
                    Actor = "muster",
                    Director = "muster",
                    Poster = "muster",
                    FullPrice = 0
                };
                if (ConfigForm.showDialog("creat a new movie",
                    newMovie, true) == DialogResult.OK)
                {
                    using (CinemaModelContainer context = new CinemaModelContainer())
                    {
                        context.Movies.Add(newMovie);
                        context.SaveChanges();
                    }

                }
            }
            catch (Exception ex)

            {
                handle(ex);
            }
        }


        private void handle(Exception exception)
        {
            string msg =
                Environment.NewLine +
                Environment.NewLine +
                @"Copy to Clipboard?";

            Exception ex = exception;
            string report = "";
            while (ex != null)
            {
                report +=
                    String.Format("{0}{1}", exception, Environment.NewLine);
                ex = ex.InnerException;
            }
            DbEntityValidationException valEx =
                exception as DbEntityValidationException;
            if (valEx != null)
            {
                msg = "Validation Error" + msg;
                report += String.Format("{0}Validation errors:{0}{1}",
                    Environment.NewLine,
                    string.Join(
                        Environment.NewLine,
                        valEx.EntityValidationErrors.Select(
                            err => err.Entry.Entity.GetType().Name +
                                   string.Join(Environment.NewLine,
                                       err.ValidationErrors.Select(
                                           v => $"{v.PropertyName} - {v.ErrorMessage}")))));

            }
            else
            {
                msg = "Error" + msg;
            }

            report = report.Replace(":", ":" + Environment.NewLine + "    ");
            report = report.Replace("--->", Environment.NewLine + "--->");

            Trace.WriteLine(report);
            if (MessageBox.Show(msg, @"Error",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Clipboard.SetText(report);
            }
        }

        //movie update
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (CinemaModelContainer context = new CinemaModelContainer())
                {
                    Movie movieToUpdate = SelectDialog<Movie>.show(
                        "Movie Update",
                        "please select a movie",
                        null,
                        context.Movies);
                    if (movieToUpdate == null) return;

                    if (ConfigForm.showDialog("Movie Update",
                        movieToUpdate, true) != DialogResult.OK) return;

                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                handle(ex);
            }
        }


        //movie cancle
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (CinemaModelContainer context = new CinemaModelContainer())
                {
                    Movie movieToCanc = SelectDialog<Movie>.show(
                        "Movie Delete",
                        "please select a movie",
                        null,
                        context.Movies);
                    if (movieToCanc == null) return;

                    // find all tickets and scheduleitem with selected movie
                    var ticket =
                                (from par in context.Tickets
                                 where par.ScheduleItem.MovieItem.Id.Equals(movieToCanc.Id)
                                 select par);

                    context.Tickets.RemoveRange(ticket.ToArray());
                    context.SaveChanges();

                    var item =
                            (from par in context.ScheduleItems
                             where par.MovieItem.Id.Equals(movieToCanc.Id)
                             select par);

                    context.ScheduleItems.RemoveRange(item.ToArray());
                    context.SaveChanges();

                    context.Movies.Remove(movieToCanc);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                handle(ex);
            }
        }


        //creat schedule with scheduleitems
        private void button6_Click(object sender, EventArgs e)
        {
            /*try
            {

                ScheduleItem newItem = new ScheduleItem()
                {
                    Time = new DateTime(2020, 01, 10, 16, 00, 00)

                };

                if (ConfigForm.showDialog("creat a new schedule item", newItem, true) == DialogResult.OK)
                {
                    using (CinemaModelContainer context = new CinemaModelContainer())
                    {
                        context.ScheduleItems.Add(newItem);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)

            {
                handle(ex);
            }*/

            try
            {
                using (CinemaModelContainer context = new CinemaModelContainer())
                {

                    Movie movieSelect = SelectDialog<Movie>.show(
                        "create a new schedule item",
                        "please select a movie firstly.",
                        null,
                        context.Movies);
                    if (movieSelect == null) return;

                    ScheduleItem newItem = new ScheduleItem()
                    {
                        //Number = Guid.NewGuid()
                        //  .ToString()
                        //  .Replace("-", string.Empty)
                        //  .Substring(0, 6)

                        Time = new DateTime(2020, 01, 10, 16, 00, 00)
                    };
                    newItem.MovieItem = movieSelect;
                    if (ConfigForm.showDialog("creat a new schedule item",
                        newItem, true) == DialogResult.OK)
                    {
                        context.ScheduleItems.Add(newItem);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                handle(ex);
            }
        }

        // update scheduleitem
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (CinemaModelContainer context = new CinemaModelContainer())
                {
                    ScheduleItem itemToUpdate = SelectDialog<ScheduleItem>.show(
                        "update schedule item",
                        "please select a schedule item",
                        null,
                        context.ScheduleItems);
                    if (itemToUpdate == null) return;

                    if (ConfigForm.showDialog("scheduel item Update",
                        itemToUpdate, true) != DialogResult.OK) return;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                handle(ex);
            }

        }

        // cancle scheduleitem
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (CinemaModelContainer context = new CinemaModelContainer())
                {
                    ScheduleItem itemToCanc = SelectDialog<ScheduleItem>.show(
                        "delete schedule item",
                        "please select a schedule item",
                        null,
                        context.ScheduleItems);
                    if (itemToCanc == null) return;
                    context.ScheduleItems.Remove(itemToCanc);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                handle(ex);
            }
        }


        // open sale and return system
        private void button9_Click(object sender, EventArgs e)
        {
            TicketForm.ticketForm.ShowDialog();
        }


        // empty all Tickets
        private void button8_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Empty all tickets");

            try
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    context.Tickets.RemoveRange(context.Tickets.ToArray());
                    context.SaveChanges();

                    dbContextTransaction.Commit();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Empty Database");

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


            Console.WriteLine("Fill Database");

            try
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    context.ScheduleItems.AddRange(DemoData.ScheduleItems);
                    context.SaveChanges();

                    dbContextTransaction.Commit();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            // show Demo Day in combo box
            //TicketForm.ticketForm.loadSchedule();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
