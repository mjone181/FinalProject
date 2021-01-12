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
using Microsoft.AspNet.Identity;

namespace FinalProject.UI.MVC.Controllers
{
    public class ReservationsController : Controller
    {
        //Create a new Database Keyword
        FinalProjectEntities1 db = new FinalProjectEntities1();

        // GET: Reservations       
        public ActionResult Index()
        {
            
            //Select the Database from SQL Server and show it to the screen.
            var reservations = (from r in db.Reservations
                                select r).ToList();
            //var currentUserId = db.UserDetails.Where(x => x.UserId)
            //if (User.IsInRole("Owner"))
            //{
            //    return View(reservations.Where(x => x.OwnerAsset.OwnerAssetId == currentUserId))
            //}
            return View(reservations);
        }
        
        public ActionResult Reservations()
        {
            //Link to SQL Database with ReservationsViewModel
            List<ReservationsViewModel> reservations = db.Reservations.
                Select(r => new ReservationsViewModel()
                {
                    ReservationId = r.ReservationId,
                    OwnerAssetId = r.OwnerAssetId,                   
                    LocationId = r.LocationId,
                    Locations = new LocationsViewModel()
                    {
                        LocationId = r.LocationId,
                        LocationName = r.Location.LocationName,
                        Address = r.Location.Address,
                        City = r.Location.City,
                        State = r.Location.State,
                        ZipCode = r.Location.ZipCode,
                        ReservationLimit = r.Location.ReservationLimit
                    },
                    ReservationDate = r.ReservationDate
                }).ToList<ReservationsViewModel>();

            return View();
        }

        //GET: Reservations/Details        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of Reservations.
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                //Return an Error Message if there is no reservation.
                return HttpNotFound();
            }
            return View(reservation);
        }

        [Authorize(Roles = "Owner")]
        //GET: Reservations/Create
        public ActionResult Create()
        {
            //Get Reservations items by ReservationId
            ViewBag.ReservationId = new SelectList(db.Reservations, "ReservationId", "Reservations");
            return View();
        }

        [Authorize(Roles = "Owner")]
        //POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId, OwnerAssetId, LocationId, ReservationDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {           
                //If user is not an Admin Role
                if (!User.IsInRole("Admin"))
                {

                    //get the reservation limit for the current location (returns an int)
                    int currentLimit = db.Locations.Where(x => x.LocationId == reservation.LocationId).Select(x => x.ReservationLimit).Single();

                    //find number of reservations at that location for that date (returns an int)
                    int numberOfReservations = db.Reservations.Where(x => x.LocationId == reservation.LocationId &&
                    x.ReservationDate == reservation.ReservationDate).Count();
                    
                    //check if reservation limit is less than the number of reservations (if statement)
                    if (numberOfReservations <= currentLimit)
                    {
                        //if less than limit add reservation, save changes, return to Index
                        //Add a new Reservation to the database with a View if Model is valid
                        db.Reservations.Add(reservation);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    //else (value is NOT less than limit) - Add a Viewbag message that says spots are no longer available.
                    else
                    {
                        ViewBag.Message("Sorry! Spots are no longer available.");
                        return View(reservation);
                    }                  

                }
                
            }

            //Grabbing the newly entered data and showing it to the screen.
            ViewBag.ReservationId = new SelectList(db.Reservations, "ReservationId", "ReservationId", reservation.ReservationId);
            return View(reservation);            
        }

        // GET: Reservations/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of Reservations.
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                //Return an Error Message if there is no reservation.
                return HttpNotFound();
            }

            //Grab the data and throw it to the screen.
            ViewBag.ReservationId = new SelectList(db.Reservations, "ReservationId", "ReservationId", reservation.ReservationId);
            return View(reservation);
        }

        //POST: Reservations/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationId, OwnerAssetId, LocationId, ReservationDate")]
        Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                //Return Error Message if Model State isn't valid.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Update the current state of the selected instance and return it to the screen.
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReservationId = new SelectList(db.Reservations, "ReservationId", "ReservationId", reservation.ReservationId);
            return View(reservation);
        }

        [Authorize(Roles = "Admin")]
        //GET: Reservations/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of Reservations
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                //Return an Error Message if there is no reservation.
                return HttpNotFound();
            }
            //Return the data to the screen.
            return View(reservation);
        }

        [Authorize(Roles = "Admin")]
        //POST: Reservations/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Grab the id value of Reservations.
            Reservation reservation = db.Reservations.Find(id);

            //Remove the current instance of Reservations and save the changes. Send user back to Index afterwards.
            db.Reservations.Remove(reservation);
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