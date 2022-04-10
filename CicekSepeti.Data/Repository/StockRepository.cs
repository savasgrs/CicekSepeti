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
    public class StockRepository : IStockRepository
    {
        public readonly StockDbContext _context;

        public StockRepository(StockDbContext context)
        {
            _context = context;
        }
        public async Task<Stock> AddStock(Stock stock)
        {

            if (_context.Stock.Contains(stock))
            {
                return default;
            }
            // Add the new stock,
            _context.Stock.Add(stock);

            await _context.SaveChangesAsync();

            return stock;
        }

        public async Task<Stock> DeleteStock(int stockId)
        {
            Stock stock = await _context.Stock.FindAsync(stockId);
            if (stock != null)
            {
                // Delete the stock from the stock table
                _context.Remove(stock);

                // Save DB changes
                _context.SaveChanges();
            }
            return stock;
        }

        public async Task<List<Stock>> GetAllStock()
        {
            
            return await _context.Stock.ToListAsync();
        }

        public async Task<Stock> GetStock(int stockId)
        {
            return await _context.Stock.FirstOrDefaultAsync(p => p.Id.Equals(stockId));
        }

        public async Task<Stock> UpdateStock(Stock stock)
        {
            _context.Stock.Update(stock);
            await _context.SaveChangesAsync();
            return stock;
        }
    }
}
