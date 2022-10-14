using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<int> integers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Lake lake = new Lake(integers);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
