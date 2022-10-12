using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfStrings
{
    public class Box<T>
    {
        public Box(T input)
        {
            this.Input = input;
        }
        public T Input { get; set; }

        public override string ToString()
        {
            return $"{this.Input.GetType()}: {this.Input}";
        }
    }
}
