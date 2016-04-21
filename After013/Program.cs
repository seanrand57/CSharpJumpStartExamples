using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace After013
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = "The quick brown fox jumped over the lazy dog";

            // one
            Console.WriteLine(x.Substring(4, 5));

            // two
            var stringSplit = x.Split(' ');
            Console.WriteLine(stringSplit[1]);

            // three
            var regexSplit = System.Text.RegularExpressions.Regex.Split(x, " ");
            Console.WriteLine(regexSplit[1]);

            // four
            var regexFind = System.Text.RegularExpressions.Regex.Match(x, "(The )(.+)( brown)");
            Console.WriteLine(regexFind.Groups[2].Value);

            Console.Read();
        }
    }
}
