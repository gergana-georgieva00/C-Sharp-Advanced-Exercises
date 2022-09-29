using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(input[0], int.Parse(input[1]));
                people.Add(person);
            }

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<List<Person>, string, int, List<Person>> generateFilter = CreateFilter;
            people = generateFilter(people, condition, ageThreshold);
            Action<List<Person>, string> printThePeople = PrintPeople;
            printThePeople(people, format);
        }

        static List<Person> CreateFilter(List<Person> people, string condition, int ageThreshold)
        {
            switch (condition)
            {
                case "younger":
                    return people.Where(p => p.Age < ageThreshold).ToList();
                    break;
                default:
                    return people.Where(p => p.Age >= ageThreshold).ToList();
                    break;
            }
        }

        static void PrintPeople(List<Person> people, string format)
        {
            switch (format)
            {
                case "name":
                    people.ForEach(p => Console.WriteLine(p.Name));
                    break;
                case "age":
                    people.ForEach(p => Console.WriteLine(p.Age));
                    break;
                default:
                    people.ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
                    break;
            }
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        
    }
}
