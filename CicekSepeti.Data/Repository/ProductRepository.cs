using CicekSepeti.Core;
using CicekSepeti.Data.Repository.Abstraction;
using CicekSepeti.Data.Context;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        public readonly ECommerceDBContext _context;

        public ProductRepository(ECommerceDBContext context)
        {
            _context = context;
        }
        public async Task<CartItem> AddProduct(CartItem product)
        {

            if (_context.Products.Contains(product))
            {
                return default;
            }
            // Add the new product,
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<CartItem> DeleteProduct(int productId)
        {
            CartItem product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                // Delete the product from the product table
                _context.Remove(product);

                // Save DB changes
                await  _context.SaveChangesAsync();
            }
            return product;
        }

        public async Task<List<CartItem>> GetAllProduct()
        {
            
            return await _context.Products.ToListAsync();
        }

        public async Task<CartItem> GetProduct(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(productId));
        }

        public async Task<CartItem> UpdateProduct(CartItem product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
