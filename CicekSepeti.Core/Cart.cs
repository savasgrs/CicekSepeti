using CicekSepeti.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CicekSepeti.Core
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            CartItems = new List<CartItem>()
        }
        [Key]
        public Guid CartGuid { get; set; }
        public List<CartItem> CartItems { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
