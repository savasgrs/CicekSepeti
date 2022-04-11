using CicekSepeti.Core;
using CicekSepeti.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Data.Context
{
    public class MockDatas
    {
        /// <summary>
        /// Example CartData DB add
        /// </summary>
        public void CartData()
        {
            var options = new DbContextOptionsBuilder<CartDbContext>()
                             .UseInMemoryDatabase("cartDB")
                             .Options;

            using (var context = new CartDbContext(options))
            {
                //New Cart 
                Cart cart;
                CartItem product;

                cart = new Cart();
                cart.CartGuid = new Guid();
                
                product = new CartItem()
                {
                    Id = 1,
                    Name = "ball",
                    Description = "sports goods are sold",
                    Price = (decimal)10.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };
                cart.Quantity++;
                cart.Amount = (decimal)10.99;

                cart.CartItems.Add(product);

                context.Cart.Add(cart);


                //New Cart 
                cart = new Cart();
                cart.CartGuid = new Guid();
                
                product = new CartItem()
                {
                    Id = 2,
                    Name = "Tennis Racket",
                    Description = "sports goods are sold",
                    Price = (decimal)20.99,
                    CreateByUser = "2",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };
                cart.Quantity++;
                cart.Amount = (decimal)20.99;

                cart.CartItems.Add(product);

                context.Cart.Add(cart);


                //New Cart 
                cart = new Cart();
                cart.CartGuid = new Guid();
                product = new CartItem()
                {
                    Id = 3,
                    Name = "T-Shirt black",
                    Description = "T-Shirt",
                    Price = (decimal)13,
                    CreateByUser = "3",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };
                cart.Quantity++;

                //New Cart 
                cart.CartGuid = new Guid();
                product = new CartItem()
                {
                    Id = 3,
                    Name = "T-Shirt re",
                    Description = "T-Shirt",
                    Price = (decimal)17,
                    CreateByUser = "3",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };
                cart.Quantity++;
                cart.Amount = (decimal)30;

                cart.CartItems.Add(product);


                context.Cart.Add(cart);

                //New Carts DB add 
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Example Product DB add
        /// </summary>
        public void ProductData()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                             .UseInMemoryDatabase("productDB")
                             .Options;

            using (var context = new ProductDbContext(options))
            {
                CartItem product;

                product = new CartItem()
                {
                    Id = 1,
                    Name = "ball",
                    Description = "sports goods are sold",
                    Price = (decimal)10.99,
                    CreateByUser = "1",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };

                context.Products.Add(product);


                product = new CartItem()
                {
                    Id = 2,
                    Name = "Tennis Racket",
                    Description = "sports goods are sold",
                    Price = (decimal)20.99,
                    CreateByUser = "2",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };

                context.Products.Add(product);


                product = new CartItem()
                {
                    Id = 3,
                    Name = "T-Shirt",
                    Description = "black T-Shirt",
                    Price = (decimal)14.99,
                    CreateByUser = "3",// will be user id or uniq username
                    CreateDateTime = DateTime.UtcNow,
                };

                context.Products.Add(product);

                context.SaveChanges();               
            }
        }
    }
}
