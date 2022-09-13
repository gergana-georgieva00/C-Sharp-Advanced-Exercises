using System;
using System.Collections;
using System.Collections.Generic;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (var c in input)
            {
                stack.Push(c);
            }

            foreach (var c in stack)
            {
                Console.Write(c);
            }
        }
    }
}
