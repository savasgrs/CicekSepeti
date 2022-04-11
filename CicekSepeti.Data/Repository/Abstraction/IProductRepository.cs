using CicekSepeti.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repository.Abstraction
{
    public interface IProductRepository
    {
        Task<List<CartItem>> GetAllProduct();
        Task<CartItem> GetProduct(int productId);

        Task<CartItem> AddProduct(CartItem product);

        Task<CartItem> UpdateProduct(CartItem product);

        Task<CartItem> DeleteProduct(int productId);
    }
}
