using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<double>> list = new List<Box<double>>();
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(new Box<double>(input));
            }

            double elementForComparison = double.Parse(Console.ReadLine());

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
