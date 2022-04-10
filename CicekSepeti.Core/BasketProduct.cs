using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CicekSepeti.Core
{
    public class BasketProduct
    {
        [Key]
        public Guid BasketGuid { get; set; }
        public Product Product { get; set; }
    }
}
