using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(integers);

            while (queue.Count > 0 && n - queue.Peek() >= 0)
            {
                n -= queue.Dequeue();
            }

            Console.WriteLine(integers.Max());

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ', queue)}");

            }
        }
    }
}
