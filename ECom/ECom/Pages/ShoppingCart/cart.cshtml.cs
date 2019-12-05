using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECom.Models;
using ECom.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECom.Pages.ShoppingCart
{
    public class CartModel : PageModel
    {
        private readonly ICartManager _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartModel(ICartManager context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IEnumerable<CartItems> TestItem { get; set; }

        public async Task OnGet()
        {
            ApplicationUser newUser = await _userManager.GetUserAsync(User);

            TestItem = await _context.GetItemsAsync(newUser.Email);
        }


        public  void OnPost()
        {
        }
    }
}