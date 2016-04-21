using System;

namespace Before008
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

            // more complex example
            Logger.Log(LogLevel.NoLogging, "I logged something");
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