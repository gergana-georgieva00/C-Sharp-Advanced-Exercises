using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
         public int Compare(Book book, Book other)
         {
             if (book.Title.CompareTo(other.Title) == 0)
             {
                 return book.Year.CompareTo(other.Year);
             }

             return book.Title.CompareTo(other.Title);
         }
    
    }
}
