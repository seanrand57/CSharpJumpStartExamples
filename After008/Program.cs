using System;

namespace After008
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IAnimal favorite;

            Console.WriteLine("What is your favorite animal? 1=Monkey, 2=Dog");
            string input = Console.ReadLine();
            int id = int.Parse(input); // you should have error checking!!!

            // I want to have the chosen animal vocalize!
            switch (id)
            {
                case 1:
                    favorite = new Monkey();
                    break;

                case 2:
                    favorite = new Dog();
                    break;

                default:
                    favorite = new Dog(); // I like dogs
                    break;
            }

            favorite.Vocalize();

            Logger.Log(LogLevel.Detailed, "Favorite chosen!");
        }
    }

    internal enum LogLevel
    {
        NoLogging,
        Simple, // simple and brief mean the same thing
        Brief,
        Detailed
    }

}