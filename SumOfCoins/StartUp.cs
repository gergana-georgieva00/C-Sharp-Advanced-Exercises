using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(", ").Select(int.Parse).OrderByDescending(i => i).ToArray();
            int sum = int.Parse(Console.ReadLine());


        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            return null;
        }
    }
}
