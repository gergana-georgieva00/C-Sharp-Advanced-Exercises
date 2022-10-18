using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return this.Drones.Count; } }

        public string AddDrone(Drone drone)
        {
            if (this.Drones.Count >= this.Capacity)
            {
                return "Airfield is full.";
            }

            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }

            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            this.Drones.Add(drone);

            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            if (this.Drones.Any(d => d.Name == name))
            {
                this.Drones = this.Drones.Where(d => d.Name != name).ToList();
                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            if (this.Drones.Any(d => d.Brand == brand))
            {
                int removedCount = 0;
                foreach (var drone in this.Drones)
                {
                    if (drone.Brand == brand)
                    {
                        removedCount++;
                    }
                }

                this.Drones = this.Drones.Where(d => d.Brand != brand).ToList();
                return removedCount;
            }

            return 0;
        }

        public Drone FlyDrone(string name)
        {
            if (this.Drones.Any(d => d.Name == name))
            {
                Drone drone = this.Drones.Where(d => d.Name == name).ToList()[0];
                drone.Available = false;
                return drone;
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = new List<Drone>();

            foreach (var drone in this.Drones)
            {
                if (drone.Range >= range)
                {
                    drone.Available = false;
                    drones.Add(drone);
                }
            }

            return drones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var drone in this.Drones)
            {
                if (drone.Available == true)
                {
                    sb.AppendLine(drone.ToString());
                }
            }

            return sb.ToString();
        }
    }
}
