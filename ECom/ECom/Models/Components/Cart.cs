using ECom.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.Models.Components
{
    public class Cart : ViewComponent
    {
        private StoreDbContext _context;

        public Cart(StoreDbContext context)
        {
            _context = context;
        }

        //this next method is not complete. -enrique
        public async Task<IViewComponentResult> InvokeAsync(int number)
        {
            var products = _context.Products.OrderByDescending(x => x.ID)
                                             .Take(number);
            return View(products);
        }
    }
}
