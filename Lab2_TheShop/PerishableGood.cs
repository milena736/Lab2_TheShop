using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public class PerishableGood : PhysicalGood, IDiscountable
    {
        private int shelfLifeDays;
        public int ShelfLifeDays { get { return shelfLifeDays; } }
        public const decimal SurchargeFee = 0.40m;


        public PerishableGood(string sku, string name, decimal unitPrice, int quantityOnHand, int shelfLifeDays)
            : base(sku, name, unitPrice, quantityOnHand)
        {
            this.shelfLifeDays = shelfLifeDays;
        }
        public override string Category()
        {
            return "Perishable Good";
        }
        public override decimal HandlingFee()
        {
            return ShippingCost() + SurchargeFee;
        }
        public bool IsOnSale
        {
            get
            {
                return shelfLifeDays <= 3;
            }
        }
        public decimal SalePrice()
        {
            if (IsOnSale)
            {
                return UnitPrice * 0.7m; 
            }
            else
            {
                return UnitPrice;
            }
        }
        public override string Describe()
        {
            return base.Describe() + string.Format(", {0} days left", shelfLifeDays);
        }
    }

}
