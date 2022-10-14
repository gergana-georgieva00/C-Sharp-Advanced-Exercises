using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private Frog frog;

        public Lake(List<int> stonesCollection)
        {
            this.StonesCollection = new List<int>(stonesCollection);
        }

        public List<int> StonesCollection { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < StonesCollection.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return StonesCollection[i];
                }
            }

            for (int i = StonesCollection.Count - 1; i >= 0; i--)
            {
                if (!(i % 2 == 0))
                {
                    yield return StonesCollection[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
