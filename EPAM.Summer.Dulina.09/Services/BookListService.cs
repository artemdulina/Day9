using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public sealed class BookListService
    {
        private IBookListStorage _storage;

        public IBookListStorage Storage
        {
            get { return _storage; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _storage = value;
            }
        }

        public BookListService(IBookListStorage storage)
        {
            Storage = storage;
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            List<Book> books = _storage.LoadBooks();

            if (books.Contains(book))
            {
                throw new ArgumentException("Already exists", nameof(book));
            }
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            List<Book> books = _storage.LoadBooks();

            if (!books.Contains(book))
            {
                throw new ArgumentException("Doesn't exist in the storage", nameof(book));
            }
            books.Add(book);
        }
    }
}
