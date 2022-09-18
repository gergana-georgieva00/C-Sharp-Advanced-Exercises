using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();
            StringBuilder sb = new StringBuilder(string.Empty);

            stack.Push(sb.ToString());
            
            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                
                if (command == "1")
                {
                    string argument = input[1];

                    sb.Append(argument);
                    stack.Push(sb.ToString());
                }
                else if (command == "2")
                {
                    int argument = int.Parse(input[1]);

                    for (int j = 1; j <= argument; j++)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    stack.Push(sb.ToString());
                }
                else if (command == "3")
                {
                    int argument = int.Parse(input[1]);

                    Console.WriteLine(sb.ToString()[argument - 1]);
                }
                else
                {
                    stack.Pop();
                    sb = new StringBuilder(stack.Peek());
                }
            }
        }
    }
}
