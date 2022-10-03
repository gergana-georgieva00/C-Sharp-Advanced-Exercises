using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person peter = new Person();
            peter.Name = "Peter";
            peter.Age = 20;
            Console.WriteLine(peter.Name);
            Console.WriteLine(peter.Age);
        }
    }
}
