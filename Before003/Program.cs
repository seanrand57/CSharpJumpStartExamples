using System.Collections;

namespace Before003
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Arraylist of objects
            var animals = new ArrayList {new Monkey(), new Dog()};

            object firstAnimal = animals[0];
        }
    }
}