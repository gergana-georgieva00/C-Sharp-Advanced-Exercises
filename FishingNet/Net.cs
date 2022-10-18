using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }

        public List<Fish> Fish { get; set; }
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

            if (this.Fish.Count >= this.Capacity)
            {
                return "Fishing net is full.";
            }

            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if (this.Fish.Any(f => f.Weight == weight))
            {
                this.Fish = this.Fish.Where(f => f.Weight != weight).ToList();
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            Fish fish = this.Fish.Where(f => f.FishType == fishType).ToList()[0];
            return fish;
        }

        public Fish GetBiggestFish()
        {
            Fish fish = this.Fish.OrderByDescending(f => f.Length).ToList()[0];
            return fish;
        }

        public string Report()
        {
            this.Fish = this.Fish.OrderByDescending(f => f.Length).ToList();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {this.Material}:");

            for (int i = 0; i < this.Fish.Count; i++)
            {
                if (i == this.Fish.Count - 1)
                {
                    sb.Append(Fish[i].ToString());
                }
                else
                {
                    sb.AppendLine(Fish[i].ToString());
                }
            }

            return sb.ToString();
        }
    }
}
