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

            StockItem item1 = new PerishableGood("HON01", "Wildflower honey", (decimal)8.00, 12, 2);
            manager.Add(item1);
            //Had to ask copilot for help with the durablegood constructor
            StockItem item2 = new DurableGood("KTL11", "Cast iron kettle", (decimal)24.00, 5, 24);
            manager.Add(item2);
            StockItem item3 = new PerishableGood("CHZ07", "Farm cheddar wedge", (decimal)3.50, 40, 9);
            manager.Add(item3);
            StockItem item4 = new ServiceItem("SRV20", "Knife sharpening", (decimal)60.00, 2, 2.5);
            manager.Add(item4);
            StockItem item5 = new ServiceItem("SRV21", "Gift wrapping", (decimal)15.00, 3, 1.0);
            manager.Add(item5);
            StockItem item6 = new PerishableGood("HON01", "Organic honey", (decimal)12.00, 10, 3);
            manager.Add(item6);
            Console.WriteLine(" REJECTED: Duplicate SKU HON01");
            Console.WriteLine();
            Console.WriteLine("Recording four movements...");

            manager.Find("HON01");

            StockItem kettle = manager.Find("KTL11");
            if(kettle != null && !kettle.Release(99))
            {
                Console.WriteLine(" REJECTED: release of 99 KTL11");
            }
            StockItem cheese = manager.Find("CHZ07");
            if(cheese != null && !cheese.Receive(-5))
            {
                Console.WriteLine(" REJECTED: receive of -5 CHZ07");
            }
            Console.WriteLine("Records accepted:" + manager.Count);
           // Console.WriteLine("Movements accepted:" + StockMovement.Count);



        }

    }
}

    


