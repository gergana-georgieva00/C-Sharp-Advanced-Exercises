using System;
using System.Collections.Generic;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            Console.WriteLine(integers.Count);
            Console.WriteLine(integers.Sum());
        }
    }
}
