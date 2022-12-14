using System;

namespace SuperMario2_0
{
    class Program
    {
        static void Main(string[] args)
        {
            int e = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            // fill matrix
            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();
                matrix[row] = new char[currRow.Length];

                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row][col] = currRow[col];
                }
            }

            // logic
            while (true)
            {
                // move enemy
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int rowEnemy = int.Parse(command[1]);
                int colEnemy = int.Parse(command[2]);

                if (rowEnemy >= 0 && colEnemy >= 0 && rowEnemy < n && colEnemy < matrix[rowEnemy].Length)
                {
                    // move enemy
                    matrix[rowEnemy][colEnemy] = 'B';
                }
                else
                {
                    continue;
                }

                // move mario
                e--;
                
                // is command for mario valid
                int rowMario = FindMarioCoordinates(matrix, n)[0];
                int colMario = FindMarioCoordinates(matrix, n)[1];

                switch (command[0])
                {
                    case "W":
                        if (rowMario - 1 >= 0)
                        {
                            // check for conflict with enemy
                            if (matrix[rowMario - 1][colMario] == 'B')
                            {
                                e -= 2;

                                if (e <= 0)
                                {
                                    matrix[rowMario][colMario] = '-';
                                    matrix[rowMario - 1][colMario] = 'X';
                                    Console.WriteLine($"Mario died at {rowMario - 1};{colMario}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                else
                                {
                                    matrix[rowMario][colMario] = '-';
                                    matrix[rowMario - 1][colMario] = 'M';
                                }
                            }
                            // check for princess
                            else if(matrix[rowMario - 1][colMario] == 'P')
                            {
                                matrix[rowMario][colMario] = '-';
                                matrix[rowMario - 1][colMario] = '-';
                                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {e}");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            // regular position
                            else
                            {
                                matrix[rowMario][colMario] = '-';
                                matrix[rowMario - 1][colMario] = 'M';
                                if (e <= 0)
                                {
                                    matrix[rowMario - 1][colMario] = 'X';
                                    Console.WriteLine($"Mario died at {rowMario - 1};{colMario}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                            }
                        }
                        break;
                    case "S":
                        if (rowMario + 1 < n)
                        {
                            // check for conflict with enemy
                            if (matrix[rowMario + 1][colMario] == 'B')
                            {
                                e -= 2;

                                if (e <= 0)
                                {
                                    matrix[rowMario][colMario] = '-';
                                    matrix[rowMario + 1][colMario] = 'X';
                                    Console.WriteLine($"Mario died at {rowMario + 1};{colMario}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                else
                                {
                                    matrix[rowMario][colMario] = '-';
                                    matrix[rowMario + 1][colMario] = 'M';
                                }
                            }
                            // check for princess
                            else if (matrix[rowMario + 1][colMario] == 'P')
                            {
                                matrix[rowMario][colMario] = '-';
                                matrix[rowMario + 1][colMario] = '-';
                                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {e}");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            // regular position
                            else
                            {
                                matrix[rowMario][colMario] = '-';
                                matrix[rowMario + 1][colMario] = 'M';
                                if (e <= 0)
                                {
                                    matrix[rowMario + 1][colMario] = 'X';
                                    Console.WriteLine($"Mario died at {rowMario + 1};{colMario}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                            }
                        }
                        break;
                    case "A":
                        if (colMario - 1 >= 0)
                        {
                            // check for conflict with enemy
                            if (matrix[rowMario][colMario - 1] == 'B')
                            {
                                e -= 2;

                                if (e <= 0)
                                {
                                    matrix[rowMario][colMario] = '-';
                                    matrix[rowMario][colMario - 1] = 'X';
                                    Console.WriteLine($"Mario died at {rowMario};{colMario - 1}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                else
                                {
                                    matrix[rowMario][colMario] = '-';
                                    matrix[rowMario][colMario - 1] = 'M';
                                }
                            }
                            // check for princess
                            else if (matrix[rowMario][colMario - 1] == 'P')
                            {
                                matrix[rowMario][colMario] = '-';
                                matrix[rowMario][colMario - 1] = '-';
                                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {e}");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            // regular position
                            else
                            {
                                matrix[rowMario][colMario] = '-';
                                matrix[rowMario][colMario - 1] = 'M';
                                if (e <= 0)
                                {
                                    matrix[rowMario][colMario - 1] = 'X';
                                    Console.WriteLine($"Mario died at {rowMario};{colMario - 1}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                            }
                        }
                        break;
                    case "D":
                        if (colMario + 1 < matrix[rowMario].Length)
                        {
                            // check for conflict with enemy
                            if (matrix[rowMario][colMario + 1] == 'B')
                            {
                                e -= 2;

                                if (e <= 0)
                                {
                                    matrix[rowMario][colMario] = '-';
                                    matrix[rowMario][colMario + 1] = 'X';
                                    Console.WriteLine($"Mario died at {rowMario};{colMario + 1}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                else
                                {
                                    matrix[rowMario][colMario] = '-';
                                    matrix[rowMario][colMario + 1] = 'M';
                                }
                            }
                            // check for princess
                            else if (matrix[rowMario][colMario + 1] == 'P')
                            {
                                matrix[rowMario][colMario] = '-';
                                matrix[rowMario][colMario + 1] = '-';
                                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {e}");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            // regular position
                            else
                            {
                                matrix[rowMario][colMario] = '-';
                                matrix[rowMario][colMario + 1] = 'M';
                                if (e <= 0)
                                {
                                    matrix[rowMario][colMario + 1] = 'X';
                                    Console.WriteLine($"Mario died at {rowMario};{colMario + 1}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                            }
                        }
                        break;
                }
            }

        }

        static void PrintMatrix(char[][] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }

        static int[] FindMarioCoordinates(char[][] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            return new int[] { 0, 0 };
        }
    }
}
