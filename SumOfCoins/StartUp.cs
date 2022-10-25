using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var integers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int sum = int.Parse(Console.ReadLine());

            var selectedCoins = ChooseCoins(integers, sum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");

            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            int[] sortedCoins = coins.OrderByDescending(c => c).ToArray();

            Dictionary<int, int> chosenCoins = new Dictionary<int, int>();

            int currentSum = 0;
            int coinIndex = 0;

            while (currentSum != targetSum && coinIndex < sortedCoins.Length)
            {
                int currCoinValue = sortedCoins[coinIndex];
                int remainder = targetSum - currentSum;
                int numberOfCoins = remainder / currCoinValue;

                if (currentSum + currCoinValue <= targetSum)
                {
                    chosenCoins.Add(currCoinValue, numberOfCoins);
                    currentSum += currCoinValue;
                }

                coinIndex++;
            }

            if (currentSum != targetSum)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return chosenCoins;
            }
            
        }
    }
}
