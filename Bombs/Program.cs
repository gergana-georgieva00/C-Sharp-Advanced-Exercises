using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            string[] coordinatesOfBombCells = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var coordinate in coordinatesOfBombCells)
            {
                int row = int.Parse(coordinate.Split(',', StringSplitOptions.RemoveEmptyEntries)[0]);
                int col = int.Parse(coordinate.Split(',', StringSplitOptions.RemoveEmptyEntries)[1]);

                int numBomb = matrix[row, col];

                if (numBomb <= 0)
                {
                    continue;
                }

                matrix[row, col] = 0;

                // left
                if (col - 1 >= 0 && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= numBomb;
                }
                // right
                if (col + 1 < n && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= numBomb;
                }
                // top
                if (row - 1 >= 0 && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= numBomb;
                }
                // bottom
                if (row + 1 < n && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= numBomb;
                }
                // first diagonal
                if (row - 1 >= 0 && col - 1 >= 0 && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= numBomb;
                }
                // second diagonal
                if (row - 1 >= 0 && col + 1 < n && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= numBomb;
                }
                // third diagonal
                if (row + 1 < n && col - 1 >= 0 && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= numBomb;
                }
                // fourth diagonal
                if (row + 1 < n && col + 1 < n && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= numBomb;
                }
            }

            // find count alive cells and their sum
            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
