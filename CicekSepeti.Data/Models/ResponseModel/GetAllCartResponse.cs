using CicekSepeti.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Data.Models.ResponseModel
{
    public class GetAllCartResponse : IRequest<IEnumerable<Cart>>
    {
    }
}
