using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] jaggedArray = new char[n][];

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                jaggedArray[row] = new char[currRow.Length];

                for (int col = 0; col < currRow.Length; col++)
                {
                    jaggedArray[row][col] = currRow[col];
                }
            }

            int myTokens = 0;
            int opponentTokens = 0;

            string command;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] splitCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(splitCommand[1]);
                int col = int.Parse(splitCommand[2]);

                if (splitCommand[0] == "Find")
                {
                    if (IsCommandValid(row, col, n, jaggedArray) && jaggedArray[row][col] == 'T')
                    {
                        myTokens++;
                        jaggedArray[row][col] = '-';
                    }
                }
                else
                {
                    string direction = splitCommand[3];

                    if (IsCommandValid(row, col, n, jaggedArray) && jaggedArray[row][col] == 'T')
                    {
                        opponentTokens++;
                        jaggedArray[row][col] = '-';

                        switch (direction)
                        {
                            case "up":
                                if (row - 1 >= 0)
                                {
                                    if (jaggedArray[row - 1][col] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row - 1][col] = '-';
                                    }
                                }
                                if (row - 2 >= 0)
                                {
                                    if (jaggedArray[row - 2][col] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row - 2][col] = '-';
                                    }
                                }
                                if (row - 3 >= 0)
                                {
                                    if (jaggedArray[row - 3][col] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row - 3][col] = '-';
                                    }
                                }
                                break;
                            case "down":
                                if (row + 1 < n)
                                {
                                    if (jaggedArray[row + 1][col] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row + 1][col] = '-';
                                    }
                                }
                                if (row + 2 < n)
                                {
                                    if (jaggedArray[row + 2][col] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row + 2][col] = '-';
                                    }
                                }
                                if (row + 3 < n)
                                {
                                    if (jaggedArray[row + 3][col] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row + 3][col] = '-';
                                    }
                                }
                                break;
                            case "left":
                                if (col - 1 >= 0)
                                {
                                    if (jaggedArray[row][col - 1] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row][col - 1] = '-';
                                    }
                                }
                                if (col - 2 >= 0)
                                {
                                    if (jaggedArray[row][col - 2] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row][col - 2] = '-';
                                    }
                                }
                                if (col - 3 >= 0)
                                {
                                    if (jaggedArray[row][col - 3] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row][col - 3] = '-';
                                    }
                                }
                                break;
                            case "right":
                                if (col + 1 < jaggedArray[row].Length)
                                {
                                    if (jaggedArray[row][col + 1] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row][col + 1] = '-';
                                    }
                                }
                                if (col + 2 < jaggedArray[row].Length)
                                {
                                    if (jaggedArray[row][col + 2] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row][col + 2] = '-';
                                    }
                                }
                                if (col + 3 < jaggedArray[row].Length)
                                {
                                    if (jaggedArray[row][col + 3] == 'T')
                                    {
                                        opponentTokens++;
                                        jaggedArray[row][col + 3] = '-';
                                    }
                                }
                                break;
                        }
                    }
                }
            }

            PrintArray(n, jaggedArray);
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        static void PrintArray(int n, char[][] jaggedArray)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        static bool IsCommandValid(int row, int col, int n, char[][] jaggedArr)
        {
            if (row >= 0 && col >= 0 && row < n && col < jaggedArr[row].Length)
            {
                return true;
            }

            return false;
        }
    }
}
