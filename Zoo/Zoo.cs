using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo
{
    public class Zoo
    {
        private readonly List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.animals = new List<Animal>();
        }

        public List<Animal> Animals { get { return this.animals; } }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (this.animals.Count == this.Capacity)
            {
                return "The zoo is full.";
            }

            this.animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = this.animals.FindAll(a => a.Species == species).ToList().Count;

            for (int i = 0; i < count; i++)
            {
                this.animals.Remove(this.animals.Find(a => a.Species == species));
            }

            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalsByDiet = this.animals.FindAll(a => a.Diet == diet);

            return animalsByDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            Animal animal = this.animals.Find(a => a.Weight == weight);

            return animal;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> animalsByLength = this.animals.FindAll(a => a.Length >= minimumLength && a.Length <= maximumLength);

            return $"There are {animalsByLength.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
