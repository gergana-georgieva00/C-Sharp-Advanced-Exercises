using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            List<int> evenNums = new List<int>();

            while (queue.Count > 0)
            {
                if (queue.Peek() % 2 == 0)
                {
                    evenNums.Add(queue.Dequeue());
                }
                else
                {
                    queue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}
