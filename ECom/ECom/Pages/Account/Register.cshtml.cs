using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECom.Models;
using ECom.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ECom.Pages.Account
{
    /// <summary>
    /// claims are added to the registration page because this is the one area where you, the developer are able 
    /// to get more info from the user and the user actually be willing to input that information. Added the cart claim to be able
    /// store the user's email as a cartid.
    /// </summary>
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _email;

        public IConfiguration Configuration { get; }

        private ICartManager _context;

        [BindProperty]
        public RegisterInput Input { get; set; }

        //brought in configuration to be able to get admin email from user secrets.
        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, ICartManager context, IEmailSender email)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Configuration = configuration;
            _context = context;
            _email = email;
        }

        //Gets default info for page
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            //the state of the model is what we are expecting. Following data notations
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, FirstName= Input.FirstName,
                LastName= Input.LastName, Birthdate= Input.Birthdate};
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    //add claim once registration is created but before you sign them in.
                    //To.String("u") cuts off the time and only keeps the date(mm/dd/yyyy).
                    Claim fullName = new Claim("FullName", $"{Input.FirstName} {Input.LastName}");
                    Claim dob = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthdate.Year, user.Birthdate.Month,
                        user.Birthdate.Day).ToString("u"), ClaimValueTypes.DateTime);

                    Claim email = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);
                    Claim country = new Claim(ClaimTypes.Country, Input.Country, ClaimValueTypes.String);
                    //created a cart claim to be able to add a cart to every registered user. Using the user's email address as the cart Id.
                   // Claim cart = new Claim("CartId", $"{Input.Email}");

                    Cart newCart = new Cart() { CartId = Input.Email };
                    await _context.CreateCartAsync(newCart);



                    List<Claim> claims = new List<Claim> { dob, email, country, fullName};
                    
                    //we created claims, now we need to add all claims. Put all claims in a list and put that list in as a parameter in the AddClaimsAsync method.
                    await _userManager.AddClaimsAsync(user, claims);
                    //be cautious of this line of code:
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    // send email here
                    SendRegEmail(user.Email);

                    //if user registers in with admin email, make that user an admin user. Admin email is located in our user secrets. 
                    if(Input.Email == Configuration["AdminEmail"])
                    {
                        //make sure role is singular to only allow this user admin access. We are not going to give them both roles of admin and member.
                        //you can if you want, just change 'role' to 'roles'
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                    }
                    //if user doesnt register with admin email make them a member.
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);


                    return RedirectToAction("Index", "Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }

        private void SendRegEmail(string toEmail)
        {
            StringBuilder sb = new StringBuilder();
            Email email = new Email();

            sb.Append("Thank you for Registering. You will find the best prices and best models in our site. Customer satisfaction guaranteed! ");


            //populate sb with yoru welcome email


            _email.SendEmailAsync(toEmail, "Welcome to Luxury Cars", sb.ToString());

        }

        public class RegisterInput
        {
            [Required]
            [EmailAddress]
            [Display(Name = "EmailAdress")]
            public string Email { get; set; }

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime Birthdate { get; set; }

            //claim added
            [Required]
            public string Country { get; set; }


            [Required]
            [DataType(DataType.Password)]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at a max {1} characters long", MinimumLength = 6)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Error")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "The Password did not match")]
            public string ConfirmPassword { get; set; }
        }
    }
}