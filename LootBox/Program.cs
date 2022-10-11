using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            Queue<int> first = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> second = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            while (first.Count > 0 && second.Count > 0)
            {
                int currSum = first.Peek() + second.Peek();

                if (currSum % 2 == 0)
                {
                    sum += currSum;
                    first.Dequeue();
                    second.Pop();
                }
                else
                {
                    int lastItem = second.Pop();
                    first.Enqueue(lastItem);
                }
            }

            if (first.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
