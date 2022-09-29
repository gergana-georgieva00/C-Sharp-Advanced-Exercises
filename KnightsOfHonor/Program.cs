using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<string> printer = x => Console.WriteLine("Sir " + x);
            names.ForEach(n => printer(n));
        }
    }
}
