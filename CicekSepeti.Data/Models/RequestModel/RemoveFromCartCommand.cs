using CicekSepeti.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Data.Models.RequestModel
{
    public class RemoveFromCartCommand : IRequest<int>
    {
        public Guid CartGuid { get; set; }
        public int ProductId { get; set; }
        
    }
}
