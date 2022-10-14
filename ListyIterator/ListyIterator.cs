using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        int index = 0;

        public ListyIterator(List<T> collection)
        {
            this.collection = new List<T>(collection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i++)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Move()
        {
            if (index + 1 < collection.Count)
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return index < collection.Count - 1;
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Pperation!");
            }

            Console.WriteLine(collection[index]);
        }
    }
}
