using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicekSepeti.Api.Const
{
    public static class CartException
    {
        public static readonly string GetAllProductList = "Failed to get Product List  ";
        public static readonly string GetProductList = "Failed to get Product ";
        public static readonly string Delete = "Failed to Delete ";
        public static readonly string CheckStockAmount = "Stock Error ";
    }
}
