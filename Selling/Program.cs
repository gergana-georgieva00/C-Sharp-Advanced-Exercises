using System;

namespace Selling
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

            int collectedMoney = 0;
            bool enoughMoney = true;

            while (collectedMoney < 50)
            {
                string command = Console.ReadLine();

                if (IsCommandValid(matrix, command))
                {
                    int row = GetCurrentPosition(matrix)[0];
                    int col = GetCurrentPosition(matrix)[1];

                    if (command == "left")
                    {
                        if (matrix[row, col - 1] == 'O')
                        {
                            matrix[row, col] = '-';
                            matrix[row, col - 1] = '-';

                            int rowPillar = FindExitPillarCoordinates(matrix)[0];
                            int colPillar = FindExitPillarCoordinates(matrix)[1];

                            matrix[rowPillar, colPillar] = 'S';
                        }
                        else if (matrix[row, col - 1] == '-')
                        {
                            matrix[row, col] = '-';
                            matrix[row, col - 1] = 'S';
                        }
                        else
                        {
                            collectedMoney += int.Parse(matrix[row, col - 1].ToString());

                            matrix[row, col] = '-';
                            matrix[row, col - 1] = 'S';
                        }
                    }
                    else if (command == "right")
                    {
                        if (matrix[row, col + 1] == 'O')
                        {
                            matrix[row, col] = '-';
                            matrix[row, col + 1] = '-';

                            int rowPillar = FindExitPillarCoordinates(matrix)[0];
                            int colPillar = FindExitPillarCoordinates(matrix)[1];

                            matrix[rowPillar, colPillar] = 'S';
                        }
                        else if (matrix[row, col + 1] == '-')
                        {
                            matrix[row, col] = '-';
                            matrix[row, col + 1] = 'S';
                        }
                        else
                        {
                            collectedMoney += int.Parse(matrix[row, col + 1].ToString());

                            matrix[row, col] = '-';
                            matrix[row, col + 1] = 'S';
                        }
                    }
                    else if (command == "up")
                    {
                        if (matrix[row - 1, col] == 'O')
                        {
                            matrix[row, col] = '-';
                            matrix[row - 1, col] = '-';

                            int rowPillar = FindExitPillarCoordinates(matrix)[0];
                            int colPillar = FindExitPillarCoordinates(matrix)[1];

                            matrix[rowPillar, colPillar] = 'S';
                        }
                        else if (matrix[row - 1, col] == '-')
                        {
                            matrix[row, col] = '-';
                            matrix[row - 1, col] = 'S';
                        }
                        else
                        {
                            collectedMoney += int.Parse(matrix[row - 1, col].ToString());

                            matrix[row, col] = '-';
                            matrix[row - 1, col] = 'S';
                        }
                    }
                    else
                    {
                        if (matrix[row + 1, col] == 'O')
                        {
                            matrix[row, col] = '-';
                            matrix[row + 1, col] = '-';

                            int rowPillar = FindExitPillarCoordinates(matrix)[0];
                            int colPillar = FindExitPillarCoordinates(matrix)[1];

                            matrix[rowPillar, colPillar] = 'S';
                        }
                        else if (matrix[row + 1, col] == '-')
                        {
                            matrix[row, col] = '-';
                            matrix[row + 1, col] = 'S';
                        }
                        else
                        {
                            collectedMoney += int.Parse(matrix[row + 1, col].ToString());

                            matrix[row, col] = '-';
                            matrix[row + 1, col] = 'S';
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    enoughMoney = false;
                    break;
                }
            }

            if (enoughMoney)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {collectedMoney}");

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

        static int[] FindExitPillarCoordinates(char[,] matrix)
        {
            int[] coordinates = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O')
                    {
                        coordinates[0] = row;
                        coordinates[1] = col;
                        break;
                    }
                }
            }

            return coordinates;
        }

        static int[] GetCurrentPosition(char[,] matrix)
        {
            int[] coordinates = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        coordinates[0] = row;
                        coordinates[1] = col;
                        break;
                    }
                }
            }

            return coordinates;
        }

        static bool IsCommandValid(char[,] matrix, string command)
        {
            int currRow = GetCurrentPosition(matrix)[0];
            int currCol = GetCurrentPosition(matrix)[1];

            switch (command)
            {
                case "left":
                    if (currCol - 1 >= 0)
                    {
                        return true;
                    }
                    break;
                case "right":
                    if (currCol + 1 < matrix.GetLength(1))
                    {
                        return true;
                    }
                    break;
                case "up":
                    if (currRow - 1 >= 0)
                    {
                        return true;
                    }
                    break;
                case "down":
                    if (currRow < matrix.GetLength(0))
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
