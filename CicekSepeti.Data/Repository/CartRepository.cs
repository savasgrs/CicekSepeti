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
    public class CartRepository : ICartRepository
    {
        public readonly CartDbContext _context;

        public CartRepository(CartDbContext context)
        {
            _context = context;
        }
        public async Task<BasketProduct> AddBasketProduct(BasketProduct basketProduct)
        {

            if (_context.Cart.Contains(basketProduct))
            {
                return default;
            }
            // Add the new basket product,
            _context.Cart.Add(basketProduct);

            await _context.SaveChangesAsync();

            return basketProduct;
        }

        public async Task<BasketProduct> DeleteBasketProduct(int basketProductId)
        {
            BasketProduct basketProduct = await _context.Cart.FindAsync(basketProductId);
            if (basketProduct != null)
            {
                // Delete the basket product from the basket product table
                _context.Remove(basketProduct);

                // Save DB changes
                _context.SaveChanges();
            }
            return basketProduct;
        }

        public async Task<List<BasketProduct>> GetAllBasketProduct()
        {
            
            return await _context.Cart.ToListAsync();
        }

        public async Task<BasketProduct> GetBasketProduct(int basketProductId)
        {
            return await _context.Cart.FirstOrDefaultAsync(p => p.Product.Id.Equals(basketProductId));
        }

        public async Task<BasketProduct> UpdateBasketProduct(BasketProduct basketProduct)
        {
            _context.Cart.Update(basketProduct);
            await _context.SaveChangesAsync();
            return basketProduct;
        }
    }
}
