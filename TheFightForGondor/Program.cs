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

            for (int i = 0; i < n; i++)
            {
                int[] orcsInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Stack<int> orcs = new Stack<int>(orcsInput);

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
        }
    }
}
