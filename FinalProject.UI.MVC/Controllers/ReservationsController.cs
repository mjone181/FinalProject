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
    public class ReservationsController : Controller
    {
        //Create a new Database Keyword
        FinalProjectEntities db = new FinalProjectEntities();

        // GET: Reservations
        public ActionResult Index()
        {            
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
                    OwnerAssets = new OwnerAssetsViewModel()
                    {
                        OwnerAssetId = r.OwnerAssetId,
                        AssetName = r.OwnerAsset.AssetName,
                        OwnerId = r.OwnerAsset.OwnerId,
                        UserDetails = new UserDetailsViewModel()
                        {
                            UserId = r.OwnerAsset.UserDetail.UserId,
                            FirstName = r.OwnerAsset.UserDetail.FirstName,
                            LastName = r.OwnerAsset.UserDetail.LastName
                        },
                        AssetPhoto = r.OwnerAsset.AssetPhoto,
                        SpecialNotes = r.OwnerAsset.SpecialNotes,
                        IsActive = r.OwnerAsset.IsActive,
                        DateAdded = r.OwnerAsset.DateAdded
                    },
                    LocationId = r.LocationId
                }).ToList<ReservationsViewModel>();
            return View();
        }

        //GET 
        public ActionResult Create()
        {
            ViewBag.ReservationId = new SelectList(db.Reservations, "ReservationId", "Reservations");
            return View();
        }

        //POST: Reservations
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId, OwnerAssetId, LocationId, ReservationDate")] Reservations reservation)
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
    }
}