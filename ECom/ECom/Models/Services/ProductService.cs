using ECom.Data;
using ECom.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.Models.Services
{
    /// <summary>
    /// This service has a dependecy injection where we are injecting our database into our service. It is also
    /// creating our crud operations.
    /// </summary>
    public class ProductService : IInventory
    {
        private StoreDbContext _context;
        public ProductService(StoreDbContext context)
        {
            _context = context;
        }
        //create
        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        //delete
        public async Task DeleteProductAsync(int id)
        {
            Product product = await GetProductByIDAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        //read
        public async Task<Product> GetProductByIDAsync(int id) => await _context.Products.FirstOrDefaultAsync(pd1 => pd1.ID == id);

        public async Task<List<Product>> GetProductsAsync()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        //update
        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
