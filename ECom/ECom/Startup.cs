using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECom.Data;
using ECom.Models.Interfaces;
using ECom.Models.Services;
using ECom.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ECom
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }

        public Startup(IHostEnvironment environment)
        {
            Environment = environment;
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            string storeConnectionString = Environment.IsDevelopment()
                    ? Configuration["ConnectionStrings:StoreDbLocalConnection"]
                    : Configuration["ConnectionStrings:StoreDbProductionConnection"];

            string applicationConnectionString = Environment.IsDevelopment()
                    ? Configuration["ConnectionStrings:ApplicationDbLocalConnection"]
                    : Configuration["ConnectionStrings:ApplicationDbProductionConnection"];

            services.AddDbContext<StoreDbContext>(options =>
            options.UseSqlServer(storeConnectionString));


            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(applicationConnectionString));

            services.AddScoped<IInventory, ProductService>();
            services.AddScoped<ICartManager, CartService>();

            //Connect user to specific Database for information storage
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            //on authorization add policy which is 'Admin Only' policy, the 'Admin Only' policy is going to be based off the admin role.
            services.AddAuthorization(options =>
            options.AddPolicy("Admin Only", policy => policy.RequireRole(ApplicationRoles.Admin)));

            services.AddScoped<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Enable Authentication
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                
            });

            RoleInitializer.SeedData(serviceProvider);
        }
    }
}
