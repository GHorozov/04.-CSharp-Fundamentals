using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
       return new LibraryEnumerator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    private class LibraryEnumerator : IEnumerator<Book>
    {
        private IReadOnlyList<Book> books;
        private int index;

        public LibraryEnumerator(IReadOnlyList<Book> books)
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

