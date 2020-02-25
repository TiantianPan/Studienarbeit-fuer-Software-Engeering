using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinamaLib1;
using CinemaWebApp.Models;


namespace CinemaWebApp.Controllers
{
    public class SaleSystemController : Controller
    {
        private CinemaModelContainer db = new CinemaModelContainer();

        // GET: SaleSystem
        public ActionResult Index()
        {
            // Initialisierung Sitzplaetze
            SeatBuilder2 SetSeats = new SeatBuilder2();
            SetSeats.SetSeats();

            // filter all Datetime in Form mm/dd/yy from SQL
            var dates = GetAllDate();

            ViewModel viewModel = new ViewModel
            {
                DateTimes = GetSelectListItems(dates)
            };

            return View(viewModel);
        }


        // POST: Ticket/SaleSystem
        // To protect from overposting attacks, please enable the specific properties you want to bind to, 
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ViewModel viewModel)
        {
            // filter all Datetime in Form mm/dd/yy from SQL
            var dates = GetAllDate();
            // save dates in select list
            viewModel.DateTimes = GetSelectListItems(dates);

            if (ModelState.IsValid)
            {
                Session["ViewModel"] = viewModel;

                // select all scheduleitems with this selected Datetime from SQL
                var scheduleItems = GetAllScheduleItems();

                viewModel.ScheduleItems = scheduleItems;

                //update SaleSystem View()
                return View(viewModel);
            }
            return View(viewModel);
        }


        public ActionResult SelectSeat(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ScheduleItem scheduleItem = db.ScheduleItems.Find(id);

            if (scheduleItem == null)
            {
                return HttpNotFound();
            }

            ViewModel viewModel = new ViewModel
            {
                ScheduleItem = scheduleItem,
                Seats = db.Seats
            };

            // find all SeatNum with selected scheduleitem
            var seatNums = GetAllSeatNumWithSelectItem(id);
            viewModel.SoldSeatNums = seatNums;

            return View(viewModel);
        }

        // POST: SecheduleItems/SelectSeat
        // To protect from overposting attacks, please enable the specific properties you want to bind to,
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectSeat(int? id, string seatNumString, ViewModel viewModel)
        {
            var BindRdoTicket = Request.Form["RdoTicketType"];
            var BindTxtCouponNum = Request.Form["TxtCouponNum"];

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ScheduleItem scheduleItem = db.ScheduleItems.Find(id);

            if (scheduleItem == null)
            {
                return HttpNotFound();
            }

            viewModel.ScheduleItem = scheduleItem;
            viewModel.Seats = db.Seats;

            var seatNums = GetAllSeatNumWithSelectItem(id);
            viewModel.SoldSeatNums = seatNums;

            var soldticketvar = (from par in db.Tickets
                                 where par.ScheduleItemId == id && par.SeatItem.SeatNum == seatNumString
                                 select par).ToList();

            if (soldticketvar.Count() > 0)
            {
                return View(viewModel);
            }

            if (ModelState.IsValid)
            {
                Session["ViewModel"] = viewModel;

                if (BindRdoTicket == "Free")
                {
                    if (BindTxtCouponNum == "")
                    {
                        return RedirectToAction("CouponNumMiss", "Tickets");
                    }
                }

                // create a ticket 
                CreateTicket(scheduleItem, seatNumString, BindRdoTicket, BindTxtCouponNum);
                var seatNumsUpdate = GetAllSeatNumWithSelectItem(id);
                viewModel.SoldSeatNums = seatNumsUpdate;

                return View(viewModel);
            }

            return View(viewModel);
        }
       

        private IEnumerable<string> GetAllDate()
        {
            if (db.ScheduleItems != null)
            {
                // filter all Datetime in Form mm/dd/yy from SQL
                var datevar = (from par in db.ScheduleItems
                               orderby par.Time
                               select par.Time.Month.ToString() +
                               " /" + par.Time.Day.ToString() +
                               " /" + par.Time.Year.ToString())
                               .Distinct();

                return datevar.ToList();
            }

            return new List<string> { };
        }


        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var SelectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                SelectList.Add(new SelectListItem { Value = element, Text = element });
            }

            return SelectList;
        }


        public IEnumerable<ScheduleItem> GetAllScheduleItems()
        {
            var viewModel = Session["ViewModel"] as ViewModel;

            if (viewModel.SelectDateTime != null)
            {
                //selected Datetime
                DateTime date1 = DateTime.Parse(viewModel.SelectDateTime);
                DateTime date2 = date1.AddDays(1);

                // select all scheduleitems with this selected Datetime from SQL
                var scheduleItems =
                    (from par in db.ScheduleItems
                     where par.Time >= date1 && par.Time < date2
                     orderby par.MovieItem.Name
                     select par);

                return scheduleItems.ToList();
            }

            return new List<ScheduleItem> { };
        }

        public IEnumerable<string> GetAllSeatNumWithSelectItem(int? id)
        {
            // find all SeatNum with selected scheduleitem
            var seatnums = (from par in db.Tickets
                            where par.ScheduleItemId == id
                            select par.SeatItem.SeatNum).ToList();

            return seatnums;
        }


        public Ticket CreateTicket(ScheduleItem scheduleItem, string seatNumString, 
                                   string RdoTicketType, string TxtCouponNum)
        {
            var viewModel = Session["ViewModel"] as ViewModel;

            Ticket ticket = new Ticket();

            //get the selected seat nummer
            var seat = (from par in db.Seats
                        where par.SeatNum == seatNumString
                        select par).ToList();

            //save the selected scheduleitem in new ticket
            ticket.ScheduleItem = scheduleItem;
            //save the selected seat nummer in new ticket
            ticket.SeatItem = seat[0];
            //save the selected ticket type in new ticket
            ticket.TicketType = RdoTicketType;

            //calculate final price and save in new ticket
            switch (RdoTicketType)
            {
                case "Normal":
                    ticket.Price = scheduleItem.MovieItem.FullPrice;
                    break;
                case "Student":              
                    ticket.Discount = 0.70;
                    ticket.Price = scheduleItem.MovieItem.FullPrice * Convert.ToDouble(ticket.Discount);
                    break;
                default:
                    ticket.Coupon = TxtCouponNum;
                    ticket.Price = 0;
                    break;
            }

            // save in SQL-Server
            db.Tickets.Add(ticket);
            db.SaveChanges();

            return ticket;
        }
    }
}
