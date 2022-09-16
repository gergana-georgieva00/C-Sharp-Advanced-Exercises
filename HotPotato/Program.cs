using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(input);
            int count = 1;

            while (queue.Count > 1)
            {
                string currKid = queue.Dequeue();

                if (count == n)
                {
                    Console.WriteLine($"Removed {currKid}");
                    count = 1;
                    continue;
                }

                count++;
                queue.Enqueue(currKid);
                Console.WriteLine(string.Join(',', queue));
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
