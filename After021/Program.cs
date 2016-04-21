using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace After021
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            Action<CancellationToken> longRunning = async (token) =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("{0} {1}", i, stopwatch.Elapsed.TotalMilliseconds); 
                    await Task.Delay(new Random().Next(3, 100));
                    if (token.IsCancellationRequested)
                        break;
                }
            };

            // start with cancel option
            var source = new CancellationTokenSource();
            longRunning.Invoke(source.Token);

            // wait for a second 
            Thread.Sleep(1000);

            // top processing
            source.Cancel();

            Console.Read();
        }
    }
}
