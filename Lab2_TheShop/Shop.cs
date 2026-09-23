using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab2_TheShop
{
    public class Shop : IReportable
    {
        private List<StockItem> items;

        public string Name { get; private set; }
        public int Count { get { return items?.Count ?? 0; } }

        public Shop(string name)
        {
            this.Name = name;
            this.items = new List<StockItem>();
        }
        public StockItem Find(string sku)
        {
            return items.Find(x => x.Sku == sku);
            if (sku == null)
            {
                return null;
            }
        }
        public bool Add(StockItem item)
        {
            if (item == null)
            {
                return false;
            }
            if (items.Find(x => x.Sku == item.Sku) != null)
            {
                return false;
            }
            items.Add(item);
            return true;
        }
        public decimal TotalValue()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.ExtendedValue();
            }
            return total;
        }
        public decimal SaleVaule()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                if (item is IDiscountable discountableItem && discountableItem.IsOnSale)
                {
                    total += (discountableItem.SalePrice() + item.HandlingFee()) * item.QuantityOnHand;
                }
                else
                {
                    total += item.ExtendedValue();
                }
            }
            return total;
        }
        public int SignedCount()
        {
            int count = items.Count(item => item is IDiscountable);
            return count;
        }

        public int OnSaleCount() 
        {
            int count = items.Count(item => item is IDiscountable discountableItem && discountableItem.IsOnSale);
            return count;
        }
        public void SortBuValue()
        {
            for (int i = 0; i < items.Count - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < items.Count; j++)
                {
                    if (max != i)
                    {
                        StockItem temp = items[i];
                        items[i] = items[max];
                        items[max] = temp;
                    }
                }
            }
        }
        private static bool Beats(StockItem a, StockItem b)
        {
            if  (a.ExtendedValue() != b.ExtendedValue());
                 return a.ExtendedValue() > b.ExtendedValue();
            return string.Compare(a.Name, b.Name, StringComparison.Ordinal) < 0;
        }
        string IReportable.ReportLine()
        {
            return String.Format("{0}: {1} items, ${2:N2} on hand", Name, Count, TotalValue());
        }
        public void PrintReport()
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("  RIVER CITY SUPPLY : REPORT");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" {0,-7} {1,-21} {2,-10} {3,4} {4,11}", "SKU, ITEM,CATEGORY, QTY, VALUE");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(((IReportable)this).ReportLine());
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(" {0,-46} {1,11}","Records on file: " + Count);
            Console.WriteLine(" {0,-46}${1,11:N2}","Total value on hand: " + TotalValue());
            Console.WriteLine(" {0,-46}${1,11:N2}","Value if every sale price were taken: " + SaleVaule());
            Console.WriteLine(new string('=', 60));
        }
    }
}
