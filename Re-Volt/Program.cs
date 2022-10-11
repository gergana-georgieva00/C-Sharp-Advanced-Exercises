using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            // read matrix
            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            // read commands
            for (int i = 0; i < count; i++)
            {
                string command = Console.ReadLine();

                int playerRow = GetPositionOfPlayer(matrix, n)[0];
                int playerCol = GetPositionOfPlayer(matrix, n)[1];

                int rowCopy = playerRow;
                int colCopy = playerCol;

                // validate command
                if (!IsCommandValid(command, n, playerRow, playerCol))
                {
                    matrix[playerRow, playerCol] = '-';

                    switch (command)
                    {
                        case "up":
                            playerRow = n - 1;
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                matrix[playerRow - 1, playerCol] = 'f';
                            }
                            else if (matrix[playerRow, playerCol] == 'T')
                            {
                                matrix[rowCopy, playerCol] = 'f';
                            }
                            else if (matrix[playerRow, playerCol] == 'F')
                            {
                                matrix[playerRow, playerCol] = 'f';

                                Console.WriteLine("Player won!");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = 'f';
                            }
                            break;
                        case "down":
                            playerRow = 0;
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                matrix[playerRow + 1, playerCol] = 'f';
                            }
                            else if (matrix[playerRow, playerCol] == 'T')
                            {
                                matrix[rowCopy, playerCol] = 'f';
                            }
                            else if (matrix[playerRow, playerCol] == 'F')
                            {
                                matrix[playerRow, playerCol] = 'f';

                                Console.WriteLine("Player won!");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = 'f';
                            }
                            break;
                        case "left":
                            playerCol = n - 1;
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                matrix[playerRow, playerCol - 1] = 'f';
                            }
                            else if (matrix[playerRow, playerCol] == 'T')
                            {
                                matrix[playerRow, colCopy] = 'f';
                            }
                            else if (matrix[playerRow, playerCol] == 'F')
                            {
                                matrix[playerRow, playerCol] = 'f';

                                Console.WriteLine("Player won!");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = 'f';
                            }
                            break;
                        case "right":
                            playerCol = 0;
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                matrix[playerRow, playerCol + 1] = 'f';
                            }
                            else if (matrix[playerRow, playerCol] == 'T')
                            {
                                matrix[playerRow, colCopy] = 'f';
                            }
                            else if (matrix[playerRow, playerCol] == 'F')
                            {
                                matrix[playerRow, playerCol] = 'f';

                                Console.WriteLine("Player won!");
                                PrintMatrix(matrix, n);
                                return;
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = 'f';
                            }
                            break;
                    }
                }
                else
                {
                    switch (command)
                {
                    case "up":
                        if (matrix[playerRow - 1, playerCol] == 'B')
                        {
                            if (IsCommandValid(command, n, playerRow - 1, playerCol))
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[playerRow - 2, playerCol] = 'f';
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[n - 1, playerCol] = 'f';
                            }
                        }
                        else if (matrix[playerRow - 1, playerCol] == 'T')
                        {
                            // stays on the same place
                        }
                        else if (matrix[playerRow - 1, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow - 1, playerCol] = 'f';

                            Console.WriteLine("Player won!");
                            PrintMatrix(matrix, n);
                            return;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow - 1, playerCol] = 'f';
                        }
                        break;
                    case "down":
                        if (matrix[playerRow + 1, playerCol] == 'B')
                        {
                            if (IsCommandValid(command, n, playerRow + 1, playerCol))
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[playerRow + 2, playerCol] = 'f';
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[0, playerCol] = 'f';
                            }
                        }
                        else if (matrix[playerRow + 1, playerCol] == 'T')
                        {
                            // stays on the same place
                        }
                        else if (matrix[playerRow + 1, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow + 1, playerCol] = 'f';

                            Console.WriteLine("Player won!");
                            PrintMatrix(matrix, n);
                            return;

                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow + 1, playerCol] = 'f';
                        }
                        break;
                    case "left":
                        if (matrix[playerRow, playerCol - 1] == 'B')
                        {
                            if (IsCommandValid(command, n, playerRow, playerCol - 1))
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[playerRow, playerCol - 2] = 'f';
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[playerRow, n - 1] = 'f';
                            }
                        }
                        else if (matrix[playerRow, playerCol - 1] == 'T')
                        {
                            // stays on the same place
                        }
                        else if (matrix[playerRow, playerCol - 1] == 'F')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, playerCol - 1] = 'f';

                            Console.WriteLine("Player won!");
                            PrintMatrix(matrix, n);
                            return;

                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, playerCol - 1] = 'f';
                        }
                        break;
                    case "right":
                        if (matrix[playerRow, playerCol + 1] == 'B')
                        {
                            if (IsCommandValid(command, n, playerRow, playerCol + 1))
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[playerRow, playerCol + 1] = 'f';
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[playerRow, 0] = 'f';
                            }
                        }
                        else if (matrix[playerRow, playerCol + 1] == 'T')
                        {
                            // stays on the same place
                        }
                        else if (matrix[playerRow, playerCol + 1] == 'F')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, playerCol + 1] = 'f';

                            Console.WriteLine("Player won!");
                            PrintMatrix(matrix, n);
                            return;

                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, playerCol + 1] = 'f';
                        }
                        break;
                }
                }
                
            }

            Console.WriteLine("Player lost!");
            PrintMatrix(matrix, n);
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

        static int[] GetPositionOfPlayer(char[,] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        return new int[] { row, col };
                    }                
                }
            }

            return new int[] { 0, 0 };
        }

        static bool IsCommandValid(string command, int n, int playerRow, int playerCol)
        {
            switch (command)
            {
                case "up":
                    if (playerRow - 1 >= 0)
                    {
                        return true;
                    }
                    break;
                case "down":
                    if (playerRow + 1 < n)
                    {
                        return true;
                    }
                    break;
                case "left":
                    if (playerCol - 1 >= 0)
                    {
                        return true;
                    }
                    break;
                case "right":
                    if (playerCol + 1 < n)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
