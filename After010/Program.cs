namespace After010
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] array = { 3, 2, 5, 1, 4, 10, 7, 6, 9, 8 };

            // loop through array until you find 6: for
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 6)
                {
                    break;
                }

                Console.WriteLine(array[i]);
            }

            // loop through array until you find 6: foreach
            foreach (var item in array)
            {
                if (item == 6)
                {
                    break;
                }

                Console.WriteLine(item);
            }

            // skip processing for ever 2nd item in the array : for
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 > 0)
                {
                    continue;
                }

                Console.WriteLine(array[i]);
            }

            // skip processing if item is 3 : foreach
            foreach (var item in array)
            {
                if (item == 3)
                {
                    continue;
                }

                Console.WriteLine(item);
            }

          

            // demo while

            var index1 = 0;
            while(index1 < array.Length)
            {
                // body only executed if expression is true
                Console.WriteLine(array[index1++]);
            }

            // demo do ????
            var index2 = 0;
            do
            {
                // body always executed at least once
                Console.WriteLine(array[index2++]);
            }
            while (index2 < array.Length);

            // note: we can break and continue from while & do loops too

            // demo yield
            var animals = new AnimalCollection();
            foreach (var animal in animals)
            {
                ((IAnimal)animal).Vocalize();
            }
            
            // using yield return and yield break to fill a list
            var list = new List<int>(Range(23, 200));
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

        }

        private static IEnumerable<int> Range(int min, int max)
        {
            while (true)
            {
                if ( min >= max)
                {
                    yield break;
                }

                yield return min++;
            }
        }
    }

    internal class AnimalCollection : IEnumerable, IEnumerable<IAnimal>   
    {
        private IAnimal[] _animals = { new Monkey(), new Dog(), new Monkey(), new Dog(), new Dog() };

        public IEnumerator<IAnimal> GetEnumerator()
        {
            foreach (var animal in _animals)
            {
                // could be hard work here
                yield return animal;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}