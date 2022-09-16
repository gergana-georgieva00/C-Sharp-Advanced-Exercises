using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Queue<string> queue = new Queue<string>(input);

            while (queue.Count > 0)
            {
                string command = Console.ReadLine();

                if (command.Contains("Play"))
                {
                    queue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    command = command.Replace("Add ", "");

                    if (queue.Contains(command))
                    {
                        Console.WriteLine($"{command} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(command);
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("No more songs!");
            }
        }
    }
}
