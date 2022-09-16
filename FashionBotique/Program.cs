using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBotique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());
            int capacityCopy = capacity;

            Stack<int> stack = new Stack<int>(integers);
            int sum = 0;
            int racks = 1;

            if (capacity == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (stack.Count > 0)
            {
                if (capacityCopy - stack.Peek() == 0 && stack.Count > 0)
                {
                    capacityCopy = capacity;
                    stack.Pop();

                    if (stack.Count > 0)
                    {
                        racks++;
                    }
                }
                else if (capacityCopy - stack.Peek() < 0 && stack.Count > 0)
                {
                    capacityCopy = capacity;

                    if (stack.Count > 0)
                    {
                        racks++;
                    }
                }
                else
                {
                    capacityCopy -= stack.Pop();
                }
            }

            Console.WriteLine(racks);
        }
    }
}
