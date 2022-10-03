using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public bool CanCarMoveDistance(double amountOfKm)
        {
            double usedFuel = amountOfKm * this.FuelConsumptionPerKilometer;

            if (usedFuel <= this.FuelAmount)
            {
                this.FuelAmount -= usedFuel;
                this.TravelledDistance += amountOfKm;
                return true;
            }

            Console.WriteLine("Insufficient fuel for the drive");
            return false;
        }

    }
}
