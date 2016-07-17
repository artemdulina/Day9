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
        private IBookListStorage storage;

        public IBookListStorage Storage
        {
            get { return storage; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                storage = value;
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

            List<Book> books = storage.LoadBooks();

            if (books.Contains(book))
            {
                throw new ArgumentException("Already exists", nameof(book));
            }

            books.Add(book);
            storage.SaveBooks(books);
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            List<Book> books = storage.LoadBooks();

            if (!books.Contains(book))
            {
                throw new ArgumentException("Doesn't exist in the storage", nameof(book));
            }

            books.Remove(book);
            storage.SaveBooks(books);
        }

        public void SortAndUpdate(IComparer<Book> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            List<Book> books = storage.LoadBooks();

            books.Sort(comparer);
            storage.SaveBooks(books);
        }


        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="predicate">The System.Predicate&lt;Book&gt; delegate that defines the conditions of the element to search for.</param>
        /// <returns>The first element that matches the conditions defined by the specified predicate, if found; 
        /// the default value for type Book if not found.</returns>
        public Book FindBook(Predicate<Book> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            List<Book> books = storage.LoadBooks();

            Book findBook = books.Find(predicate);
            return findBook;
        }
    }
}
