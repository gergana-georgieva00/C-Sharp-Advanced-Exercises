using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count { get { return this.Participants.Count; } }

        public void Add(Car car)
        {
            if ((!this.Participants.Any(c => c.LicensePlate == car.LicensePlate)) 
                && this.Participants.Count < this.Capacity 
                && car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licencePlate)
        {
            if (this.Participants.Any(c => c.LicensePlate == licencePlate))
            {
                this.Participants = this.Participants.Where(c => c.LicensePlate != licencePlate).ToList();
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licencePlate)
        {
            if (this.Participants.Any(c => c.LicensePlate == licencePlate))
            {
                Car car = this.Participants.Where(c => c.LicensePlate == licencePlate).ToList()[0];
                return car;
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (this.Participants.Count == 0)
            {
                return null;
            }

            Car car = this.Participants.OrderByDescending(c => c.HorsePower).ToList()[0];
            return car;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            for (int i = 0; i < this.Participants.Count; i++)
            {
                if (i == this.Participants.Count - 1)
                {
                    sb.Append(this.Participants[i].ToString());
                }
                else
                {
                    sb.AppendLine(this.Participants[i].ToString());
                }
            }

            return sb.ToString();
        }
    }
}
