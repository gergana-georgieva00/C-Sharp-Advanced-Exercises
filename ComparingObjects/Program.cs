using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string name = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                int age = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                string town = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2];

                people.Add(new Person(name, age, town));
            }

            int n = int.Parse(Console.ReadLine());

            Person person = people[n - 1];

            int countEqual = 0;
            int countNotEqual = 0;

            foreach (var p in people)
            {
                if (person.CompareTo(p) == 0)
                {
                    countEqual++;
                }
                else
                {
                    countNotEqual++;
                }
            }

            if (countEqual == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countEqual} {countNotEqual} {people.Count}");
            }
        }
    }
}
