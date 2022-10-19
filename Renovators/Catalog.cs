using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.Renovators = new List<Renovator>();
        }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public List<Renovator> Renovators { get; set; }
        public int Count { get { return this.Renovators.Count; } }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (this.Renovators.Count == this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (this.Renovators.Any(r => r.Name == name))
            {
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = this.Renovators.FindAll(r => r.Type == type).ToList().Count;
            this.Renovators.Remove(this.Renovators.Find(r => r.Type == type));

            return count;
        }

        public Renovator HireRenovator(string name)
        {
            if (this.Renovators.Any(r => r.Name == name))
            {
                this.Renovators.Find(r => r.Name == name).Hired = true;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> payed = this.Renovators.FindAll(r => r.Days >= days);

            return payed;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.Project}:");
            for (int i = 0; i < this.Renovators.Count; i++)
            {
                if (Renovators[i].Hired == false)
                {
                    if (i == Renovators.Count - 1)
                    {
                        sb.Append(Renovators[i].ToString());
                    }
                    else
                    {
                        sb.AppendLine(Renovators[i].ToString());
                    }
                }
            }

            return sb.ToString();
        }
    }
}
