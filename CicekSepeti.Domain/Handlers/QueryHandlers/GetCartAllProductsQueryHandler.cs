
using CicekSepeti.Core;
using CicekSepeti.Data.Models.ResponseModel;
using CicekSepeti.Data.Repository.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CicekSepeti.Data.Queries.Request;

namespace CicekSepeti.Domain.Handlers.QueryHandlers
{
    public class GetCartAllProductsQueryHandler : IRequestHandler<GetAllCartQuery, List<Cart>>
    {
        private readonly ICartRepository _cartRepository;
        public GetCartAllProductsQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<List<Cart>> Handle(GetAllCartQuery request, CancellationToken cancellationToken)
        {
            return await _cartRepository.GetAllCart();
        }
    }

}
