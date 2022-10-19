using System;
using System.Linq;

namespace TruffleHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] forest = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    forest[row, col] = currRow[col];
                }
            }

            int white = 0;
            int black = 0;
            int summer = 0;
            int wb = 0;

            string command;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                if (command.Contains("Collect"))
                {
                    int row = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                    int col = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);

                    if (row >= 0 && row < n && col >= 0 && col < n
                        && forest[row, col] != '-'
                        )
                    {
                        switch (forest[row, col])
                        {
                            case 'W':
                                white++;
                                forest[row, col] = '-';
                                break;
                            case 'B':
                                black++;
                                forest[row, col] = '-';
                                break;
                            case 'S':
                                summer++;
                                forest[row, col] = '-';
                                break;
                        }
                    }
                }
                else
                {
                    int row = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                    int col = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
                    string direction = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray()[3];

                    switch (forest[row, col])
                    {
                        case 'W':
                            wb++;
                            break;
                        case 'B':
                            wb++;
                            break;
                        case 'S':
                            wb++;
                            break;
                    }

                    forest[row, col] = '-';

                    switch (direction)
                    {
                        case "up":
                            while (row - 2 >= 0)
                            {
                                row -= 2;
                                if (forest[row, col] == 'W' || forest[row, col] == 'B' || forest[row, col] == 'S')
                                {
                                    wb++;
                                    forest[row, col] = '-';
                                }
                            }
                            break;
                        case "down":
                            while (row + 2 < n)
                            {
                                row += 2;
                                if (forest[row, col] == 'W' || forest[row, col] == 'B' || forest[row, col] == 'S')
                                {
                                    wb++;
                                    forest[row, col] = '-';
                                }
                            }
                            break;
                        case "left":
                            while (col - 2 >= 0)
                            {
                                col -= 2;
                                if (forest[row, col] == 'W' || forest[row, col] == 'B' || forest[row, col] == 'S')
                                {
                                    wb++;
                                    forest[row, col] = '-';
                                }
                            }
                            break;
                        case "right":
                            while (col + 2 < n)
                            {
                                col += 2;
                                if (forest[row, col] == 'W' || forest[row, col] == 'B' || forest[row, col] == 'S')
                                {
                                    wb++;
                                    forest[row, col] = '-';
                                }
                            }
                            break;
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {black} black, {summer} summer, and {white} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wb} truffles.");
            Print(forest, n);
        }

        static void Print(char[,] forest, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(forest[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
