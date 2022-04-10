using CicekSepeti.Core;
using CicekSepeti.Data.Repository.Abstraction;
using CicekSepetiCaseStudy.Data.Context;
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
        public readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(Product product)
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

        public async Task<Product> DeleteProduct(int productId)
        {
            Product product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                // Delete the product from the product table
                _context.Remove(product);

                // Save DB changes
                _context.SaveChanges();
            }
            return product;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(productId));
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
