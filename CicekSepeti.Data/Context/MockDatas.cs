using CicekSepeti.Core;
using CicekSepetiCaseStudy.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepetiCaseStudy.Data.Context
{
    public class MockDatas
    {
        public void CartData()
        {
            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("cartDB")
                             .Options;


            using (var context = new CartDbContext(options))
            {
                //New BasketProduct 
                BasketProduct basketProduct;

                basketProduct = new BasketProduct();
                basketProduct.BasketGuid = new Guid();
                basketProduct.Product = new Product()
                {
                    Id = 1,
                    Name = "ball",
                    Description = "sports goods are sold",
                    Price = (decimal)10.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                    IsActive = true
                };



                context.Cart.Add(basketProduct);

                //New BasketProduct 
                basketProduct = new BasketProduct();
                basketProduct.BasketGuid = new Guid();
                basketProduct.Product = new Product()
                {
                    Id = 2,
                    Name = "Tennis Racket",
                    Description = "sports goods are sold",
                    Price = (decimal)20.99,
                    CreateByUser = "2",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                    IsActive = true
                };


                context.Cart.Add(basketProduct);

                //New BasketProduct 
                basketProduct = new BasketProduct();
                basketProduct.BasketGuid = new Guid();
                basketProduct.Product = new Product()
                {
                    Id = 3,
                    Name = "T-Shirt",
                    Description = "black T-Shirt",
                    Price = (decimal)14.99,
                    CreateByUser = "3",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                    IsActive = true
                };

                context.Cart.Add(basketProduct);

                //New BasketProducts DB add 
                context.SaveChanges();
            }
        }
        public void ProductData()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                             .UseInMemoryDatabase("productDB")
                             .Options;
            using (var context = new ProductDbContext(options))
            {
                Product product;

                product = new Product()
                {
                    Id = 1,
                    Name = "ball",
                    Description = "sports goods are sold",
                    Price = (decimal)10.99,
                    IsActive = true,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };

                context.Products.Add(product);


                product = new Product()
                {
                    Id = 2,
                    Name = "Tennis Racket",
                    Description = "sports goods are sold",
                    Price = (decimal)20.99,
                    IsActive = true,
                    CreateByUser = "2",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };

                context.Products.Add(product);


                product = new Product()
                {
                    Id = 3,
                    Name = "T-Shirt",
                    Description = "black T-Shirt",
                    Price = (decimal)14.99,
                    IsActive = true,
                    CreateByUser = "3",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };

                context.Products.Add(product);

                context.SaveChanges();               
            }
        }


        public void StockProductData()
        {
            var options = new DbContextOptionsBuilder<StockDbContext>()
                             .UseInMemoryDatabase("stockDB")
                             .Options;
            using (var context = new StockDbContext(options))
            {
                Stock stock;

                stock = new Stock
                {
                    Id=1,
                    ProductId=1,
                    Quantity=3,
                    CreateByUser = "10",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };

                context.Stock.Add(stock);


                stock = new Stock
                {
                    Id = 2,
                    ProductId = 5,
                    Quantity = 352,
                    CreateByUser = "22",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };

                context.Stock.Add(stock);
                
                
                stock = new Stock
                {
                    Id = 3,
                    ProductId = 85,
                    Quantity = 84,
                    CreateByUser = "60",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };

                context.Stock.Add(stock);

                context.SaveChanges();
            }
        }

    }
}
