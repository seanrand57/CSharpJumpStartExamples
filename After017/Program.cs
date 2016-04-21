using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace After017
{
    class Program
    {
        static void Main(string[] args)
        {
            int ports; int max;
            ThreadPool.GetMaxThreads(out max, out ports);
            Console.WriteLine("Max:" + max.ToString());
            ThreadPool.SetMaxThreads(100, 1);

            // one
            ThreadPool.QueueUserWorkItem(CallBack, "One");

            // two
            ThreadPool.QueueUserWorkItem(CallBack, "One");
            ThreadPool.QueueUserWorkItem(CallBack, "Two");

            Console.ReadLine();

            // overload!
            var callbacks = Enumerable.Range(1, 10).Select(x => new Action(() => { ThreadPool.QueueUserWorkItem(CallBack, x); }));
            Parallel.Invoke(callbacks.ToArray());

            Console.Read();
        }

        private static void CallBack(object state)
        {
            Thread.Sleep(new Random().Next(3, 100));
            Console.WriteLine("{0}\r\n", state);
        }
    }
}
