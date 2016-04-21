namespace Before020_Mutex
{
    using System;
    using System.Threading;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // I only want one instance of this app to run on this machine!
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            while(true)
            {
                Console.WriteLine("There can be only one!");
                Thread.Sleep(500);
            }
        }
    }
}