using System;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string snake = Console.ReadLine();

            char[,] matrix = new char[sizeMatrix[0], sizeMatrix[1]];

            int indexSnake = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (indexSnake >= snake.Length)
                        {
                            indexSnake = 0;
                        }

                        matrix[row, col] = snake[indexSnake];
                        indexSnake++;
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (indexSnake >= snake.Length)
                        {
                            indexSnake = 0;
                        }

                        matrix[row, col] = snake[indexSnake];
                        indexSnake++;
                    }
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
