using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public class StockMovement
    {
       
        public int seq { get; }
        public string kind { get; }
        public int count { get; } = 0;

        public StockMovement(int seq, string kind, int count)
        {
            seq = seq ++;
            this.kind = kind;
            this.count = count;
        }
        public string Describe()
        {
            return string.Format("    move {0}: {1} {2}", seq, kind, count);
        }
    }
}
