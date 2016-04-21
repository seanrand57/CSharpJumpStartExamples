using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace After033
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Enumerable.Range(1, 50);

            var method = // IEnumerable<string>
                 data.Where(x => x % 2 == 0)
                 .Select(x => x.ToString());

            var query = // IEnumerable<string>
                from d in data
                where d % 2 == 0
                select d.ToString();

            Debugger.Break();

            var projection =
                from d in data
                select new
                {
                    Even = (d % 2 == 0),
                    Odd = !(d % 2 == 0),
                    Value = d,
                };

            var letters = new[] { "A", "C", "B", "E", "Q" };

            Debugger.Break();

            var sortAsc =
                from d in data
                orderby d ascending
                select d;

            var sortDesc =
                data.OrderByDescending(x => x);

            Debugger.Break();

            // candy

            var values = new[] { "A", "B", "A", "C", "A", "D" };

            var distinct = values.Distinct();
            var first = values.First();
            var firstOr = values.FirstOrDefault();
            var last = values.Last();
            var page = values.Skip(2).Take(2);

            Debugger.Break();

            // aggregates

            var numbers = Enumerable.Range(1, 50);
            var any = numbers.Any(x => x % 2 == 0);
            var count = numbers.Count(x => x % 2 == 0);
            var sum = numbers.Sum();
            var max = numbers.Max();
            var min = numbers.Min();
            var avg = numbers.Average();

            Debugger.Break();

            var dictionary = new Dictionary<string, string>()
            {
                 {"1", "B"}, {"2", "A"}, {"3", "B"}, {"4", "A"},
            };

            var group = // IEnumerable<string, IEnumerable<string>>
                from d1 in dictionary
                group d1 by d1.Value into g
                select new
                {
                    Key = g.Key,
                    Members = g,
                };

            Debugger.Break();

            var dictionary1 = new Dictionary<string, string>()
            {
                 {"1", "B"}, {"2", "A"}, {"3", "B"}, {"4", "A"},
            };

            var dictionary2 = new Dictionary<string, string>()
            {
                 {"5", "B"}, {"6", "A"}, {"7", "B"}, {"8", "A"},
            };

            var join =
                from d1 in dictionary1
                join d2 in dictionary2 on d1.Value equals d2.Value
                select new
                {
                    Key1 = d1.Key,
                    Key2 = d2.Key,
                    Value = d1.Value
                };

            Debugger.Break();

        }
    }
}
