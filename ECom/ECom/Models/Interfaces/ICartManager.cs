using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECom.Models.Interfaces
{
    public interface ICartManager
    {
        //create a cart
        Task CreateCartAsync(Cart cart);

        //get specific cart 
        Task <Cart> GetCartByIdAsync(string CartId); 

        //add item to a specific cart
        Task AddItemToCartAsync(CartItems item);

        //Get specific item from a specific cart
        Task<CartItems> GetItemByIDAsync(string CartId, int ProductId);

        //Get all items from a specific user's cart
        Task<List<CartItems>> GetItemsAsync(string CartId);

        //Update specific item
        Task UpdateItemAsync(CartItems item);

        //Delete specific item from a user's cart
        Task DeleteItemAsync(CartItems item);
    }
}
