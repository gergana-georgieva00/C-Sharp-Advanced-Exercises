using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] second = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] third = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (second[2] == "drunk")
            {
                second[2] = "true";
            }
            else
            {
                second[2] = "false";
            }

            Threeuple<string, string, string> firstT = new Threeuple<string, string, string>(first[0] + " " + first[1], first[2], first[3]);

            if (first.Length > 4)
            {
                firstT = new Threeuple<string, string, string>(first[0] + " " + first[1], first[2], first[3] + " " + first[4]);
            }

            Threeuple<string, int, bool> secondT = new Threeuple<string, int, bool>(second[0], int.Parse(second[1]), bool.Parse(second[2]));
            Threeuple<string, double, string> thirdT = new Threeuple<string, double, string>(third[0], double.Parse(third[1]), third[2]);

            Console.WriteLine(firstT.ToString());
            Console.WriteLine(secondT.ToString());
            Console.WriteLine(thirdT.ToString());
        }
    }
}
