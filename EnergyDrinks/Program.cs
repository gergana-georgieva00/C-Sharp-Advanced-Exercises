using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> mgCoffee = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int caffeinePerDay = 0;

            while (mgCoffee.Count > 0 && energyDrinks.Count > 0)
            {
                int currMult = mgCoffee.Peek() * energyDrinks.Peek();

                if (currMult + caffeinePerDay <= 300)
                {
                    mgCoffee.Pop();
                    energyDrinks.Dequeue();

                    caffeinePerDay += currMult;
                }
                else
                {
                    mgCoffee.Pop();
                    energyDrinks.Enqueue(energyDrinks.Dequeue());

                    if (caffeinePerDay - 30 >= 0)
                    {
                        caffeinePerDay -= 30;
                    }
                    else
                    {
                            
                    }
                }
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {caffeinePerDay} mg caffeine.");
        }
    }
}
