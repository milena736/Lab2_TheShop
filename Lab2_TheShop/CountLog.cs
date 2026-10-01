using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_TheShop
{
    public class CountLog : IDisposable
    {
        private StreamWriter writer;
        private string path;
        private int count;
        private bool isClosed;

        public string Path { get { return path; } }
        public int Count { get { return count; } }
        public bool IsClosed { get { return isClosed; } }

        public CountLog(string path)
        {
            writer = new StreamWriter(path);

            writer.WriteLine("LOG OPENED");
            count = 0;
            isClosed = false;
        }
        
        public void Write(ShelfCount r)
        {
            count = count + 1;
            Console.WriteLine("{0,3} {1}", count, r);

        }

        public void Dispose()
        {
            if (isClosed = true)
            {
                return;
            }
            try
            {
                if (writer != null)
                {
                    Console.WriteLine(String.Format("LOG CLOSED, {0} lines written", count));

                }
            }
            catch
            {

            }
            finally
            {
                writer = null;
                isClosed = true;
            }

        }
    }
}