using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] threadsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int taskToKill = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(tasksInput);
            Queue<int> threads = new Queue<int>(threadsInput);

            while (true)
            {
                if (tasks.Peek() == taskToKill)
                {
                    tasks.Pop();
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
                    break;
                }

                if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(' ', threads));
        }
    }
}
