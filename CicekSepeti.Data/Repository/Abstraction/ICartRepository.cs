using CicekSepeti.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repository.Abstraction
{
    public interface ICartRepository
    {
        Task<List<BasketProduct>> GetAllBasketProduct();
        Task<BasketProduct> GetBasketProduct(int basketProductId);

        Task<BasketProduct> AddBasketProduct(BasketProduct basketProduct);

        Task<BasketProduct> UpdateBasketProduct(BasketProduct basketProduct);

        Task<BasketProduct> DeleteBasketProduct(int basketProductId);
    }
}
