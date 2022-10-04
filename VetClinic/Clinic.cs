using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.Pets = new List<Pet>();
        }

        public List<Pet> Pets { get { return pets; } set { pets = value; } }
        public int Capacity { get; set; }
        public int Count { get { return this.Pets.Count; } }

        public void Add(Pet pet)
        {
            if (this.Pets.Count < this.Capacity)
            {
                this.Pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            if (this.Pets.Any(p => p.Name == name))
            {
                this.Pets = this.Pets.Where(p => p.Name != name).ToList();
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            if (this.Pets.Any(p => p.Name == name && p.Owner == owner))
            {
                Pet pet = this.Pets.Find(p => p.Name == name && p.Owner == owner);
                return pet;
            }

            return null;
        }

        public Pet GetOldestPet()
        {
            Pet pet = this.Pets.OrderByDescending(p => p.Age).ToList()[0];
            return pet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (Pet pet in this.Pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString();
        }
    }
}
