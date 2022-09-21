using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> chars = new Dictionary<char, int>();

            foreach (var character in input)
            {
                if (!chars.ContainsKey(character))
                {
                    chars.Add(character, 1);
                }
                else
                {
                    chars[character]++;
                }
            }

            foreach (var kvp in chars.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
