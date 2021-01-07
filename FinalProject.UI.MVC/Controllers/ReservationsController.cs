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

        //GET: Reservations/Create
        public ActionResult Create()
        {
            //Get Reservations items by ReservationId
            ViewBag.ReservationId = new SelectList(db.Reservations, "ReservationId", "Reservations");
            return View();
        }

        //POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId, OwnerAssetId, LocationId, ReservationDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                //Add a new Reservation to the database with a View if Model is valid
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            db.Entry(reservation).State = EntityState.Modified;
            ViewBag.ReservationId = new SelectList(db.Reservations, "ReservationId", "ReservationId", reservation.ReservationId);
            return View(reservation);
        }

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