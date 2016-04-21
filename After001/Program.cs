using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
namespace After001
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var man = new Man("John", "Doe");
            System.Console.WriteLine("{0} {1}", man.FirstName, man.LastName);

            man.Update("Jane", "Doe");
            System.Console.WriteLine("{0} {1}", man.FirstName, man.LastName);

            man.Update(lastName: "Smith", firstName: "Bob");
            System.Console.WriteLine("{0} {1}", man.FirstName, man.LastName);

            man.Update("Mark");
            System.Console.WriteLine("{0} {1}", man.FirstName, man.LastName);

            System.Console.Read();
        }

        void List()
        {
            var objects = new ArrayList();
            objects.Add(1);
            objects.Add(2);
            objects.Add("three");

            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            // error if you try to list up the incorrect type
           // list.Add("three");
        }

        // GENERICS

        void Breakfast()
        {
            var bird = new Animal<Egg>();
            var pig = new Animal<Piglet>();
        }

        public class Animal<T> where T : Offspring
        {
            public T Offspring { get; set; }
        }

        public abstract class Offspring { }
        public class Egg : Offspring { }
        public class Piglet : Offspring { }

        public class Man
        {
            public Man(string firstName, string lastName)
            {
                Update(firstName, lastName);
            }

            public void Update(string firstName, string lastName = "Jones")
            {
                this.FirstName = firstName;
                this.LastName = lastName;
            }

            private string _firstName;
            public string FirstName
            {
                get { return _firstName; }
                set { _firstName = value; }
            }

            private string _lastName;
            public string LastName
            {
                get { return _lastName; }
                set { _lastName = value; }
            }

        }
    }
}