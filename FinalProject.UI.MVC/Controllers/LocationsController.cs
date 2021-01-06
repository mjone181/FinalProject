using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Getting access to the Models to make this Controller work
using FinalProject.UI.MVC.Models;
//Accessing the Data Layer to bring our Data into the UI Layer
using FinalProject.DATA.EF;

namespace FinalProject.UI.MVC.Controllers
{
    public class LocationsController : Controller
    {
        //Create a new Database Keyword
        FinalProjectEntities db = new FinalProjectEntities();

        // GET: Locations
        public ActionResult Index()
        {
            var locations = (from l in db.UserDetails
                               select l).ToList();
            return View(locations);
        }

        public ActionResult Locations()
        {
            //Link to SQL Database with UserDetailsViewModel
            List<LocationsViewModel> locations = db.Locations.
                Select(l => new LocationsViewModel()
                {
                   LocationId = l.LocationId,
                   LocationName = l.LocationName,
                   Address = l.Address,
                   City = l.City,
                   State = l.State,
                   ZipCode = l.ZipCode,
                   ReservationLimit = l.ReservationLimit    
                }).ToList<LocationsViewModel>();
            return View();
        }

        //GET
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Locations, "LoactionId", "Locations");
            return View();
        }

        //POST: Locations
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationId, LocationName, Address, City, State, ZipCode, ReservationLimit")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Grabbing the newly entered data and showing it to the screen.
            ViewBag.OwnerAssetId = new SelectList(db.Locations, "LocationId", "LocationId", location.LocationId);
            return View(location);
        }
    }
}