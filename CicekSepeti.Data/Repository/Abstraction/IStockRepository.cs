using CicekSepeti.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repository.Abstraction
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllStock();
        Task<Stock> GetStock(int stockId);

        Task<Stock> GetStockbyProductId(int productId);


        Task<Stock> AddStock(Stock stock);

        Task<int> UpdateStock(Stock stock);

        Task<int> DeleteStock(int stockId);

        Task<int> SaveChangesAsync();
    }
}
