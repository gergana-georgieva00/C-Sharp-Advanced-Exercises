using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray());
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray());

            Dictionary<string, int> products = new Dictionary<string, int>();

            products.Add("Croissant", 0);
            products.Add("Muffin", 0);
            products.Add("Baguette", 0);
            products.Add("Bagel", 0);

            int counter = 0;
            if (water.Count > flour.Count)
            {
                counter = flour.Count;
            }
            else
            {
                counter = water.Count;
            }

            bool end = false;

            while(water.Count > 0 && flour.Count > 0)
            {
                double sum = water.Peek() + flour.Peek();
                double waterPercentage = water.Peek() * 100 / sum;
                double flourPercentage = 100 - waterPercentage;

                switch (waterPercentage)
                {
                    // Croissant
                    case 50:
                        if (flourPercentage == 50)
                        {
                            products["Croissant"]++;

                            water.Dequeue();
                            flour.Pop();
                            counter--;
                        }
                        break;
                    // Muffin 
                    case 40:
                        if (flourPercentage == 60)
                        {
                            products["Muffin"]++;

                            water.Dequeue();
                            flour.Pop();
                            counter--;
                        }
                        break;
                    //	Baguette 
                    case 30:
                        if (flourPercentage == 70)
                        {
                            products["Baguette"]++;

                            water.Dequeue();
                            flour.Pop();
                            counter--;
                        }
                        break;
                    // Bagel
                    case 20:
                        if (flourPercentage == 80)
                        {
                            products["Bagel"]++;

                            water.Dequeue();
                            flour.Pop();
                            counter--;
                        }
                        break;
                    default:
                        products["Croissant"]++;
                        double currFlour = flour.Pop() - water.Dequeue();

                        if (currFlour > 0)
                        {
                            flour.Push(currFlour);
                        }
                        break;
                        
                }
            }

            if (products.Values.Any(v => v > 0))
            {
                foreach (var product in products.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
                {
                    if (product.Value > 0)
                    {
                        Console.WriteLine($"{product.Key}: {product.Value}");
                    }
                }

                if (water.Count > 0)
                {
                    Console.WriteLine($"Water left: {string.Join(", ", water)}");
                }
                else
                {
                    Console.WriteLine("Water left: None");
                }

                if (flour.Count > 0)
                {
                    Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
                }
                else
                {
                    Console.WriteLine("Flour left: None");
                }
            }
        }
    }
}
