namespace Before018
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, short.MaxValue).ToArray();

            var stopwatch = Stopwatch.StartNew();

            var total = 0;
            for (int i = 0; i < 10000; i++)
            {
                total += numbers.Sum();
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(total);

            stopwatch = Stopwatch.StartNew();
            var total2 = 0;
            for (int i = 0; i < 10000; i++)
            {
                total2 += numbers.AsParallel().Sum();
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(total2);
        }
    }
}