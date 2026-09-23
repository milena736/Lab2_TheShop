using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public class DurableGood : PhysicalGood
    {
        private int warrantymonths;
        public int WarrantyMonths { get { return WarrantyMonths; } private set { WarrantyMonths = value; } }

        // Public constructor matching the usage in Program.cs (sku, name, unitPrice, quantityOnHand, warrantyMonths)
        public DurableGood(string sku, string name, decimal unitPrice, int quantityOnHand, int warrantyMonths)
            : base(sku, name, unitPrice, quantityOnHand)
        {
            this.warrantymonths = warrantyMonths;
            this.WarrantyMonths = warrantyMonths;
        }

        // Existing protected constructor (kept for compatibility) corrected
        protected DurableGood(string sku, string name, decimal unitPrice, int quantityOnHand, double weightPounds, int warrantyMonths)
            : base(sku, name, unitPrice, quantityOnHand)
        {
            this.warrantymonths = warrantyMonths;
            this.WarrantyMonths = warrantyMonths;
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
            return base.Describe() + string.Format(", {0} month warranty", warrantymonths);
        }
    }
}


