using CicekSepeti.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repository.Abstraction
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProduct(int productId);

        Task<Product> AddProduct(Product product);

        Task<Product> UpdateProduct(Product product);

        Task<Product> DeleteProduct(int productId);
    }
}
