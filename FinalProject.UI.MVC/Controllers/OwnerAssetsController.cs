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

        //GET
        public ActionResult Create()
        {
            ViewBag.OwnerAssetId = new SelectList(db.OwnerAssets, "OwnerAssetId", "OwnerAssets");
            return View();
        }

        //POST
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
    }
}