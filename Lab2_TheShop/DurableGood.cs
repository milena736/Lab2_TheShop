using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public class DurableGood : PhysicalGood
    {
        private int warrantyMonths;
        public int WarrantyMonths { get { return warrantyMonths; } private set { warrantyMonths = value; }  }
        public DurableGood(string sku, string name, decimal unitPrice, int quantityOnHand, double weightPounds, int warrantyMonths)
            : base(sku, name, unitPrice, quantityOnHand, weightPounds)
        { 
            this.warrantyMonths = warrantyMonths;
        }

        public override string Category()
        {
            return "Durable";
        }
        public override decimal HandlingFee()
        {
            return ShippingCost();
        }
        public override string Describe()
        {
            return base.Describe() + string.Format(", {0} month warranty", WarrantyMonths);
        }
    }
}


