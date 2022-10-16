using System;

namespace TheBattleofTheFiveArmies
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

            // process commands
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string direction = command[0];
                int rowEnemy = int.Parse(command[1]);
                int colEnemy = int.Parse(command[2]);

                int playerRow = GetPlayerCoordinates(matrix, n)[0];
                int playerCol = GetPlayerCoordinates(matrix, n)[1];

                // enemy spawns
                matrix[rowEnemy][colEnemy] = 'O';

                // army moves
                if (IsCommandValid(matrix, n, direction, playerRow, playerCol))
                {
                    // fight enemy
                    if (FightEnemy(matrix, playerRow, playerCol, direction))
                    {
                        e--;

                        e -= 2;
                        if (e <= 0)
                        {
                            matrix[playerRow][playerCol] = '-';
                            matrix[rowEnemy][colEnemy] = 'X';
                            Console.WriteLine($"The army was defeated at {rowEnemy};{colEnemy}.");
                            PrintMatrix(matrix, n);
                            return;
                        }
                        else
                        {
                            matrix[playerRow][playerCol] = '-';
                            switch (direction)
                            {
                                case "up":
                                    matrix[rowEnemy - 1][colEnemy] = 'A';
                                    break;
                                case "down":
                                    matrix[rowEnemy + 1][colEnemy] = 'A';
                                    break;
                                case "left":
                                    matrix[rowEnemy][colEnemy - 1] = 'A';
                                    break;
                                case "right":
                                    matrix[rowEnemy][colEnemy + 1] = 'A';
                                    break;
                            }
                        }
                    }
                    
                    else
                    {
                        matrix[playerRow][playerCol] = '-';
                        e--;

                        switch (direction)
                        {
                            case "up":
                                // regular position
                                if (matrix[playerRow - 1][playerCol] == '-')
                                {
                                    matrix[playerRow - 1][playerCol] = 'A';
                                }
                                // reach mordor
                                else
                                {
                                    matrix[playerRow - 1][playerCol] = '-';
                                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                break;
                            case "down":
                                if (matrix[playerRow + 1][playerCol] == '-')
                                {
                                    matrix[playerRow + 1][playerCol] = 'A';
                                }
                                else
                                {
                                    matrix[playerRow + 1][playerCol] = '-';
                                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                                    PrintMatrix(matrix, n);
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                break;
                            case "left":
                                if (matrix[playerRow][playerCol - 1] == '-')
                                {
                                    matrix[playerRow][playerCol - 1] = 'A';
                                }
                                else
                                {
                                    matrix[playerRow][playerCol - 1] = '-';
                                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                break;
                            case "right":
                                if (matrix[rowEnemy][colEnemy + 1] == '-')
                                {
                                    matrix[rowEnemy][colEnemy + 1] = 'A';
                                }
                                else
                                {
                                    matrix[rowEnemy][colEnemy + 1] = '-';
                                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                break;
                        }
                    }
                }
                else
                {
                    e--;
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

        static bool FightEnemy(char[][] matrix, int row, int col, string direction)
        {
            switch (direction)
            {
                case "up":
                    if (matrix[row - 1][col] == 'O')
                    {
                        return true;
                    }
                    break;
                case "down":
                    if (matrix[row + 1][col] == 'O')
                    {
                        return true;
                    }
                    break;
                case "left":
                    if (matrix[row][col - 1] == 'O')
                    {
                        return true;
                    }
                    break;
                case "right":
                    if (matrix[row][col + 1] == 'O')
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        static int[] GetPlayerCoordinates(char[][] matrix, int n)
        {
            int[] coordinates = new int[] { 0, 0 };

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        coordinates[0] = row;
                        coordinates[1] = col;

                        return coordinates;
                    }
                }
            }

            return coordinates;
        }

        static bool IsCommandValid(char[][] matrix, int n, string direction, int row, int col)
        {
            switch (direction)
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
                    if (col + 1 < matrix[row].Length)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
