using System;
using System.Collections.Generic;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            integers = integers.Where(n => n % 2 == 0).OrderBy(n => n).ToList();
            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
