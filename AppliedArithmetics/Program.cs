using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<int, int> add = num => num + 1;
            Func<int, int> multiply = num => num * 2;
            Func<int, int> subtract = num => num - 1;
            Action<List<int>> print = li => Console.WriteLine(string.Join(' ', li));

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(n => add(n)).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => n = multiply(n)).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => n = subtract(n)).ToList();
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }

        static int Add(int num)
        {
            return num + 1;
        }
    }
}
