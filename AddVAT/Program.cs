using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, decimal> parseToDouble = d => decimal.Parse(d);
            List<decimal> prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(parseToDouble).ToList();

            Func<decimal, decimal> addVAT = d => d += 0.2m * d;
            prices = prices.Select(addVAT).ToList();
            prices.ForEach(p => Console.WriteLine($"{p:f2}"));
        }
    }
}
