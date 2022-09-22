using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                string color = input[0];
                string[] items = input[1].Split(',');

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());

                    foreach (var item in items)
                    {
                        if (clothes[color].ContainsKey(item))
                        {
                            clothes[color][item]++;
                        }
                        else
                        {
                            clothes[color].Add(item, 1);
                        }
                    }
                }
                else
                {
                    foreach (var item in items)
                    {
                        if (clothes[color].ContainsKey(item))
                        {
                            clothes[color][item]++;
                        }
                        else
                        {
                            clothes[color].Add(item, 1);
                        }
                    }
                }
            }

            string[] searchItem = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string colorItem = searchItem[0];
            string type = searchItem[1];

            foreach (var kvp in clothes)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var typeCount in kvp.Value)
                {
                    if (kvp.Key == colorItem && typeCount.Key == type)
                    {
                        Console.WriteLine($"* {typeCount.Key} - {typeCount.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {typeCount.Key} - {typeCount.Value}");
                    }
                }
            }
        }
    }
}
