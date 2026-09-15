using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public abstract class PhysicalGood : StockItem
    {
        private double weightPounds;

        public const decimal HandlingRate = 0.60m;
        public double WeightPounds { get; }
       

        protected PhysicalGood(string sku, string name, decimal unitPrice, int quantityOnHand) : base(sku, name, unitPrice, quantityOnHand)
        {
            WeightPounds = weightPounds >=0 ? weightPounds : 0;
        }
        public decimal ShippingCost()
        {
            return (decimal)WeightPounds * HandlingRate;
        }
        public override string Describe()
        {
            return base.Describe() + string.Format(", {0:N1} lbs", WeightPounds);
        }

       
    }
}
