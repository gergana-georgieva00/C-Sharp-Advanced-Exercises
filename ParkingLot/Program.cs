using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] spl = input.Split(", ");

                string direction = spl[0];
                string carNumber = spl[1];

                if (direction == "IN")
                {
                    cars.Add(carNumber);
                }
                else
                {
                    cars.Remove(carNumber);
                }
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
