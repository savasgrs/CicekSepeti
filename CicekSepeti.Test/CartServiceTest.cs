using CicekSepeti.Core;
using CicekSepeti.Data.Repository;
using CicekSepetiCaseStudy.Core.Models;
using CicekSepetiCaseStudy.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CicekSepetiCaseStudy.Test
{
    [TestClass]
    public class CartServiceTest
    {
        [TestMethod]
        public void GetProductByIdTest()
        {
            Cart testCartProduct;
            Guid testGuid = new Guid();
            decimal testAmount = (decimal)10.99;

            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("testCartDb1")
                             .Options;
            using (var context = new CartDbContext(options))
            {
                testCartProduct = new Cart();
                testCartProduct.CartGuid = testGuid;
                testCartProduct.Amount = testAmount;

                CartItem product;

                product = new CartItem()
                {
                    Id = 1,
                    Name = "ball",
                    Description = "sports goods are sold",
                    Price = (decimal)10.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow
                };


                context.Cart.Add(testCartProduct);
                context.SaveChanges();
            }
            using (var context = new CartDbContext(options))
            {
                testCartProduct.Amount = testAmount;

                CartRepository cartService = new CartRepository(context);
                Assert.AreEqual(cartService.GetCart(testCartProduct.CartGuid).Result.CartGuid, testCartProduct.CartGuid);
                Assert.AreNotEqual(cartService.GetCart(testCartProduct.CartGuid).Result.CartGuid, -1);
            }
        }
        [TestMethod]
        public void GetAllProductsTest()
        {
            Guid testGuid = new Guid();
            Cart testCartProduct;
            decimal testAmount = (decimal)1110.99;

            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("test_cart_db_2")
                             .Options;
            using (var context = new CartDbContext(options))
            {

                testCartProduct = new Cart();
                testCartProduct.CartGuid = testGuid;
                testCartProduct.Amount = testAmount;

                CartItem product;

                product = new CartItem()
                {
                    Id = 2,
                    Name = "computer",
                    Description = "technologies goods are sold",
                    Price = (decimal)1000.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow
                };



                context.Cart.Add(testCartProduct);
                context.SaveChanges();
            }
            using (var context = new CartDbContext(options))
            {
                testCartProduct.Amount = testAmount;

                CartRepository cartService = new CartRepository(context);
                Assert.AreEqual(cartService.GetAllCart().Result.Count(), context.Cart.Count());
                Assert.AreNotEqual(cartService.GetAllCart().Result.Count(), -1);
            }
        }

        [TestMethod]
        public void AddProductToCartAsyncTest()
        {
            Guid testGuid = new Guid();
            Cart testCartProduct;
            decimal testAmount = (decimal)10.99;

            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("test_cart_db_3")
                             .Options;
            using (var context = new CartDbContext(options))
            {
                testCartProduct = new Cart();
                testCartProduct.CartGuid = testGuid;
                testCartProduct.Amount = testAmount;

                CartItem product;

                product = new CartItem()
                {
                    Id = 3,
                    Name = "T-Shirt",
                    Description = "sports goods are sold",
                    Price = (decimal)11.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow
                };

                context.Cart.Add(testCartProduct);
                context.SaveChanges();
            }
            using (var context = new CartDbContext(options))
            {
                testCartProduct.Amount = testAmount;

                CartRepository cartService = new CartRepository(context);
                Assert.AreEqual(cartService.AddCart(testCartProduct).Result, testCartProduct);
                Assert.AreEqual(cartService.AddCart(testCartProduct).Result, null);
            }
        }

        [TestMethod]
        public void UpdateProductInCartTest()
        {
            decimal testAmount = (decimal)10.99;
            Guid testGuid = new Guid();
            Cart testCartProduct;

            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("test_cart_db_4")
                             .Options;
            using (var context = new CartDbContext(options))
            {
                testCartProduct = new Cart();
                testCartProduct.CartGuid = testGuid;
                testCartProduct.Amount = testAmount;

                CartItem product;

                product = new CartItem()
                {
                    Id = 4,
                    Name = "suit",
                    Description = "sports goods are sold",
                    Price = (decimal)8.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow
                };

                context.Cart.Add(testCartProduct);
                context.SaveChanges();
            }
            using (var context = new CartDbContext(options))
            {
                testCartProduct.Amount = testAmount;

                CartRepository cartService = new CartRepository(context);
                Assert.AreEqual(cartService.UpdateCart(testCartProduct).Result, 1);
                Assert.AreEqual(cartService.GetCart(testCartProduct.CartGuid).Result.Amount, testAmount);
                Assert.AreNotEqual(cartService.GetCart(testCartProduct.CartGuid).Result.Amount, -1);
            }
        }

        [TestMethod]
        public void RemoveProductFromCart()
        {
            decimal testAmount = (decimal)10.99;
            Guid testGuid = new Guid();
            Cart testCartProduct;

            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("test_cart_db_5")
                             .Options;
            using (var context = new CartDbContext(options))
            {
                testCartProduct = new Cart();
                testCartProduct.CartGuid = testGuid;
                testCartProduct.Amount = testAmount;

                CartItem product;

                product = new CartItem()
                {
                    Id = 5,
                    Name = "ball",
                    Description = "sports goods are sold",
                    Price = (decimal)8.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow
                };

                context.Cart.Add(testCartProduct);
                context.SaveChanges();
            }
            using (var context = new CartDbContext(options))
            {
                testCartProduct.Amount = testAmount;

                CartRepository cartService = new CartRepository(context);
                Assert.AreEqual(cartService.DeleteCart(testCartProduct.CartGuid).Result, 1);

                Assert.AreEqual(cartService.GetAllCart().Result.Count(), 0);
                Assert.AreNotEqual(cartService.GetAllCart().Result.Count(), 1);
            }
        }
    }
}
