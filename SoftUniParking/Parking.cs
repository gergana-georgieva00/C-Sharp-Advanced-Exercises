using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return this.Cars.Count; }
        }


        public string AddCar(Car Car)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == Car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
                //return false;
            }

            if (this.Cars.Count >= this.Capacity)
            {
                return "Parking is full!";
                //return false;
            }

            this.Cars.Add(Car);
            return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";
            //return true;
        }

        public string RemoveCar(string RegistrationNumber)
        {
            if (!this.Cars.Any(c => c.RegistrationNumber == RegistrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
                //return false;
            }

            this.Cars = this.Cars.Where(c => c.RegistrationNumber != RegistrationNumber).ToList();
            return $"Successfully removed {RegistrationNumber}";
            //return true;
        }

        public Car GetCar(string RegistrationNumber)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == RegistrationNumber))
            {
                Car car = this.Cars.Find(c => c.RegistrationNumber == RegistrationNumber);
                return car;
            }

            return null;
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
