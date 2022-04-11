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
        public async Task<Cart> AddCart(Cart cart)
        {

            if (_context.Cart.Contains(cart))
            {
                return default;
            }
            // Add the new Cart,
            _context.Cart.Add(cart);

            await _context.SaveChangesAsync();

            return cart;
        }

        public async Task<Cart> DeleteCart(Guid cartId)
        {
            Cart cart = await _context.Cart.FindAsync(cartId);
            if (cart != null)
            {
                // Delete the Cart from the Cart table
                _context.Remove(cart);

                // Save DB changes
                _context.SaveChanges();
            }
            return cart;
        }

        public async Task<List<Cart>> GetAllCart()
        {
            
            return await _context.Cart.ToListAsync();
        }

        public async Task<Cart> GetCart(Guid guidCartId)
        {
            return await _context.Cart.FirstOrDefaultAsync(p => p.CartGuid.Equals(guidCartId));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            _context.Cart.Update(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
    }
}
