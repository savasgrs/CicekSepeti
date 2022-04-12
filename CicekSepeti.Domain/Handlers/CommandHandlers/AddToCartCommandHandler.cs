using CicekSepeti.Core;
using CicekSepeti.Data.Models.RequestModel;
using CicekSepeti.Data.Repository.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepeti.Domain.Handlers.CommandHandlers
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartRequest, Cart>
    {

        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;

        public AddToCartCommandHandler(ICartRepository cartRepository,IProductRepository productRepository, IStockRepository stockRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _stockRepository = stockRepository;
        }

        public async Task<Cart> Handle(AddToCartRequest command, CancellationToken cancellationToken)
        {
            //get CartItems
            var cart = await _cartRepository.GetCart(command.CartGuid);

            CartItem product = await _productRepository.GetProduct(command.ProductId);

            //Stock kontrol
            Stock stock = await _stockRepository.GetStockbyProductId(product.Id);

            if (stock.StockQuantity == 0)
            {
                throw new ArgumentException("No exist stock", nameof(AddToCartCommandHandler));
            }

            if (cart != null)
            {
                //if exist product
                if (cart.CartItemId == command.ProductId)
                {
                    cart.Quantity++;
                }
            }
            else// very first time adding the product to cart
            {
                //new CartItem add
                cart = new Cart();
                cart.CartGuid = Guid.NewGuid();                                
                cart.CartItemId = product.Id;

                await _cartRepository.AddCart(cart);
            }

            cart.Amount += product.Price;
                       
            await _cartRepository.AddCart(cart);

            stock.StockQuantity--;

            await _stockRepository.UpdateStock(stock);
            return cart;
        }
    }
}
