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
        Task<Stock> GetStock(int stocktId);

        Task<Stock> AddStock(Stock stockt);

        Task<Stock> UpdateStock(Stock stockt);

        Task<Stock> DeleteStock(int stocktId);
    }
}
