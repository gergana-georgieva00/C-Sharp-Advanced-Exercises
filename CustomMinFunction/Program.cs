using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<List<int>, int> findSmallestNum = x => x.Min();
            Action<List<int>> printer = x => Console.WriteLine(findSmallestNum(x));
            printer(integers);
        }
    }
}
