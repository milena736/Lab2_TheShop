using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public abstract class PhysicalGood : StockItem
    {

        public const decimal HandlingRate = 0.60m;
        public double weightPounds { get; }
       

        protected PhysicalGood(string sku, string name, decimal unitPrice, int quantityOnHand, double weightPounds) : base(sku, name, unitPrice, quantityOnHand)
        {
            this.weightPounds = weightPounds;
        }
        public decimal ShippingCost()
        {
            return (decimal)weightPounds * HandlingRate;
        }
        public override string Describe()
        {
            return base.Describe() + string.Format(", {0:N1} lbs", weightPounds);
        }

       
    }
}
