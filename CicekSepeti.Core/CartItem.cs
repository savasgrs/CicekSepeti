using CicekSepetiCaseStudy.Core.Models.Product;
using System;

namespace CicekSepeti.Core
{
    public class CartItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
