using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, bool> filter = name => name.Length <= n;
            names = names.Where(name => filter(name)).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
