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

        [Authorize(Roles = "Admin")]
        // GET: UserDetails
        public ActionResult Index()
        {
            //Select the Database from SQL Server and show it to the screen.
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

        [Authorize(Roles = "Admin")]
        //GET: UserDetails/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of UserDetails.
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                //Return an Error Message if there is no userDetail.
                return HttpNotFound();
            }
            return View(userDetail);
        }

        [Authorize(Roles = "Admin")]
        //GET: UserDetails/Create
        public ActionResult Create()
        {
            //Get UserDetails items by UserId
            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "UserDetails");
            return View();
        }

        [Authorize(Roles = "Admin")]
        //POST: UserDetails/Create
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

        [Authorize(Roles = "Admin")]
        // GET: UserDetails/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of UserDetails.
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                //Return an Error Message if there is no userDetail.
                return HttpNotFound();
            }

            //Grab the data and throw it to the screen.
            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "UserId", userDetail.UserId);
            return View(userDetail);
        }

        [Authorize(Roles = "Admin")]
        //POST: UserDetails/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId, FirstName, LastName")]
        UserDetail userDetail)
        {
            if (!ModelState.IsValid)
            {
                //Return Error Message if Model State isn't valid.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Update the current state of the selected instance and return it to the screen.
            if (ModelState.IsValid)
            {
                db.Entry(userDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "UserId", userDetail.UserId);
            return View(userDetail);
        }

        [Authorize(Roles = "Admin")]
        //GET: UserDetails/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of UserDetails.
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                //Return an Error Message if there is no userDetail.
                return HttpNotFound();
            }
            //Return the data to the screen.
            return View(userDetail);
        }

        [Authorize(Roles = "Admin")]
        //POST: UserDetails/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]        
        public ActionResult DeleteConfirmed(int id)
        {
            //Grab the id value of UserDetails.
            UserDetail userDetail = db.UserDetails.Find(id);
            
            //Remove the current instance of UserDetails and save the changes. Send user back to Index afterwards.
            db.UserDetails.Remove(userDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Make sure the instance is actually deleted permanently.
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