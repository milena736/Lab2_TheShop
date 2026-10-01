using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public class GroupedByKey: IComparer<ShelfCount>
    {
        public int Compare(ShelfCount a, ShelfCount b)
        {
            int byAisle = string.Compare(a.aisle, b.aisle, StringComparison.Ordinal);
            if (byAisle != 0)
            {
                return byAisle;
            }
            byAisle = b.valueOnHand.CompareTo(a.valueOnHand);
            if (byAisle != 0)
            {
                return byAisle;
            }
            return a.slot.CompareTo( b.slot);

        }
    }
}
