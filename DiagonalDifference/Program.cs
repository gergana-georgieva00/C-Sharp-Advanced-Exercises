using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] currRowArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRowArr[col];
                }
            }

            int currRow = 0;
            int currCol = 0;

            int primaryDiagonal = 0;

            while (currRow < n && currCol < n)
            {
                primaryDiagonal += matrix[currRow, currCol];

                currRow++;
                currCol++;
            }

            currRow = 0;
            currCol = n - 1;

            int secondaryDiagonal = 0;

            while (currRow < n && currCol >= 0)
            {
                secondaryDiagonal += matrix[currRow, currCol];

                currRow++;
                currCol--;
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
