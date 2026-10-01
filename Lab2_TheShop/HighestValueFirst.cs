using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public class HighestValueFirst : IComparer<ShelfCount>
    {
        public int Compare(ShelfCount a, ShelfCount b)
        {
            if (b == null)
            {
                return -1;
            }
            if (a == null)
            {
                return 1;
            }
            if (a == null && b == null)
            {
                return 0;
            }
            if (a.valueOnHand != b.valueOnHand)
            {
                return b.valueOnHand.CompareTo(a.valueOnHand);
            }
            return a.CompareTo(b);

        }
    }
}
