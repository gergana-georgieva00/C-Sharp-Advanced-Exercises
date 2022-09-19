using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[int.Parse(Console.ReadLine())][];

            for (int rows = 0; rows < jaggedArray.GetLength(0); rows++)
            {
                int[] currRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[rows] = new int[currRow.Length];

                for (int cols = 0; cols < currRow.Length; cols++)
                {
                    jaggedArray[rows][cols] = currRow[cols];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] spl = command.Split();
                int row = int.Parse(spl[1]);
                int col = int.Parse(spl[2]);
                int value = int.Parse(spl[3]);

                // validate coordinates
                if (row < 0 || col < 0 || row >= jaggedArray.GetLength(0) || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
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

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(' ', jaggedArray[row]));
            }
        }
    }
}
