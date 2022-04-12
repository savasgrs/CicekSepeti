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

        Task<int> UpdateCart(Cart cart);

        Task<int> DeleteCart(Guid cartId);

        Task<int> SaveChangesAsync();
    }
}
