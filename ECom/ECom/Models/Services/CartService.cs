using ECom.Data;
using ECom.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.Models.Services
{
    public class CartService : ICartManager
    {
        private StoreDbContext _context;
        public CartService(StoreDbContext context)
        {
            _context = context;
        }

        //creating a cart
        public async Task CreateCartAsync(Cart cart)
        {
            await _context.Cart.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        //getting a specific user's cart
        public async Task<Cart> GetCartByIdAsync(string CartId) => await _context.Cart.FirstOrDefaultAsync(it => it.CartId == CartId);

        //adding an item to a user's cart
        public async Task AddItemToCartAsync(CartItems item)
        {
            await _context.CartItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        //get a specific item 
        public async Task<CartItems> GetItemByIDAsync(string CartId, int ProductId) => await _context.CartItems.FirstOrDefaultAsync(it1 => it1.CartId == CartId && it1.ProductId == ProductId);


        //delete a specific item from a user's cart
        public async Task DeleteItemAsync(CartItems item)
        {
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }


        //get all items associated to a specific user
        public async Task<List<CartItems>> GetItemsAsync(string CartId)
        {
            List<CartItems> items = await _context.CartItems.Where(x => x.CartId == CartId).ToListAsync();
            return items;
        }

        //updating specific item 
        public async Task UpdateItemAsync(CartItems item)
        {
             _context.CartItems.Update(item);
            await _context.SaveChangesAsync();
        }

    }
}
