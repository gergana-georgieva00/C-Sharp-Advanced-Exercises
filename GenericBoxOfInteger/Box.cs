using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T data)
        {
            this.Data = data;
        }

        public T Data { get; set; }

        public override string ToString()
        {
            return $"{this.Data.GetType()}: {this.Data}".ToString();
        }
    }
}
