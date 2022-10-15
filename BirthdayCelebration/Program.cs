using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> eatingCapacity = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int wastedFood = 0;

            while (eatingCapacity.Count > 0 && plates.Count > 0)
            {
                if (eatingCapacity.Peek() <= plates.Peek())
                {
                    wastedFood += plates.Pop() - eatingCapacity.Dequeue();
                }
                else
                {
                    int currGuest = eatingCapacity.Dequeue() - plates.Pop();

                    List<int> guests = eatingCapacity.ToList();
                    guests.Insert(0, currGuest);

                    eatingCapacity = new Queue<int>(guests);
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(' ', plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(' ', eatingCapacity)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
