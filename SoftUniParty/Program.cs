using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (Char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (vip.Contains(input))
                {
                    vip.Remove(input);
                }

                if (regular.Contains(input))
                {
                    regular.Remove(input);
                }
            }

            Console.WriteLine(vip.Count + regular.Count);

            if (vip.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, vip));
            }

            if (regular.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, regular));
            }
        }
    }
}
