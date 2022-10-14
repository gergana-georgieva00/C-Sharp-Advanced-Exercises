using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToList();

            Stackk<int> stack = new Stackk<int>(input);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command.Contains("Push"))
                {
                    int numToPush = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                    stack.Push(numToPush);
                }
                else
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
