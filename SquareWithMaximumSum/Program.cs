using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int biggestSum = int.MinValue;
            int[,] biggestSquare = new int[2, 2];

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currSum > biggestSum)
                    {
                        biggestSum = currSum;

                        biggestSquare[0, 0] = matrix[row, col];
                        biggestSquare[0, 1] = matrix[row, col + 1];
                        biggestSquare[1, 0] = matrix[row + 1, col];
                        biggestSquare[1, 1] = matrix[row + 1, col + 1];
                    }
                }
            }

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write($"{biggestSquare[row, col]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(biggestSum);
        }
    }
}
