using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using CinamaLib1;
using CinemaWebApp.Models;
using System.Linq;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Web;



namespace CinemaWebApp.Controllers
{
    public class HomeController : Controller
    {
        private CinemaModelContainer db = new CinemaModelContainer();

      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            var user = from Customer in db.Customers where Customer.Email == User.Identity.Name select Customer;
            if (user.Count() == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Customer customer = user.First();
                string LogInUser = customer.FirstName; 
                ViewBag.User = LogInUser;
                Session["IsAdmin"] = customer.IsAdmin; 
                return View(customer);
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Helper()
        {
            ViewBag.Message = "Your Helper page.";

            return View();
        }

        /// <summary>
        /// Clear up all movies and Schedule items in SQL
        /// Import Demo Data and save in SQL
        /// </summary>
        /// <returns></returns>
        public ActionResult InitScheduleDemo()
        {
            Demo2 saveDemoTosql = new Demo2();
            saveDemoTosql.saveDemoData();
            return View(db.ScheduleItems.ToList());
        }


    }
}
