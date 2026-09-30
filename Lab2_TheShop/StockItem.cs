using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lab2_TheShop
{
    public abstract class StockItem : IReportable
    {
        private decimal unitPrice;
        public int nextSeq = 0;

        public string sku { get; private set; }
        public string name { get; private set; }
        public decimal UnitPrice { get { return unitPrice; } }
        public int quantityOnHand { get; private set; }
        public List<StockMovement> history { get; } 


        protected StockItem(string sku, string name, decimal unitPrice, int quantityOnHand)
        {



            this.sku = sku;
            this.name = name;
            this.unitPrice = unitPrice;
            this.quantityOnHand = quantityOnHand;

            if (unitPrice < 0)
            {
                unitPrice = 0;
            }
            if (quantityOnHand < 0)
            {
                quantityOnHand = 0;
            }
            history = new List<StockMovement>();
            nextSeq = nextSeq +1;
        }
        public abstract string Category();
        public abstract decimal HandlingFee();
        public decimal ExtendedValue()
        {
            return (unitPrice + HandlingFee()) * quantityOnHand;
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
            quantityOnHand += count;
            history.Add(new StockMovement(nextSeq++, "Received", count));
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
            return string.Format("{0} {1} ({2})", sku, name, Category());
        }
        public string MovementLines()
        {
            if (history.Count == 0)
            
                return string.Empty;
            
           return string.Join(Environment.NewLine, history.Select(m => m.Describe()));

        }

        string IReportable.ReportLine()
        {
            return string.Format(" {0,-7} {1,-21} {2,-10} {3,4} ${4,11:N2}", sku, name, Category(), quantityOnHand, ExtendedValue());
        }
        public override string ToString()
        {
            return Describe();
        }



    }
}
