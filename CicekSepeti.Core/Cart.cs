using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CicekSepeti.Core
{
    public class Cart
    {
        public Cart()
        {
            Products = new List<Product>();
        }
        [Key]
        public Guid CartGuid { get; set; }
        public List<Product> Products { get; set; }
        public decimal Amount { get; set; }
    }
}
