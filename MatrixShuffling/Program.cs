using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[sizeMatrix[0], sizeMatrix[1]];

            for (int row = 0; row < sizeMatrix[0]; row++)
            {
                string[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < sizeMatrix[1]; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (!command.Contains("swap") || command.Split().Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string[] splCommand = command.Split();
                int row1 = int.Parse(splCommand[1]);
                int col1 = int.Parse(splCommand[2]);
                int row2 = int.Parse(splCommand[3]);
                int col2 = int.Parse(splCommand[4]);

                if (row1 < 0 || row2 < 0 || col1 < 0 || col2 < 0 ||
                    row1 >= matrix.GetLength(0) || row2 >= matrix.GetLength(0) ||
                    col1 >= matrix.GetLength(1) || col2 >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string elementToMove = matrix[row2, col2];
                matrix[row2, col2] = matrix[row1, col1];
                matrix[row1, col1] = elementToMove;

                PrintMatrix(matrix);
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
