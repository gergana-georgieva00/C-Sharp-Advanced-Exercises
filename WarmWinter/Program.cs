using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> scarves = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Queue<int> sets = new Queue<int>();

            while (hats.Count > 0 && scarves.Count > 0)
            {
                if (hats.Peek() > scarves.Peek())
                {
                    sets.Enqueue(hats.Pop() + scarves.Dequeue());
                }
                else if (hats.Peek() < scarves.Peek())
                {
                    hats.Pop();
                }
                else
                {
                    scarves.Dequeue();
                    int newHat = hats.Pop() + 1;
                    hats.Push(newHat);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine($"{string.Join(' ', sets)}");
        }
    }
}
