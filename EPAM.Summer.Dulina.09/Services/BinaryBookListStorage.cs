using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public class BinaryBookListStorage : IBookListStorage
    {
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Null or empty", nameof(value));
                }
                _fileName = value;
            }
        }

        public BinaryBookListStorage(string fileName)
        {
            FileName = fileName;
        }

        public List<Book> LoadBooks()
        {
            throw new NotImplementedException();
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            throw new NotImplementedException();
        }
    }
}
