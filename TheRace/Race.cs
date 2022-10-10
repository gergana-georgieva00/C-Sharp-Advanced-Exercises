using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers;
        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Racers = new List<Racer>();
        }

        public List<Racer> Racers { get { return racers; } set { racers = value; } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Racers.Count; } }

        public void Add(Racer Racer)
        {
            if (this.Racers.Count < this.Capacity)
            {
                this.Racers.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            if (this.Racers.Any(r => r.Name == name))
            {
                this.Racers = this.Racers.Where(r => r.Name != name).ToList();
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            Racer oldestRacer = this.Racers.OrderByDescending(r => r.Age).ToList()[0];
            return oldestRacer;
        }

        public Racer GetRacer(string name)
        {
            Racer racer = this.Racers.Where(r => r.Name == name).ToList()[0];
            return racer;
        }

        public Racer GetFastestRacer()
        {
            Racer fastestRacer = this.Racers.OrderByDescending(r => r.Car.Speed).ToList()[0];
            return fastestRacer;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");
            for (int i = 0; i < this.Racers.Count; i++)
            {
                if (i == this.Racers.Count - 1)
                {
                    sb.Append(this.Racers[i].ToString());
                }
                else
                {
                    sb.AppendLine(this.Racers[i].ToString());
                }
            }

            return sb.ToString();
        }
    }
}
