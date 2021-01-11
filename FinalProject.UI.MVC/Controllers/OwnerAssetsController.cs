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
    public class OwnerAssetsController : Controller
    {
        //Create a new Database Keyword
        FinalProjectEntities1 db = new FinalProjectEntities1();

        // GET: OwnerAssets
        public ActionResult Index()
        {
            var ownerAssets = (from o in db.OwnerAssets
                               select o).ToList(); 
            return View(ownerAssets);
        }

        public ActionResult OwnerAssets()
        {
            //Link to SQL Database with OwnerAssetsViewModel
            List<OwnerAssetsViewModel> ownerAssets = db.OwnerAssets.
                Select(o => new OwnerAssetsViewModel()
                {
                    OwnerAssetId = o.OwnerAssetId,
                    AssetName = o.AssetName,
                    OwnerId = o.OwnerId,
                    AssetPhoto = o.AssetPhoto,
                    SpecialNotes = o.SpecialNotes,
                    IsActive = o.IsActive,
                    DateAdded = o.DateAdded
                }).ToList<OwnerAssetsViewModel>();

            return View();
        }

        //GET: OwnerAssets/Details        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of OwnerAssets.
            OwnerAsset ownerAsset = db.OwnerAssets.Find(id);
            if (ownerAsset == null)
            {
                //Return an Error Message if there is no ownerAsset.
                return HttpNotFound();
            }
            return View(ownerAsset);
        }

        //Only available in Owner Role.
        [Authorize(Roles = "Owner")]
        //GET: OwnerAssets/Create
        public ActionResult Create()
        {
            ViewBag.OwnerAssetId = new SelectList(db.OwnerAssets, "OwnerAssetId", "OwnerAssets");
            return View();
        }

        //Only available in Owner Role.
        [Authorize(Roles = "Owner")]
        //POST: OwnerAssets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OwnerAssetId, AssetName, OwnerId, AssetPhoto, SpecialNotes, IsActive, DateAdded")] OwnerAsset ownerAsset)
        {
            if (ModelState.IsValid)
            {
                //Add a new OwnerAsset to the database with a View if Model is valid
                db.OwnerAssets.Add(ownerAsset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Grabbing the newly entered data and showing it to the screen.
            ViewBag.OwnerAssetId = new SelectList(db.OwnerAssets,"OwnerAssetId", "OwnerAssetId", ownerAsset.OwnerAssetId);
            return View(ownerAsset);
        }

        // GET: OwnerAssets/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of OwnerAssets.
            OwnerAsset ownerAsset = db.OwnerAssets.Find(id);
            if (ownerAsset == null)
            {
                //Return an Error Message if there is no ownerAsset.
                return HttpNotFound();
            }

            //Grab the data and throw it to the screen.
            ViewBag.OwnerAssetId = new SelectList(db.OwnerAssets, "OwnerAssetId", "OwnerAssetId", ownerAsset.OwnerAssetId);
            return View(ownerAsset);
        }

        //POST: OwnerAssets/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OwnerAssetId, AssetName, OwnerId, AssetPhoto, SpecialNotes, IsActive, DateAdded")] OwnerAsset ownerAsset)
        {            
            if (!ModelState.IsValid)
            {
                //Return Error Message if Model State isn't valid.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Update the current state of the selected instance and return it to the screen.
            if (ModelState.IsValid)
            {
                db.Entry(ownerAsset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
            ViewBag.OwnerAssetId = new SelectList(db.Reservations, "OwnerAssetId", "OwnerAssetId", ownerAsset.OwnerAssetId);
            return View(ownerAsset);
        }

        //Only available in Admin Role.
        [Authorize(Roles = "Admin")]
        //GET: OwnerAssets/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //Return Error Message if there is no id.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Grab the id value of OwnerAssets
           OwnerAsset ownerAsset = db.OwnerAssets.Find(id);
            if (ownerAsset == null)
            {
                //Return an Error Message if there is no ownerAsset.
                return HttpNotFound();
            }
            //Return the data to the screen.
            return View(ownerAsset);
        }

        //Only available in Admin Role.
        [Authorize(Roles = "Admin")]
        //POST: Reservations/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Grab the id value of OwnerAssets.
            OwnerAsset ownerAsset = db.OwnerAssets.Find(id);

            //Remove the current instance of OwnerAssets and save the changes. Send user back to Index afterwards.
            db.OwnerAssets.Remove(ownerAsset);
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