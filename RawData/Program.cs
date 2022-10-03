using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Car car = new Car(model);

                Engine engine = new Engine()
                {
                    Speed = engineSpeed,
                    Power = enginePower
                };

                Cargo cargo = new Cargo()
                {
                    Type = cargoType,
                    Weight = cargoWeight
                };

                Tire tire1 = new Tire()
                {
                    Age = tire1Age,
                    Pressure = tire1Pressure
                };

                Tire tire2 = new Tire()
                {
                    Age = tire2Age,
                    Pressure = tire2Pressure
                };

                Tire tire3 = new Tire()
                {
                    Age = tire3Age,
                    Pressure = tire3Pressure
                };

                Tire tire4 = new Tire()
                {
                    Age = tire4Age,
                    Pressure = tire4Pressure
                };

                car.Engine = engine;
                car.Cargo = cargo;

                Tire[] tires = new Tire[]
                {
                    tire1, tire2, tire3, tire4
                };

                car.Tires = tires;

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var carsFiltered = cars.Where(c => c.Cargo.Type == "fragile").ToList();

                foreach (var car in carsFiltered)
                {
                    Tire[] tires = car.Tires;

                    foreach (var tire in tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            Console.WriteLine(car.Model);
                            break;
                        }
                    }
                }
            }
            else
            {
                var carsFiltered = cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250).ToList();

                foreach (var car in carsFiltered)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
