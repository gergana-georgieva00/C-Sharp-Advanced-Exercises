using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());

            //Family family = new Family();

            //for (int i = 0; i < n; i++)
            //{
            //    string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //    string name = input[0];
            //    int age = int.Parse(input[1]);

            //    Person person = new Person(name, age);
            //    family.AddMember(person);
            //}

            //var sorted = family.People.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();

            //foreach (var person in sorted)
            //{
            //    Console.WriteLine($"{person.Name} - {person.Age}");
            //}


            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier modifier = new DateModifier();
            Console.WriteLine(Math.Abs(modifier.GetDifferenceInDays(date1, date2)));
        }
    }
}
