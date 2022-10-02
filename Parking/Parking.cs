using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    class Parking
    {
        private List<Car> cars;

        public Parking(string type, int capacity)
        {
            this.Cars = new List<Car>();
            this.Type = type;
            this.Capacity = capacity;
        }

        public List<Car> Cars { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get { return this.Cars.Count; }
        }


        public void Add(Car car)
        {
            if (Cars.Count < this.Capacity)
            {
                this.Cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (this.Cars.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                Car carToRemove = Cars.Find(c => c.Manufacturer == manufacturer && c.Model == model);
                this.Cars.Remove(carToRemove);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            if (Cars.Count > 0)
            {
                Car latestCar = Cars.OrderByDescending(c => c.Year).ToList()[0];
                return latestCar;
            }

            return null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            if (Cars.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                Car car = Cars.Find(c => c.Manufacturer == manufacturer && c.Model == model);
                return car;
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            sb.AppendLine(string.Join(Environment.NewLine, Cars));

            return sb.ToString();
        }
    }
}
