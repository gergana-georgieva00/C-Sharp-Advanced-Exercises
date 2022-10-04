using System;

namespace Bee
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

            int pollinatedFlowers = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int[] currCoordinates = GetCurrentPositon(matrix);
                int row = currCoordinates[0];
                int col = currCoordinates[1];

                if (command == "left")
                {
                    if (IsCommandValid(command, matrix))
                    {
                        if (matrix[row, col - 1] == 'f')
                        {
                            pollinatedFlowers++;
                            matrix[row, col] = '.';
                            matrix[row, col - 1] = 'B';
                        }
                        else if (matrix[row, col - 1] == 'O')
                        {
                            if (matrix[row, col - 2] == 'f')
                            {
                                pollinatedFlowers++;
                            }

                            matrix[row, col] = '.';
                            matrix[row, col - 1] = '.';
                            matrix[row, col - 2] = 'B';
                        }
                        else
                        {
                            matrix[row, col] = '.';
                            matrix[row, col - 1] = 'B';
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[row, col] = '.';
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (IsCommandValid(command, matrix))
                    {
                        if (matrix[row, col + 1] == 'f')
                        {
                            pollinatedFlowers++;
                            matrix[row, col] = '.';
                            matrix[row, col + 1] = 'B';
                        }
                        else if (matrix[row, col + 1] == 'O')
                        {
                            if (matrix[row, col + 2] == 'f')
                            {
                                pollinatedFlowers++;
                            }

                            matrix[row, col] = '.';
                            matrix[row, col + 1] = '.';
                            matrix[row, col + 2] = 'B';
                        }
                        else
                        {
                            matrix[row, col] = '.';
                            matrix[row, col + 1] = 'B';
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[row, col] = '.';
                        break;
                    }
                }
                else if (command == "up")
                {
                    if (IsCommandValid(command, matrix))
                    {
                        if (matrix[row - 1, col] == 'f')
                        {
                            pollinatedFlowers++;
                            matrix[row, col] = '.';
                            matrix[row - 1, col] = 'B';
                        }
                        else if (matrix[row - 1, col] == 'O')
                        {
                            if (matrix[row - 2, col] == 'f')
                            {
                                pollinatedFlowers++;
                            }

                            matrix[row, col] = '.';
                            matrix[row - 1, col] = '.';
                            matrix[row - 2, col] = 'B';
                        }
                        else
                        {
                            matrix[row, col] = '.';
                            matrix[row - 1, col] = 'B';
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[row, col] = '.';
                        break;
                    }
                }
                else
                {
                    if (IsCommandValid(command, matrix))
                    {
                        if (matrix[row + 1, col] == 'f')
                        {
                            pollinatedFlowers++;
                            matrix[row, col] = '.';
                            matrix[row + 1, col] = 'B';
                        }
                        else if (matrix[row + 1, col] == 'O')
                        {
                            if (matrix[row + 2, col] == 'f')
                            {
                                pollinatedFlowers++;
                            }

                            matrix[row, col] = '.';
                            matrix[row + 1, col] = '.';
                            matrix[row + 2, col] = 'B';
                        }
                        else
                        {
                            matrix[row, col] = '.';
                            matrix[row + 1, col] = 'B';
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        matrix[row, col] = '.';
                        break;
                    }
                }
            }

            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

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

        static int[] GetCurrentPositon(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            return new int[] { 0, 0 };
        }

        static bool IsCommandValid(string command, char[,] matrix)
        {
            int row = GetCurrentPositon(matrix)[0];
            int col = GetCurrentPositon(matrix)[1];

            switch (command)
            {
                case "left":
                    if (col - 1 >= 0)
                    {
                        return true;
                    }
                    break;
                case "right":
                    if (col + 1 < matrix.GetLength(1))
                    {
                        return true;
                    }
                    break;
                case "up":
                    if (row - 1 >= 0)
                    {
                        return true;
                    }
                    break;
                case "down":
                    if (row + 1 < matrix.GetLength(0))
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
