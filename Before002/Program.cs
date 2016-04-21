using System;

namespace Before002
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var m = new Monkey();
            var d = new Dog();

            Console.WriteLine(m.Legs);
            Console.WriteLine(d.Legs);
        }
    }

    interface IAnimal
    {
        int Legs { get; set; }
    }

    abstract class Mammal : IAnimal
    {
        public int Legs { get; set; }
    }

    class Dog : Mammal
    {
        public Dog() { Legs = 4; }
    }

    class Monkey : Mammal
    {
        public Monkey() { Legs = 2; }
    }








    //internal class Dog
    //{
    //    public Dog()
    //    {
    //        NumberOfLegs = 4;
    //    }

    //    public int NumberOfLegs { get; private set; }

    //    public void Vocalize()
    //    {
    //        Console.WriteLine("Woof!");
    //    }
    //}

    //internal class Monkey
    //{
    //    public Monkey()
    //    {
    //        NumberOfLegs = 2;
    //    }

    //    public int NumberOfLegs { get; private set; }

    //    public void Vocalize()
    //    {
    //        Console.WriteLine("<Monkey Sound/>");
    //    }
    //}
}