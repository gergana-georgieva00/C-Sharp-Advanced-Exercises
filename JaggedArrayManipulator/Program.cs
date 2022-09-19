using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            long[][] jaggedArray = new long[int.Parse(Console.ReadLine())][];

            for (int rows = 0; rows < jaggedArray.GetLength(0); rows++)
            {
                int[] currRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArray[rows] = new long[currRow.Length];

                for (int cols = 0; cols < currRow.Length; cols++)
                {
                    jaggedArray[rows][cols] = currRow[cols];
                }
            }

            // analyze the array
            for (int row = 0; row < jaggedArray.GetLength(0) - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    if (jaggedArray[row].Length > jaggedArray[row + 1].Length)
                    {
                        for (int col = 0; col < jaggedArray[row].Length; col++)
                        {
                            jaggedArray[row][col] /= 2;

                            if (col < jaggedArray[row + 1].Length)
                            {
                                jaggedArray[row + 1][col] /= 2;
                            }
                        }
                    }
                    else
                    {
                        for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                        {
                            jaggedArray[row + 1][col] /= 2;

                            if (col < jaggedArray[row].Length)
                            {
                                jaggedArray[row][col] /= 2;
                            }
                        }
                    }
                }
            }

            // start receiving commands
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] spl = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(spl[1]);
                int col = int.Parse(spl[2]);
                int value = int.Parse(spl[3]);

                // validate indexes
                if (row < 0 || col < 0 || row >= jaggedArray.GetLength(0) || col >= jaggedArray[row].Length)
                {
                    continue;
                }

                if (spl[0] == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else
                {
                    jaggedArray[row][col] -= value;
                }
            }

            // print array
            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(' ', jaggedArray[row]));
            }
        }
    }
}
