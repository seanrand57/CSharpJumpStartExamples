using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace After11
{
    class Program
    {
        static void Main(string[] args)
        {
            One();

            Console.WriteLine(string.Empty);
            Console.WriteLine(Two());

            Console.WriteLine(string.Empty);
            Three();

            Console.Read();
        }

        static void One()
        {
            Console.WriteLine("Red");
            Console.WriteLine("White");
            return;
            Console.WriteLine("Blue");
        }

        static string Two()
        {
            Console.WriteLine("Red");
            Console.WriteLine("White");
            return "Blue";
        }

        static void Three()
        {
            goto spot;
            Console.Write("Red");
            Console.Write("White");
        spot:
            Console.Write("Blue");
        }
    }
}
