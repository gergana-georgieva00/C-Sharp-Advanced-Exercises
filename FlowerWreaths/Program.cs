using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] rInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> roses = new Queue<int>(rInput);
            Stack<int> lilies = new Stack<int>(lInput);

            List<int> backup = new List<int>();

            int wreathCount = 0;

            while (roses.Count > 0 && lilies.Count > 0)
            {
                if (roses.Peek() + lilies.Peek() == 15)
                {
                    wreathCount++;
                    roses.Dequeue();
                    lilies.Pop();
                }
                else if (roses.Peek() + lilies.Peek() > 15)
                {
                    int currLily = lilies.Pop() - 2;
                    lilies.Push(currLily);
                }
                else
                {
                    int currRose = roses.Dequeue();
                    int currLily = lilies.Pop();

                    backup.Add(currRose + currLily);
                }
            }

            if (backup.Sum() / 15 >= 1)
            {
                wreathCount += backup.Sum() / 15;
            }

            if (wreathCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCount} wreaths more!");
            }
        }
    }
}
