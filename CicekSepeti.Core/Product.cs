using CicekSepetiCaseStudy.Core.Models.Product;
using System;

namespace CicekSepeti.Core
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public int IsStock { get; set; }
    }
}
