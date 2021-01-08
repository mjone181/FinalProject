using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Allows Email Form to work
using System.ComponentModel.DataAnnotations;

namespace FinalProject.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "* Your name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* Your email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        //If used.
        [Required(ErrorMessage = "* A subject is required.")]
        public string Subject { get; set; }

        [UIHint("MultilineText")]//Replaces textbox with textarea in the UI wherver an EditorFor() is located.
        [Required(ErrorMessage = "* A message is required.")]
        public string Message { get; set; }
    }
}