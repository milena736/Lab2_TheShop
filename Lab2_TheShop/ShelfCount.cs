using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    internal class ShelfCount : IEquatable<ShelfCount>, IComparable<ShelfCount>
    {

        public string Aisle { get; private set; }
        public int Slot { get; private set; }
        public double ValueOnHand { get; private set; }

        public ShelfCount(string aisle, int slot, double valueOnHand)
        {
            Aisle = aisle;
            Slot = slot;
            ValueOnHand = valueOnHand;
        }
        public bool Equals(ShelfCount other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Aisle == other.Aisle && this.Slot == other.Slot;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as ShelfCount);

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Aisle, Slot);
        }
        public int CompareTo(ShelfCount other)
        {
            if (other == null)
            {
                return 1;
            }
            int aisleComparison = this.Aisle.CompareTo(other.Aisle);
            if (aisleComparison != 0)
            {
                return aisleComparison;
            }
            return this.Slot.CompareTo(other.Slot);
        }
        public override string ToString()
        {
            return String.Format("{0,-6} #{1} {2,8:N2}", Aisle, Slot, ValueOnHand);
        }

    }
}
