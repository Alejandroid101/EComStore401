using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.Models
{
    /// <summary>
    /// This ApplicationUser model has properties that we will use to store information in our database regarding our users.
    /// Data notation is included to make the properties required, it also is used to change the display names for some properties.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }


      

    }

    //creating roles for our applications 
    public static class ApplicationRoles
    {
        public const string Member = "Member";
        public const string Admin = "Administrator";
    }

}
