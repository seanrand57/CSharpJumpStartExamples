using System;

namespace After037_WhileDoWhile
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var loopCounter = 0;

            while (loopCounter > 0)
            {
                Console.WriteLine("This will not execute!");
            }

            do
            {
                Console.WriteLine("This will execute once!");
            } while (loopCounter > 0);
        }
    }
}