using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = dimensions[0];
            int m = dimensions[1];

            char[,] matrix = new char[n, m];

            // fill the matrix
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = '0';
                }
            }

            // plant the flowers
            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                if (CheckIfCommandIsValid(row, col, matrix))
                {
                    matrix[row, col] = '1';
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
            }

            // bloom the flowers
            List<int> coordinatesFlowers = FindCoordinatesOfFlowers(matrix);

            for (int i = 0; i < coordinatesFlowers.Count; i+=2)
            {
                int row = coordinatesFlowers[i];
                int col = coordinatesFlowers[i + 1];

                // left
                while (col - 1 >= 0)
                {
                    if (matrix[row, col - 1] == '0')
                    {
                        matrix[row, col - 1] = '1';
                    }
                    else if(matrix[row, col - 1] == '1')
                    {
                        int currElement = int.Parse(matrix[row, col - 1].ToString()) + 1;
                        matrix[row, col - 1] = char.Parse(currElement.ToString());
                    }

                    col--;
                }

                row = coordinatesFlowers[i];
                col = coordinatesFlowers[i + 1];

                // right
                while (col + 1 < matrix.GetLength(1))
                {
                    if (matrix[row, col + 1] == '0')
                    {
                        matrix[row, col + 1] = '1';
                    }
                    else if(matrix[row, col + 1] == '1')
                    {
                        int currElement = int.Parse(matrix[row, col + 1].ToString()) + 1;
                        matrix[row, col + 1] = char.Parse(currElement.ToString());
                    }

                    col++;
                }

                row = coordinatesFlowers[i];

                col = coordinatesFlowers[i + 1];
                // up
                while (row - 1 >= 0)
                {
                    if (matrix[row - 1, col] == '0')
                    {
                        matrix[row - 1, col] = '1';
                    }
                    else if(matrix[row - 1, col] == '1')
                    {
                        int currElement = int.Parse(matrix[row - 1, col].ToString()) + 1;
                        matrix[row - 1, col] = char.Parse(currElement.ToString());
                    }

                    row--;
                }

                row = coordinatesFlowers[i];
                col = coordinatesFlowers[i + 1];

                // down
                while (row + 1 < matrix.GetLength(0))
                {
                    if (matrix[row + 1, col] == '0')
                    {
                        matrix[row + 1, col] = '1';
                    }
                    else if (matrix[row + 1, col] == '1')
                    {
                        int currElement = int.Parse(matrix[row + 1, col].ToString()) + 1;
                        matrix[row + 1, col] = char.Parse(currElement.ToString());
                    }
                    
                    row++;
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
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        static bool CheckIfCommandIsValid(int row, int col, char[,] matrix)
        {
            if (row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1)
                && matrix[row, col] == '0')
            {
                return true;
            }

            return false;
        }

        static List<int> FindCoordinatesOfFlowers(char[,] matrix)
        {
            List<int> coordinates = new List<int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '1')
                    {
                        coordinates.Add(row);
                        coordinates.Add(col);
                    }
                }
            }

            return coordinates;
        }
    }
}
