using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECom.Models;
using ECom.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECom.Pages.Show
{
    public class detailsModel : PageModel
    {
        //add the id as a parameter in order to get the details of a specific product.

        private readonly IInventory _context;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly ICartManager _cart;

        public detailsModel(IInventory context, UserManager<ApplicationUser> manager, ICartManager cart)
        {
            _context = context;
            _manager = manager;
            _cart = cart;
        }
        public Product Product { get; set; }

        public async Task OnGet(int id)
        {
            Product = await _context.GetProductByIDAsync(id);
        }



        public async Task<IActionResult> OnPostAsync(int id)
        {
            ApplicationUser user = await _manager.GetUserAsync(User);
            Cart cart = await _cart.GetCartByIdAsync(user.Email);
            {
                if (ModelState.IsValid)
                {
                    CartItems item = new CartItems();
                    item.CartId = cart.CartId;
                    item.ProductId = id;
                    item.Quantity = 1;

                    await _cart.AddItemToCartAsync(item);
                }
            }
            return Redirect("/ShoppingCart/Cart");

        }
    }
}
    