using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = nm[0];
            int m = nm[1];

            HashSet<int> nSet = new HashSet<int>();
            HashSet<int> mSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                nSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                mSet.Add(int.Parse(Console.ReadLine()));
            }

            var same = nSet.Intersect(mSet).ToArray();

            if (same.Length > 0)
            {
                Console.WriteLine(string.Join(' ', same));
            }
        }
    }
}
