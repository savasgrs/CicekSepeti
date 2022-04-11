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
        private readonly IProductRepository _productRepository;

        public AddToCartCommandHandler(ICartRepository cartRepository,IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<Cart> Handle(AddToCartRequest command, CancellationToken cancellationToken)
        {
            //get CartItems
            var cart = await _cartRepository.GetCart(command.CartGuid);
            CartItem product;


            if (cart != null)
            {
                //if exist product
                product = cart.CartItems.Where(d => d.Id == command.ProductId).FirstOrDefault();
                product.Quantity++;
            }
            else// very first time adding the product to cart
            {
                //new CartItem add
                cart = new Cart();
                cart.CartGuid = Guid.NewGuid();

                product = await _productRepository.GetProduct(command.ProductId);
                                
                cart.CartItems.Add(product);

                await _cartRepository.AddCart(cart);
            }


            foreach (CartItem productItem in cart.CartItems)
            {
                cart.Amount += productItem.Price;
            }
            await _cartRepository.AddCart(cart);

            return cart;
        }
    }
}
