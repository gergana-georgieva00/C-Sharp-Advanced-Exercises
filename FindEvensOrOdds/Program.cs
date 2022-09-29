using System;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isInRange = num => num % 2 == 0;

            int[] range = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string evenOrOdd = Console.ReadLine();

            for (int i = range[0]; i <= range[1]; i++)
            {
                if (evenOrOdd == "even")
                {
                    if (isInRange(i))
                    {
                        Console.Write(i + " ");
                    }
                }
                else
                {
                    if (!isInRange(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
