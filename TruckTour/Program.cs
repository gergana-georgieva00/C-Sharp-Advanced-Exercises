using System;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] pair = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int amountPetrol = pair[0];
                int distance = pair[1];


            }
        }
    }
}
