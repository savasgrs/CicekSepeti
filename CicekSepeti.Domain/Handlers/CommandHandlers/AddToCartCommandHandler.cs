using CicekSepeti.Core;
using CicekSepeti.Data.Models.RequestModel;
using CicekSepeti.Data.Repository.Abstraction;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepeti.Domain.Handlers.CommandHandlers
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartRequest, Cart>
    {

        private readonly ICartRepository _cartRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;

        public AddToCartCommandHandler(ICartRepository cartRepository, IStockRepository stockRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _stockRepository = stockRepository;
            _productRepository = productRepository;
        }

        public async Task<Cart> Handle(AddToCartRequest command, CancellationToken cancellationToken)
        {
            var products = command.Cart.Products.Where(d => d.Id == command.ProductId).ToList();

            var stockProduct = await _stockRepository.GetStock(command.ProductId);


            //stock control
            if (stockProduct.Quantity == 0)
                return default;

            if (products.Count() == stockProduct.Quantity)
                return default;
            
            
            var responsepProduct = await _productRepository.GetProduct(stockProduct.ProductId);


            var cart = await _cartRepository.GetCart(command.Cart.CartGuid.ToString());

            if (cart == null) // very first time adding the product to cart
            {
                cart = new Cart();
                cart.CartGuid = Guid.NewGuid();

                Product product;

                product = new Product()
                {
                    Id = command.ProductId,
                    Name = responsepProduct.Name,
                    Description = responsepProduct.Description,
                    Price = responsepProduct.Price,
                    IsActive = responsepProduct.IsActive
                };

                cart.Products.Add(product);

                await _cartRepository.AddCart(cart);
            }
            else  // increment the amount of existing product in cart
            {
                foreach (Product productItem in products)
                {
                    cart.Amount += productItem.Price;
                }
                await _cartRepository.AddCart(cart);
            }
            return cart;
        }
    }
}
