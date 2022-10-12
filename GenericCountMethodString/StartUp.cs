using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<string>> list = new List<Box<string>>();
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.Add(new Box<string>(input));
            }

            string elementForComparison = Console.ReadLine();

            foreach (var item in list)
            {
                if (item.AreEqual(elementForComparison))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
