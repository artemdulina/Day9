using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IBookListStorage
    {
        /// <summary>
        /// Gets System.Collections.Generic.List&lt;Book>
        /// </summary>
        /// <returns></returns>
        List<Book> LoadBooks();
        void SaveBooks(IEnumerable<Book> books);
    }
}
