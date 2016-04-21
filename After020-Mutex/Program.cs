namespace After020_Mutex
{
    using System;
    using System.Threading;

    internal class Program
    {
        private static readonly string _appId = "BBA4993A-B60F-4740-B2E9-6F1144E1DF90";

        private static void Main(string[] args)
        {
            // The "Global\" prefix enforces only one instance of the app on terminal services too!
            using (var mutex = new Mutex(false, @"Global\" + _appId))
            {
                if (!mutex.WaitOne(0, false))
                {
                    Console.WriteLine("There already is one! Goodbye!");
                    return;
                }

                // I only want one instance of this app to run on this machine!
                var program = new Program();
                program.Run();
            }
        }

        private void Run()
        {
            while (true)
            {
                Console.WriteLine("There can be only one!");
                Thread.Sleep(500);
            }
        }
    }
}