using CicekSepeti.Core;
using CicekSepetiCaseStudy.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepetiCaseStudy.Data.Context
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
        }

        public DbSet<Stock> Stock { get; set; }
    }
}
