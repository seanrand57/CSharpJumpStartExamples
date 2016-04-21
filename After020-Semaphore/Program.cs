namespace After020_Semaphore
{
    using System;
    using System.Threading;

    internal partial class Program
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(5);
        private static readonly Random _random = new Random();

        private static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                new Thread(DoorManService).Start(i);
            }

            Console.ReadLine();
        }

        private static void DoorManService(object id)
        {
            WriteYellowLine("Partier {0} wants to enter the night club...", id);
            _semaphore.Wait();
            WriteGreenLine("The doorman has let partier {0} enter the night club...", id);
            for (int i = 0; i < _random.Next(2, 5); i++)
            {
                WriteWhiteLine("Partier {0} is dancing...", id);
                Thread.Sleep(100);
            }
            WriteRedLine("Partier {0} has left the club", id);
            _semaphore.Release();
        }
    }

}