using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            // find current coordinates
            int currRow = 0;
            int currCol = 0;

            int coalCount = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    else if (matrix[row, col] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            // start processing commands 
            foreach (var command in commands)
            {
                switch (command)
                {
                    case "up":
                        if (currRow - 1 >=0)
                        {
                            currRow -= 1;

                            if (matrix[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                            else if (matrix[currRow, currCol] == 'c')
                            {
                                coalCount--;
                                matrix[currRow, currCol] = '*';

                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "down":
                        if (currRow + 1 < size)
                        {
                            currRow += 1;

                            if (matrix[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                            else if (matrix[currRow, currCol] == 'c')
                            {
                                coalCount--;
                                matrix[currRow, currCol] = '*';

                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "left":
                        if (currCol - 1 >= 0)
                        {
                            currCol -= 1;

                            if (matrix[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                            else if (matrix[currRow, currCol] == 'c')
                            {
                                coalCount--;
                                matrix[currRow, currCol] = '*';

                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "right":
                        if (currCol + 1 < size)
                        {
                            currCol += 1;

                            if (matrix[currRow, currCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                            else if (matrix[currRow, currCol] == 'c')
                            {
                                coalCount--;
                                matrix[currRow, currCol] = '*';

                                if (coalCount == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"{coalCount} coals left. ({currRow}, {currCol})");
        }
    }
}
