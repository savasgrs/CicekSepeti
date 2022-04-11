using CicekSepeti.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repository.Abstraction
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllCart();
        Task<Cart> GetCart(Guid guidCartId);

        Task<Cart> AddCart(Cart cart);

        Task<Cart> UpdateCart(Cart cart);

        Task<Cart> DeleteCart(Guid cartId);

        Task<int> SaveChangesAsync();

    }
}
