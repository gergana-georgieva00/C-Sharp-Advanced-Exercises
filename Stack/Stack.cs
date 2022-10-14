using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stackk<T> : IEnumerable<T>
    {
        private List<T> stack;

        public Stackk(List<T> collection)
        {
            this.stack = new List<T>(collection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }

            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Push(T element)
        {
            this.stack.Add(element);
        }

        public T Pop()
        {
            if (this.stack.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T removed = this.stack[this.stack.Count - 1];
            this.stack.RemoveAt(this.stack.Count - 1);

            return removed;
        }
    }
}
