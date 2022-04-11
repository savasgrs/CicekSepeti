

using CicekSepeti.Core;
using MediatR;
using System.Collections.Generic;

namespace CicekSepeti.Data.Queries.Request
{
    public class GetAllCartQuery : IRequest<List<Cart>>
    {

    }
}
