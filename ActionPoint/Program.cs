using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<List<string>> printer = x => Console.WriteLine(string.Join(Environment.NewLine, x));
            printer(input);
        }
    }
}
