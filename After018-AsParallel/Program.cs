namespace After018_AsParallel
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 10).ToArray();

            foreach (var item in numbers)
                Console.WriteLine(item);

            Console.WriteLine("NEXT");

            foreach (var item in numbers.AsParallel())
                Console.WriteLine(item);

            Console.WriteLine("NEXT");

            var random = new Random();
            foreach (var item in numbers.AsParallel())
            {
                Task.Factory.StartNew(() =>
                {
                    Task.Delay(random.Next(1, 100));
                    Console.WriteLine(item);
                });
            }

            Console.Read();

            return;

            var stopwatch = Stopwatch.StartNew();

            float total2 = 0;
            for (int i = 0; i < 10000; i++)
            {
                total2 += numbers.AsParallel().Sum();
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(total2);

            Console.Read();

            stopwatch = Stopwatch.StartNew();

            float total = 0;
            for (int i = 0; i < 10000; i++)
            {
                total += numbers.Sum();
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(total);
        }
    }
}