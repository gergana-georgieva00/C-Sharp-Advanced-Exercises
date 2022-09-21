using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> valuesCount = new Dictionary<double, int>();

            double[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            foreach (var value in input)
            {
                if (valuesCount.ContainsKey(value))
                {
                    valuesCount[value]++;
                }
                else
                {
                    valuesCount.Add(value, 1);
                }
            }

            foreach (var kvp in valuesCount)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
