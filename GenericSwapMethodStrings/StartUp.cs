using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<string>> list = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                list.Add(new Box<string>(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int index1 = indexes[0];
            int index2 = indexes[1];

            Swap<string>(list, index1, index2);

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void Swap<T>(List<Box<T>> list, int index1, int index2)
        {
            var removed1 = list[index1];
            var removed2 = list[index2];

            list.RemoveAt(index1);
            list.Insert(index1, removed2);

            list.RemoveAt(index2);
            list.Insert(index2, removed1);
        }
    }
}
