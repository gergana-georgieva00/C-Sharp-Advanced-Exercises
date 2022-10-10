using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int e = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            // fill matrix
            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            // logic
            while (e > 0)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);

                // move enemy
                matrix[row, col] = 'B';

                // move mario
                if (IsCommandValid(matrix, n, command[0], row, col))
                {
                    int rowMario = GetCurrentPositionOfMario(matrix, n)[0];
                    int colMario = GetCurrentPositionOfMario(matrix, n)[1];

                    matrix[rowMario, colMario] = '-';

                    if (!IsEnemy(command[0], matrix, n))
                    {
                        if (!IsPrincess(command[0], matrix, n, rowMario , colMario))
                        {
                            MoveMario(command[0], matrix, n, rowMario, colMario);
                            e--;

                            if (e <= 0)
                            {
                                Console.WriteLine($"Mario died at {FindWhereMarioDies(matrix, n, command[0])[0]};{FindWhereMarioDies(matrix, n, command[0])[1]}.");
                                PrintMatrix(matrix, n);
                                return;
                            }
                        }
                        else
                        {
                            e--;

                            switch (command[0])
                            {
                                // up
                                case "W":
                                    matrix[rowMario - 1, colMario] = '-';
                                    break;
                                // down
                                case "S":
                                    matrix[rowMario + 1, colMario] = '-';
                                    break;
                                // left
                                case "A":
                                    matrix[rowMario, colMario - 1] = '-';
                                    break;
                                //right
                                case "D":
                                    matrix[rowMario, colMario + 1] = '-';
                                    break;
                            }

                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {e}");
                            PrintMatrix(matrix, n);
                            return;
                        }
                    }
                    else
                    {
                        e--;
                        e -= 2;

                        if (e <= 0)
                        {
                            Console.WriteLine($"Mario died at {FindWhereMarioDies(matrix, n, command[0])[0]};{FindWhereMarioDies(matrix, n, command[0])[1]}.");
                            PrintMatrix(matrix, n);
                            return;
                        }
                    }
                }
                else
                {
                    e--;
                }
            }
        }

        static void PrintMatrix(char[,] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static int[] FindWhereMarioDies(char[,] matrix, int n, string command)
        {
            int rowMario = GetCurrentPositionOfMario(matrix, n)[0];
            int colMario = GetCurrentPositionOfMario(matrix, n)[1];

            switch (command)
            {
                // up
                case "W":
                    matrix[rowMario - 1, colMario] = 'X';
                    return new int[] { rowMario - 1, colMario };
                    break;
                // down
                case "S":
                    matrix[rowMario + 1, colMario] = 'X';
                    return new int[] { rowMario + 1, colMario };
                    break;
                // left
                case "A":
                    matrix[rowMario, colMario - 1] = 'X';
                    return new int[] { rowMario, colMario - 1 };
                    break;
                //right
                case "D":
                    matrix[rowMario, colMario + 1] = 'X';
                    return new int[] { rowMario, colMario + 1 };
                    break;
            }

            return new int[] { 0, 0 };
        }

        static bool IsPrincess(string command, char[,] matrix, int n, int row, int col)
        {
            switch (command)
            {
                // up
                case "W":
                    if (IsCommandValid(matrix, n, command, row, col) && matrix[row - 1, col] == 'P')
                    {
                        return true;
                    }

                    break;
                // down
                case "S":
                    if (IsCommandValid(matrix, n, command, row, col) && matrix[row + 1, col] == 'P')
                    {
                        return true;
                    }

                    break;
                // left
                case "A":
                    if (IsCommandValid(matrix, n, command, row, col) && matrix[row, col - 1] == 'P')
                    {
                        return true;
                    }

                    break;
                //right
                case "D":
                    if (IsCommandValid(matrix, n, command, row, col) && matrix[row, col + 1] == 'P')
                    {
                        return true;
                    }

                    break;
            }

            return false;
        }

        static bool IsEnemy(string command, char[,] matrix, int n)
        {
            int rowMario = GetCurrentPositionOfMario(matrix, n)[0];
            int colMario = GetCurrentPositionOfMario(matrix, n)[1];

            switch (command)
            {
                // up
                case "W":
                    if (IsCommandValid(matrix, n, command, rowMario, colMario) && matrix[rowMario - 1, colMario] == 'B')
                    {
                        return true;
                    }
                    
                    break;
                // down
                case "S":
                    if (IsCommandValid(matrix, n, command, rowMario, colMario) && matrix[rowMario + 1, colMario] == 'B')
                    {
                        return true;
                    }
                    
                    break;
                // left
                case "A":
                    if (IsCommandValid(matrix, n, command, rowMario, colMario) && matrix[rowMario, colMario - 1] == 'B')
                    {
                        return true;
                    }
                    
                    break;
                //right
                case "D":
                    if (IsCommandValid(matrix, n, command, rowMario, colMario) && matrix[rowMario, colMario + 1] == 'B')
                    {
                        return true;
                    }
                    
                    break;
            }

            return false;
        }

        static void MoveMario(string command, char[,] matrix, int n, int row, int col)
        {
            switch (command)
            {
                // up
                case "W":
                    matrix[row - 1, col] = 'M';
                    break;
                // down
                case "S":
                    matrix[row + 1, col] = 'M';
                    break;
                // left
                case "A":
                    matrix[row, col - 1] = 'M';
                    break;
                //right
                case "D":
                    matrix[row, col + 1] = 'M';
                    break;
            }
        }

        static int[] GetCurrentPositionOfMario(char[,] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            return new int[] { 0, 0 };
        }

        static bool IsCommandValid(char[,] matrix, int n, string command, int rowMario, int colMario)
        {
            switch (command)
            {
                // up
                case "W":
                    if (rowMario - 1 >= 0)
                    {
                        return true;
                    }
                    break;
                // down
                case "S":
                    if (rowMario + 1 < n)
                    {
                        return true;
                    }
                    break;
                // left
                case "A":
                    if (colMario - 1 >= 0)
                    {
                        return true;
                    }
                    break;
               //right
                case "D":
                    if (colMario + 1 < n)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
