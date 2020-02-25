using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinamaLib1;

namespace CinemaWebApp.Controllers
{
    public class ReturnSystemController : Controller
    {
        private CinemaModelContainer db = new CinemaModelContainer();

        // GET: ReturnSystem
        public ActionResult Index()
        {
            return View();
        }



        // POST: Ticket/ReturnSystem
        // To protect from overposting attacks, please enable the specific properties you want to bind to,
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(
        [Bind(Include = "Id,Price,TicketType,Discount,Coupon,ScheduleItemId,SeatItemId")] 
                            Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                //find returned Ticket in SQL
                Ticket returnTicket = db.Tickets.Find(ticket.Id);

                if (returnTicket == null)
                {
                    //show TicketNotValid View() when entered ticket-ID not exist
                    return RedirectToAction("TicketNotValid", "Tickets");
                }

                //show ReturnSystem View()
                return View(returnTicket);
            }

            return View(ticket);
        }

    }
}
