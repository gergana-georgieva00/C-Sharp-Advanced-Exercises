using System;
using System.Linq;

namespace Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            integers = integers.OrderByDescending(i => i).ToArray();

            if (integers.Length <= 3)
            {
                Console.WriteLine(string.Join(' ', integers));
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(integers[i] + " ");
                }
            }
        }
    }
}
