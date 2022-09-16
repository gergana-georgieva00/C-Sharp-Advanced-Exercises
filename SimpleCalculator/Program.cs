using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Array.Reverse(input);

            Stack<string> stack = new Stack<string>(input);

            int result = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                string currOperator = stack.Pop();
                int currNum = int.Parse(stack.Pop());

                if (currOperator == "+")
                {
                    result += currNum;
                }
                else
                {
                    result -= currNum;
                }
            }

            Console.WriteLine(result);
        }
    }
}
