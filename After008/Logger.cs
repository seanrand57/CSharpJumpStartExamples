using System;

namespace After008
{
    internal static class Logger
    {
        internal static void Log(LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.NoLogging:
                    break;

                case LogLevel.Brief:
                case LogLevel.Simple:
                    Console.WriteLine(message);
                    break;

                case LogLevel.Detailed:
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine(message);
                    break;

                default:
                    Console.WriteLine("Unknown logging level");
                    break;
            }
        }
    }
}