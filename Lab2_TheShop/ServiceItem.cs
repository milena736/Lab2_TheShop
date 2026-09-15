using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public class ServiceItem : StockItem, IDiscountable
    {
        private double laborHours;

        public double LaborHours { get; }

        public ServiceItem(string sku, string name, decimal unitPrice, int quantityOnHand, double laborHours)
            : base(sku, name, unitPrice, quantityOnHand)
        {
            this.laborHours = LaborHours;
        }

        public override string Category()
        {
            return "Service";
        }

        public override decimal HandlingFee()
        {
            return 0m;
        }
        public bool IsOnSale
        {
            get
            {
                return laborHours >= 2;
            }
        }
        public decimal SalePrice()
        {
            if (IsOnSale)
            {
                return UnitPrice * 0.85m;
            }
            else
            {
                return UnitPrice;
            }
        }
        public override string Describe()
        {
            return base.Describe() + string.Format(", {0:N1} labor hours", LaborHours);
        }
    }
}
