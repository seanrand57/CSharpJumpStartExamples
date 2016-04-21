using System;

namespace After007
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = 2;

            // stacked if
            if (value == 1)
                Console.WriteLine("One");
            if (value == 2)
                Console.WriteLine("Two");
            if (value != 1 && value != 2)
                Console.WriteLine("Other");

            // else if
            if (value == 1)
                Console.WriteLine("One");
            else if (value == 2)
                Console.WriteLine("Two");
            else
                Console.WriteLine("Other");

            if (value == 1)
            {
                Console.WriteLine("One");
            }
            else
            {
                Console.WriteLine("Not One");
            }

            // ternary
            Console.WriteLine(value == 1 ? "One" : "Not One");

            // use braces to encapsulate blocks
            if (value == 1)
            {
                Console.WriteLine("One");
                DoSomethingElse();
            }
            else if (value == 2)
            {
                Console.WriteLine("Two");
                DoSomethingElse();
            }
            else
            {
                Console.WriteLine("Other");
                DoSomethingElse();
            }


            Console.Read();
        }

        
        private static void DoSomethingElse()
        {}

    }
}