using System;

namespace RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Result(n));
        }

        static long Result(int n)
        {
            long result = 0;

            if (n == 0)
            {
                return 1;
            }

            return result += n * Result(n - 1);
        }
    }
}
