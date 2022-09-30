using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> filter = (name, n) =>
            {
                int currSum = 0;

                foreach (char ch in name)
                {
                    currSum += (int)ch;
                }

                return currSum >= n;
            };

            Func<List<string>, Func<string, int, bool>, string> result = (names, filter) =>
            {
                foreach (var name in names)
                {
                    if (filter(name, n))
                    {
                        Console.WriteLine(name);
                        return name;
                    }
                }

                return "";
            };

            result(names, filter);
        }
    }
}
