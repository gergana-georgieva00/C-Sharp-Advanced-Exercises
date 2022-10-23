using System;
using System.Linq;

namespace RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int index = 0;
            Console.WriteLine(Sum(integers, index));
        }

        static int Sum(int[] array, int index)
        {
            int sum = 0;

            if (index < array.Length)
            {
                return sum += array[index++] + Sum(array, index);
            }

            return sum;
        }
    }
}
