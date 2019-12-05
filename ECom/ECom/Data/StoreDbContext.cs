using ECom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItems>().HasKey(CartItems =>
            new { CartItems.CartId, CartItems.ProductId });

            

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    //description taken from wikipedia, images taken from google images
                    {
                        ID = 1,
                        Sku = "TGYHBVCD",
                        Name = "Ferrari 488 Spider",
                        Year = 2019,
                        Color = "White",
                        Price = 280900.00M,
                        Description = "The Ferrari 488 (Type F142M) is a mid-engine sports car produced by the Italian automobile manufacturer Ferrari. " +
                        "The car is an update to the 458 with notable exterior and performance changes. " +
                        "The car is powered by a 3.9 - litre twin - turbocharged V8 engine, smaller in displacement but generating a higher power output than the 458's naturally aspirated engine. " +
                        "The 488 GTB was named 'The Supercar of the Year 2015' by car magazine Top Gear, as well as becoming Motor Trend's 2017 'Best Driver's Car'. ",
                        Image = "/assets/ferrari.jpg"
                    },
                      new Product
                      {
                          ID = 2,
                          Sku = "FLOMIJER",
                          Name = "Lamborghini Aventador S",
                          Year = 2019,
                          Color = "Grey",
                          Price = 417826.00M,
                          Description = "An icon cannot be reinvented, it can only be challenged. And only Aventador could surpass itself. This Lamborghini Aventador is a mid-engine sports car produced by the Italian automotive manufacturer Lamborghini. " +
                          "In keeping with Lamborghini tradition, the Aventador is named after a fighting bull.",
                          Image = "/assets/lambo.jpg"
                      },
                        new Product
                        {
                            ID = 3,
                            Sku = "PQASKFGV",
                            Name = "Rolls-Royce Ghost",
                            Year = 2019,
                            Color = "White",
                            Price = 351900.00M,
                            Description = "The Rolls-Royce Ghost is a British full-size luxury car manufactured by Rolls-Royce Motor Cars. The 'Ghost' nameplate, named in honour of the Silver Ghost, a car first produced in 1906, was announced in April 2009 at the Auto Shanghai show. During development, the Ghost was known as the 'RR04'.",
                            Image = "/assets/ghost.jpg"
                        },
                          new Product
                          {
                              ID = 4,
                              Sku = "MVNCBRTY",
                              Name = "Porsche 911",
                              Year = 2019,
                              Color = "Grey",
                              Price = 113300.00M,
                              Description = "The Porsche 911 is a two-door, 2+2 high performance rear-engined sports car made since in 1963 by Porsche AG of Stuttgart, Germany. " +
                              "It has a rear-mounted flat-six engine and all round independent suspension. " +
                              "It has undergone continuous development, though the basic concept has remained unchanged.",
                              Image = "/assets/911.jpg"
                          }, new Product
                          {
                              ID = 5,
                              Sku = "LOFJKMDR",
                              Name = "Mercedes Benz S65",
                              Year = 2019,
                              Color = "Black",
                              Price = 230400.00M,
                              Description = "A handcrafted 621-hp biturbo V12 teams with a road-scanning, curve-tilting, fully active suspension in the AMG S 65. It's more than luxurious, and more than powerful. " +
                              "It's a sensation of majesty and magic no other sedan can match.",
                              Image = "/assets/benz.jpg"
                          }, new Product
                          {
                              ID = 6,
                              Sku = "ASGTEFJN",
                              Name = "BMW i8",
                              Year = 2019,
                              Color = "White",
                              Price = 147500.00M,
                              Description = "The BMW i8 is a plug-in hybrid sports car developed by BMW. The i8 is part of BMW's electric fleet 'Project i' being marketed as a new sub-brand, BMW i. " +
                              "The BMW i8 accelerates from 0 to 100 km / h(62 mph) in 4.4 seconds and has an electronic limited top speed of 250 km / h(155 mph).",
                              Image = "/assets/bmw.jpg"


                          }, new Product
                          {
                              ID = 7,
                              Sku = "QSDEWFTG",
                              Name = "Tesla Roadster",
                              Year = 2020,
                              Color = "White",
                              Price = 200000.00M,
                              Description = "The Tesla Roadster is an upcoming all-electric battery-powered four-seater sports car made by Tesla, Inc. " +
                              "Tesla has said it will be capable of 0 to 97 km/h (0 to 60 mph) in 1.9 seconds, quicker than any street legal production car to date at its announcement in November 2017." +
                              " The Roadster is the successor to Tesla's first production car, which was the 2008 Roadster.",
                              Image = "/assets/tesla.jpg"
                          },
                            new Product
                            {
                                ID = 8,
                                Sku = "POLEDFRT",
                                Name = "Jaguar F-TYPE",
                                Year = 2019,
                                Color = "Grey",
                                Price = 61600.00M,
                                Description = "The Jaguar F-type is a quintessential sports car, with a head-turning design and high-octane performance. " +
                                "This Jaguar two-seater takes form as either a sleek coupe or a stunning convertible. " +
                                "Along with a snarling supercharged V-6, the 2020 F-type offers a more affordable turbocharged four-cylinder engine.",
                                Image = "/assets/jag.jpg"

                            },
                              new Product
                              {
                                  ID = 9,
                                  Sku = "JGNMHKTE",
                                  Name = "Audi R8",
                                  Year = 2019,
                                  Color = "Light Grey",
                                  Price = 169900.00M,
                                  Description = "The Audi R8 is a mid-engine, 2-seater sports car, which uses Audi's trademark quattro permanent all-wheel drive system. It was introduced by the German car manufacturer Audi AG in 2006. " +
                                  "The car is exclusively designed, developed, and manufactured by Audi AG's private subsidiary company manufacturing high performance automotive parts, Audi Sport GmbH (formerly quattro GmbH), and is based on the Lamborghini Gallardo and presently the Huracán platform.",
                                  Image = "/assets/audi.jpg"

                              },
                                new Product
                                {
                                    ID = 10,
                                    Sku = "BGHVDPWO",
                                    Name = "Bentley Bentayga",
                                    Year = 2019,
                                    Color = "Black",
                                    Price = 165000.00M,
                                    Description = "The Bentley Bentayga is a mid-size, front-engine, all-wheel drive, five-door luxury crossover marketed by Bentley, beginning with model year 2016. " +
                                    "Its body is manufactured at the Volkswagen Zwickau-Mosel plant, then painted by Paintbox Editions in Banbury, and finally assembled at the company's Crewe factory.",
                                    Image = "/assets/bentley.jpg"
                                }
                                );

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
    }
}
