using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] second = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] third = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            MyTuple<string, string> firstT = new MyTuple<string, string>(first[0] + " " + first[1], first[2]);
            MyTuple<string, int> secondT = new MyTuple<string, int>(second[0], int.Parse(second[1]));
            MyTuple<int, double> thirdT = new MyTuple<int, double>(int.Parse(third[0]), double.Parse(third[1]));

            Console.WriteLine(firstT.ToString());
            Console.WriteLine(secondT.ToString());
            Console.WriteLine(thirdT.ToString());
        }
    }
}
