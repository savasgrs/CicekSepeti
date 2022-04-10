using CicekSepetiCaseStudy.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Core
{
    public class Stock : BaseEntity
    {
        public int ProductId { get; set; }

        public long Quantity { get; set; }
    }
}
