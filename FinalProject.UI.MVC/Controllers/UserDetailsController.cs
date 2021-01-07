//Accessing the Data Layer to bring our Data into the UI Layer
using FinalProject.DATA.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Getting access to the Models to make this Controller work
using FinalProject.UI.MVC.Models;
//Need these to make Edit Views possible.
using System.Net;
using System.Data.Entity;

namespace FinalProject.UI.MVC.Controllers
{
    public class UserDetailsController : Controller
    {
        //Create a new Database Keyword
        FinalProjectEntities1 db = new FinalProjectEntities1();

        // GET: UserDetails
        public ActionResult Index()
        {
            var userDetails = (from u in db.UserDetails
                               select u).ToList();
            return View(userDetails);
        }

        public ActionResult UserDetails()
        {
            //Link to SQL Database with UserDetailsViewModel
            List<UserDetailsViewModel> userDetails = db.UserDetails.
                Select(u => new UserDetailsViewModel()
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }).ToList<UserDetailsViewModel>();
            return View();
        }

        //GET: UserDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "UserDetails");
            return View();
        }

        //POST: UserDetails
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId, FirstName, LastName")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                //Add a new UserDetail to the database with a View if Model is valid
                db.UserDetails.Add(userDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Grabbing the newly entered data and showing it to the screen.
            ViewBag.OwnerAssetId = new SelectList(db.UserDetails, "UserId", "UserId", userDetail.UserId);
            return View(userDetail);

        }

        // GET: UserDetails/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }

            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "UserId", userDetail.UserId);
            return View(userDetail);
        }

        //POST: UserDetails/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId, FirstName, LastName")]
        UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db.Entry(userDetail).State = EntityState.Modified;
            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "UserId", userDetail.UserId);
            return View(userDetail);
        }


        //GET: UserDetails/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //POST: UserDetails/Delete
        public ActionResult DeleteConfirmed(int id)
        {
            UserDetail userDetail = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetail);
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
    }
}