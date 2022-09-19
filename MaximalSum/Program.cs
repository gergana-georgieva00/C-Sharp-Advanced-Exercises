using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];

            for (int row = 0; row < sizeMatrix[0]; row++)
            {
                int[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < sizeMatrix[1]; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int maxSum = int.MinValue;
            int[,] maxMatrix = new int[3, 3];

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;

                        maxMatrix[0, 0] = matrix[row, col];
                        maxMatrix[0, 1] = matrix[row, col + 1];
                        maxMatrix[0, 2] = matrix[row, col + 2];
                        maxMatrix[1, 0] = matrix[row + 1, col];
                        maxMatrix[1, 1] = matrix[row + 1, col + 1];
                        maxMatrix[1, 2] = matrix[row + 1, col + 2];
                        maxMatrix[2, 0] = matrix[row + 2, col];
                        maxMatrix[2, 1] = matrix[row + 2, col + 1];
                        maxMatrix[2, 2] = matrix[row + 2, col + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(maxMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
