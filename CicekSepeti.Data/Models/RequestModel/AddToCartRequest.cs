using CicekSepeti.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Data.Models.RequestModel
{
    public class AddToCartRequest : IRequest<Cart>
    {
        public int ProductId { get; set; }
        public Guid CartGuid { get; set; }
    }
}
