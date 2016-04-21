namespace Before020_Semaphore
{
    using System;
    using System.Threading;

    internal partial class Program
    {
        private static void Main(string[] args)
        {
            // Runs with 2 threads, fails with 3
            for (int i = 0; i < 2; i++)
            {
                new Thread(ResourceHungryService).Start(i);
            }
        }

        private static void ResourceHungryService(object id)
        {
            WriteGreenLine("Thread {0} eating memory...", id);
            const int number = 20000000;
            var pool = new MemoryHog[number];
            for (int i = 0; i < number; i++)
            {
                pool[i] = new MemoryHog();
                if (i % 10000000 == 0)
                {
                    WriteWhiteLine("Thread {0} nom nom nom", id);
                }
            }
            WriteRedLine("Thread {0} is satiated", id);
        }
    }

    internal class MemoryHog
    {
        private static readonly Random seed = new Random();

        public Int32 Buffer1;

        public Int32 Buffer2;

        public Int64 Buffer3;

        public MemoryHog()
        {
            Buffer1 = (Int32)seed.NextDouble();
            Buffer2 = (Int32)seed.NextDouble();
            Buffer3 = (Int64)seed.NextDouble();
        }
    }
}