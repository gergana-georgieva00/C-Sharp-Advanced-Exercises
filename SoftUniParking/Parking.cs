using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.Cars = new List<Car>();
        }

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count
        {
            get { return this.Cars.Count; }
        }


        public string AddCar(Car Car)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == Car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.Cars.Count >= this.Capacity)
            {
                return "Parking is full!";
            }

            this.Cars.Add(Car);
            return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";
        }

        public string RemoveCar(string RegistrationNumber)
        {
            if (!this.Cars.Any(c => c.RegistrationNumber == RegistrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.Cars = this.Cars.Where(c => c.RegistrationNumber != RegistrationNumber).ToList();
            return $"Successfully removed {RegistrationNumber}";
        }

        public Car GetCar(string RegistrationNumber)
        {
            Car car = this.Cars.Find(c => c.RegistrationNumber == RegistrationNumber);
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var regNumber in RegistrationNumbers)
            {
                if (this.Cars.Any(c => c.RegistrationNumber == regNumber))
                {
                    this.Cars = this.Cars.Where(c => c.RegistrationNumber != regNumber).ToList();
                }
            }
        }
    }
}
