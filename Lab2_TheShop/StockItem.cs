using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public abstract class StockItem : IReportable
    {
        private string sku;
        private string name;
        private decimal unitPrice;
        private int quantityOnHand;
        private List<StockMovement> history;
        private int nextSeq;

        public string Sku { get; }
        public string Name { get; }
        public decimal UnitPrice { get; }
        public int QuantityOnHand { get; set; }
        internal List<StockMovement> History { get; } = new List<StockMovement>();


        protected StockItem(string sku, string name, decimal unitPrice, int quantityOnHand)
        {



            this.sku = Sku;
            this.name = Name;
            this.unitPrice = UnitPrice;
            this.quantityOnHand = QuantityOnHand;

            if (unitPrice < 0)
            {
                unitPrice = 0;
            }
            if (quantityOnHand < 0)
            {
                quantityOnHand = 0;
            }
            this.history =History ?? new List<StockMovement>();
            this.nextSeq = nextSeq++;
        }
        public abstract string Category();
        public abstract decimal HandlingFee();
        public decimal ExtendedValue()
        {
            return (UnitPrice + HandlingFee()) * QuantityOnHand;
        }
        public int MoveCount()
        {
            return history.Count;
        }
        public bool Receive(int count)
        {
            if (count <= 0)
            {
                return false;
            }
            QuantityOnHand += count;
            History.Add(new StockMovement(nextSeq++, "Received", count));
                    return true;
        }
        public bool Release(int count)
        {
            if (count <= 0 || count > quantityOnHand)
            {
                return false;
            }
            quantityOnHand -= count;
            history.Add(new StockMovement(nextSeq++, "Released", count));
            return true;
        }
        public virtual string Describe()
        {
            return string.Format("{0} {1} ({2})", Sku, Name, Category());
        }
        public string MovementLines()
        {
            if (history.Count == 0)
            
                return string.Empty;
            
           return string.Join(Environment.NewLine, history.Select(m => m.Describe()));

        }

        public string ReportLine()
        {
            return string.Format(" {0,-7} {1,-21} {2,-10} {3,4} ${4,11:N2}");
        }
        public override string ToString()
        {
            return Describe();
        }



    }
}
