//Accessing the Data Layer to bring our Data into the UI Layer
using FinalProject.DATA.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Getting access to the Models to make this Controller work
using FinalProject.UI.MVC.Models;

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

        //GET
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
    }
}