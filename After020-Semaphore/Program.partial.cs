namespace After020_Semaphore
{
    using System;

    internal partial class Program
    {
        private static readonly object _syncObject = new object();

        private static void WriteGreenLine(string format, object arg)
        {
            lock (_syncObject)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                WriteLine(format, arg);
            }
        }

        private static void WriteLine(string format, object arg)
        {
            Console.WriteLine(format, arg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WriteYellowLine(string format, object arg)
        {
            lock (_syncObject)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                WriteLine(format, arg);
            }
        }

        private static void WriteRedLine(string format, object arg)
        {
            lock (_syncObject)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine(format, arg);
            }
        }

        private static void WriteWhiteLine(string format, object arg)
        {
            lock (_syncObject)
            {
                Console.ForegroundColor = ConsoleColor.White;
                WriteLine(format, arg);
            }
        }
    }
}