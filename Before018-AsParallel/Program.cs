namespace Before018_AsParallel
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

            float total = 0;
            for (int i = 0; i < 10000; i++)
            {
                total += numbers.Sum();
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            //implement as parallel
        }
    }
}