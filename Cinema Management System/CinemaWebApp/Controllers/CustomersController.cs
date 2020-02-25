using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using CinamaLib1;


namespace CinemaWebApp.Controllers
{
    public class CustomersController : Controller
    {
        private CinemaModelContainer db = new CinemaModelContainer();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }


        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            string First = customer.FirstName;
            string Last = customer.LastName;
            string Fullname = First + Last;
            ViewBag.FullName = Fullname;
            return View(customer);
        }


        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            var user = from Customer in db.Customers where Customer.Email == User.Identity.Name select Customer;
            Customer userNotAdmin = user.First();
            if ((Boolean)Session["IsAdmin"] == false && userNotAdmin.Id != id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, LastName, FirstName, Email, EmployeeNum, IsAdmin, Telefon")] Customer customer)
        {
            if (customer.LastName == null)
            {
                ModelState.AddModelError("", "Bitte trage deinen Nachnamen ein.");
                return View(customer);
            }
            if (customer.FirstName == null)
            {
                ModelState.AddModelError("", "Bitte trage deinen Vornamen ein.");
                return View(customer);
            }
            if (customer.EmployeeNum == null)
            {
                ModelState.AddModelError("", "Bitte trage deinen Stammnummer ein.");
                return View(customer);
            }

            if (customer.Telefon == null)
            {
                ModelState.AddModelError("", "Bitte trage deine Telefonnummer ein.");
                return View(customer);
            }
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            /*var ideas = from Idea in db.Ideas where person.Id == Idea.Creator.Id select Idea;
            if (ideas.Any())
            {
                db.Ideas.RemoveRange(ideas);
            }*/
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //MeinKonto
        public ActionResult MeinProfil()
        {
            var user = from Customer in db.Customers where Customer.Email == User.Identity.Name select Customer;
            Customer customer = user.First();
            return View(customer);
        }
        //Angemeldete Benutzer um in der ViewBag auszugeben: Willkommen [Angemelder Benutzer]
        public string LogInUser()
        {
            string LogInUser;
            var user = from Customer in db.Customers where Customer.Email == User.Identity.Name select Customer;
            if (user.First() == null)
            {
                LogInUser = "";
            }
            else
            {
                Customer customer = user.First();
                LogInUser = customer.FirstName;
            }
            return (LogInUser);
        }
        //Ist die angemeldete Person ein Admin? 
        public bool IsAdmin()
        {
            var user = from Customer in db.Customers where Customer.Email == User.Identity.Name select Customer;
            Customer customer = user.First();
            bool isAdmin;
            if (customer.IsAdmin == true)
            {
                isAdmin = true;
            }
            else
            {
                isAdmin = false;
            }
            return (isAdmin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}