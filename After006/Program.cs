using System;

namespace After006
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var strings = new[] {"String 1", "String 2", "String 3"};

            // how can I iterate through the string array?

            #region Crazy

            Console.WriteLine(strings[0]);
            Console.WriteLine(strings[1]);
            Console.WriteLine(strings[2]);

            // not really iterating

            #endregion

            #region how abount an index variable?

            var index0 = 0;

            Console.WriteLine(strings[index0++]); // post increment
            Console.WriteLine(strings[index0++]); ;
            Console.WriteLine(strings[index0++]); ;

            // but wait - index is too big now
            // if we do
            Console.WriteLine(strings[index0++]); // we get an exception

            #endregion

            #region we could add a length check:
            var index1 = 0;

            if (index1 < strings.Length)
            {
                Console.WriteLine(strings[index1++]); ;
            }

            if (index1 < strings.Length)
            {
                Console.WriteLine(strings[index1++]); ;
            }

            if (index1 < strings.Length)
            {
                Console.WriteLine(strings[index1++]); ;
            }

            if (index1 < strings.Length)
            {
                // never runs!
                Console.WriteLine(strings[index1++]); ;
            }

            // but that is a lot of work!!!
            #endregion

            #region easier

            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i]); ;
            }

            #endregion

            #region easy!

            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }

            #endregion
        }
    }
}