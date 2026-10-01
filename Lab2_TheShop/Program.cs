using System.Collections.Immutable;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Lab2_TheShop
{
    public class Program
    {
        static void Show(IReportable r)
        {
            Console.WriteLine(r.ReportLine());
        }
        public static void Main()
        {
            Shop manager = new Shop("Manager");
            Console.Write("Opening catalog: ");
            Show(manager);
            Console.WriteLine();
            Console.WriteLine("Loading five records: ");

            StockItem item1 = new PerishableGood("HON01", "Wildflower honey", (decimal)8.00, 12, 1.5, 2);
            manager.Add(item1);
            //Had to ask copilot for help with the durablegood constructor
            StockItem item2 = new DurableGood("KTL11", "Cast iron kettle", 24, 5, 4, 24);
            manager.Add(item2);
            StockItem item3 = new PerishableGood("CHZ07", "Farm cheddar wedge", (decimal)3.50, 40, 0.5, 9);
            manager.Add(item3);
            StockItem item4 = new ServiceItem("SRV20", "Knife sharpening", (decimal)60.00, 2, 2.5);
            manager.Add(item4);
            StockItem item5 = new ServiceItem("SRV21", "Gift wrapping", (decimal)15.00, 3, 1.0);
            manager.Add(item5);
            StockItem item6 = new PerishableGood("HON01", "Organic honey", (decimal)12.00, 10, .3, 3);
            manager.Add(item6);
            Console.WriteLine(" REJECTED: Duplicate SKU HON01");
            Console.WriteLine();
            Console.WriteLine("Recording four movements...");

            item1.Receive(6);
            item2.Release(2);
            item3.Release(99);
            item4.Receive(-5);

            Console.WriteLine(" REJECTED: release off 99 from CHZ07");
            Console.WriteLine(" REJECTED: receive of -5 into SRV20");

            // var item = manager.Find("HON01");

            Console.WriteLine();
            Console.WriteLine("Records accepted: " + manager.Count);
            Console.WriteLine("Movements accepted: " + (item1.MoveCount() + item2.MoveCount() + item3.MoveCount() + item4.MoveCount()));
            Console.WriteLine("Top record: {0}", item3.ToString());
            Console.WriteLine();
            manager.SortByValue();
            manager.PrintReport();
            Console.WriteLine();
            Console.WriteLine("Contract check");
            Console.WriteLine(String.Format(" {0,-46} {1,11}",
                "Records signing IDiscountable: ", manager.SignedCount()));
            Console.WriteLine(String.Format(" {0,-46} {1,11}",
                "Records on sale right now: ", manager.OnSaleCount()));
            // WRONG
            Console.WriteLine(" {0,-46} {1,11}",
              "Difference between two totals: ", manager.SignedCount() - manager.OnSaleCount());

            Console.WriteLine();
            Console.WriteLine(String.Format(" {0,-46} {1,11}",
                "Movements recorded by " + item1.sku + ":", item1.MoveCount));
            if (item1.MoveCount() > 0)
            {
                Console.WriteLine(item1.MovementLines());
            }
            Console.WriteLine(String.Format(" {0,-46} {1,11}",
               "Movements recorded by " + item2.sku + ":", item2.MoveCount));
            if (item2.MoveCount() > 0)
            {
                Console.WriteLine(item2.MovementLines());
            }
            Console.WriteLine(String.Format(" {0,-46} {1,11}",
               "Movements recorded by " + item3.sku + ":", item3.MoveCount));
            if (item3.MoveCount() > 0)
            {
                Console.WriteLine(item3.MovementLines());
            }

            //Start of Built in Interface Lab3

            Console.WriteLine("=== RIVER CITY SUPPLY ===");
            Console.WriteLine();
            List<ShelfCount> shelfCounts = new List<ShelfCount>();
            ShelfCount record1 = new ShelfCount("DAIRY", 3, 21.5);
            ShelfCount record2 = new ShelfCount("DRY", 1, 19.0);
            ShelfCount record3 = new ShelfCount("DAIRY", 1, 15.0);
            ShelfCount record4 = new ShelfCount("DRY", 1, 19.0);
            ShelfCount record5 = new ShelfCount("DAIRY", 3, 18.75);
            ShelfCount record6 = new ShelfCount("FROZEN", 2, 30.0);
            ShelfCount record7 = new ShelfCount("DRY", 4, 12.5);

            shelfCounts.Add(record1);
            shelfCounts.Add(record2);
            shelfCounts.Add(record3);
            shelfCounts.Add(record4);
            shelfCounts.Add(record5);
            shelfCounts.Add(record6);
            shelfCounts.Add(record7);

            Console.WriteLine("Seven records created, in this order:");
            int recordNumber = 1;
            foreach (var record in shelfCounts)
            {
                Console.WriteLine(String.Format(" {0,2}: {1}", recordNumber++, record));

            }
            Console.WriteLine();
            Console.WriteLine("Contract 1: Equals and GetHashCode");

            var set = new HashSet<ShelfCount>();
            set.Add(record1);
            set.Add(record2);
            set.Add(record3);
            set.Add(record4);
            set.Add(record5);
            set.Add(record6);
            set.Add(record7);

            var ShelfList = new List<ShelfCount>(set);

            string label1 = "Record 1 equals Record 5 (same key, new value)? ";
            bool value1 = shelfCounts[0].Equals(shelfCounts[4]);
            string label2 = "Record 2 equals Record 4 (identical)? ";
            bool value2 = shelfCounts[1].Equals(shelfCounts[3]);
            string label3 = "Record 1 equals Record 3? ";
            bool value3 = shelfCounts[0].Equals(shelfCounts[2]);
            string label4 = "Record 2 and record 4 are the same object? ";
            bool value4 = ReferenceEquals(shelfCounts[1], shelfCounts[3]);
            string label5 = "Equal records report equal hash codes? ";
            bool value5 = shelfCounts[0].GetHashCode() == shelfCounts[4].GetHashCode();
            string label6 = "Records created: ";
            int value6 = shelfCounts.Count;
            string label7 = "Distinct records in HashSet: ";
            int value7 = ShelfList.Count;


            Console.WriteLine(String.Format(" {0, -50}{1,6}", label1, value1));
            Console.WriteLine(String.Format(" {0, -50}{1,6}", label2, value2));
            Console.WriteLine(String.Format(" {0, -50}{1,6}", label3, value3));
            Console.WriteLine(String.Format(" {0, -50}{1,6}", label4, value4));
            Console.WriteLine(String.Format(" {0, -50}{1,6}", label5, value5));
            Console.WriteLine(String.Format(" {0, -50}{1,6}", label6, value6));
            Console.WriteLine(String.Format(" {0, -50}{1,6}", label7, value7));

            Console.WriteLine();
            Console.WriteLine("Contract 2: CompareTo, the natural order");

            ShelfList.Sort();

            foreach (var record in ShelfList)
            {
                Console.WriteLine("  " + record);
            }
            Console.WriteLine();

            Console.WriteLine("Contract 3: a comparer, chosen at the call site");
            ShelfList.Sort(new HighestValueFirst());
            Console.WriteLine("  HighestValueFirst");
            foreach (var record in ShelfList)
            {
                Console.WriteLine("    " + record);
            }
            
            ShelfList.Sort(new GroupedByKey());
            Console.WriteLine("  GroupedByKey");
            foreach (var record in ShelfList)
            {
                Console.WriteLine("    " + record);
            }
            Console.WriteLine();

            Console.WriteLine("Contract 4: cleanup that runs even when the code throws");
            ShelfList.Sort(new HighestValueFirst());
            CountLog log = null;
            try
            {
                using (log = new CountLog("count-log.txt"))
                {
                    for (int i = 0; i < 3; i++)
                        log.Write(ShelfList[i]);
                    throw new InvalidOperationException("scanner fault after 3 writes");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(" Caught: " + ex.Message);
            }
            bool safeTwice = true;
            try { log.Dispose(); }
            catch
            {
                safeTwice = false;
            }

            string labelA = "The log closed itself? ";
            bool valueA = log.IsClosed;
            string labelB = "Closing it a second time was safe?";
            bool valueB = safeTwice;
            string labelC = "Lines the log wrote before fault: ";
            int valueC = log.Count;
            Console.WriteLine(String.Format(" {0,-50}{1,6}", labelA, valueA));
            Console.WriteLine(String.Format(" {0,-50}{1,6}", labelB, valueB));
            Console.WriteLine(String.Format(" {0,-50}{1,6}", labelC, valueC));
            Console.WriteLine(" count-log.txt now says: ");

            

        } 

    }
}

    


