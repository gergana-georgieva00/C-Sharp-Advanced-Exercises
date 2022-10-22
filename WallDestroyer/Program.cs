using System;

namespace WallDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int currRow = 0;
            int currCol = 0;

            for (int row = 0; row < n; row++)
            {
                string rowInput = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowInput[col];

                    if (matrix[row, col] == 'V')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            // recieve commands
            string command;
            while ((command = Console.ReadLine()) != "End")
            {

            }
        }
    }
}
