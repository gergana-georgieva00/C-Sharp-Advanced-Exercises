using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<char> stack = new Stack<char>();
            List<string> allStrings = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                
                if (command == "1")
                {
                    string argument = input[1];

                    string currString = "";
                    foreach (var ch in argument)
                    {
                        stack.Push(ch);
                        currString += ch;
                    }

                    allStrings.Add(currString);
                }
                else if (command == "2")
                {
                    string argument = input[1];

                    for (int j = 0; j < int.Parse(argument); j++)
                    {
                        stack.Pop();
                    }

                    char[] charArray = string.Join("", stack).ToCharArray();
                    Array.Reverse(charArray);
                    allStrings.Add(new string(charArray));
                }
                else if (command == "3")
                {
                    string argument = input[1];

                    string currText = allStrings[allStrings.Count - 1];
                    char ch = currText[int.Parse(argument) - 1];
                    Console.WriteLine(ch);
                }
                else
                {
                    if (allStrings.Count > 1)
                    {
                        stack = new Stack<char>(allStrings[allStrings.Count - 2]);
                    }
                    else
                    {
                        stack = new Stack<char>(allStrings[allStrings.Count - 1]);
                    }
                    
                    allStrings.RemoveAt(allStrings.Count - 1);
                    //allStrings.RemoveAt(allStrings.Count - 1);
                }
            }
        }
    }
}
