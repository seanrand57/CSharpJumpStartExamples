using System;
using System.Reflection;

namespace After004
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // without reflection
            ////var dog = new Dog { NumberOfLegs = 4 };
            ////Console.WriteLine("A dog has {0} legs", dog.NumberOfLegs);

            // with reflection
            object dog = Activator.CreateInstance(typeof (Dog));
            PropertyInfo[] properties = typeof (Dog).GetProperties();
            PropertyInfo numberOfLegsProperty1 = properties[0];

            // or
            PropertyInfo numberOfLegsProperty2 = null;
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.Name.Equals("NumberOfLegs", StringComparison.InvariantCulture))
                {
                    numberOfLegsProperty2 = propertyInfo;
                }
            }

            numberOfLegsProperty1.SetValue(dog, 3, null);

            Console.WriteLine(numberOfLegsProperty2.GetValue(dog, null));

            // use reflection to invoke different constructors

            var defaultConstructor = typeof (Dog).GetConstructor(new Type[0]);
            var legConstructor = typeof (Dog).GetConstructor(new [] {typeof (int)});

            var defaultDog = (Dog)defaultConstructor.Invoke(null);
            Console.WriteLine(defaultDog.NumberOfLegs);

            var legDog = (Dog) legConstructor.Invoke(new object[] {5});
            Console.WriteLine(legDog.NumberOfLegs);

        }
    }

    internal class Dog
    {
        public int NumberOfLegs { get; set; }

        public Dog()
        {
            NumberOfLegs = 4;
        }

        public Dog(int legs)
        {
            NumberOfLegs = legs;
        }
    }
}