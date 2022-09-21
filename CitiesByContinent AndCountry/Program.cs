using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> countries = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!countries.ContainsKey(continent))
                {
                    countries.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!countries[continent].ContainsKey(country))
                {
                    countries[continent].Add(country, new List<string>());
                }

                countries[continent][country].Add(city);
               
            }

            foreach (var kvp in countries)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var countryCity in kvp.Value)
                {
                    Console.WriteLine($"  {countryCity.Key} -> {string.Join(", ", countryCity.Value)}");
                }
            }
        }
    }
}
