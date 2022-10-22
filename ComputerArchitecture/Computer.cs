using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }

        public List<CPU> Multiprocessor { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (this.Multiprocessor.Count < this.Capacity)
            {
                this.Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            if (this.Multiprocessor.Any(p => p.Brand == brand))
            {
                this.Multiprocessor.Remove(this.Multiprocessor.Find(p => p.Brand == brand));
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            CPU mostPowerful = this.Multiprocessor.OrderByDescending(p => p.Frequency).ToList()[0];
            return mostPowerful;
        }

        public CPU GetCPU(string brand)
        {
            if (this.Multiprocessor.Any(p => p.Brand == brand))
            {
                CPU cpu = this.Multiprocessor.Find(p => p.Brand == brand);
                return cpu;
            }

            return null;
        }

        public string Report()
        {
            return $"CPUs in the Computer {this.Model}:" + Environment.NewLine + string.Join(Environment.NewLine, this.Multiprocessor);
        }
    }
}
