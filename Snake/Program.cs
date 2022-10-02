using System;
using System.Linq;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int food = 0;

            while (food < 10)
            {
                string command = Console.ReadLine();

                int[] coordinates = GetCurrentRowAndCol(matrix);
                int currRow = coordinates[0];
                int currCol = coordinates[1];


                if (command == "left")
                {
                    if (IsCommandValid(command, matrix))
                    {
                        char currElement = matrix[currRow, currCol - 1];

                        switch (currElement)
                        {
                            case '*':
                                food++;
                                matrix[currRow, currCol] = '.';
                                matrix[currRow, currCol - 1] = 'S';
                                break;
                            case 'B':
                                matrix[currRow, currCol] = '.';
                                matrix[currRow + 1, currCol] = '.';
                                int[] coordExitBurrow = FindExitBurrow(matrix);
                                matrix[coordExitBurrow[0], coordExitBurrow[1]] = 'S';
                                break;
                            default:
                                matrix[currRow, currCol] = '.';
                                matrix[currRow, currCol - 1] = 'S';
                                break;
                        }
                    }
                    else
                    {
                        matrix[currRow, currCol] = '.';
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {food}");
                        PrintMatrix(matrix);
                        return;
                    }
                }
                else if (command == "right")
             {
                    if (IsCommandValid(command, matrix))
                    {
                        char currElement = matrix[currRow, currCol + 1];

                        switch (currElement)
                        {
                            case '*':
                                food++;
                                matrix[currRow, currCol] = '.';
                                matrix[currRow, currCol + 1] = 'S';
                                break;
                            case 'B':
                                matrix[currRow, currCol] = '.';
                                matrix[currRow + 1, currCol] = '.';
                                int[] coordExitBurrow = FindExitBurrow(matrix);
                                matrix[coordExitBurrow[0], coordExitBurrow[1]] = 'S';
                                break;
                            default:
                                matrix[currRow, currCol] = '.';
                                matrix[currRow, currCol + 1] = 'S';
                                break;
                        }
                    }
                    else
                    {
                        matrix[currRow, currCol] = '.';
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {food}");
                        PrintMatrix(matrix);
                        return;
                    }
                }
                else if (command == "up")
                {
                    if (IsCommandValid(command, matrix))
                    {
                        char currElement = matrix[currRow - 1, currCol];

                        switch (currElement)
                        {
                            case '*':
                                food++;
                                matrix[currRow, currCol] = '.';
                                matrix[currRow - 1, currCol] = 'S';
                                break;
                            case 'B':
                                matrix[currRow, currCol] = '.';
                                matrix[currRow + 1, currCol] = '.';
                                int[] coordExitBurrow = FindExitBurrow(matrix);
                                matrix[coordExitBurrow[0], coordExitBurrow[1]] = 'S';
                                break;
                            default:
                                matrix[currRow, currCol] = '.';
                                matrix[currRow - 1, currCol] = 'S';
                                break;
                        }
                    }
                    else
                    {
                        matrix[currRow, currCol] = '.';
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {food}");
                        PrintMatrix(matrix);
                        return;
                    }
                }
                else
                {
                    if (IsCommandValid(command, matrix))
                    {
                        char currElement = matrix[currRow + 1, currCol];

                        switch (currElement)
                        {
                            case '*':
                                food++;
                                matrix[currRow, currCol] = '.';
                                matrix[currRow + 1, currCol] = 'S';
                                break;
                            case 'B':
                                matrix[currRow, currCol] = '.';
                                matrix[currRow + 1, currCol] = '.';
                                int[] coordExitBurrow = FindExitBurrow(matrix);
                                matrix[coordExitBurrow[0], coordExitBurrow[1]] = 'S';
                                break;
                            default:
                                matrix[currRow, currCol] = '.';
                                matrix[currRow + 1, currCol] = 'S';
                                break;
                        }
                    }
                    else
                    {
                        matrix[currRow, currCol] = '.';
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {food}");
                        PrintMatrix(matrix);
                        return;
                    }
                }
            }

            Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {food}");
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

        static int[] FindExitBurrow(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        return new int[]
                        {
                            row, col
                        };
                    }
                }
            }

            return new int[] { 0, 0 };
        }

        static int[] GetCurrentRowAndCol(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        return new int[]
                        {
                            row, col
                        };
                    }
                }
            }

            return new int[] { 0, 0 };
        }

        static bool IsCommandValid(string command, char[,] matrix)
        {
            int[] coordinates = GetCurrentRowAndCol(matrix);
            int currRow = coordinates[0];
            int currCol = coordinates[1];

            if (command == "left")
            {
                if (currCol - 1 >= 0)
                {
                    return true;
                }
            }
            else if (command == "right")
            {
                if (currCol + 1 < matrix.GetLength(1))
                {
                    return true;
                }
            }
            else if (command == "up")
            {
                if (currRow - 1 >= 0)
                {
                    return true;
                }
            }
            else
            {
                if (currRow + 1 < matrix.GetLength(0))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
