using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesMan
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int power = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];

                    Engine engine = new Engine(model, power, displacement, efficiency);
                    engines.Add(engine);
                }
                else if (input.Length == 3)
                {
                    int num;
                    var isNumeric = int.TryParse(input[2], out num);

                    if (isNumeric)
                    {
                        int displacement = int.Parse(input[2]);

                        Engine engine = new Engine(model, power, displacement);
                        engines.Add(engine);
                    }
                    else
                    {
                        string efficiency = input[2];

                        Engine engine = new Engine(model, power, efficiency);
                        engines.Add(engine);
                    }
                }
                else
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                Engine engine = engines.Find(e => e.Model == input[1]);

                if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);
                    string color = input[3];

                    Car car = new Car(model, engine, weight, color);
                    cars.Add(car);
                }
                else if (input.Length == 3)
                {
                    int num;
                    var isNumeric = int.TryParse(input[2], out num);

                    if (isNumeric)
                    {
                        int weight = int.Parse(input[2]);

                        Car car = new Car(model, engine, weight);
                        cars.Add(car);
                    }
                    else
                    {
                        string color = input[2];

                        Car car = new Car(model, engine, color);
                        cars.Add(car);
                    }
                }
                else
                {
                    Car car = new Car(model, engine);
                    cars.Add(car);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");

                if (car.Engine.Displacement != 0)
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }
                else
                {
                    Console.WriteLine($"    Displacement: n/a");
                }

                if (car.Engine.Efficiency != null)
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }

                if (car.Weight != 0)
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine($"  Weight: n/a");
                }

                if (car.Color != null)
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
                else
                {
                    Console.WriteLine($"  Color: n/a");
                }
            }
        }
    }
}
