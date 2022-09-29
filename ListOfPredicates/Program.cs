using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> numsToCheck = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                numsToCheck.Add(i);
            }

            Func<int, int, bool> checker = (num1, num2) => num1 % num2 == 0;

            foreach (var numToCheck in numsToCheck)
            {
                bool isValid = false;

                foreach (var divider in dividers)
                {
                    if (checker(numToCheck, divider))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }

                if (!isValid)
                {
                    continue;
                }
                else
                {
                    Console.Write(numToCheck + " ");
                }
            }
        }
    }
}
