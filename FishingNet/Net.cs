using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.fish = new List<Fish>();
        }

        public List<Fish> Fish { get { return this.fish; } private set { this.fish = value; } }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Fish.Count; } }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || string.IsNullOrEmpty(fish.FishType))
            {
                return "Inlavid fish";
            }

            if (fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Inlavid fish";
            }

            if (this.Capacity > this.fish.Count)
            {
                this.fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
                
            }

            return "Fishing net is full.";
        }

        public bool ReleaseFish(double weight)
        {
            if (this.Fish.Any(f => f.Weight == weight))
            {
                this.fish = this.fish.Where(f => f.Weight != weight).ToList();
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            Fish fish = this.fish.Where(f => f.FishType == fishType).ToList()[0];
            return fish;
        }

        public Fish GetBiggestFish()
        {
            Fish fish = this.fish.OrderByDescending(f => f.Length).ToList()[0];
            return fish;
        }

        public string Report()
        {
            this.fish = this.fish.OrderByDescending(f => f.Length).ToList();
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Into the {this.Material}:");

            for (int i = 0; i < this.fish.Count; i++)
            {
                if (i == this.fish.Count - 1)
                {
                    sb.Append(fish[i].ToString());
                }
                else
                {
                    sb.AppendLine(fish[i].ToString());
                }
            }

            return sb.ToString();
        }
    }
}
