using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    internal class ShelfCount : IEquatable<ShelfCount>, IComparable<ShelfCount>
    {

        public string aisle { get; set; }
        public int slot { get; set; }
        public double valueOnHand { get; set; }

        public ShelfCount(string aisle, int slot, double valueOnHand)
        {
            this.aisle = aisle;
            this.slot = slot;
            this.valueOnHand = valueOnHand;
        }
        public bool Equals(ShelfCount other)
        {
            if (other == null)
            {
                return false;
            }
            return this.aisle == other.aisle && this.slot == other.slot;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as ShelfCount);

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(aisle, slot);
        }
        public int CompareTo(ShelfCount other)
        {
            if (other == null)
            {
                return 1;
            }
            int aisleComparison = this.aisle.CompareTo(other.aisle);
            if (aisleComparison != 0)
            {
                return aisleComparison;
            }
            return this.slot.CompareTo(other.slot);
        }
        public override string ToString()
        {
            return String.Format("{0,-6} #{1} {2,8:N2}", aisle, slot, valueOnHand);
        }

    }
}
