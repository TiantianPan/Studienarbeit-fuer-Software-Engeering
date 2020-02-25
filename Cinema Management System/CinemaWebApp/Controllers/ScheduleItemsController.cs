using CinamaLib1;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using CinemaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CinemaWebApp.Controllers
{
    public class ScheduleItemsController : Controller
    {
        private CinemaModelContainer db = new CinemaModelContainer();

        // GET: ScheduleItems
        public ActionResult Index()
        {
            var scheduleItems = db.ScheduleItems.Include(s => s.MovieItem);
            return View(scheduleItems.ToList());
        }

        // GET: ScheduleItems/Details/5
        public ActionResult Details(int? id)
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
            return View(scheduleItem);
        }

        // GET: ScheduleItems/Create
        public ActionResult Create()
        {
            ViewBag.MovieItemId = new SelectList(db.Movies, "Id", "Name");
            return View();
        }

        // POST: ScheduleItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Time,MovieItemId")] ScheduleItem scheduleItem)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleItems.Add(scheduleItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieItemId = new SelectList(db.Movies, "Id", "Name", scheduleItem.MovieItemId);
            return View(scheduleItem);
        }

        // GET: ScheduleItems/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.MovieItemId = new SelectList(db.Movies, "Id", "Name", scheduleItem.MovieItemId);
            return View(scheduleItem);
        }

        // POST: ScheduleItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Time,MovieItemId")] ScheduleItem scheduleItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleItem).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieItemId = new SelectList(db.Movies, "Id", "Name", scheduleItem.MovieItemId);
            return View(scheduleItem);
        }

        // GET: ScheduleItems/Delete/5
        public ActionResult Delete(int? id)
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
            return View(scheduleItem);
        }

        // POST: ScheduleItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleItem scheduleItem = db.ScheduleItems.Find(id);

            var datevar = (from par in db.Tickets
                           where par.ScheduleItemId == id
                           select par).ToList();

            if (datevar.Count() != 0)
            {
                //show TicketNotValid View() when this movie exist in a schedule
                return RedirectToAction("DeleteScheduleItemFailed");

            }

            db.ScheduleItems.Remove(scheduleItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult DeleteScheduleItemFailed()
        {
            return View();
        }

    }
}
