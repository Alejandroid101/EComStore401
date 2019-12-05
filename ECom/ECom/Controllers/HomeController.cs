using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text;
using ECom.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ECom.Controllers
{
    //Home controller will return the index view that we have setup. In our home folder in views.
    
    public class HomeController : Controller
    {
        private IEmailSender _email;

        public HomeController(IEmailSender email)
        {
            _email = email;
        }
        public IActionResult Index()
        {
            Email newEmail = ConstructEmail();

            _email.SendEmailAsync(newEmail.ToEmail, newEmail.Subject, newEmail.Message);
            return View();
        }   
        private Email ConstructEmail()
        {
            StringBuilder sb = new StringBuilder();

            Email email = new Email();

            //email.ToEmail = ""
                //User.Claims.FirstOrDefault(x => x.Type == ClaimValueTypes.Email).Value;
            email.Subject = "Welcome to Luxury Cars LTD";

            sb.Append("Thank you for your business, we apreciate it very much. ");
            sb.Append("Here are the things you purchased:");
            for (int i = 0; i < 5; i++)
            {
                sb.Append($"`the is item {i}`");
            }
            email.Message = sb.ToString();

            return email;
        }
    }
}