using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();

            foreach (char ch in input)
            {
                if (ch == '(')
                {
                    indexes.Push(input.IndexOf(ch));
                }

                if (ch == ')')
                {
                    int index = indexes.Pop();
                    string subexpression = input.Substring(index, input.IndexOf(')') - index + 1);

                    Console.WriteLine(subexpression);
                }
            }
        }
    }
}
