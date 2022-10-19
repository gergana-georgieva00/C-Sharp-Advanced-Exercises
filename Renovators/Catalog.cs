using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        private readonly List<Renovator> renovators;
        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public List<Renovator> Renovators { get { return this.renovators; } }
        public int Count { get { return this.renovators.Count; } }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (this.Count >= this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (this.renovators.Any(r => r.Name == name))
            {
                this.renovators.Remove(this.renovators.Find(r => r.Name == name));
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            return renovators.RemoveAll(r => r.Type == type);
        }

        public Renovator HireRenovator(string name)
        {
            if (this.renovators.Any(r => r.Name == name))
            {
                Renovator r = this.renovators.Find(r => r.Name == name);
                r.Hired = true;
                return r;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> payed = this.renovators.Where(r => r.Days >= days).ToList();

            return payed;
        }

        public string Report()
            => $"Renovators available for Project {this.Project}:" +
               Environment.NewLine +
               string.Join(Environment.NewLine, this.Renovators.FindAll(r => !r.Hired));
    }
}
