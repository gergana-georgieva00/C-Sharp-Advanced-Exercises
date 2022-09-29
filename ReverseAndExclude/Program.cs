using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int nFilter = int.Parse(Console.ReadLine());

            Func<int, bool> filter = n => n % nFilter != 0;
            numbers = numbers.Where(n => filter(n)).Reverse().ToList();
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
