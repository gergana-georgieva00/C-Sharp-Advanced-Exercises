using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }

            if (n == 2)
            {
                Console.WriteLine(1);
                Console.WriteLine(1 + " " + 1);
                return;
            }

            long[][] jaggedArray = new long[n][];

            for (int row = 0; row < n; row++)
            {
                jaggedArray[row] = new long[row + 1];
                jaggedArray[row][0] = 1;
                jaggedArray[row][row] = 1;

                for (int col = 1; col < row; col++)
                {
                    jaggedArray[row][col] = jaggedArray[row - 1][col - 1] + jaggedArray[row - 1][col];
                }
            }

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(' ', jaggedArray[row]));
            }
        }
    }
}
