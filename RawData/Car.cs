using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public Car(string model)
        {
            this.Model = model;
            //this.Engine = new Engine();
            //this.Cargo = new Cargo();
            this.Tires = new Tire[4];
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
    }
}
