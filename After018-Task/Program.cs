namespace After018_Task
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Program
    {
        private static void DoLongRunningWork()
        {
            Console.WriteLine("Some long running work");
            Thread.Sleep(5000);
            Console.WriteLine("Finished long running work");
        }

        private static void DoMoreWork()
        {
            Console.WriteLine("More work");
            Thread.Sleep(2000);
            Console.WriteLine("Finished more work");
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Starting to do work");

            Parallel.Invoke(DoLongRunningWork, DoMoreWork);

            Console.WriteLine("Finished all work");
        }
    }
}