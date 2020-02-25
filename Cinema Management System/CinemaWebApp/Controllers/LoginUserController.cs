using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinamaLib1;
using Microsoft.AspNet.Identity;
using CinemaWebApp.Models;


public class LoginUserController : Controller
{

    private CinemaModelContainer db = new CinemaModelContainer();

    // GET: Costumer/Edit/5
    public ActionResult Edit(int? id)
    {
        var userName = User.Identity.GetUserName();
        Customer user = db.Customers.FirstOrDefault(
            u => u.Email == userName);

        if (user == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        return View(user);
    }

    // POST: Costumer/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id, LastName, FirstName, Email, EmployeeNum, IsAdmin, Telefon")] Customer user)
    {
        if (user.LastName == null)
        {
            ModelState.AddModelError("", "Bitte trage deinen Nachnamen ein.");
            return View(user);
        }
        if (user.FirstName == null)
        {
            ModelState.AddModelError("", "Bitte trage deinen Vornamen ein.");
            return View(user);
        }
        if (user.Telefon == null)
        {
            ModelState.AddModelError("", "Bitte trage deine Telefonnummer ein.");
            return View(user);
        }
        if (ModelState.IsValid)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("HomePage", "Home");
        }
        return View(user);
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
