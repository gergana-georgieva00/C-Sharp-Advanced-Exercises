using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] spl = command.Split();

                if (spl[0] == "add")
                {
                    int firstNum = int.Parse(spl[1]);
                    int secondNum = int.Parse(spl[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else
                {
                    int count = int.Parse(spl[1]);

                    if (stack.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
