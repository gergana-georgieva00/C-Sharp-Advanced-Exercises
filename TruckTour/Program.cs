using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                string pair = Console.ReadLine();

                queue.Enqueue(pair);
            }

            int index = 0;
            int liters = 0;
            int iterations = 1;

            while (queue.Count > 0)
            {
                liters += int.Parse(queue.Peek().Split()[0]);

                if (liters - int.Parse(queue.Peek().Split()[1]) > 0)
                {
                    iterations++;
                    liters -= int.Parse(queue.Peek().Split()[1]);
                    queue.Dequeue();
                }
                else
                {
                    index++;
                    iterations = 1;
                    liters = 0;
                    queue.Enqueue(queue.Dequeue());
                }
            }

            Console.WriteLine(index);
        }
    }
}
