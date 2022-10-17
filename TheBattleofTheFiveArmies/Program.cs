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

                // enemy spawns
                matrix[rowEnemy][colEnemy] = 'O';
                
                // get player cooridnates
                int playerRow = GetPlayerCoordinates(matrix, n)[0];
                int playerCol = GetPlayerCoordinates(matrix, n)[1];

                // army moves
                e--;

                switch (direction)
                {
                    case "up":
                        // is command valid
                        if (playerRow - 1 >= 0)
                        {
                            // is regular position
                            if (matrix[playerRow - 1][playerCol] == '-')
                            {
                                if (e <= 0)
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow - 1][playerCol] = 'X';
                                    Console.WriteLine($"The army was defeated at {playerRow - 1};{playerCol}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow - 1][playerCol] = 'A';
                            }
                            // is mordor
                            else if (matrix[playerRow - 1][playerCol] == 'M')
                            {
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow - 1][playerCol] = '-';
                                Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            // is enemy
                            else
                            {
                                e -= 2;
                                if (e <= 0)
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow - 1][playerCol] = 'X';
                                    Console.WriteLine($"The army was defeated at {playerRow - 1};{playerCol}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                else
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow - 1][playerCol] = 'A';
                                }
                            }
                        }
                        break;
                    case "down":
                        // is command valid
                        if (playerRow + 1 < n)
                        {
                            // is regular position
                            if (matrix[playerRow + 1][playerCol] == '-')
                            {
                                if (e <= 0)
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow + 1][playerCol] = 'X';
                                    Console.WriteLine($"The army was defeated at {playerRow + 1};{playerCol}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow + 1][playerCol] = 'A';
                            }
                            // is mordor
                            else if (matrix[playerRow + 1][playerCol] == 'M')
                            {
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow + 1][playerCol] = '-';
                                Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            // is enemy
                            else
                            {
                                e -= 2;
                                if (e <= 0)
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow + 1][playerCol] = 'X';
                                    Console.WriteLine($"The army was defeated at {playerRow + 1};{playerCol}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                else
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow + 1][playerCol] = 'A';
                                }
                            }
                        }
                        break;
                    case "left":
                        // is command valid
                        if (playerCol - 1 >= 0)
                        {
                            // is regular position
                            if (matrix[playerRow][playerCol - 1] == '-')
                            {
                                if (e <= 0)
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow][playerCol - 1] = 'X';
                                    Console.WriteLine($"The army was defeated at {playerRow};{playerCol - 1}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow][playerCol - 1] = 'A';
                            }
                            // is mordor
                            else if (matrix[playerRow][playerCol - 1] == 'M')
                            {
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow][playerCol - 1] = '-';
                                Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            // is enemy
                            else
                            {
                                e -= 2;
                                if (e <= 0)
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow][playerCol - 1] = 'X';
                                    Console.WriteLine($"The army was defeated at {playerRow};{playerCol - 1}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                else
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow][playerCol - 1] = 'A';
                                }
                            }
                        }
                        break;
                    case "right":
                        // is command valid
                        if (playerCol + 1 < matrix[playerRow].Length)
                        {
                            // is regular position
                            if (matrix[playerRow][playerCol + 1] == '-')
                            {
                                if (e <= 0)
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow][playerCol + 1] = 'X';
                                    Console.WriteLine($"The army was defeated at {playerRow};{playerCol + 1}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow][playerCol + 1] = 'A';
                            }
                            // is mordor
                            else if (matrix[playerRow][playerCol + 1] == 'M')
                            {
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow][playerCol + 1] = '-';
                                Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            // is enemy
                            else
                            {
                                e -= 2;
                                if (e <= 0)
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow][playerCol + 1] = 'X';
                                    Console.WriteLine($"The army was defeated at {playerRow};{playerCol + 1}.");
                                    PrintMatrix(matrix, n);
                                    return;
                                }
                                else
                                {
                                    matrix[playerRow][playerCol] = '-';
                                    matrix[playerRow][playerCol + 1] = 'A';
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
