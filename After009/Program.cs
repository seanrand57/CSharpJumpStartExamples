using System;

namespace After009
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var x = 2;

            Console.WriteLine(x == 2);
            Console.WriteLine(x != 2);
            Console.WriteLine(x > 2);
            Console.WriteLine(x >= 2);
            Console.WriteLine(x < 2);
            Console.WriteLine(x <= 2);
            Console.WriteLine(x%2);
            Console.WriteLine(x += 2);
            Console.WriteLine(x -= 2);
            Console.WriteLine(x = -2);

            Console.Read();
        }
    }
}