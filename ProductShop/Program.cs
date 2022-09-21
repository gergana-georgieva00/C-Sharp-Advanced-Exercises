using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopPrices = new Dictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] spl = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = spl[0];
                string product = spl[1];
                double price = double.Parse(spl[2]);

                if (shopPrices.ContainsKey(shop))
                {
                    if (!shopPrices[shop].ContainsKey(product))
                    {
                        shopPrices[shop].Add(product, price);
                    }
                }
                else
                {
                    shopPrices.Add(shop, new Dictionary<string, double>());

                    if (!shopPrices[shop].ContainsKey(product))
                    {
                        shopPrices[shop].Add(product, price);
                    }
                }
            }

            foreach (var kvp in shopPrices.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var productPrice in kvp.Value)
                {
                    Console.WriteLine($"Product: {productPrice.Key}, Price: {productPrice.Value}");
                }
            }
        }
    }
}
