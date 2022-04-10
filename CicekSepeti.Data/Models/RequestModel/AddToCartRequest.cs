using CicekSepeti.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Data.Models.RequestModel
{
    public class AddToCartRequest
    {
        public int ProductId { get; set; }
        public Cart Cart { get; set; }
    }
}
