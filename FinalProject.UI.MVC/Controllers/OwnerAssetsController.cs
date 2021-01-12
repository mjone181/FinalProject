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
//Need these to actually make an Image show up
using System.Drawing;
using FinalProject.UI.MVC.Utilities;

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
        public ActionResult Create([Bind(Include = "OwnerAssetId, AssetName, OwnerId, AssetPhoto, SpecialNotes, IsActive, DateAdded")] OwnerAsset ownerAsset, HttpPostedFileBase AssetPhoto)
        {
            #region File Upload
            if (ModelState.IsValid)
            {
                //Use default image if none is provided.
                string imgName = "noImage.png";
                if (AssetPhoto != null) //HttpPostedFileBase added to the action != null
                {
                    //Get image and return to variable.
                    imgName = AssetPhoto.FileName;

                    //Declare and assign ext variable.
                    string ext = imgName.Substring(imgName.LastIndexOf('.'));

                    //Declare a list of valid extensions.
                    string[] goodExts = { ".jpeg", ".jpg", ".gif", ".png" };

                    //Check the ext variable (toLower()) against the valid list.
                    if (goodExts.Contains(ext.ToLower()) && (AssetPhoto.ContentLength <= 4194304))//Max 4MB value allowed by ASP.net
                    {
                        //If it is in the list using a guid
                        imgName = Guid.NewGuid() + ext;

                        //save to the webserver
                        AssetPhoto.SaveAs(Server.MapPath("~/Content/images/" + imgName));

                        //Create variables to resize image.
                        string savePath = Server.MapPath("~/Content/images/");

                        Image convertedImage = Image.FromStream(AssetPhoto.InputStream);

                        int maxImgSize = 500;
                        int maxThumbSize = 100;

                        UploadUtility.ResizeImage(savePath, imgName, convertedImage, maxImgSize, maxThumbSize);
                    }
                    else
                    {
                        imgName = "noImage.png";
                    }

                    //No matter what, add imgName to the object.
                    ownerAsset.AssetPhoto = imgName;
                }

            }
            #endregion  
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
        public ActionResult Edit([Bind(Include = "OwnerAssetId, AssetName, OwnerId, AssetPhoto, SpecialNotes, IsActive, DateAdded")] OwnerAsset ownerAsset, HttpPostedFileBase AssetPhoto)
        {
            #region File Upload
            if (AssetPhoto != null)//HttpPostedFileBase added to the action != null
            {
                //Get image and assign to variable
                string imgName = AssetPhoto.FileName;

                //Declare and assign ext value
                string ext = imgName.Substring(imgName.LastIndexOf('.'));

                //Declare a list of valid extensions.
                string[] goodExts = { ".jpeg", ".jpg", ".gif", ".png" };

                //Check the ext value (toLower()) against the valid list
                if (goodExts.Contains(ext.ToLower()) && (AssetPhoto.ContentLength <= 4194304))//4MB max allowed by ASP.NET
                {
                    //If it is in the list rename using a guid
                    imgName = Guid.NewGuid() + ext;

                    //Save to the webserver
                    AssetPhoto.SaveAs(Server.MapPath("~/Content/images/" + imgName));

                    //Create variables to resize image.
                    string savePath = Server.MapPath("~/Content/images/");

                    Image convertedImage = Image.FromStream(AssetPhoto.InputStream);

                    int maxImgSize = 500;
                    int maxThumbSize = 100;

                    UploadUtility.ResizeImage(savePath, imgName, convertedImage, maxImgSize, maxThumbSize);

                    //Make sure you are not deleting your default image.
                    if (ownerAsset.AssetPhoto != null && ownerAsset.AssetPhoto != "GenericHotelImage.jpg")
                    {
                        //Remove the original file
                        string path = Server.MapPath("~/Content/images/");
                        UploadUtility.Delete(path, ownerAsset.AssetPhoto);
                    }

                    //Only save if image meets criteria imageName to the object.
                    ownerAsset.AssetPhoto = imgName;
                }

            }
            #endregion
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
            
            if (ownerAsset.AssetPhoto != null && ownerAsset.AssetPhoto != "noImage.jpg")
                {
                    //Remove the original file from the edit view.
                    string path = Server.MapPath("~/Content/images/");
                    UploadUtility.Delete(path, ownerAsset.AssetPhoto);
                }

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