using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    internal interface IDiscountable
    {
        bool IsOnSale { get; }
        decimal SalePrice();
    }
}
