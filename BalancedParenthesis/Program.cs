using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (!(input.Length % 2 == 0))
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> stack = new Stack<char>();
            bool balanced = true;

            foreach (var ch in input)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                else
                {
                    if (ch == ')')
                    {
                        if (stack.Pop() != '(')
                        {
                            balanced = false;
                            break;
                        }
                    }
                    else if (ch == ']')
                    {
                        if (ch == ']')
                        {
                            if (stack.Pop() != '[')
                            {
                                balanced = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (ch == '}')
                        {
                            if (stack.Pop() != '{')
                            {
                                balanced = false;
                                break;
                            }
                        }
                    }
                }
            }

            if (balanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
