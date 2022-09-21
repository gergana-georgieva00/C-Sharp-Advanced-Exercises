using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (studentGrades.ContainsKey(name))
                {
                    studentGrades[name].Add(grade);
                }
                else
                {
                    studentGrades.Add(name, new List<decimal>());
                    studentGrades[name].Add(grade);
                }
            }

            foreach (var kvp in studentGrades)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(' ', kvp.Value.Select(g => g.ToString("F2")))} (avg: {kvp.Value.Average():f2})");
            }
        }
    }
}
