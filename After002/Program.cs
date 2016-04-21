using System;

namespace After002
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var animals = new IAnimal[] {new Monkey(), new Dog()};
            foreach (var animal in animals)
            {
                DisplayAnimalData(animal);
            }
        }

        private static void DisplayAnimalData(IAnimal animal)
        {
            Console.WriteLine("Animal has {0} legs and makes this sound: {1}", animal.NumberOfLegs);
            animal.Vocalize();
        }
    }

    internal interface IAnimal
    {
        int NumberOfLegs { get; }
        void Vocalize();
    }

    internal abstract class AnimalBase : IAnimal
    {
        private readonly string _sound;

        protected AnimalBase(int numberOfLegs, string sound)
        {
            NumberOfLegs = numberOfLegs;
            _sound = sound;
        }

        public int NumberOfLegs { get; private set; }

        public void Vocalize()
        {
            Console.WriteLine(_sound);
        }
    }

    internal class Dog : AnimalBase
    {
        public Dog() : base(4, "woof!")
        {
        }
    }

    internal class Monkey : AnimalBase
    {
        public Monkey() : base(2, "<monkey sound/>!")
        {
        }
    }
}