using ECom.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.Models
{
    //this is the class that is going to get activated when I want to get those roles added to the db.
    //going to call this in the startup file to be able to add the roles to the application.
    public class RoleInitializer
    {
        //set to private because we only want the roleInitializer to have access to these properties. Created a list of roles
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            //roles
            //GUID = Globally Unique Identifier
            new IdentityRole {Name = ApplicationRoles.Admin, NormalizedName = ApplicationRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole {Name = ApplicationRoles.Member, NormalizedName = ApplicationRoles.Member.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() }
        };

        public static void SeedData(IServiceProvider serviceProvider)
        {
            //creating a new instance of db context, and instantiating new new version of the db.
            using (var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService < DbContextOptions<ApplicationDbContext>>()))
            {
                //make sure db is created if not create one.
                dbContext.Database.EnsureCreated();

                //add roles
                AddRoles(dbContext);
            }
        }
        private static void AddRoles(ApplicationDbContext dbContext)
        {
            //if 'roles' table exist go back.
            if (dbContext.Roles.Any()) return;
            //otherwise loop through our list of roles and add each role to the db
            foreach (var role in Roles)
            {
                dbContext.Roles.Add(role);
                dbContext.SaveChanges();
            }
        }
    }
}
