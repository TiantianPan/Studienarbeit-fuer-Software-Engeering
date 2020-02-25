using CinamaLib1;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CinemaWebApp.Controllers
{
    public class TicketsController : Controller
    {
        private CinemaModelContainer db = new CinemaModelContainer();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.ScheduleItem).Include(t => t.SeatItem);
            return View(tickets.ToList());
        }


        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("TickedDeleted");
        }


        //TicketNotValid: when entered ticket-ID not exist
        public ActionResult TicketNotValid()
        {
            return View();
        }
        
        //TicketDeleted: after ticket sucesseful delete
        public ActionResult TickedDeleted()
        {
            return View();
        }
        


        public ActionResult CouponNumMiss()
        {
            return View();
        }

    }
}
