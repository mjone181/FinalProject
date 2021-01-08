//Required to make Contact View work.
using FinalProject.UI.MVC.Models;
using System.Web.Mvc;
//Needed for Email functionality.
using System.Net.Mail;
using System.Net;
using System;

namespace FinalProject.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                //If the Model is vaild send the email via a MailMessage.
                string body = $"{cvm.Name} has sent you the following message: <br />" + $"{cvm.Message} <strong>from the email address</strong> {cvm.Email}";
                MailMessage m = new MailMessage("no-reply@jonesmack.com", "mjone181@gmail.com", cvm.Subject, body);

                //Allows HTML
                m.IsBodyHtml = true;

                //Makes Email high priority.
                m.Priority = MailPriority.High;

                //Reply to person who filled out form.
                m.ReplyToList.Add(cvm.Email);

                //Configure Mail client
                SmtpClient client = new SmtpClient("mail.jonesmack.com");

                //Configure Mail credentials
                client.Credentials = new NetworkCredential("no-reply@jonesmack.com", "Allenwalker1!");

                try
                {
                    //Send mail
                    client.Send(m);
                }
                catch (Exception e)
                {
                    //Error message in ViewBag for Admins to see.
                    ViewBag.Message = e.StackTrace; 
                    throw;
                }

                return View("EmailConfirmation");
            }
            return View(cvm);

        }
    }
}
