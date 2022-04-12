using CicekSepeti.Core;
using CicekSepeti.Core.Models;
using CicekSepeti.Data.Context;
using CicekSepeti.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Test
{
    [TestClass]
    public class StockServiceTest
    {

        [TestMethod]
        public void CheckStockTest()
        {
            Stock stockProduct;

            var options = new DbContextOptionsBuilder<ECommerceDBContext>()
                             .UseInMemoryDatabase("testStockDB")
                             .Options;
            using (var context = new ECommerceDBContext(options))
            {
                stockProduct = new Stock
                {
                    Id=1,
                    ProductId = 1,
                    StockQuantity = 4,
                };

                context.Stock.Add(stockProduct);
                context.SaveChanges();
            }
            using (var context = new ECommerceDBContext(options))
            {
                StockRepository stockRepository = new StockRepository(context);
                Assert.AreEqual(stockRepository.GetStock(stockProduct.Id).Result.Id, stockProduct.Id);
                Assert.AreNotEqual(stockRepository.GetStock(stockProduct.Id).Result, -1);
            }
        }


        [TestMethod]
        public void GetStockProductTest()
        {
            Stock stockProduct, stockProduct1;

            var options = new DbContextOptionsBuilder<ECommerceDBContext>()
                             .UseInMemoryDatabase("testStockDB")
                             .Options;
            using (var context = new ECommerceDBContext(options))
            {
                stockProduct = new Stock
                {
                    Id=2,
                    ProductId = 2,
                    StockQuantity=3
                };

                stockProduct1 = new Stock
                {
                    Id=3,
                    ProductId = 3,
                    StockQuantity =44
                };

                context.Stock.Add(stockProduct);
                context.Stock.Add(stockProduct1);
                context.SaveChanges();
            }
            using (var context = new ECommerceDBContext(options))
            {
                StockRepository stockRepository = new StockRepository(context);
                Assert.AreEqual(stockRepository.GetStockbyProductId(stockProduct.ProductId).Result.ProductId, stockProduct.ProductId);
                Assert.AreNotEqual(stockRepository.GetStockbyProductId(stockProduct.ProductId).Result.ProductId, stockProduct1.ProductId);
            }
        }

    }
}
