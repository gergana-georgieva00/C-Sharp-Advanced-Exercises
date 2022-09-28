using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> isStartWithCapital = w => Char.IsUpper(w[0]);

            input = input.Where(x => isStartWithCapital(x)).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
