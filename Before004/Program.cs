using System;

namespace Before004
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // without reflection
            var dog = new Dog {NumberOfLegs = 4};
            Console.WriteLine("A dog has {0} legs", dog.NumberOfLegs);

            // with reflection
        }
    }

    internal class Dog
    {
        public int NumberOfLegs { get; set; }
    }
}