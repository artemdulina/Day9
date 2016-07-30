using System.Collections.Generic;
using Entities;

namespace Services
{
    /// <summary>
    /// Provides interface for Entities.Book storage
    /// </summary>
    public interface IBookListStorage
    {
        /// <summary>
        /// Gets System.Collections.Generic.List&lt;Book>.
        /// </summary>
        /// <returns></returns>
        List<Book> LoadBooks();

        /// <summary>
        /// Saves Entities.Book books.
        /// </summary>
        /// <param name="books">System.Collections.Generic.IEnumerable&lt;Book></param>
        void SaveBooks(IEnumerable<Book> books);
    }
}
