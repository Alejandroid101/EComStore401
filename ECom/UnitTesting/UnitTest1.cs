using System;
using Xunit;
using ECom;
using ECom.Models;
using Microsoft.EntityFrameworkCore;
using ECom.Data;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class UnitTest1
    {

        /// <summary>
        /// created unit tests for getters and setters
        /// </summary>
        [Fact]
        public void CreateProduct()
        {

            Product test = new Product();
            test.ID = 1;
            test.Name = "Camry";
            test.Color = "White";
            test.Price = 200000.00M;
            test.Sku = "GEGEGEGE";
            test.Year = 1995;
            test.Description = "testing";

            Assert.Equal(1, test.ID);
            Assert.Equal("Camry", test.Name);
            Assert.Equal(200000.00M, test.Price);
            Assert.Equal("White", test.Color);
            Assert.Equal("GEGEGEGE", test.Sku);
            Assert.Equal(1995, test.Year);
            Assert.Equal("testing", test.Description);

        }
        [Fact]
        public void EditProduct()
        {
            Product test = new Product();
            test.ID = 1;
            test.Name = "Camry";
            test.Color = "White";
            test.Color = "Black";

            Assert.Equal(1, test.ID);
            Assert.Equal("Camry", test.Name);
            Assert.Equal("Black", test.Color);

        }
        [Fact]
        public void CreateUser()
        {
            ApplicationUser ben = new ApplicationUser();
            ben.FirstName = "Ben";
            ben.LastName = "Smith";

            Assert.Equal("Ben", ben.FirstName);
            Assert.Equal("Smith", ben.LastName);
        }

        [Fact]
        public void EditUserInfo()
        {
            ApplicationUser ben = new ApplicationUser();
            ben.FirstName = "Ben";
            ben.FirstName = "John";
            ben.LastName = "Smith";

            Assert.Equal("John", ben.FirstName);
            Assert.Equal("Smith", ben.LastName);
        }


    }
}
