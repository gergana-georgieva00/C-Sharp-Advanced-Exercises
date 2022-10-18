using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            Stack<char> woodBranches = new Stack<char>();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (IsCommandValid(n, command, CurrCoordinates(n, matrix)[0], CurrCoordinates(n, matrix)[1]))
                {
                    int row = CurrCoordinates(n, matrix)[0];
                    int col = CurrCoordinates(n, matrix)[1];

                    switch (command)
                    {
                        case "up":
                            if (matrix[row - 1, col] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row - 1, col] = 'B';
                            }
                            else if (Char.IsLower(matrix[row - 1, col]))
                            {
                                matrix[row, col] = '-';
                                woodBranches.Push(matrix[row - 1, col]);
                                matrix[row - 1, col] = 'B';
                            }
                            else
                            {
                                matrix[row, col] = '-';

                                if (row - 1 == 0)
                                {
                                    matrix[row - 1, col] = '-';

                                    if (Char.IsLower(matrix[n - 1, col]))
                                    {
                                        woodBranches.Push(matrix[n - 1, col]);
                                    }

                                    matrix[n - 1, col] = 'B';
                                }
                                else
                                {
                                    matrix[row - 1, col] = '-';

                                    if (Char.IsLower(matrix[0, col]))
                                    {
                                        woodBranches.Push(matrix[0, col]);
                                    }

                                    matrix[0, col] = 'B';
                                }
                            }
                            break;
                        case "down":
                            if (matrix[row + 1, col] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row + 1, col] = 'B';
                            }
                            else if (Char.IsLower(matrix[row + 1, col]))
                            {
                                matrix[row, col] = '-';
                                woodBranches.Push(matrix[row + 1, col]);
                                matrix[row + 1, col] = 'B';
                            }
                            else
                            {
                                matrix[row, col] = '-';

                                if (row + 1 == n - 1)
                                {
                                    matrix[row + 1, col] = '-';

                                    if (Char.IsLower(matrix[0, col]))
                                    {
                                        woodBranches.Push(matrix[0, col]);
                                    }

                                    matrix[0, col] = 'B';
                                }
                                else
                                {
                                    matrix[row + 1, col] = '-';

                                    if (Char.IsLower(matrix[n - 1, col]))
                                    {
                                        woodBranches.Push(matrix[n - 1, col]);
                                    }

                                    matrix[n - 1, col] = 'B';
                                }
                            }
                            break;
                        case "left":
                            if (matrix[row, col - 1] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row, col - 1] = 'B';
                            }
                            else if (Char.IsLower(matrix[row, col - 1]))
                            {
                                matrix[row, col] = '-';
                                woodBranches.Push(matrix[row, col - 1]);
                                matrix[row, col - 1] = 'B';
                            }
                            else
                            {
                                matrix[row, col] = '-';

                                if (col - 1 == 0)
                                {
                                    matrix[row, col - 1] = '-';

                                    if (Char.IsLower(matrix[row, n - 1]))
                                    {
                                        woodBranches.Push(matrix[row, n - 1]);
                                    }

                                    matrix[row, n - 1] = 'B';
                                }
                                else
                                {
                                    matrix[row, col - 1] = '-';

                                    if (Char.IsLower(matrix[row, 0]))
                                    {
                                        woodBranches.Push(matrix[row, 0]);
                                    }

                                    matrix[row, 0] = 'B';
                                }
                            }
                            break;
                        case "right":
                            if (matrix[row, col + 1] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row, col + 1] = 'B';
                            }
                            else if (Char.IsLower(matrix[row, col + 1]))
                            {
                                matrix[row, col] = '-';
                                woodBranches.Push(matrix[row, col + 1]);
                                matrix[row, col + 1] = 'B';
                            }
                            else
                            {
                                matrix[row, col] = '-';

                                if (col + 1 == n - 1)
                                {
                                    matrix[row, col + 1] = '-';

                                    if (Char.IsLower(matrix[row, 0]))
                                    {
                                        woodBranches.Push(matrix[row, 0]);
                                    }

                                    matrix[row, 0] = 'B';
                                }
                                else
                                {
                                    matrix[row, col + 1] = '-';

                                    if (Char.IsLower(matrix[row, n - 1]))
                                    {
                                        woodBranches.Push(matrix[row, n - 1]);
                                    }

                                    matrix[row, n - 1] = 'B';
                                }
                            }
                            break;
                    }

                    if (BranchesLeft(n, matrix) <= 0)
                    {
                        break;
                    }
                }
                else
                {
                    if (woodBranches.Count > 0)
                    {
                        woodBranches.Pop();
                    }

                    if (BranchesLeft(n, matrix) <= 0)
                    {
                        break;
                    }
                }


                if (BranchesLeft(n, matrix) <= 0)
                {
                    break;
                }

            }

            if (BranchesLeft(n, matrix) <= 0)
            {
                Console.WriteLine($"The Beaver successfully collect {woodBranches.Count} wood branches: {string.Join(", ", woodBranches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {BranchesLeft(n, matrix)} branches left.");
            }

            PrintMatrix(n, matrix);
        }

        static void PrintMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        static int BranchesLeft(int n, char[,] matrix)
        {
            int count = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (char.IsLetter(matrix[row, col]) && char.IsLower(matrix[row, col]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        static int[] CurrCoordinates(int n, char[,] matrix)
        {
            int[] coord = new int[] { 0, 0 };

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        coord[0] = row;
                        coord[1] = col;

                        return coord;
                    }
                }
            }

            return coord;
        }

        static bool IsCommandValid(int n, string command, int row, int col)
        {
            switch (command)
            {
                case "up":
                    if (row - 1 >= 0)
                    {
                        return true;
                    }
                    break;
                case "down":
                    if (row + 1 < n)
                    {
                        return true;
                    }
                    break;
                case "left":
                    if (col - 1 >= 0)
                    {
                        return true;
                    }
                    break;
                case "right":
                    if (col + 1 < n)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        static bool AnyWood(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (char.IsLower(matrix[row, col]))
                    {
                        return true;
                    }

                }
            }

            return false;
        }
    }
}
