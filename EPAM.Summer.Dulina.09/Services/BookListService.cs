using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using NLog;

namespace Services
{
    /// <summary>
    /// Class provides ability to add/remove books to/from the specified Services.IBookListStorage storage.
    /// </summary>
    public sealed class BookListService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IBookListStorage storage;

        /// <summary>
        /// Gets Services.IBookListStorage
        /// </summary>
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

        /// <summary>
        /// Add book to the Services.IBookListStorage storage if book exists.
        /// </summary>
        /// <param name="book">Book to add.</param>
        /// <exception cref="ArgumentNullException">Book is null.</exception>
        /// <exception cref="ArgumentException">Book already exists.</exception>
        public void AddBook(Book book)
        {
            if (book == null)
            {
                logger.Error(new ArgumentNullException(nameof(book)));
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

        /// <summary>
        /// Remove book from the storage if exists.
        /// </summary>
        /// <param name="book">Book to remove.</param>
        /// <exception cref="ArgumentNullException">Book is null.</exception>
        /// <exception cref="ArgumentException">Book not found.</exception>
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

        /// <summary>
        /// Sorts the elements using the specified System.Collections.IComparer&lt;Book> and rewrite data.
        /// </summary>
        /// <param name="comparer">The System.Collections.IComparer&lt;Book> implementation to use when comparing elements or null 
        /// to use the System.IComparable implementation of each element.
        ///</param>
        /// <exception cref="ArgumentNullException">Comparer is null.</exception>
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
        /// <param name="predicate">The System.Predicate&lt;Book> delegate that defines the conditions of the element to search for.</param>
        /// <returns>The first element that matches the conditions defined by the specified predicate, if found; 
        /// the default value for type Book if not found.</returns>
        /// /// <exception cref="ArgumentNullException">Predicate is null.</exception>
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
