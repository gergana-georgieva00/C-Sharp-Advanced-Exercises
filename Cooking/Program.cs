using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] ingredientsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> liquids = new Queue<int>(liquidsInput);
            Stack<int> ingredients = new Stack<int>(ingredientsInput);

            Dictionary<string, int> foodQuantity = new Dictionary<string, int>();
            foodQuantity.Add("Bread", 0);
            foodQuantity.Add("Cake", 0);
            foodQuantity.Add("Pastry", 0);
            foodQuantity.Add("Fruit Pie", 0);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int sum = liquids.Peek() + ingredients.Peek();

                if (sum == 25 || sum == 50 || sum == 75 || sum == 100)
                {
                    switch (sum)
                    {
                        case 25:
                            foodQuantity["Bread"]++;
                            break;
                        case 50:
                            foodQuantity["Cake"]++;
                            break;
                        case 75:
                            foodQuantity["Pastry"]++;
                            break;
                        case 100:
                            foodQuantity["Fruit Pie"]++;
                            break;
                    }

                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    int currIngredient = ingredients.Pop() + 3;
                    ingredients.Push(currIngredient);
                }
            }

            if (foodQuantity.ContainsValue(0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            foreach (var kvp in foodQuantity.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
