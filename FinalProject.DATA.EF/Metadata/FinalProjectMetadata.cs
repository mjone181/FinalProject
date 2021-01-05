using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DATA.EF.Metadata
{
    #region Location

    //Metadata for Location
    public class LocationMetadata
    {
        //Foreign Key
        public int LocationId { get; set; }

        [Display(Name = "Location Name:")]
        [Required(ErrorMessage = "*Location Name is required.")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        public string LocationName { get; set; }

        [Display(Name = "Address:")]
        [Required(ErrorMessage = "*Address is required.")]
        [StringLength(100, ErrorMessage = "*Must be 100 characters or less.")]
        public string Address { get; set; }

        [Display(Name = "City:")]
        [Required(ErrorMessage = "*City is required.")]
        [StringLength(100, ErrorMessage = "*Must be 100 characters or less.")]
        public string City { get; set; }

        [Display(Name = "State:")]
        [Required(ErrorMessage = "*State is required.")]
        [StringLength(2, ErrorMessage = "*Must be 2 characters or less.")]
        public string State { get; set; }

        [Display(Name = "Zip Code:")]
        [Required(ErrorMessage = "*Zip Code is required.")]
        [StringLength(5, ErrorMessage = "*Must be 5 characters or less.")]
        public string ZipCode { get; set; }

        [Display(Name ="Reservation Limit")]
        [Required(ErrorMessage = "*Limit is required")]
        public byte ReservationLimit { get; set; }
    }
    #endregion

    #region OwnerAsset

    //Metadata for OwnerAsset
    public class OwnerAssetMetadata
    {
        //Foreign Key
        public int OwnerAssetId { get; set; }

        [Display(Name = "Asset Name:")]
        [Required(ErrorMessage = "*Asset Name is required.")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        public string AssetName { get; set; }
        public string OwnerId { get; set; }

        [Display(Name = "Asset Photo:")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]        
        public string AssetPhoto { get; set; }

        [Display(Name = "Special Notes:")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(50, ErrorMessage = "*Must be 300 characters or less.")]
        [UIHint("MultilineText")]
        public string SpecialNotes { get; set; }
        public bool IsActive { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]       
        public System.DateTime DateAdded { get; set; }
    }
    #endregion

    #region Reservation

    //Metadata for Reservation
    public class ReservationMetadata
    {
        //Foreign Key
        public int ReservationId { get; set; }
        public int OwnerAssetId { get; set; }
        public int LocationId { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime ReservationDate { get; set; }
    }
    #endregion

    #region UserDetail
    
    //Metadata for UserDetail
    public class UserDetailMetadata
    {
        //Foreign Key
        public string UserId { get; set; }

        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "*First Name is required.")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "*Last Name is required.")]
        [StringLength(50, ErrorMessage = "*Must be 50 characters or less.")]
        public string LastName { get; set; }
    }
    #endregion
}


