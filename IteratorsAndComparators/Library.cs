using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] booksInput)
        {
            this.Books = new List<Book>(booksInput.ToList());
        }

        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            public Book Current => this.Books[this.CurrentIndex];

            object IEnumerator.Current => this.Current;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.Books = new List<Book>();
            }
            public List<Book> Books { get; set; }
            public int CurrentIndex { get; set; }

            public void Dispose() { }

            public bool MoveNext()
            {
                return ++this.CurrentIndex < this.Books.Count;
            }

            public void Reset()
            {
                this.CurrentIndex = -1;
            }
        }
    }
}
