namespace Before022_Typed
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input a number or 'exit' to close:");
                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                byte b = Byte.Parse(input);

                Console.WriteLine("You entered {0}", b);
                Console.WriteLine();
            }
        }
    }
}