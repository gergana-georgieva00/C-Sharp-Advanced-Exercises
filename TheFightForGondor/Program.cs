using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] platesInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> plates = new Queue<int>(platesInput);
            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= n; i++)
            {
                int[] orcsInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (plates.Count > 0)
                {
                    orcs = new Stack<int>(orcsInput);

                    if (i % 3 == 0)
                    {
                        plates.Enqueue(int.Parse(Console.ReadLine()));
                    }
                }

                while (orcs.Count > 0 && plates.Count > 0)
                {
                    if (orcs.Peek() > plates.Peek())
                    {
                        int currOrc = orcs.Pop() - plates.Dequeue();
                        orcs.Push(currOrc);
                    }
                    else if (orcs.Peek() < plates.Peek())
                    {
                        List<int> newPlates = new List<int>(plates);
                        newPlates[0] -= orcs.Pop();
                        plates = new Queue<int>(newPlates);
                    }
                    else
                    {
                        orcs.Pop();
                        plates.Dequeue();
                    }
                }
            }

            if (plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
