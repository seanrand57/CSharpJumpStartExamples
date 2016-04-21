using System.Collections.Generic;

namespace After003
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var animal = new Animal();

            // default values
            System.Console.WriteLine(animal.Name);
            System.Console.WriteLine(animal.Weight);
            System.Console.WriteLine(animal.Color);
            System.Console.Read();

            animal.Name = "Monkey";
            // animal.Weight = 123.4d;
            animal.Color = "Brown";
        
            // updated values
            System.Console.WriteLine(animal.Name);
            System.Console.WriteLine(animal.Weight);
            System.Console.WriteLine(animal.Color);
            System.Console.Read();
        }

        class Animal
        {
            public string Name { get; set; }
            public double Weight { get; private set; }
            public string Color { get; set; }
        }
    }
}