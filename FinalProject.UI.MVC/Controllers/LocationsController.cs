using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Getting access to the Models to make this Controller work
using FinalProject.UI.MVC.Models;
//Accessing the Data Layer to bring our Data into the UI Layer
using FinalProject.DATA.EF;
//Need these to make Edit Views possible.
using System.Net;
using System.Data.Entity;

namespace FinalProject.UI.MVC.Controllers
{
    public class LocationsController : Controller
    {
        //Create a new Database Keyword
        FinalProjectEntities1 db = new FinalProjectEntities1();

        // GET: Locations
        public ActionResult Index()
        {
            var locations = (from l in db.Locations
                               select l).ToList();
            return View(locations);
        }

        public ActionResult Locations()
        {
            //Link to SQL Database with LocationsViewModel
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

        //GET: Locations/Details        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of Locations.
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                //Return an Error Message if there is no ownerAsset.
                return HttpNotFound();
            }
            return View(location);
        }

        //GET: Locations/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Locations, "LoactionId", "Locations");
            return View();
        }

        //POST: Locations/Create
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
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationId", location.LocationId);
            return View(location);
        }

        //GET: Locations/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of Locations.
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                //Return an Error Message if there is no location.
                return HttpNotFound();
            }

            //Grab the data and throw it to the screen.
            ViewBag.LocationId = new SelectList(db.Locations, "OwnerAssetId", "OwnerAssetId", location.LocationId);
            return View(location);
        }

        //POST: Locations/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationId, LocationName, Address, City, State, ZipCode, ReservationLimit")] Location location)
        {
            if (!ModelState.IsValid)
            {
                //Return Error Message if Model State isn't valid.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Update the current state of the selected instance and return it to the screen.
            db.Entry(location).State = EntityState.Modified;
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationId", location.LocationId);
            return View(location);
        }

        //GET: Locations/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of Locations
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                //Return an Error Message if there is no location.
                return HttpNotFound();
            }
            //Return the data to the screen.
            return View(location);
        }

        //POST: Reservations/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Grab the id value of Locations.
            Location location = db.Locations.Find(id);

            //Remove the current instance of Locations and save the changes. Send user back to Index afterwards.
            db.Locations.Remove(location);
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