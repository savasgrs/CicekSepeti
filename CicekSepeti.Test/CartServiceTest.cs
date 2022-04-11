using CicekSepeti.Core;
using CicekSepeti.Data.Repository;
using CicekSepeti.Core.Models;
using CicekSepeti.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CicekSepeti.Test
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
                             .UseInMemoryDatabase("testCartDb")
                             .Options;

            using (var context = new CartDbContext(options))
            {
                testCartProduct = new Cart();
                testCartProduct.CartGuid = testGuid;
                testCartProduct.Amount = testAmount;

                CartItem product = new CartItem()
                {
                    Id = 1,
                    Name = "ball",
                    Description = "sports goods are sold",
                    Price = (decimal)10.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,

                };

                testCartProduct.Quantity = 1;
                testCartProduct.CartItemId = product.Id;

                context.Cart.Add(testCartProduct);
                context.SaveChanges();
            }
            using (var context = new CartDbContext(options))
            {
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
                             .UseInMemoryDatabase("testCartDb2")
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
                    Price = (decimal)421.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow
                };

                testCartProduct.Quantity = 1;
                context.Cart.Add(testCartProduct);
                context.SaveChanges();
            }

            using (var context = new CartDbContext(options))
            {
                CartRepository cartService = new CartRepository(context);
                Assert.AreEqual(cartService.GetAllCart().Result.Count(), context.Cart.Count());
                Assert.AreNotEqual(cartService.GetAllCart().Result.Count(), -1);
            }
        }

        [TestMethod]
        public void AddToCartCommandHandlerTest()
        {
            Guid testGuid = new Guid();
            Cart testCartProduct;
            decimal testAmount = (decimal)11.99;

            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("testCartDb3")
                             .Options;
            using (var context = new CartDbContext(options))
            {
                testCartProduct = new Cart();
                testCartProduct.CartGuid = testGuid;
                testCartProduct.Amount = testAmount;

                CartItem product = new CartItem()
                {
                    Id = 3,
                    Name = "T-Shirt",
                    Description = "sports goods are sold",
                    Price = (decimal)11.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,

                };

                testCartProduct.Quantity = 1;
                testCartProduct.CartItemId = product.Id;

                context.Cart.Add(testCartProduct);
                context.SaveChanges();
            }

            using (var context = new CartDbContext(options))
            {
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
                             .UseInMemoryDatabase("testCartDb4")
                             .Options;
            using (var context = new CartDbContext(options))
            {
                testCartProduct = new Cart();
                testCartProduct.CartGuid = testGuid;
                testCartProduct.Amount = testAmount;


                CartItem product = new CartItem()
                {
                    Id = 4,
                    Name = "suit",
                    Description = "sports goods are sold",
                    Price = (decimal)19.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow
                };

                testCartProduct.Quantity = 1;
                testCartProduct.CartItemId = product.Id;

                context.Cart.Add(testCartProduct);
                context.SaveChanges();
            }

            using (var context = new CartDbContext(options))
            {
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
                             .UseInMemoryDatabase("testCartDb5")
                             .Options;
            using (var context = new CartDbContext(options))
            {
                testCartProduct = new Cart();
                testCartProduct.CartGuid = testGuid;
                testCartProduct.Amount = testAmount;


                CartItem product = new CartItem()
                {
                    Id = 5,
                    Name = "ball",
                    Description = "sports goods are sold",
                    Price = (decimal)8.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow
                };

                testCartProduct.Amount = (decimal)8.99;
                testCartProduct.Quantity = 1;
                testCartProduct.CartItemId = product.Id;

                context.Cart.Add(testCartProduct);
                context.SaveChanges();
            }

            using (var context = new CartDbContext(options))
            {
                CartRepository cartService = new CartRepository(context);
                Assert.AreEqual(cartService.DeleteCart(testCartProduct.CartGuid).Result, 1);
                Assert.AreEqual(cartService.GetAllCart().Result.Count(), 0);
                Assert.AreNotEqual(cartService.GetAllCart().Result.Count(), 1);
            }
        }
    }
}
