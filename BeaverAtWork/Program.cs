using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
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
                            if (char.IsLetter(matrix[row - 1, col]) && char.IsLower(matrix[row - 1, col]))
                            {
                                woodBranches.Push(matrix[row - 1, col]);

                                matrix[row, col] = '-';
                                matrix[row - 1, col] = 'B';
                            }
                            else if (matrix[row - 1, col] == 'F')
                            {
                                matrix[row, col] = '-';
                                row--;

                                // if fish is on the last index
                                if ((row == 0 && command == "up") || (row == n - 1 && command == "down") 
                                    || (col == 0 && command == "left") || (col == n - 1 && command == "right"))
                                {
                                    matrix[row, col] = '-';

                                    switch (command)
                                    {
                                        case "up":
                                            if (char.IsLetter(matrix[n - 1, col]) && char.IsLower(matrix[n - 1, col]))
                                            {
                                                woodBranches.Push(matrix[n - 1, col]);
                                            }

                                            matrix[n - 1, col] = 'B';
                                            break;
                                        case "down":
                                            if (char.IsLetter(matrix[0, col]) && char.IsLower(matrix[0, col]))
                                            {
                                                woodBranches.Push(matrix[0, col]);
                                            }

                                            matrix[0, col] = 'B';
                                            break;
                                        case "left":
                                            if (char.IsLetter(matrix[row, n - 1]) && char.IsLower(matrix[row, n - 1]))
                                            {
                                                woodBranches.Push(matrix[row, n - 1]);
                                            }

                                            matrix[row, n - 1] = 'B';
                                            break;
                                        case "right":
                                            if (char.IsLetter(matrix[row, 0]) && char.IsLower(matrix[row, 0]))
                                            {
                                                woodBranches.Push(matrix[row, 0]);
                                            }

                                            matrix[row, 0] = 'B';
                                            break;
                                    }
                                }
                                // if not on the last index
                                else
                                {
                                    switch (command)
                                    {
                                        case "up":
                                            if (char.IsLetter(matrix[0, col]) && char.IsLower(matrix[0, col]))
                                            {
                                                woodBranches.Push(matrix[0, col]);
                                            }

                                            matrix[0, col] = 'B';
                                            break;
                                        case "down":
                                            if (char.IsLetter(matrix[n - 1, col]) && char.IsLower(matrix[n - 1, col]))
                                            {
                                                woodBranches.Push(matrix[n - 1, col]);
                                            }

                                            matrix[n - 1, col] = 'B';
                                            break;
                                        case "left":
                                            if (char.IsLetter(matrix[row, 0]) && char.IsLower(matrix[row, 0]))
                                            {
                                                woodBranches.Push(matrix[row, 0]);
                                            }

                                            matrix[row, 0] = 'B';
                                            break;
                                        case "right":
                                            if (char.IsLetter(matrix[row, n - 1]) && char.IsLower(matrix[row, n - 1]))
                                            {
                                                woodBranches.Push(matrix[row, n - 1]);
                                            }

                                            matrix[row, n - 1] = 'B';
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                matrix[row, col] = '-';
                                row--;

                                if (char.IsLetter(matrix[row, col]) && char.IsLower(matrix[row, col]))
                                {
                                    woodBranches.Push(matrix[row, col]);
                                }

                                matrix[row, col] = 'F';
                            }
                            break;
                        case "down":
                            if (char.IsLetter(matrix[row + 1, col]) && char.IsLower(matrix[row + 1, col]))
                            {
                                woodBranches.Push(matrix[row + 1, col]);

                                matrix[row, col] = '-';
                                matrix[row + 1, col] = 'B';
                            }
                            else if (matrix[row + 1, col] == 'F')
                            {
                                matrix[row, col] = '-';
                                row++;

                                // if fish is on the last index
                                if ((row == 0 && command == "up") || (row == n - 1 && command == "down")
                                    || (col == 0 && command == "left") || (col == n - 1 && command == "right"))
                                {
                                    matrix[row, col] = '-';

                                    switch (command)
                                    {
                                        case "up":
                                            if (char.IsLetter(matrix[n - 1, col]) && char.IsLower(matrix[n - 1, col]))
                                            {
                                                woodBranches.Push(matrix[n - 1, col]);
                                            }

                                            matrix[n - 1, col] = 'B';
                                            break;
                                        case "down":
                                            if (char.IsLetter(matrix[0, col]) && char.IsLower(matrix[0, col]))
                                            {
                                                woodBranches.Push(matrix[0, col]);
                                            }

                                            matrix[0, col] = 'B';
                                            break;
                                        case "left":
                                            if (char.IsLetter(matrix[row, n - 1]) && char.IsLower(matrix[row, n - 1]))
                                            {
                                                woodBranches.Push(matrix[row, n - 1]);
                                            }

                                            matrix[row, n - 1] = 'B';
                                            break;
                                        case "right":
                                            if (char.IsLetter(matrix[row, 0]) && char.IsLower(matrix[row, 0]))
                                            {
                                                woodBranches.Push(matrix[row, 0]);
                                            }

                                            matrix[row, 0] = 'B';
                                            break;
                                    }
                                }
                                // if not on the last index
                                else
                                {
                                    switch (command)
                                    {
                                        case "up":
                                            if (char.IsLetter(matrix[0, col]) && char.IsLower(matrix[0, col]))
                                            {
                                                woodBranches.Push(matrix[0, col]);
                                            }

                                            matrix[0, col] = 'B';
                                            break;
                                        case "down":
                                            if (char.IsLetter(matrix[n - 1, col]) && char.IsLower(matrix[n - 1, col]))
                                            {
                                                woodBranches.Push(matrix[n - 1, col]);
                                            }

                                            matrix[n - 1, col] = 'B';
                                            break;
                                        case "left":
                                            if (char.IsLetter(matrix[row, 0]) && char.IsLower(matrix[row, 0]))
                                            {
                                                woodBranches.Push(matrix[row, 0]);
                                            }

                                            matrix[row, 0] = 'B';
                                            break;
                                        case "right":
                                            if (char.IsLetter(matrix[row, n - 1]) && char.IsLower(matrix[row, n - 1]))
                                            {
                                                woodBranches.Push(matrix[row, n - 1]);
                                            }

                                            matrix[row, n - 1] = 'B';
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                matrix[row, col] = '-';
                                row++;

                                if (char.IsLetter(matrix[row, col]) && char.IsLower(matrix[row, col]))
                                {
                                    woodBranches.Push(matrix[row, col]);
                                }

                                matrix[row, col] = 'F';
                            }
                            break;
                        case "left":
                            if (char.IsLetter(matrix[row, col - 1]) && char.IsLower(matrix[row, col - 1]))
                            {
                                woodBranches.Push(matrix[row, col - 1]);

                                matrix[row, col] = '-';
                                matrix[row, col - 1] = 'B';
                            }
                            else if (matrix[row, col - 1] == 'F')
                            {
                                matrix[row, col] = '-';
                                row--;

                                // if fish is on the last index
                                if ((row == 0 && command == "up") || (row == n - 1 && command == "down")
                                    || (col == 0 && command == "left") || (col == n - 1 && command == "right"))
                                {
                                    matrix[row, col] = '-';

                                    switch (command)
                                    {
                                        case "up":
                                            if (char.IsLetter(matrix[n - 1, col]) && char.IsLower(matrix[n - 1, col]))
                                            {
                                                woodBranches.Push(matrix[n - 1, col]);
                                            }

                                            matrix[n - 1, col] = 'B';
                                            break;
                                        case "down":
                                            if (char.IsLetter(matrix[0, col]) && char.IsLower(matrix[0, col]))
                                            {
                                                woodBranches.Push(matrix[0, col]);
                                            }

                                            matrix[0, col] = 'B';
                                            break;
                                        case "left":
                                            if (char.IsLetter(matrix[row, n - 1]) && char.IsLower(matrix[row, n - 1]))
                                            {
                                                woodBranches.Push(matrix[row, n - 1]);
                                            }

                                            matrix[row, n - 1] = 'B';
                                            break;
                                        case "right":
                                            if (char.IsLetter(matrix[row, 0]) && char.IsLower(matrix[row, 0]))
                                            {
                                                woodBranches.Push(matrix[row, 0]);
                                            }

                                            matrix[row, 0] = 'B';
                                            break;
                                    }
                                }
                                // if not on the last index
                                else
                                {
                                    switch (command)
                                    {
                                        case "up":
                                            if (char.IsLetter(matrix[0, col]) && char.IsLower(matrix[0, col]))
                                            {
                                                woodBranches.Push(matrix[0, col]);
                                            }

                                            matrix[0, col] = 'B';
                                            break;
                                        case "down":
                                            if (char.IsLetter(matrix[n - 1, col]) && char.IsLower(matrix[n - 1, col]))
                                            {
                                                woodBranches.Push(matrix[n - 1, col]);
                                            }

                                            matrix[n - 1, col] = 'B';
                                            break;
                                        case "left":
                                            if (char.IsLetter(matrix[row, 0]) && char.IsLower(matrix[row, 0]))
                                            {
                                                woodBranches.Push(matrix[row, 0]);
                                            }

                                            matrix[row, 0] = 'B';
                                            break;
                                        case "right":
                                            if (char.IsLetter(matrix[row, n - 1]) && char.IsLower(matrix[row, n - 1]))
                                            {
                                                woodBranches.Push(matrix[row, n - 1]);
                                            }

                                            matrix[row, n - 1] = 'B';
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                matrix[row, col] = '-';
                                col--;

                                if (char.IsLetter(matrix[row, col]) && char.IsLower(matrix[row, col]))
                                {
                                    woodBranches.Push(matrix[row, col]);
                                }

                                matrix[row, col] = 'F';
                            }
                            break;
                        case "right":
                            if (char.IsLetter(matrix[row, col + 1]) && char.IsLower(matrix[row, col + 1]))
                            {
                                woodBranches.Push(matrix[row, col + 1]);

                                matrix[row, col] = '-';
                                matrix[row, col + 1] = 'B';
                            }
                            else if (matrix[row, col + 1] == 'F')
                            {
                                matrix[row, col] = '-';
                                row++;

                                // if fish is on the last index
                                if ((row == 0 && command == "up") || (row == n - 1 && command == "down")
                                    || (col == 0 && command == "left") || (col == n - 1 && command == "right"))
                                {
                                    matrix[row, col] = '-';

                                    switch (command)
                                    {
                                        case "up":
                                            if (char.IsLetter(matrix[n - 1, col]) && char.IsLower(matrix[n - 1, col]))
                                            {
                                                woodBranches.Push(matrix[n - 1, col]);
                                            }

                                            matrix[n - 1, col] = 'B';
                                            break;
                                        case "down":
                                            if (char.IsLetter(matrix[0, col]) && char.IsLower(matrix[0, col]))
                                            {
                                                woodBranches.Push(matrix[0, col]);
                                            }

                                            matrix[0, col] = 'B';
                                            break;
                                        case "left":
                                            if (char.IsLetter(matrix[row, n - 1]) && char.IsLower(matrix[row, n - 1]))
                                            {
                                                woodBranches.Push(matrix[row, n - 1]);
                                            }

                                            matrix[row, n - 1] = 'B';
                                            break;
                                        case "right":
                                            if (char.IsLetter(matrix[row, 0]) && char.IsLower(matrix[row, 0]))
                                            {
                                                woodBranches.Push(matrix[row, 0]);
                                            }

                                            matrix[row, 0] = 'B';
                                            break;
                                    }
                                }
                                // if not on the last index
                                else
                                {
                                    switch (command)
                                    {
                                        case "up":
                                            if (char.IsLetter(matrix[0, col]) && char.IsLower(matrix[0, col]))
                                            {
                                                woodBranches.Push(matrix[0, col]);
                                            }

                                            matrix[0, col] = 'B';
                                            break;
                                        case "down":
                                            if (char.IsLetter(matrix[n - 1, col]) && char.IsLower(matrix[n - 1, col]))
                                            {
                                                woodBranches.Push(matrix[n - 1, col]);
                                            }

                                            matrix[n - 1, col] = 'B';
                                            break;
                                        case "left":
                                            if (char.IsLetter(matrix[row, 0]) && char.IsLower(matrix[row, 0]))
                                            {
                                                woodBranches.Push(matrix[row, 0]);
                                            }

                                            matrix[row, 0] = 'B';
                                            break;
                                        case "right":
                                            if (char.IsLetter(matrix[row, n - 1]) && char.IsLower(matrix[row, n - 1]))
                                            {
                                                woodBranches.Push(matrix[row, n - 1]);
                                            }

                                            matrix[row, n - 1] = 'B';
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                matrix[row, col] = '-';
                                col++;

                                if (char.IsLetter(matrix[row, col]) && char.IsLower(matrix[row, col]))
                                {
                                    woodBranches.Push(matrix[row, col]);
                                }

                                matrix[row, col] = 'F';
                            }
                            break;
                    }

                    if (!AnyWood(n, matrix))
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

                    if (!AnyWood(n, matrix))
                    {
                        break;
                    }
                }
            }

            if (!AnyWood(n, matrix))
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
                    if (char.IsLetter(matrix[row, col]) && char.IsLower(matrix[row, col]))
                    {
                        return true;
                    }
                    
                }
            }

            return false;
        }
    }
}
