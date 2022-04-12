using CicekSepeti.Core;
using CicekSepeti.Data.Context;
using CicekSepeti.Data.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repository
{
    public class StockRepository : IStockRepository
    {
        public readonly ECommerceDBContext _context;

        public StockRepository(ECommerceDBContext context)
        {
            _context = context;
        }
        public async Task<Stock> AddStock(Stock stock)
        {

            if (_context.Stock.Contains(stock))
            {
                return default;
            }
            // Add the new Stock,
            _context.Stock.Add(stock);

            await _context.SaveChangesAsync();

            return stock;
        }

        public async Task<int> DeleteStock(int stockId)
        {
            Stock stock = await _context.Stock.FindAsync(stockId);
            if (stock != null)
            {
                // Delete the Stock from the Stock table
                _context.Remove(stock);

                // Save DB changes
            }
            return await _context.SaveChangesAsync(); ;
        }

        public async Task<List<Stock>> GetAllStock()
        {
            return await _context.Stock.ToListAsync();
        }

        public async Task<Stock> GetStock(int stockId)
        {
            return await _context.Stock.FirstOrDefaultAsync(p => p.Id.Equals(stockId));
        }

        public async Task<Stock> GetStockbyProductId(int productId)
        {
            return await _context.Stock.FirstOrDefaultAsync(x=> x.ProductId == productId);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateStock(Stock stock)
        {
            _context.Stock.Update(stock);
            return await _context.SaveChangesAsync();
        }
    }

}
