using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.UI.MVC.Models
{
    public class ReservationsViewModel
    {        
        public int ReservationId { get; set; }
        public int OwnerAssetId { get; set; }
        public int LocationId { get; set; }        
        public System.DateTime ReservationDate { get; set; } 
        public LocationsViewModel Locations { get; set; }
    }

    public class LocationsViewModel
    {        
        public int LocationId { get; set; }        
        public string LocationName { get; set; }        
        public string Address { get; set; }        
        public string City { get; set; }        
        public string State { get; set; }        
        public string ZipCode { get; set; }        
        public byte ReservationLimit { get; set; }
    }

    public class OwnerAssetsViewModel
    {        
        public int OwnerAssetId { get; set; }        
        public string AssetName { get; set; }
        public string OwnerId { get; set; }        
        public string AssetPhoto { get; set; }        
        public string SpecialNotes { get; set; }
        public bool IsActive { get; set; }        
        public System.DateTime DateAdded { get; set; }        
    }

    public class UserDetailsViewModel
    {        
        public string UserId { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }
    }
}