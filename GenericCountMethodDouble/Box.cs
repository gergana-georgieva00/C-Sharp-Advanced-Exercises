using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
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

        public bool AreEqual(T element)
        {
            if (this.Data.CompareTo(element) == 1)
            {
                return true;
            }

            return false;
        }
    }
}
