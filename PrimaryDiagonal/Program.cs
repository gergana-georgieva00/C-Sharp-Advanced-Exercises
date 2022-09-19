using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRoww = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRoww[col];
                }
            }

            int currRow = 0;
            int currCol = 0;
            int sum = 0;

            while (currRow < n && currCol < n)
            {
                sum += matrix[currRow, currCol];

                currRow++;
                currCol++;
            }

            Console.WriteLine(sum);
        }
    }
}
