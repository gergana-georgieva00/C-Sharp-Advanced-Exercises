using System;
using System.Linq;

namespace RallyRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string racingNumber = Console.ReadLine();

            char[,] matrix = new char[n, n];

            for (int roww = 0; roww < n; roww++)
            {
                char[] rowInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int coll = 0; coll < n; coll++)
                {
                    matrix[roww, coll] = rowInput[coll];
                }
            }

            // logic
            int row = 0;
            int col = 0;

            int kmPassed = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                matrix[row, col] = '.';

                switch (command)
                {
                    case "up":
                        row--;
                        break;
                    case "down":
                        row++;
                        break;
                    case "left":
                        col--;
                        break;
                    case "right":
                        col++;
                        break;
                }

                if (matrix[row, col] == 'F')
                {
                    matrix[row, col] = 'C';
                    kmPassed += 10;
                    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                    Console.WriteLine($"Distance covered {kmPassed} km.");
                    Print(matrix, n);
                    return;
                }
                else if (matrix[row, col] == '.')
                {
                    matrix[row, col] = 'C';
                    kmPassed += 10;
                }
                else if (matrix[row, col] == 'T')
                {
                    matrix[row, col] = '.';

                    int[] exit = FindTunnelExit(matrix, n);

                    matrix[exit[0], exit[1]] = '.';

                    row = exit[0];
                    col = exit[1];

                    kmPassed += 30;
                }
            }

            matrix[row, col] = 'C';
            Console.WriteLine($"Racing car {racingNumber} DNF.");
            Console.WriteLine($"Distance covered {kmPassed} km.");
            Print(matrix, n);
        }

        static void Print(char[,] matrix, int n)
        {
            for (int roww = 0; roww < n; roww++)
            {
                for (int coll = 0; coll < n; coll++)
                {
                    Console.Write(matrix[roww, coll]);
                }

                Console.WriteLine();
            }
        }

        static int[] FindTunnelExit(char[,] matrix, int n)
        {
            int[] exit = new int[] { 0, 0 };

            for (int roww = 0; roww < n; roww++)
            {
                for (int coll = 0; coll < n; coll++)
                {
                    if (matrix[roww, coll] == 'T')
                    {
                        exit[0] = roww;
                        exit[1] = coll;

                        return exit;
                    }
                }
            }

            return exit;
        }
    }
}
