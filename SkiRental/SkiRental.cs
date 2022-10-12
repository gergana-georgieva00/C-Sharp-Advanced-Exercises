using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> ski;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Ski = new List<Ski>();
        }

        public List<Ski> Ski { get { return ski; } set { ski = value; } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Ski.Count; } }

        public void Add(Ski ski)
        {
            if (this.Ski.Count < this.Capacity)
            {
                this.Ski.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (this.Ski.Any(s => s.Manufacturer == manufacturer && s.Model == model))
            {
                this.Ski = this.Ski.Where(s => s.Manufacturer != manufacturer && s.Model != model).ToList();
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            if (this.Ski.Count > 0)
            {
                Ski newestSki = this.Ski.OrderByDescending(s => s.Year).ToList()[0];
                return newestSki;
            }

            return null;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            if (this.Ski.Any(s => s.Manufacturer == manufacturer && s.Model == model))
            {
                Ski ski = this.Ski.Where(s => s.Manufacturer == manufacturer && s.Model == model).ToList()[0];
                return ski;
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");

            for (int i = 0; i < this.Ski.Count; i++)
            {
                if (i == this.Ski.Count - 1)
                {
                    sb.Append(this.Ski[i].ToString());
                }
                else
                {
                    sb.AppendLine(this.Ski[i].ToString());
                }
            }

            return sb.ToString();
        }
    }
}
