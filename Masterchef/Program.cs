using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> dishes = new Dictionary<string, int>();

            dishes.Add("Dipping sauce", 0);
            dishes.Add("Green salad", 0);
            dishes.Add("Chocolate cake", 0);
            dishes.Add("Lobster", 0);

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int sum = ingredients.Peek() * freshness.Peek();

                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                if (sum == 150 || sum == 250 || sum == 300 || sum == 400)
                {
                    switch (sum)
                    {
                        case 150:
                            dishes["Dipping sauce"]++;
                            break;
                        case 250:
                            dishes["Green salad"]++;
                            break;
                        case 300:
                            dishes["Chocolate cake"]++;
                            break;
                        case 400:
                            dishes["Lobster"]++;
                            break;
                    }

                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();

                    int firstIngredient = ingredients.Dequeue();
                    if (firstIngredient > 0)
                    {
                        ingredients.Enqueue(firstIngredient + 5);
                    }
                }
            }

            if (!dishes.ContainsValue(0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var kvp in dishes.OrderBy(d => d.Key))
            {
                if (kvp.Value > 0)
                {
                    Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
                }
            }
        }
    }
}
