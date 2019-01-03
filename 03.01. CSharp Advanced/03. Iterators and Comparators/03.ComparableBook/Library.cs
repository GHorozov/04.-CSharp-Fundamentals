using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Library : IEnumerable<Book>
{
    private SortedSet<Book> books;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
       return new LibraryIterator(this.books.ToList());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    private class LibraryIterator : IEnumerator<Book>
    {
        private IReadOnlyList<Book> books;
        private int index;

        public LibraryIterator(IReadOnlyList<Book> books)
        {
            this.books = books;
            this.index = -1;
        }

        public Book Current => this.books[index];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
          
        }

        public bool MoveNext()
        {
            index++;
            return index < this.books?.Count;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
}

