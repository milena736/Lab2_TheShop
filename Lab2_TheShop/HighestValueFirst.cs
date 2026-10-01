using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public class HighestValueFirst : IComparer<ShelfCount>
    {
        public int Compare(ShelfCount a, ShelfCount b)
        {
           
            double valueA = a.valueOnHand;
            double valueB = b.valueOnHand;
            if (valueA > valueB)
            {
                return -1;
            }
            else if (valueA < valueB)
            {
                return 1;
            }
            if (valueA == valueB)
            {
                return valueA.CompareTo(valueB);
            }
           
        }
    }
}
