using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1Kilometer = double.Parse(input[2]);

                if (!cars.Any(c => c.Model == model))
                {
                    cars.Add(new Car(model, fuelAmount, fuelConsumptionFor1Kilometer));
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] spl = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = spl[1];
                double amountOfKm = double.Parse(spl[2]);

                Car currCar = cars.Find(c => c.Model == carModel);

                currCar.CanCarMoveDistance(amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
