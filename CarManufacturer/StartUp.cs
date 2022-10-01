using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string command;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                //int year = int.Parse(command.Split()[0]);
                //double pressure = double.Parse(command.Split()[0]);

                List<Tire> currTireArray = new List<Tire>();

                for (int i = 0; i < command.Split().Length; i+=2)
                {
                    Tire tire = new Tire(int.Parse(command.Split()[i]), double.Parse(command.Split()[i + 1]));
                    currTireArray.Add(tire);
                }
                
                tires.Add(currTireArray.ToArray());
            }

            string command2;
            while ((command2 = Console.ReadLine()) != "Engines done")
            {
                int horsePower = int.Parse(command2.Split()[0]);
                double cubicCapacity = double.Parse(command2.Split()[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            string command3;
            while ((command3 = Console.ReadLine()) != "Show special")
            {
                string[] spl = command3.Split();

                string make = spl[0];
                string model = spl[1];
                int year = int.Parse(spl[2]);
                double fuelQuantity = double.Parse(spl[3]);
                double fuelConsumption = double.Parse(spl[4]);
                int engineIndex = int.Parse(spl[5]);
                int tiresIndex = int.Parse(spl[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }

            // drive 20 kilometers all the cars,
            // which were manufactured during 2017 or after,
            // have horsepower above 330
            // and the sum of their tire pressure is between 9 and 10.

            var carsFiltered = cars.Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(y => y.Pressure) >= 9 && c.Tires.Sum(y => y.Pressure) <= 10).ToList();

            foreach (Car car in carsFiltered)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }

            
        }
    }
}
