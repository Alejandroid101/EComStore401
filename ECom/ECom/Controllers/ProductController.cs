using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECom.Models;
using ECom.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECom.Controllers
{
    /// <summary>
    /// we have a dependency injection with our IInventory interface. It includes an index with a return of view that 
    /// we have created in our pages folder
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IInventory _context;
        private readonly ICartManager _cart;

        public ProductController(IInventory product, ICartManager cart)
        {
            _context = product;
            _cart = cart;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddItemToCartAsync(CartItems item)
        {
            return View();
        }

 







        //public async Task<IActionResult> Delete(CartItems item)
        //{
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
            
        //    //var test = await _context.GetProductByIDAsync(CartId, ProductId);
        //    return View(test);
        //}


    }
}