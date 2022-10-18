using System;

namespace Armory
{
    class Program
    {
        static void Main(string[] args)
        {
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

            // process commands
            int price = 0;

            while (true)
            {
                string command = Console.ReadLine();

                int row = 0;
                int col = 0;

                // find army coordinates
                bool find = false;
                for (int rows = 0; rows < n; rows++)
                {
                    for (int cols = 0; cols < n; cols++)
                    {
                        if (matrix[rows, cols] == 'A')
                        {
                            row = rows;
                            col = cols;
                            find = true;
                            break;
                        }
                    }

                    if (find)
                    {
                        break;
                    }
                }

                // process command
                if (IsCommandValid(n, command, row, col))
                {
                    switch (command)
                    {
                        case "up":
                            if (matrix[row - 1, col] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row - 1, col] = 'A';
                            }
                            else if (matrix[row - 1, col] == 'M')
                            {
                                matrix[row, col] = '-';
                                matrix[row - 1, col] = '-';
                                matrix[FindMirror(n, matrix)[0], FindMirror(n, matrix)[1]] = 'A';
                            }
                            else
                            {
                                matrix[row, col] = '-';
                                price += int.Parse(matrix[row - 1, col].ToString());
                                matrix[row - 1, col] = 'A';

                                if (price >= 65)
                                {
                                    Console.WriteLine("Very nice swords, I will come back for more!");
                                    Console.WriteLine($"The king paid {price} gold coins.");
                                    PrintMatrix(n, matrix);
                                    return;
                                }
                            }
                            break;
                        case "down":
                            if (matrix[row + 1, col] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row + 1, col] = 'A';
                            }
                            else if (matrix[row + 1, col] == 'M')
                            {
                                matrix[row, col] = '-';
                                matrix[row + 1, col] = '-';
                                matrix[FindMirror(n, matrix)[0], FindMirror(n, matrix)[1]] = 'A';
                            }
                            else
                            {
                                matrix[row, col] = '-';
                                price += int.Parse(matrix[row + 1, col].ToString());
                                matrix[row + 1, col] = 'A';

                                if (price >= 65)
                                {
                                    Console.WriteLine("Very nice swords, I will come back for more!");
                                    Console.WriteLine($"The king paid {price} gold coins.");
                                    PrintMatrix(n, matrix);
                                    return;
                                }
                            }
                            break;
                        case "left":
                            if (matrix[row, col - 1] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row, col - 1] = 'A';
                            }
                            else if (matrix[row, col - 1] == 'M')
                            {
                                matrix[row, col] = '-';
                                matrix[row, col - 1] = '-';
                                matrix[FindMirror(n, matrix)[0], FindMirror(n, matrix)[1]] = 'A';
                            }
                            else
                            {
                                matrix[row, col] = '-';
                                price += int.Parse(matrix[row, col - 1].ToString());
                                matrix[row, col - 1] = 'A';

                                if (price >= 65)
                                {
                                    Console.WriteLine("Very nice swords, I will come back for more!");
                                    Console.WriteLine($"The king paid {price} gold coins.");
                                    PrintMatrix(n, matrix);
                                    return;
                                }
                            }
                            break;
                        case "right":
                            if (matrix[row, col + 1] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row, col + 1] = 'A';
                            }
                            else if (matrix[row, col + 1] == 'M')
                            {
                                matrix[row, col] = '-';
                                matrix[row, col + 1] = '-';
                                matrix[FindMirror(n, matrix)[0], FindMirror(n, matrix)[1]] = 'A';
                            }
                            else
                            {
                                matrix[row, col] = '-';
                                price += int.Parse(matrix[row, col + 1].ToString());
                                matrix[row, col + 1] = 'A';

                                if (price >= 65)
                                {
                                    Console.WriteLine("Very nice swords, I will come back for more!");
                                    Console.WriteLine($"The king paid {price} gold coins.");
                                    PrintMatrix(n, matrix);
                                    return;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    matrix[row, col] = '-';
                    Console.WriteLine("I do not need more swords!");
                    Console.WriteLine($"The king paid {price} gold coins.");
                    PrintMatrix(n, matrix);
                    return;
                }
            }
        }

        static int[] FindMirror(int n, char[,] matrix)
        {
            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    if(matrix[rows, cols] == 'M')
                    {
                        return new int[] { rows, cols };
                    }
                }
            }

            return new int[] { 0, 0 };
        }

        static void PrintMatrix(int n, char[,] matrix)
        {
            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    Console.Write(matrix[rows, cols]);
                }

                Console.WriteLine();
            }
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
    }
}
