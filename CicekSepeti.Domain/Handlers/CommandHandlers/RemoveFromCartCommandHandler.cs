using CicekSepeti.Data.Models.RequestModel;
using CicekSepeti.Data.Repository.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepeti.Domain.Handlers.CommandHandlers
{
    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand, int>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public RemoveFromCartCommandHandler(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<int> Handle(RemoveFromCartCommand command, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCart(command.CartGuid);

            var product = await _productRepository.GetProduct(command.ProductId);

            cart.CartItems.Remove(product);

            return await _cartRepository.SaveChangesAsync();

        }
    }
}
