namespace After020
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Program
    {
        private static readonly Queue<int> _workUnits = new Queue<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

        private static void Main(string[] args)
        {
            var worker1 = new Worker(_workUnits, "Worker 1", 300);
            var worker2 = new Worker(_workUnits, "Worker 2", 100);
            Parallel.Invoke(worker1.DoWork, worker2.DoWork);
        }
    }

    internal class Worker
    {
        private static readonly object _syncObject = new object();

        private readonly string _name;

        private readonly Queue<int> _queue;

        private readonly int _wait;

        public Worker(Queue<int> queue, string name, int wait)
        {
            _queue = queue;
            _name = name;
            _wait = wait;
        }

        internal void DoWork()
        {
            while (_queue.Count > 0)
            {
                lock (_syncObject)
                {
                    if (_queue.Count > 0)
                    {
                        Console.WriteLine("{0}: Count remaining - {1}", _name, _queue.Count);
                        Thread.Sleep(_wait);
                        _queue.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Phew! Dodged a bullet there!");
                    }
                }
            }

            Console.WriteLine("{0} finished", _name);
        }
    }
}