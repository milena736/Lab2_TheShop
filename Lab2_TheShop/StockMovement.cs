using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public class StockMovement
    {
        private int seq;
        private string kind;
        private int count;
        public int Seq { get; }
        public string Kind { get; }
        public int Count { get; } = 0;

        public StockMovement(int seq, string kind, int count)
        {
            this.seq = Seq;
            this.kind = Kind;
            this.count = Count;
        }
        public string Describe()
        {
            return string.Format("    move {0}: {1} {2}", Seq, Kind, Count);
        }
    }
}
